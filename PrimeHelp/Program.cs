using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace PrimeHelp
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
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var c = Process.GetCurrentProcess();

            bool instance;
            var mutex = new Mutex(true, c.ProcessName + Application.ProductName, out instance);

            if (!instance)
            {
                // Search for instances of this application
                var first = false;

                foreach (var p in Process.GetProcessesByName(c.ProcessName).Where(p => p.Id != c.Id))
                    if (!first)
                    {
                        first = true;
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
