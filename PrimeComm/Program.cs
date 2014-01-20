using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

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
                            p.Kill();
            }
            else
            {
                Application.Run(new FormMain());
                GC.KeepAlive(mutex);
            }
        }
    }
}
