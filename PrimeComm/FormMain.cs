using System.Diagnostics;
using System.Linq;
using System.Reflection;
using FolderSelect;
using PrimeComm.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using DataReceivedEventArgs = UsbLibrary.DataReceivedEventArgs;
using Timer = System.Threading.Timer;

namespace PrimeComm
{
    public partial class FormMain : Form
    {
        private bool _calculatorExists, _working, _receivingData, _checkingData, _sending;
        private Queue<byte[]> _receivedData = new Queue<byte[]>();
        private PrimeUsbFile _receivedFile;
        private Timer _checker;
        private int _uiCycles = 0;
        private IniParser _config;
        private string _sendingStatus;

        public FormMain()
        {
            var ini = Path.ChangeExtension(Application.ExecutablePath, "ini");
            _config = File.Exists(ini) ? new IniParser(ini) : new IniParser();

            Environment.CurrentDirectory = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            InitializeComponent();
            Text = String.Format("{0} v{1}", Application.ProductName, Assembly.GetExecutingAssembly().GetName().Version.ToString(2));
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

                if (_sending)
                    labelStatusSubtitle.Text = String.IsNullOrEmpty(_sendingStatus) ? Resources.StatusSending : _sendingStatus;
                else
                    labelStatusSubtitle.Text = _calculatorExists ? Resources.StatusConnected + (_receivingData ? Environment.NewLine + Environment.NewLine + (_receivedData.Count > 0 ? String.Format(Resources.StatusReceived, GetKilobytes(_receivedData.Count), 1) : Resources.StatusWaiting) : "") : Resources.StatusNotConnected;

                if (!_working)
                    _working = _receivedData.Count > 0;

                buttonReceive.Enabled = !_receivingData && _calculatorExists && !_working;
                buttonSend.Enabled = _calculatorExists && !_working;
                buttonCaptureScreen.Enabled = _calculatorExists && !_working;
                

                if(_receivingData==false)
                    if (_receivedFile != null && _receivedFile.IsComplete)
                    {
                        saveFileDialogProgram.FileName = _receivedFile.Name + ".hpprgm";
                        if (saveFileDialogProgram.ShowDialog() == DialogResult.OK)
                            _receivedFile.Save(saveFileDialogProgram.FileName);

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
            SendDataTo(Destinations.Calculator);
        }

        private void SendDataTo(Destinations destination)
        {
            _receivingData = false;
            UpdateGui();

            if (openFileDialogProgram.ShowDialog() == DialogResult.OK)
            {
                var fileSet = new FileSet(openFileDialogProgram.FileNames,
                    new ParseSettings
                    {
                        Destination = destination,
                        IgnoreInternalName = _config.GetSettingAsBoolean("input", "ignore_internal_name", true)
                    });

                if (destination == Destinations.Custom)
                {
                    var fs = new FolderSelectDialog {Title = "Select the destination folder"};
                    if (!fs.ShowDialog())
                        return; // Conversion was cancel

                    fileSet.Settings.CustomDestination = fs.FileName;
                }

                SendDataTo(fileSet);
            }
        }

        private void SendDataTo(FileSet files)
        {
            _working = true;
            _sending = true;
            backgroundWorkerSend.RunWorkerAsync(files);
            UpdateGui();
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
            var fs = (FileSet)e.Argument;
            var res = new SendResults(fs.Files.Length);
            var nullFile = new PrimeUsbFile(new byte[] {0x00});
            foreach (var file in fs.Files)
            {
                try
                {
                    var b = new PrimeProgramFile(file, fs.Settings.IgnoreInternalName);

                    try
                    {
                        if (b.IsValid)
                        {
                            switch (fs.Settings.Destination)
                            {
                                case Destinations.Calculator:
                                    nullFile.Send(hidDevice.SpecifiedDevice);
                                    new PrimeUsbFile(b.Name, b.Data, hidDevice.SpecifiedDevice.OutputReportLength).Send(hidDevice.SpecifiedDevice);
                                    nullFile.Send(hidDevice.SpecifiedDevice);
                                    res.Add(SendResult.Success);
                                    break;
                                case Destinations.UserFolder:
                                    break;
                                case Destinations.Custom:
                                    break;
                            }
                        }
                        else
                            res.Add(SendResult.ErrorInvalidFile);
                    }
                    catch
                    {
                        res.Add(SendResult.ErrorSend);
                    }
                }
                catch
                {
                    res.Add(SendResult.ErrorReading);
                }

                backgroundWorkerSend.ReportProgress(0, res);
            }

            e.Result = res;
        }

        private void backgroundWorkerSend_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _working = false;
            _sending = false;
            _sendingStatus = null;
            UpdateGui();

            if (e.Result != null)
                ((SendResults) e.Result).ShowMsg();
        }

        private void backgroundWorkerSend_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var r = (SendResults) e.UserState;
            _sendingStatus = r.GetSendMessage();
            UpdateGui();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void convertFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialogProgram.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var b = new PrimeProgramFile(openFileDialogProgram.FileName);

                    if (b.IsValid)
                        if (saveFileDialogProgram.ShowDialog() == DialogResult.OK)
                        {
                            new PrimeUsbFile(b.Data).Save(saveFileDialogProgram.FileName);
                        }
                }
                catch
                {
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Form
            {
                Text = "About " + Text,
                Icon = Icon,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                StartPosition = FormStartPosition.CenterParent,
                MinimizeBox = false,
                MaximizeBox = false,
                Font = Font,
                Height = 150,
                Width = 300
            };

            var fl = new FlowLayoutPanel {Dock = DockStyle.Top};

            fl.Controls.Add(new Label {Text = "Erwin Ried"});

            const string p = "http://ried.cl";
            var l = new LinkLabel {Text = p};
            l.Click += (o, args) => Process.Start(p);
            fl.Controls.Add(l);
            f.Controls.Add(fl);

            f.ShowDialog();
        }

        private void sendToConnKitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendDataTo(Destinations.UserFolder);
        }

        private void sendToCustomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendDataTo(Destinations.Custom);
        }
    }

    internal enum Destinations
    {
        Calculator, UserFolder, Custom
    }

    internal enum SendResult
    {
        Success,
        ErrorReading,
        ErrorSend,
        ErrorInvalidFile
    }

    internal class SendResults
    {
        private readonly int _totalFiles;
        private readonly Dictionary<SendResult, int> _results;

        public SendResults(int totalFiles)
        {
            _totalFiles = totalFiles;
            _results = new Dictionary<SendResult, int>();

            foreach (SendResult k in Enum.GetValues(typeof (SendResult)))
                _results.Add(k, 0);
        }

        internal void ShowMsg()
        {
            var ok = _results[SendResult.Success];

            if (_totalFiles > 0 && ok == _totalFiles)
                ShowMsg(_totalFiles > 1 ? Resources.StatusAllSent : Resources.StatusSent);
            else
                ShowError(_totalFiles == 1
                    ? Resources.SendError
                    : (ok == 0 ? Resources.StatusAllFailed : Resources.StatusSomeFailed));
        }

        private static void ShowMsg(string msg)
        {
            MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void ShowError(string msg)
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

    internal class FileSet
    {
        public string[] Files { get; set; }
        public ParseSettings Settings { get; set; }

        public FileSet(string[] fileNames, ParseSettings parseSettings)
        {
            Files = fileNames;
            Settings = parseSettings;
        }
    }

    internal class ParseSettings
    {
        public bool IgnoreInternalName { get; set; }

        public Destinations Destination { get; set; }

        public string CustomDestination { get; set; }
    }
}
