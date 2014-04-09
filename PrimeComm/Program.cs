using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using PrimeLib;

namespace PrimeComm
{
    static class Program
    {
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var instance = false;
            var mutex = new Mutex(true, Application.ProductName, out instance);

            if (!instance)
            {
                // Search for instances of this application
                var c = Process.GetCurrentProcess();
                var firstSeen = false;

                foreach (var p in Process.GetProcessesByName(c.ProcessName))
                    if (p.Id != c.Id)
                        if (!firstSeen)
                        {
                            firstSeen = true;
                            ShowWindow(p.MainWindowHandle, 5);
                            SetForegroundWindow(p.MainWindowHandle);
                        }
                        else
                        {
                            p.Kill();
                        }

                // Connect to the running instance
                try
                {
                    using (var pipeStream = new NamedPipeClientStream(".", Application.ProductName, PipeDirection.Out))
                    {
                        pipeStream.Connect(100);
                        using (var sr = new StreamWriter(pipeStream))
                        {
                            sr.AutoFlush = true;

                            var s = Environment.GetCommandLineArgs().SubArray(1);

                            if (s.Length == 0)
                                sr.WriteLine("show" + Utilities.CommandToken + "1");
                            else
                            foreach (var f in s)
                                sr.WriteLine("open"+Utilities.CommandToken+f);
                        }
                    }
                }
                catch
                {
                }
            }
            else
            {
                Application.Run(new FormMain());
                GC.KeepAlive(mutex);
            }
        }
    }
}
