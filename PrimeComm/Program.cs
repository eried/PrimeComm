using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PrimeComm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            /*if (args.Length > 0)
            {
                var f = new FormMain(true) {Visible = false};
                var a = AttachConsole(-1);
                Console.WriteLine();
                var streams = new List<Stream>(new[] { Console.OpenStandardInput(), Console.OpenStandardError(), Console.OpenStandardOutput() });

                // Handle console arguments
                var options = new Options();
                var parser = new Parser(with => with.HelpWriter = Console.Error);
                var p = true;

                if (args.Length == 1 && File.Exists(args[0]))
                {
                    options.SendFile = args[0];
                    options.Timeout = 5;
                }
                else
                {
                    try
                    {
                        p = parser.ParseArguments(args, options);
                    }
                    catch
                    {
                        p = false;
                        Console.WriteLine(options.GetUsage());
                    }
                }

                if (p)
                {
                    // Run
                    var timeout = options.Timeout;
                    var settings = new ParseSettings { IgnoreInternalName=options.IgnoreInternalName, Destination= Destinations.Calculator };

                    if(options.SendFile != null)
                        if (File.Exists(options.SendFile))
                        {
                            var t = Stopwatch.StartNew();
                            //f.Show();

                            do
                            {
                                if (f.IsDeviceConnected)
                                    break;
                            } while (t.Elapsed.TotalSeconds < timeout);

                            if (f.IsDeviceConnected)
                            {
                                f.SendDataTo(new FileSet(new []{options.SendFile}, settings));

                                do
                                {
                                    Application.DoEvents();
                                } while (f.IsBusy);
                            }
                            else
                            {
                                Console.WriteLine("Error sending the file, can't connect with the device");
                            }
                        }

                    foreach (var s in streams)
                        s.Close();
                }
            }
            else*/
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());
            }
        }

        // defines for commandline output
        // http://stackoverflow.com/questions/7198639/c-sharp-application-both-gui-and-commandline
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
    }
}
