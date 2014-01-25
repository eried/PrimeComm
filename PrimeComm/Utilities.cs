using System;
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