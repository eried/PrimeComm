using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using FolderSelect;
using Microsoft.Win32;
using PrimeComm.Properties;
using PrimeLib;
using DataReceivedEventArgs = PrimeLib.DataReceivedEventArgs;
using Timer = System.Threading.Timer;

namespace PrimeComm
{
    public partial class FormMain : Form
    {
        public bool Silent { get; set; }
        private bool _receivingData, _checkingData, _sending;
        private Queue<byte[]> _receivedData = new Queue<byte[]>();
        private PrimeUsbData _receivedFile;
        private Timer _checker;
        private string _sendingStatus, _emulatorFolder, _userFilesFolder;
        private PrimeCalculator _calculator;
        private PrimeParameters _parameters;
        private static readonly Object scheduleLock = new Object();

        public FormMain(bool silent=false)
        {
            Silent = silent;
            Environment.CurrentDirectory = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            InitializeComponent();
            InitializeGui();
        }

        public bool IsDeviceConnected { get; private set; }

        public bool IsBusy { get; private set; }

        private void InitializeGui()
        {
            var v = Assembly.GetExecutingAssembly().GetName().Version;
            Text = String.Format("{0} v{1} b{2}", Application.ProductName, v.ToString(2), v.Build);

            // Save
            openFilesDialogProgram.Filter = Resources.FilterInput;
            openFileDialogProgram.Filter = Resources.FilterInput;
            saveFileDialogProgram.Filter = Resources.FilterOutput;

            _userFilesFolder = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Hewlett-Packard\HP Connectivity Kit", "WorkFolder", null) as string;
            connectivityKitUserFolderToolStripMenuItem.Enabled = _userFilesFolder != null && Directory.Exists(_userFilesFolder);
            
            _emulatorFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "HP_Prime");
            sendToEmulatorKitToolStripMenuItem.Enabled = Directory.Exists(_emulatorFolder);
            emulatorToolStripMenuItem.Enabled = sendToEmulatorKitToolStripMenuItem.Enabled;
            exploreVirtualHPPrimeWorkingFolderToolStripMenuItem.Enabled = sendToEmulatorKitToolStripMenuItem.Enabled;

            //UpdateDevices();
            _calculator = new PrimeCalculator();
            _calculator.Connected += usbCalculator_OnSpecifiedDeviceArrived;
            _calculator.Disconnected += usbCalculator_OnSpecifiedDeviceRemoved;
            _calculator.DataReceived += usbCalculator_OnDataReceived;
            _calculator.CheckForChanges();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            UpdateGui();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0219 && _calculator!=null)
            {
                _calculator.CheckForChanges();
            }
            base.WndProc(ref m);	// Pass message on to base form
        }

        private void usbCalculator_OnSpecifiedDeviceArrived(object sender, EventArgs e)
        {
            IsDeviceConnected = true;
            UpdateGui();
        }

        private void UpdateGui()
        {
            this.InvokeIfRequired(() =>
            {
                if (!IsDeviceConnected)
                    _receivingData = false;

                pictureBoxStatus.Image = IsDeviceConnected ? Resources.connected : Resources.disconnected;

                if (_sending)
                    labelStatusSubtitle.Text = String.IsNullOrEmpty(_sendingStatus) ? Resources.StatusSending : _sendingStatus;
                else
                    labelStatusSubtitle.Text = IsDeviceConnected ? Resources.StatusConnected + (_receivingData ? Environment.NewLine + Environment.NewLine + (_receivedData.Count > 0 ? String.Format(Resources.StatusReceived, GetKilobytes(_receivedData.Count), 1) : Resources.StatusWaiting) : "") : Resources.StatusNotConnected;

                if (!IsBusy)
                    IsBusy = _receivedData.Count > 0;

                buttonReceive.Enabled = !_receivingData && IsDeviceConnected && !IsBusy;
                receiveToolStripMenuItem.Enabled = buttonReceive.Enabled;
                cancelReceiveToolStripMenuItem.Enabled = _receivingData;

                buttonSend.Enabled = IsDeviceConnected && !IsBusy;
                sendFilesToolStripMenuItem.Enabled = buttonSend.Enabled;
                sendClipboardToolStripMenuItem.Enabled = buttonSend.Enabled;

                buttonCaptureScreen.Enabled = IsDeviceConnected && !IsBusy;

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
            _calculator.StopReceiving();
            _receivedFile = null;
            IsBusy = false;
            _receivedData.Clear();
            UpdateGui();
        }

        private int GetKilobytes(int p)
        {
            return p * _calculator.OutputChunkSize / 1024;
        }

        private void usbCalculator_OnSpecifiedDeviceRemoved(object sender, EventArgs e)
        {
            IsDeviceConnected = false;
            UpdateGui();
        }

        private void usbCalculator_OnDataReceived(object sender, DataReceivedEventArgs args)
        {
            if (_receivingData)
            {
                try
                {
                    lock (scheduleLock)
                    {
                        _receivedData.Enqueue(args.Data);
                        ScheduleCheck();
                    }
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

            UpdateGui();

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
                _receivedFile = new PrimeUsbData(_receivedData.Peek(), Parameters);

            if (_receivedFile.IsValid)
            {
                _receivedData.Dequeue();

                while (_receivedData.Count > 0)
                {
                    var tmp = _receivedData.Dequeue();
                    _receivedFile.Chunks.Add(tmp.SubArray(1, tmp.Length-1));
                }

                if (_receivedFile.IsComplete)
                    StopReceiving();
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

        private PrimeParameters Parameters
        {
            get { return _parameters ?? new PrimeParameters(Settings.Default); }
            set { _parameters = value; }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            SendDataTo(Destinations.Calculator);
        }

        private void SendDataTo(Destinations destination)
        {
            StopReceiving();

            if (openFilesDialogProgram.ShowDialog() == DialogResult.OK)
            {
                var fileSet = PrimeFileSet.Create(openFilesDialogProgram.FileNames, new PrimeParameters(Settings.Default));

                fileSet.Destination = destination;
                if (destination == Destinations.Custom)
                {
                    var fs = new FolderSelectDialog {Title = "Select the destination folder"};
                    if (!fs.ShowDialog())
                        return; // Conversion was cancel

                    fileSet.CustomDestination = fs.FileName;
                }
                else
                    fileSet.CustomDestination = _emulatorFolder;

                SendDataTo(fileSet);
            }
        }

        public void SendDataTo(PrimeFileSet files)
        {
            IsBusy = true;
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
            StartReceiving();
        }

        private void StartReceiving()
        {
            _receivedData = new Queue<byte[]>();
            _receivingData = true;
            _receivedFile = null;
            _calculator.StartReceiving();
            UpdateGui();
        }

        private void StopReceiving()
        {
            _receivingData = false;
            _calculator.StopReceiving();
            _checker = null;
            UpdateGui();
        }

        private void backgroundWorkerSend_DoWork(object sender, DoWorkEventArgs e)
        {
            var fs = (PrimeFileSet)e.Argument;
            var res = new SendResults(fs.Files.Length, fs.Destination);
            var nullFile = new PrimeUsbData(new byte[] {0x00});
            foreach (var file in fs.Files)
            {
                try
                {
                    var b = new PrimeProgramFile(file, Settings.Default);

                    try
                    {
                        if (b.IsValid)
                        {
                            var primeFile = new PrimeUsbData(b.Name, b.Data,fs.Destination== Destinations.Calculator?_calculator.OutputChunkSize:0, Parameters);

                            switch (fs.Destination)
                            {
                                case Destinations.Calculator:
                                    _calculator.Send(nullFile);
                                    _calculator.Send(primeFile);
                                    _calculator.Send(nullFile);
                                    res.Add(SendResult.Success);
                                    break;
                                case Destinations.UserFolder:
                                case Destinations.Custom:
                                    primeFile.Save(Path.Combine(fs.CustomDestination,primeFile.Name+".hpprgm"));
                                    res.Add(SendResult.Success);
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
            IsBusy = false;
            _sending = false;
            _sendingStatus = null;
            UpdateGui();

            if (e.Result != null)
                ((SendResults) e.Result).ShowMsg(Silent, this);
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
                    var b = new PrimeProgramFile(openFileDialogProgram.FileName, Settings.Default);

                    if (b.IsValid)
                    {
                        saveFileDialogProgram.FileName = b.Name;

                        // Select the oposite filetype
                        saveFileDialogProgram.FilterIndex = openFileDialogProgram.FileName.EndsWith(".hpprgm",
                            StringComparison.OrdinalIgnoreCase)? 2: 1;

                        if (saveFileDialogProgram.ShowDialog() == DialogResult.OK)
                            new PrimeUsbData(b.Name, b.Data, 0, Parameters).Save(saveFileDialogProgram.FileName);
                    }
                }
                catch
                {
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilities.ShowAbout(this);
        }

        private void receiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartReceiving();
        }

        private void cancelReceiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopReceiving();
        }

        private void emulatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendClipboardTo(Destinations.UserFolder);
        }

        private void SendClipboardTo(Destinations destination)
        {
            var f = CreateTemporalFileFromClipboard();
            var res = new SendResults(1, destination);

            if (f != null)
            {
                var fileSet = PrimeFileSet.Create(new[] { f }, new PrimeParameters(Settings.Default));
                fileSet.Destination = destination;
                if (destination == Destinations.Custom)
                {
                    var fs = new FolderSelectDialog { Title = "Select the destination folder" };
                    if (!fs.ShowDialog())
                        return; // Conversion was cancel

                    fileSet.CustomDestination = fs.FileName;
                }
                else
                    fileSet.CustomDestination = _emulatorFolder;

                SendDataTo(fileSet);
                res.Add(SendResult.Success);
            }
            else
            {
                res.Add(SendResult.ErrorInvalidInput);
                res.ShowMsg(Silent, this);
            }
        }

        private string CreateTemporalFileFromClipboard()
        {
            var t = Path.GetTempFileName();
            File.Delete(t);
            Directory.CreateDirectory(t);

            // Get name
            try
            {
                if (Clipboard.ContainsText())
                {
                    var clipb = Clipboard.GetText(TextDataFormat.UnicodeText).Trim();

                    if (clipb.Length > 0)
                    {
                        var m = new Regex(Settings.Default.RegexProgramName, RegexOptions.IgnoreCase).Match(clipb);
                        var name = PrimeLib.Utilities.GetRandomProgramName();

                        if (m.Success)
                            name = m.Groups["name"].Value;

                        t = Path.Combine(t, name + ".txt");
                        File.WriteAllText(t, clipb, Encoding.BigEndianUnicode);
                        return t;
                    }
                }
                else if (Clipboard.ContainsImage())
                {
                    t = Path.Combine(t, PrimeLib.Utilities.GetRandomImageName()+".png");
                    Clipboard.GetImage().Save(t);

                    return t;
                }
            }
            catch
            {
            }
            return null;
        }

        private void browseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendClipboardTo(Destinations.Custom);
        }

        private void sendToEmulatorKitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendDataTo(Destinations.UserFolder);
        }

        private void sendToCustomToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SendDataTo(Destinations.Custom);
        }

        private void sendClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendClipboardTo(Destinations.Calculator);
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            if (!Settings.Default.SkipConflictingProcessChecking)
            {
                // Check running processes
                if (new[] {Constants.ConnectivityKitProcessName, Constants.EmulatorProcessName}.Any(p => Process.GetProcessesByName(p).Length > 0))
                    SendResults.ShowMsg("It seems you have either the Connectivity Kit or HP Virtual Prime running, this may conflict with this app to detect your physical calculator.",this);
            }
        }

        private void newProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormEditor().Show();
        }

        private void connectivityKitUserFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(_userFilesFolder);
        }

        private void exploreVirtualHPPrimeWorkingFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(_emulatorFolder);
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormSettings().ShowDialog();
        }
    }
}