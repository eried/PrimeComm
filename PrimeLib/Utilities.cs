using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace PrimeLib
{
    /// <summary>
    /// Generic utilities
    /// </summary>
    public static class Utilities
    {
        private static readonly Random Rnd = new Random();

        /// <summary>
        /// Returns a subarray of an array
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="data">Source</param>
        /// <param name="index">Start from</param>
        /// <param name="length">Lenght</param>
        /// <returns>Subarray</returns>
        /// <seealso cref="http://stackoverflow.com/questions/943635/c-sharp-arrays-getting-a-sub-array-from-an-existing-array"/>
        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            var result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        internal static string GenerateProgramFromImage(string path, string name)
        {
            var p = new StringBuilder("EXPORT " + name + "()");
            p.AppendLine();
            p.AppendLine("BEGIN");
            p.AppendLine("RECT(#000000);");

            const int width = 320, height = 240;
            var img = ResizeImage(Image.FromFile(path), width, height);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var c = img.GetPixel(x, y);

                    if (c.R==0&&c.G==0&&c.B==0)
                        continue;
                    
                    p.AppendLine(String.Format("PIXON_P({0},{1},{2});", x, y, ColorTranslator.ToHtml(c)));
                }
            }

            return p.AppendLine("WAIT;END;").ToString();
        }

        // http://stackoverflow.com/questions/1940581/c-sharp-image-resizing-to-different-size-while-preserving-aspect-ratio
        public static Bitmap ResizeImage(Image image, int maxWidth, int maxHeight)
        {
            var newImage = new Bitmap(maxWidth, maxHeight);

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

            Graphics.FromImage(newImage).DrawImage(image, (maxWidth - newWidth) / 2, (maxHeight - newHeight) / 2, newWidth, newHeight);
            return newImage;
        }

        public static object GetRandomProgramName()
        {
            return "program_" + GetRandomChar() + Rnd.Next(10, 99);
        }

        public static char GetRandomChar()
        {
            return (char) Rnd.Next('a', 'z' + 1);
        }
    }
}
