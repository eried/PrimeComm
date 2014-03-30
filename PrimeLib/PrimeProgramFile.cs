using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using PrimeLib.Properties;

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
        public PrimeProgramFile(string path, PrimeParameters settings = null)
        {
            IsValid = false;
            IsConversion = false;
            Name = Path.GetFileNameWithoutExtension(path);
            Data = new byte[0];

            switch (Path.GetExtension(path).ToLower())
            {
                case ".txt":
                    // Find "begin"
                    var tmp = File.ReadAllBytes(path);
                    foreach (var encoding in new[] {Encoding.Unicode, Encoding.BigEndianUnicode, null})
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
                        IsConversion = true;
                    }
                    catch
                    {
                    }
                    break;

                case ".c8":
                    try
                    {
                        // Generate a script that includes the chip8 emulator
                        Data = Encoding.Unicode.GetBytes(Resources.chip8.Replace("%program%",Utilities.GenerateByteListFromFile(path)).Replace("%name%", Name));
                        IsValid = true;
                        IsConversion = true;
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
                        var universalMode = false;

                        if (b[0] == 0xFF && b[1] == 0xFE)
                        {
                            // Plain file with Unicode flag on front
                            Data = b.SubArray(2, b.Length - 2);
                            IsValid = true;
                            break;
                        }
                        else
                        {
                            for (var i = 1; i <= 7; i++)
                                if (b[i] != 0x00) // Special case where b[4]==0x01
                                {
                                    universalMode = true;
                                    break;
                                }
                        }

                        if (universalMode) // Reads from the last byte. This will ignore any header
                        {
                            var finish = b.Length - 1;

                            // Look for the finish
                            for (; finish > 2; finish -= 2)
                            {
                                if (b[finish] == 0x00 && b[finish - 1] == 0x00)
                                {
                                    finish--;
                                    break;
                                }
                            }
                            var start = finish-1;

                            // Look for the start
                            for (; start > 2; start -= 2)
                            {
                                if (b[start] == 0x00 && b[start - 1] == 0x00)
                                {
                                    start++;
                                    IsValid = true;
                                    break;
                                }
                            }

                            if (IsValid)
                            {
                                // Clean headers
                                foreach (var h in new[] {new[] {0xfe, 0xa9, 0x1, 0x0}})
                                {
                                    var f = start + h.Length;
                                    var m = 0;
                                    for(var t=start;t<f;t++)
                                        if (b[t] == h[t - start])
                                            m++;

                                    if (m == h.Length)
                                        start += h.Length;
                                }

                                Data = b.SubArray(start, finish - start);
                                IsConversion = true;
                            }
                        }
                        else
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
                                        for (var i = 18; i < b.Length; i++)
                                            if (b[i - 1] == b[i] && b[i] == 0x00)
                                            {
                                                if (!settings.GetFlag("IgnoreInternalName"))
                                                    Name = Encoding.Unicode.GetString(b.SubArray(18, i - 18));

                                                i += 8;
                                                Data = b.SubArray(i, b.Length - i);
                                                IsValid = true;
                                                IsConversion = true; // This file will be saved as unnamed
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
        /// If the original file was converted and the current data is an interpretation
        /// </summary>
        public bool IsConversion { get; private set; }

        /// <summary>
        /// Parses the data inside a file to be used later
        /// </summary>
        /// <param name="path">Input file, including the extension to detect the format</param>
        /// <param name="settings">Parameters</param>
        public PrimeProgramFile(string path, ApplicationSettingsBase settings) : this(path, new PrimeParameters(settings)) { }

        private bool CheckEncodingAndSetData(byte[] tmp, Encoding encoding)
        {
            // If encoding is null, we will just use the Default encoding since no valid one was found
            var s = encoding == null ? Encoding.Default.GetString(tmp): encoding.GetString(tmp);
            if (encoding == null || s.IndexOf("begin", StringComparison.OrdinalIgnoreCase) >= 0 || OnlyValidChars(s))
            {
                Data = Encoding.Unicode.GetBytes(s);
                return true;
            }
            return false;
        }

        private bool OnlyValidChars(string s)
        {
            foreach (var c in s)
            {
                if (c > 65279 || (c < 65279 && c > 1000)) // Allow "safe" chars like euro and others, and Unicode null
                    return false;
            }

            return true;
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
