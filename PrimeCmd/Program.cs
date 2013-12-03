using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using CommandLine;
using PrimeLib;

namespace PrimeCmd
{
    class Program
    {
        private static readonly Queue<byte[]> ReceivedBytes = new Queue<byte[]>();
        static void Main(string[] args)
        {
            Environment.CurrentDirectory = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            var options = new Options();
            var parser = new Parser(with => with.HelpWriter = Console.Error);

            if (args.Length > 0)
            {
                var calculator = new PrimeCalculator();
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
                    if (options.RemoteMode)
                    {
                        // Message server mode
                        WaitForDevice(calculator, options.Timeout);
                        if (calculator.IsConnected)
                        {
                            Console.WriteLine("... connected. Use the calculator messaging options");
                            Console.WriteLine("to interact with the PC.");
                            Console.WriteLine();
                            Console.WriteLine("Press Ctrl-C or send EXIT from the device to exit.");
                            Console.WriteLine();
                            var _continue = true;

                            // Header
                            var assembly = Assembly.GetExecutingAssembly();
                            calculator.Send(new PrimeUsbData(String.Format("{1} v{2}{0}{3}{0}", Environment.NewLine,
                                assembly.GetName().Name, assembly.GetName().Version.ToString(3),
                                ((AssemblyCopyrightAttribute)assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)[0]).Copyright), calculator.OutputChunkSize));

                            calculator.DataReceived += calculator_DataReceived;
                            calculator.StartReceiving();

                            // Modes
                            
                            do
                            {
                                var d = ReceiveData(null); // Blocking function to receive the data
                                var separator = new String('-', Console.WindowWidth);

                                if (d != null && d.Type == PrimeUsbDataType.Message)
                                {
                                    String cmd = d.ToString();
                                    Console.WriteLine("[{0}] Executing: '{1}'", DateTime.Now.ToShortTimeString(), cmd);

                                    if (cmd.ToLower() == "exit")
                                        _continue = false;
                                    else
                                    {
                                        // Evaluate cmd
                                        var response = ExecuteCommand(cmd);
                                        Console.WriteLine("{1}{2}{0}{1}{2}", response, separator, Environment.NewLine);

                                        // Echo the response to the HP
                                        calculator.Send(new PrimeUsbData(response, calculator.OutputChunkSize));
                                    }

                                }
                            } while (_continue);

                            calculator.StopReceiving();
                            calculator.DataReceived -= calculator_DataReceived;
                        }
                        else
                        {
                            Console.WriteLine("Error! Timeout.");
                        }
                    }
                    else if (options.SendFile == null && (options.ReceiveFile != null || options.OutputFolder != null))
                    {
                        WaitForDevice(calculator, options.Timeout);

                        if (calculator.IsConnected)
                        {
                            Console.WriteLine("... connected. Tap Send with after selecting an ");
                            Console.WriteLine("element in the device, or press Ctrl-C to cancel.");

                            var d = ReceiveData(calculator); // Blocking function to receive the data

                            if(d !=null)
                                SaveFile(d, options.OutputFolder ?? options.ReceiveFile, options.OutputFolder != null);
                        }
                        else
                        {
                            Console.WriteLine("Error! Timeout.");
                        }
                    }
                    else if (options.SendFile != null)
                        if (File.Exists(options.SendFile))
                        {
                            // Process the destination
                            var destination = options.OutputFolder == null && options.ReceiveFile == null
                                ? Destinations.Calculator
                                : Destinations.Custom;

                            // Parse the file
                            var b = new PrimeProgramFile(options.SendFile, options.IgnoreInternalName);

                            if (destination == Destinations.Calculator)
                            {
                                //f.Show();
                                WaitForDevice(calculator, options.Timeout);

                                if (calculator.IsConnected)
                                {
                                    var primeFile = new PrimeUsbData(b.Name, b.Data, calculator.OutputChunkSize);

                                    Console.WriteLine("... connected. Sending file");
                                    var nullFile = new PrimeUsbData(new byte[] {0x00});
                                    calculator.Send(nullFile);
                                    calculator.Send(primeFile);
                                    calculator.Send(nullFile);
                                    Console.WriteLine("... done.");
                                }
                                else
                                {
                                    Console.WriteLine("Error! Problems connecting with the device.");
                                }
                            }
                            else
                            {
                                // Save 
                                SaveFile(new PrimeUsbData(b.Name, b.Data, 0), options.OutputFolder ?? options.ReceiveFile, options.OutputFolder != null);
                            }
                        }
                }
            }
            else
            {
                // Show help
                Console.Write(options.GetUsage());
            }
            Console.WriteLine();
        }

        private static String ExecuteCommand(string cmd)
        {
            var p = new Process
            {
                StartInfo =
                {
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    Arguments = "/C " + cmd
                }
            };

            p.Start();
            var output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            return output;
        }

        /// <summary>
        /// Receives data, file or anything valid as PrimeUsbData
        /// </summary>
        /// <param name="calculator">Calculator instance, null to avoid controlling the device</param>
        /// <returns></returns>
        private static PrimeUsbData ReceiveData(PrimeCalculator calculator)
        {
            PrimeUsbData d = null;
            var keepReceiving = true;

            if (calculator!=null)
            {
                calculator.DataReceived += calculator_DataReceived;
                calculator.StartReceiving();
            }

            do
            {
                if (ReceivedBytes.Count > 0)
                {
                    // Check for valid structure
                    if (d == null)
                    {
                        if (calculator != null)
                            Console.WriteLine("Receiving data...");
                        d = new PrimeUsbData(ReceivedBytes.Peek());
                    }

                    if (d.IsValid)
                    {
                        ReceivedBytes.Dequeue();

                        while (ReceivedBytes.Count > 0)
                        {
                            var tmp = ReceivedBytes.Dequeue();
                            d.Chunks.Add(tmp.SubArray(1, tmp.Length - 1));
                        }

                        if (d.IsComplete)
                        {
                            if (calculator != null)
                            {
                                calculator.StopReceiving();
                                calculator.DataReceived -= calculator_DataReceived;

                                Console.WriteLine("... done.");
                            }
                            keepReceiving = false;
                        }
                    }
                    else
                    {
                        // Discard and try with next chunk
                        ReceivedBytes.Dequeue();
                        d = null;
                    }
                }

                Thread.Sleep(500);
            } while (keepReceiving);

            return d;
        }

        private static void SaveFile(PrimeUsbData primeFile, String output, bool isFolder=true)
        {
            var f = isFolder ? Path.Combine(output, primeFile.Name + ".hpprgm") : output;
            Console.WriteLine();
            Console.WriteLine("Saving the file to: " + f);
            primeFile.Save(f);
        }

        static void calculator_DataReceived(object sender, PrimeLib.DataReceivedEventArgs e)
        {
            ReceivedBytes.Enqueue(e.Data);
        }

        private static void WaitForDevice(PrimeCalculator calculator, int timeout)
        {
            Console.WriteLine("Connecting to the device..."); Console.WriteLine();
            var t = Stopwatch.StartNew();
            do
            {
                calculator.CheckForChanges();
                if (calculator.IsConnected)
                    break;
                Thread.Sleep(500);
            } while (t.Elapsed.TotalSeconds < timeout);
        }
    }
}
