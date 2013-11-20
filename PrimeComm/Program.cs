using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PrimeComm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*const string language = "en-US";
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(language);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
