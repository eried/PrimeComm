using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using PrimeComm.Properties;
using PrimeLib;

namespace PrimeComm
{
    internal enum SendResult
    {
        Success,
        ErrorReading,
        ErrorSend,
        ErrorInvalidFile,
        ErrorInvalidInput
    }

    internal class SendResults
    {
        private readonly int _totalFiles;
        private static Destinations _destination;
        private readonly Dictionary<SendResult, int> _results;

        public SendResults(int totalFiles, Destinations destination)
        {
            _totalFiles = totalFiles;
            _destination = destination;
            _results = new Dictionary<SendResult, int>();

            foreach (SendResult k in Enum.GetValues(typeof (SendResult)))
                _results.Add(k, 0);
        }

        internal void ShowMsg(bool console)
        {
            var ok = _results[SendResult.Success];

            if (_totalFiles > 0 && ok == _totalFiles)
            {
                var m = _totalFiles > 1 ? Resources.StatusAllSent : Resources.StatusSent;

                if (console) Console.WriteLine(m);
                else ShowMsg(m);
            }
            else
            {
                var m = _totalFiles == 1
                    ? Resources.SendError
                    : (ok == 0 ? Resources.StatusAllFailed : Resources.StatusSomeFailed);

                if (console) Console.WriteLine(m);
                else ShowError(m);
            }
        }

        public static void ShowMsg(string msg)
        {
            var m = true;
            if (_destination != Destinations.Calculator)
                foreach (var p in Process.GetProcessesByName(Constants.EmulatorProcessName))
                {
                    m = false;

                    if (MessageBox.Show(
                        msg + Environment.NewLine + Environment.NewLine +
                        "Do you want to reload the HP Prime Virtual Calculator?", Application.ProductName,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        var image = p.MainModule.FileName;
                        try
                        {
                            p.Kill();
                            Process.Start(image);
                        }
                        catch
                        {
                        }
                    }

                    break;
                }

            if(m)
                MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowError(string msg)
        {
            MessageBox.Show(msg, Resources.MsgErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Add(SendResult r)
        {
            _results[r]++;
        }

        public string GetSendMessage()
        {
            return String.Format(Resources.StatusSendingProgress,_results.Sum(v => v.Value), _totalFiles);
        }
    }
}