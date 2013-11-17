using PrimeComm.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DataReceivedEventArgs = UsbLibrary.DataReceivedEventArgs;
using Timer = System.Threading.Timer;

namespace PrimeComm
{
    public partial class FormMain : Form
    {
        private bool _calculatorExists, _working, _receivingData, _checkingData;
        private Queue<byte[]> _receivedData = new Queue<byte[]>();
        private PrimeUsbFile _receivedFile;
        private Timer _checker;

        public FormMain()
        {
            Environment.CurrentDirectory = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            hidDevice.RegisterHandle(Handle);
            UpdateGui();
        }

        protected override void WndProc(ref Message m)
        {
            hidDevice.ParseMessages(ref m);
            base.WndProc(ref m);	// pass message on to base form
        }

        private void usbCalculator_OnSpecifiedDeviceArrived(object sender, EventArgs e)
        {
            _calculatorExists = true;
            UpdateGui();
        }

        private void UpdateGui()
        {
            this.InvokeIfRequired(() =>
            {
                if (!_calculatorExists)
                    _receivingData = false;

                pictureBoxStatus.Image = _calculatorExists ? Resources.connected : Resources.disconnected;
                //labelStatusTitle.Text = "---";
                labelStatusSubtitle.Text = _calculatorExists ? "Connected to USB" + (_receivingData ? Environment.NewLine + (_receivedData.Count > 0 ? String.Format("Receiving ({0} KB received)...",GetKilobytes(_receivedData.Count),1) : "Waiting, tap Send in the Prime") : "") : "Not connected";

                if (!_working)
                    _working = _receivedData.Count > 0;

                buttonReceive.Enabled = !_receivingData && _calculatorExists && !_working;
                buttonSend.Enabled = _calculatorExists && !_working;
                buttonClose.Enabled = !_working;

                if(_receivingData==false)
                    if (_receivedFile != null && _receivedFile.IsComplete)
                    {
                        saveFileDialogProgram.FileName = _receivedFile.Name + ".hpprgm";
                        if (saveFileDialogProgram.ShowDialog() == DialogResult.OK)
                        {
                            _receivedFile.Save(saveFileDialogProgram.FileName);
                            
                            IEnumerable<byte> b = null;
                            foreach (var c in _receivedFile.Chunks)
                            {
                                if (b == null)
                                    b = c;
                                else
                                    b = b.Concat(c);
                            }
                            File.WriteAllBytes(saveFileDialogProgram.FileName + ".received", b.ToArray());
                        }

                        ResetProgram();
                    }
            });
        }

        private void ResetProgram()
        {
            _receivedFile = null;
            _working = false;
            _receivedData.Clear();
            UpdateGui();
        }

        private int GetKilobytes(int p)
        {
            return p*hidDevice.SpecifiedDevice.OutputReportLength/1024;
        }

        private void usbCalculator_OnSpecifiedDeviceRemoved(object sender, EventArgs e)
        {
            _calculatorExists = false;
            UpdateGui();
        }

        private void usbCalculator_OnDataReceived(object sender, DataReceivedEventArgs args)
        {
            if (_receivingData)
            {
                try
                {
                    _receivedData.Enqueue(args.data);
                    ScheduleCheck();
                }
                catch
                {
                }
            }
        }

        private int _uiCycles = 0;

        private void ScheduleCheck(Boolean stop = false)
        {
            if(_checker == null)
                _checker = new Timer(CheckData, null, Timeout.Infinite, Timeout.Infinite);

            if (_uiCycles++ > 40)
            {
                _uiCycles = 0;
                UpdateGui();
            }

            if (!stop)
                _checker.Change(100, Timeout.Infinite);
        }

        private void CheckData(object state)
        {
            if (_checkingData)
            {
                ScheduleCheck();
            }
            else
            {
                _checkingData = true;
                ScheduleCheck(true);
                CheckForDataToSave();
                _checkingData = false;
            }
        }

        private void CheckForDataToSave()
        {
            if (!_receivingData || _receivedData.Count == 0)
                return;

            // Check for valid structure
            if(_receivedFile==null)
                _receivedFile = new PrimeUsbFile(_receivedData.Peek());

            if (_receivedFile.IsValid)
            {
                _receivedData.Dequeue();

                while (_receivedData.Count > 0)
                {
                    var tmp = _receivedData.Dequeue();
                    _receivedFile.Chunks.Add(tmp.SubArray(2, tmp.Length-2));
                }

                if (_receivedFile.IsComplete)
                {
                    _receivingData = false;
                    UpdateGui();
                }
                else
                    ScheduleCheck();
            }
            else
            {
                // Discard and try with next chunk
                _receivedData.Dequeue();
                _receivedFile = null;
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            _receivingData = false;
            UpdateGui();

            if (openFileDialogProgram.ShowDialog() == DialogResult.OK)
                SendToCalculator(openFileDialogProgram.FileName);
        }

        private void SendToCalculator(string path)
        {
            try
            {
                var b = new PrimeProgramFile(path);

                if (b.IsValid)
                {
                    _working = true;
                    backgroundWorkerSend.RunWorkerAsync(b);
                    UpdateGui();
                }
                else
                {
                    ShowError("Not supported file");
                }
            }
            catch
            {
                ShowError("Error sending the file");
            }

        }

        private void ShowError(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonReceive_Click(object sender, EventArgs e)
        {
            _receivedData = new Queue<byte[]>();
            _receivingData = true;
            _receivedFile = null;
            UpdateGui();
        }

        private void backgroundWorkerSend_DoWork(object sender, DoWorkEventArgs e)
        {
            var b = (PrimeProgramFile)e.Argument;
            new PrimeUsbFile(b.Name, b.Data, hidDevice.SpecifiedDevice.OutputReportLength).Send(hidDevice.SpecifiedDevice);
        }

        private void backgroundWorkerSend_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _working = false;
            UpdateGui();
        }
    }
}
