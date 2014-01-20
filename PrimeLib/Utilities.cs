using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Encoder = System.Drawing.Imaging.Encoder;

namespace PrimeLib
{
    /// <summary>
    /// Generic utilities
    /// </summary>
    public static class Utilities
    {
        private static readonly Random Rnd = new Random();

        /// <summary>
        /// Returns a subarray of an array (<see href="http://stackoverflow.com/questions/943635/c-sharp-arrays-getting-a-sub-array-from-an-existing-array">Reference</see>)
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="data">Source</param>
        /// <param name="index">Start from</param>
        /// <param name="length">Lenght</param>
        /// <returns>Subarray</returns>
        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            var result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        internal static string GenerateProgramFromImage(string path, string name, PrimeParameters settings)
        {
            const int width = 320, height = 240;
            var mode = settings.GetSetting("ImageMethod", ImageProcessingMode.DimgrobPieces);
            var img = ResizeImage(Image.FromFile(path, true), width, height, mode == ImageProcessingMode.Pixels || mode == ImageProcessingMode.DimgrobPieces, settings);
            const string defaultColor = "000000"; // RRGGBB

            var p = new StringBuilder("EXPORT " + name + "()");
            p.Append("\nBEGIN\n");

            switch (mode)
            {
                case ImageProcessingMode.Pixels:
                    p.Append("RECT(#" + defaultColor + "h);\n");
                    const int totalBytesPixels = width*height*3;
                    var bmpDataPixels = img.LockBits(new Rectangle(0, 0, img.Width, img.Height),
                        ImageLockMode.ReadOnly,
                        PixelFormat.Format24bppRgb);


                    var rgbValuesPixels = new byte[totalBytesPixels];

                    // Copy the RGB values into the array
                    Marshal.Copy(bmpDataPixels.Scan0, rgbValuesPixels, 0, totalBytesPixels);


                    for (var x = 0; x < width; x++)
                        for (var y = 0; y < height; y++)
                        {
                            var c = GetColor(ref rgbValuesPixels, x, y, width);

                            if (c != defaultColor)
                                p.Append(String.Format("PIXON_P({0},{1},#{2}h);\n", x, y, c));
                        }

                    img.UnlockBits(bmpDataPixels);
                    p.Append("WAIT;END;");
                    break;

                case ImageProcessingMode.DimgrobPieces:
                    const int totalBytes = width*height*2;
                    var bmpData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height),
                        ImageLockMode.ReadOnly,
                        PixelFormat.Format16bppArgb1555);

                    var rgbValues = new byte[totalBytes];

                    // Copy the RGB values into the array.
                    Marshal.Copy(bmpData.Scan0, rgbValues, 0, totalBytes);

                    var dimGrobParts = new List<String>();
                    var optimizeBlack = settings.GetFlag("ImageMethodDimgrobOptimizeBlacks");
                    for (var y = 0; y < height; y++)
                    {
                        for (var x = 0; x <= (width*2)-8; x+=8)
                        {
                            var r = (y*640)+x;
                            dimGrobParts.Add(GetDimGrobPiece(ref rgbValues, r, optimizeBlack));
                        }
                    }
                    img.UnlockBits(bmpData);

                    // Create the definitions
                    const int rows = 4;
                    var arr = dimGrobParts.ToArray();

                    try
                    {
                        var lines = new Dictionary<String, List<String>>();

                        for (var i = 0; i <= height - rows; i += rows)
                        {
                            var c = "DIMGROB_P(G1,320," + rows + ",{" + String.Join(",", arr, i*80, 320) + "});";
                            if(!lines.ContainsKey(c))
                                lines.Add(c, new List<String>());

                            lines[c].Add("BLIT_P(G0,0," + i + "," + 320 + "," + (i + rows) + ",G1,0,0,320," + rows + ");");
                        }

                        var optimizeSimilar = settings.GetFlag("ImageMethodDimgrobOptimizeSimilar");
                        foreach (var t in lines)
                        {
                            if(optimizeSimilar)
                                p.AppendLine(t.Key);
                            foreach (var l in t.Value)
                            {
                                if(!optimizeSimilar)
                                    p.AppendLine(t.Key);
                                p.AppendLine(l);
                            }
                        }
                    }
                    catch
                    {
                    }

                    p.Append("WAIT;END;");
                    break;

                case ImageProcessingMode.Icon:
                    p.Append("blit_p(" + (width - img.Width/2) + "," + (height - img.Height/2) +
                             ",\"img\");\nWAIT;END;\nICON img ");
                    var tmp = Path.GetTempFileName();

                    var pngCodec = ImageCodecInfo.GetImageEncoders().FirstOrDefault(codec => codec.FormatID.Equals(ImageFormat.Png.Guid));
                    

                    //
                    //Bitmap bitmap1 = new Bitmap(1, 1);
    //EncoderParameters paramList = bitmap1.GetEncoderParameterList(pngCodec.Clsid);
                    //

                    if (pngCodec != null)
                    {
                        var parameters = new EncoderParameters();
                        parameters.Param[0] = new EncoderParameter(Encoder.ColorDepth, 4L);
                        //parameters.Param[1] = new EncoderParameter(Encoder., 1);
                        img.Save(tmp, pngCodec, parameters);
                    }
                    else
                        img.Save(tmp, ImageFormat.Png);

                    p.Append(BitConverter.ToString(File.ReadAllBytes(tmp)).Replace("-", string.Empty) + ";");
                    break;
            }

            return p.ToString();
        }

        private static string GetDimGrobPiece(ref byte[] rgbValues, int r, bool optimizeBlack)
        {
            var tmp = BitConverter.ToString(new[]
            {
                (byte) (rgbValues[r + 7] & 127), rgbValues[r + 6],
                (byte) (rgbValues[r + 5] & 127), rgbValues[r + 4],
                (byte) (rgbValues[r + 3] & 127), rgbValues[r + 2],
                (byte) (rgbValues[r + 1] & 127), rgbValues[r + 0]
            }).Replace("-", String.Empty);

            if (optimizeBlack)
            {
                var hexZeros = new String('0', 4);
                while (tmp.StartsWith(hexZeros))
                    tmp = tmp.Substring(hexZeros.Length, tmp.Length - hexZeros.Length);
            }

            return "#" + (String.IsNullOrEmpty(tmp)?"0":tmp) + ":64h";
        }

        private static string GetColor(ref byte[] rgbValues, int x, int y, int width)
        {
            var pos = x*3 + (y*width*3);
            return String.Format("{0:X2}{1:X2}{2:X2}",rgbValues[pos+2],rgbValues[pos + 1],rgbValues[pos]);
        }

        
        // 
        /// <summary>
        /// Resizes an Image to fit in a canvas (<see href="http://stackoverflow.com/questions/1940581/c-sharp-image-resizing-to-different-size-while-preserving-aspect-ratio">Reference</see>)
        /// </summary>
        /// <param name="image">Source image</param>
        /// <param name="maxWidth">Canvas width</param>
        /// <param name="maxHeight">Canvas height</param>
        /// <param name="returnIncludesCanvas">If the returned image should include the canvas padding</param>
        /// <returns>Resized image</returns>
        public static Bitmap ResizeImage(Image image, int maxWidth, int maxHeight, bool returnIncludesCanvas=true, PrimeParameters settings = null)
        {
            var newWidth = image.Width;
            var newHeight = image.Height;

            if (image.Width > maxHeight || image.Height > maxHeight)
            {
                var ratioX = (double) maxWidth/image.Width;
                var ratioY = (double) maxHeight/image.Height;
                var ratio = Math.Min(ratioX, ratioY);

                newWidth = (int) (image.Width*ratio);
                newHeight = (int) (image.Height*ratio);
            }

            Bitmap newImage;
            if (returnIncludesCanvas)
            {
                newImage = new Bitmap(maxWidth, maxHeight);
                Graphics.FromImage(newImage).DrawImage(image, (maxWidth - newWidth)/2, (maxHeight - newHeight)/2, newWidth, newHeight);
            }
            else
            {
                newImage = new Bitmap(newWidth, newHeight);
                Graphics.FromImage(newImage).DrawImage(image, 0,0, newWidth, newHeight);
            }

            // Dithering
            //targetImage = 
             
            try
            {
                if (settings != null)
                {
                    if (Environment.OSVersion.Version.Major >= 6)
                    {
                        var ditherMethod = settings.GetSetting("ImageDitheringMethod", DitherType.DitherTypeNone);

                        // Dithering only works with Windows Vista or newer due GDI+ 1.1
                        if (ditherMethod != DitherType.DitherTypeNone)
                            newImage.ChangeTo16bppRgb555(ditherMethod);
                            //newImage.ChangeToSpecialIndexed(PaletteType.PaletteTypeOptimal, ditherMethod);
                    }
                }
            }
            catch
            {
            }
            return newImage;
        }

        /// <summary>
        /// Generates a random program name
        /// </summary>
        /// <returns>Random program name</returns>
        public static String GetRandomProgramName()
        {
            return GetRandomName("program");
        }

        /// <summary>
        /// Generates a random image name
        /// </summary>
        /// <returns>Random image name</returns>
        public static String GetRandomImageName()
        {
            return GetRandomName("image");
        }

        private static string GetRandomName(string prefix)
        {
            return prefix+"_" + GetRandomChar() + Rnd.Next(10, 99);
        }

        /// <summary>
        /// Generates a random lowercase char
        /// </summary>
        /// <returns>Random char</returns>
        public static char GetRandomChar()
        {
            return (char) Rnd.Next('a', 'z' + 1);
        }

        internal static string GenerateByteListFromFile(string path)
        {
            return "{"+String.Join(",", BitConverter.ToString(File.ReadAllBytes(path)).Split('-').Select(b => "#" + b + "h").ToList())+"}";
        }
    }

    /// <summary>
    /// Enumeration of methods available to process the images and generate the output script
    /// </summary>
    public enum ImageProcessingMode
    {
        /// <summary>
        /// Using PIXON_P
        /// </summary>
        Pixels,

        /// <summary>
        /// Using DIMGROB_P pieces
        /// </summary>
        DimgrobPieces,

        /// <summary>
        /// Using ICON (png)
        /// </summary>
        Icon
    }
}
