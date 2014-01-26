using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PrimeComm.Properties;

namespace PrimeComm
{
    static internal class Utilities
    {
        public static string CommandToken = "????";
        private static List<KeyValuePair<string, string>> _ascii7Codes;

        public static void InvokeIfRequired(this Control c, MethodInvoker action)
        {
            if (c.InvokeRequired) c.Invoke(action); else action();
        }

        /// <summary>
        /// TrimStart with String 
        /// http://stackoverflow.com/questions/4335878/c-sharp-trimstart-with-string-parameter
        /// </summary>
        /// <param name="target">Source string</param>
        /// <param name="trimString">String to trim</param>
        /// <param name="recursive">If the string should be processed again</param>
        /// <returns>Trimmed string</returns>
        public static string TrimStart(this string target, string trimString, bool recursive = true)
        {
            var result = target;
            while (result.StartsWith(trimString))
            {
                result = result.Substring(trimString.Length);
                if (!recursive)
                    break;
            }

            return result;
        }

        public static string CreateTemporalFileFromText(string text=null)
        {
            var t = Path.GetTempFileName();
            File.Delete(t);
            Directory.CreateDirectory(t);

            // Get name
            try
            {
                if (!String.IsNullOrEmpty(text))
                    return SaveText(text, t);

                if (Clipboard.ContainsText())
                    return SaveText(Clipboard.GetText(TextDataFormat.UnicodeText).Trim(), t);
                
                if (Clipboard.ContainsImage())
                {
                    t = Path.Combine(t, PrimeLib.Utilities.GetRandomImageName() + ".png");
                    Clipboard.GetImage().Save(t);

                    return t;
                }
            }
            catch
            {
            }
            return null;
        }

        private static string SaveText(string text, string t)
        {
            if (!String.IsNullOrEmpty(text))
            {
                var m = new Regex(Settings.Default.RegexProgramName, RegexOptions.IgnoreCase).Match(text);
                var name = PrimeLib.Utilities.GetRandomProgramName();

                if (m.Success)
                    name = m.Groups["name"].Value;

                t = Path.Combine(t, name + ".txt");
                File.WriteAllText(t, text, Encoding.BigEndianUnicode);
                return t;
            }
            else
                throw new Exception("Nothing to save");
        }

        internal static void AppendToRecentFiles(string fileName)
        {
            if (Settings.Default.RecentOpenedFiles.Contains(fileName))
                Settings.Default.RecentOpenedFiles.Remove(fileName);

            Settings.Default.RecentOpenedFiles.Add(fileName);
            UpdateRecentFiles();
        }

        internal static void UpdateRecentFiles()
        {
            RecentFiles = new ToolStripDropDown() { LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow};

            if (Settings.Default.RecentOpenedFiles != null)
            {
                while (Settings.Default.RecentOpenedFiles.Count > Settings.Default.RecentFilesMaximum &&
                       Settings.Default.RecentOpenedFiles.Count > 0)
                    Settings.Default.RecentOpenedFiles.RemoveAt(0);

                var n = 0;
                for (var i = Settings.Default.RecentOpenedFiles.Count-1; i >=0 ; i--)
                {
                    var m = Settings.Default.RecentOpenedFiles[i];
                    if (File.Exists(m))
                    {
                        RecentFiles.Items.Add(new ToolStripMenuItem("&" + ++n + ": " + m)
                        {
                            Tag = m,
                            Alignment = ToolStripItemAlignment.Left,
                            ShowShortcutKeys = true,
                            TextAlign = ContentAlignment.MiddleLeft
                        });
                    }
                }

                Settings.Default.Save();
            }
            else
                Settings.Default.RecentOpenedFiles = new StringCollection();
        }

        public static ToolStripDropDown RecentFiles { get; private set; }

        public static List<KeyValuePair<String, String>> ASCII7Codes
        {
            get
            {
                if (_ascii7Codes == null)
                {
                    _ascii7Codes = new List<KeyValuePair<string, string>>();
                    foreach (var c in new[]
                    {
                        new[] {"\xB0", @"\o_\"}, // °
                        new[] {"\xB1", @"\+-\"}, // ±
                        new[] {"\xB2", @"\^2\"}, // ²
                        new[] {"\xB3", @"\^3\"}, // ³
                        new[] {"\xB9", @"\^1\"}, // ¹
                        new[] {"\x25B6", @"\store\"}, // ▶ store symbol 
                        new[] {"\xE004", @"\^-1\"}, // 
                        new[] {"\x1D07", @"\ee\"}, // ᴇ
                        new[] {"\xE003", @"\i\"}, // , unidad imaginaria
                        new[] {"\x2260", @"\!=\"}, // ≠
                        new[] {"\x2264", @"\=<\"}, // ≤
                        new[] {"\x2265", @"\>=\"}, // ≥
                        new[] {"\x221A", @"\root\"}, // √
                        new[] {"\x222B", @"\integral\"}, // ∫
                        new[] {"\x2202", @"\diff\"}, // ∂
                        new[] {"\x2221", @"\/_\"}, // ∡ angle symbol
                        new[] {"\x2211", @"\Sigma0\"}, // ∑ sigma (mayuscula)
                        new[] {"\x221E", @"\oo_\"}, // ∞ infinite   
                        new[] {"\x2032", @"\'\"}, // ′ minutos
                        new[] {"\x2033", @"\''\"}, // ″ segundos
                        new[] {"\x2192", @"\->\"}, // →
                        new[] {"\x2212", @"\-\"}, // − menos superindice
                        new[] {"\x03B1", @"\alpha\"}, // α (minuscula)
                        new[] {"\x03B2", @"\beta\"}, // β (minuscula)
                        new[] {"\x03B3", @"\gamma\"}, //  (minuscula)
                        new[] {"\x03B4", @"\delta\"}, //  (minuscula)
                        new[] {"\x03B5", @"\epsilon\"}, //  (minuscula)
                        new[] {"\x03B6", @"\zeta\"}, //  (minuscula)
                        new[] {"\x03B7", @"\eta\"}, //  (minuscula)
                        new[] {"\x03B8", @"\theta\"}, //  (minuscula)
                        new[] {"\x03B7", @"\eta\"}, //  (minuscula)
                        new[] {"\x03B8", @"\theta\"}, //  (minuscula)
                        new[] {"\x03B9", @"\iota\"}, //  (minuscula)
                        new[] {"\x03BA", @"\kappa\"}, //  (minuscula)
                        new[] {"\x03BB", @"\lambda\"}, //  (minuscula)
                        new[] {"\x03BC", @"\mu\"}, //  (minuscula)
                        new[] {"\x03BD", @"\nu\"}, //  (minuscula)
                        new[] {"\x03BE", @"\xi\"}, //  (minuscula)
                        new[] {"\x03C0", @"\pi\"}, //  π (minuscula)
                        new[] {"\x03C1", @"\rho\"}, //  (minuscula)
                        new[] {"\x03C2", @"\sigma\"}, //  (minuscula)
                        new[] {"\x03C3", @"\sigma2\"}, //  (minuscula)
                        new[] {"\x03C4", @"\tau\"}, //  (minuscula)
                        new[] {"\x03C5", @"\upsilon\"}, //  (minuscula)
                        new[] {"\x03C6", @"\phi\"}, //  (minuscula)
                        new[] {"\x03C7", @"\chi\"}, //  (minuscula)
                        new[] {"\x03C8", @"\psi\"}, //  (minuscula)
                        new[] {"\x03C9", @"\omega\"}, //  (minuscula)
                        new[] {"\x393", @"\Gamma\"}, //  (mayuscula)
                        new[] {"\x394", @"\Delta\"}, //  (mayuscula)
                        new[] {"\x03A0", @"\Pi\"}, // Π  (mayuscula)
                        new[] {"\x03A3", @"\Sigma\"}, // (mayuscula)
                        new[] {"\x03A9", @"\Omega\"}, // (mayuscula)
                        new[] {"\x2229", @"\intersection\"}, // ∩
                        new[] {"\x222A", @"\union\"}, // ∪
                        new[] {"exp", @"\e^\"}, //
                        new[] {"&&", @"\andBit\"}, //
                        new[] {"||", @"\orBit\"}, //
                    })
                    {
                        _ascii7Codes.Add(new KeyValuePair<string, string>(c[0], c[1]));
                    }
                }
                return _ascii7Codes;
            }
        }

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SHELLEXECUTEINFO
        {
            public int cbSize;
            public uint fMask;
            public IntPtr hwnd;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpVerb;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpFile;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpParameters;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpDirectory;
            public int nShow;
            public IntPtr hInstApp;
            public IntPtr lpIDList;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpClass;
            public IntPtr hkeyClass;
            public uint dwHotKey;
            public IntPtr hIcon;
            public IntPtr hProcess;
        }

        private const int SW_SHOW = 5;
        private const uint SEE_MASK_INVOKEIDLIST = 12;

        /// <summary>
        /// Shows system file properties
        /// http://stackoverflow.com/questions/1936682/how-do-i-display-a-files-properties-dialog-from-c
        /// </summary>
        /// <param name="filename">Filepath</param>
        /// <returns>True if dialog was opened</returns>
        public static bool ShowFileProperties(string filename)
        {
            var info = new SHELLEXECUTEINFO();
            info.cbSize = Marshal.SizeOf(info);
            info.lpVerb = "properties";
            info.lpFile = filename;
            info.nShow = SW_SHOW;
            info.fMask = SEE_MASK_INVOKEIDLIST;
            return ShellExecuteEx(ref info);
        }
    }
}