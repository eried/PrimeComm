using System;
using System.Configuration;
using System.IO;
using System.Text;

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
        /// <param name="settings">Parameters</param>
        public PrimeProgramFile(string path, PrimeParameters settings)
        {
            IsValid = false;
            Name = Path.GetFileNameWithoutExtension(path);
            Data = new byte[0];

            switch (Path.GetExtension(path))
            {
                case ".txt":
                    // Find "begin"
                    var tmp = File.ReadAllBytes(path);
                    foreach (var encoding in new[] {  Encoding.Unicode, Encoding.BigEndianUnicode, Encoding.Default })
                        if (CheckEncodingAndSetData(tmp, encoding))
                        {
                            // Remove signature
                            if (Data.Length > 1 && Data[0] == 0xff && Data[1] == 0xfe)
                            {
                                for (int i = 0; i < Data.Length - 2; i++)
                                    Data[i] = Data[i + 2];

                                Data[Data.Length - 2] = 0x00;
                                Data[Data.Length - 1] = 0x00;
                            }

                            IsValid = true;
                            break;
                        }
                    break;
                  
                case ".bmp":
                case ".jpg":
                case ".jpeg":
                case ".png":
                case ".gif":
                    try
                    {
                        // Generate a script that displays the image
                        Data = Encoding.Unicode.GetBytes(Utilities.GenerateProgramFromImage(path, SafeName, settings));
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
                            if (b[i] != 0x00) // Special case where b[4]==0x01
                                goto case null;

                        switch (b[8])
                        {
                            case 0x00:
                                var size = BitConverter.ToUInt32(b, 16);
                                Data = new byte[size];

                                const int offset = 20;
                                for (var i = offset; i < offset + size && i < b.Length; i++)
                                    Data[i - offset] = b[i];

                                IsValid = true;

                                break;

                            case 0x01:
                                if (b[16] == 0x31) // Special case where b[16]==0x30
                                {
                                    for(var i=18;i<b.Length;i++)
                                        if (b[i - 1] == b[i] && b[i] == 0x00)
                                        {
                                            if (!settings.GetFlag("IgnoreInternalName"))
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
        /// Parses the data inside a file to be used later
        /// </summary>
        /// <param name="path">Input file, including the extension to detect the format</param>
        /// <param name="settings">Parameters</param>
        public PrimeProgramFile(string path, ApplicationSettingsBase settings) : this(path, new PrimeParameters(settings))
        {
        }

        private bool CheckEncodingAndSetData(byte[] tmp, Encoding encoding)
        {
            var s = encoding.GetString(tmp);
            if (s.IndexOf("begin", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Data = Encoding.Unicode.GetBytes(s);
                return true;
            }
            return false;
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

        /// <summary>
        /// Safe program name, or a random one if no one is available
        /// </summary>
        public string SafeName
        {
            get { return String.IsNullOrEmpty(_name)?Utilities.GetRandomProgramName() : _name.Replace(" ","_"); }
        }

        /// <summary>
        /// Returns if the data looks valid (header and sizes match)
        /// </summary>
        public bool IsValid { get; set; }
    }
}
