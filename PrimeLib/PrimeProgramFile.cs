using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using PrimeLib;

namespace PrimeLib
{
    /// <summary>
    /// Class for hpprgm files
    /// </summary>
    public class PrimeProgramFile
    {
        private string _name;

        /// <summary>
        /// Parses the data inside a file to be used later
        /// </summary>
        /// <param name="path">Input file, including the extension to detect the format</param>
        /// <param name="ignoreInternal">Ignore the internal name for the file, i.e. use filename</param>
        public PrimeProgramFile(string path, bool ignoreInternal = true)
        {
            IsValid = false;
            Name = Path.GetFileNameWithoutExtension(path);
            Data = new byte[0];

            switch (Path.GetExtension(path))
            {
                case ".txt":
                    Data = Encoding.Convert(Encoding.Default, Encoding.Unicode, File.ReadAllBytes(path));
                    IsValid = true;
                    break;
                  
                case ".bmp":
                case ".jpg":
                case ".jpeg":
                case ".png":
                case ".gif":
                    try
                    {
                        // Generate a script that displays the image
                        Data = Encoding.Unicode.GetBytes(Utilities.GenerateProgramFromImage(path, SafeName));
                        IsValid = true;
                    }
                    catch
                    {
                    }
                    break;

                case null:
                    break; 

                default:
                    var b = File.ReadAllBytes(path);
                    if (b.Length >= 19)
                    {
                        for (var i = 1; i <= 7; i++)
                            if (b[i] != 0x00)
                                goto case null;

                        switch (b[8])
                        {
                            case 0x00:
                                var size = b[16] + b[17]*0xff + b[18]*0xff*0xff;
                                Data = new byte[size];

                                const int offset = 20;
                                for (int i = offset; i < offset + size && i < b.Length; i++)
                                    Data[i - offset] = b[i];

                                IsValid = true;

                                break;

                            case 0x01:
                                if (b[16] == 0x31)
                                {
                                    for(var i=18;i<b.Length;i++)
                                        if (b[i - 1] == b[i] && b[i] == 0x00)
                                        {
                                            if (!ignoreInternal)
                                                Name = Encoding.Unicode.GetString(b.SubArray(18, i-18));

                                            i += 8;
                                            Data = b.SubArray(i, b.Length - i);
                                            IsValid = true;
                                            break;
                                        }
                                }

                                break;
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Contains the data of this Script (UTF-16, without headers)
        /// </summary>
        public byte[] Data { get; private set; }

        /// <summary>
        /// Name of the script
        /// </summary>
        public string Name
        {
            get { return _name; }
            private set 
            { 
                // Check name rules
                if (value.Length > 0)
                {
                    if (value[0] >= '0' && value[0] <= '9')
                        value = Utilities.GetRandomChar() + value;

                    _name = value.Substring(0, value.Length > 64 ? 64 : value.Length); 
                }
            }
        }

        public string SafeName
        {
            get { return _name.Replace(" ","_"); }
        }

        /// <summary>
        /// Returns if the data looks valid (header and sizes match)
        /// </summary>
        public bool IsValid { get; set; }
    }
}
