using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
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
        private bool _receivingData, _checkingData, _sending, _notificationHintAlreadyShown;
        private Queue<byte[]> _receivedData = new Queue<byte[]>();
        private PrimeUsbData _receivedFile;
        private Timer _checker;
        private string _sendingStatus, _emulatorFolder, _userFilesFolder;
        private PrimeCalculator _calculator;
        private PrimeParameters _parameters;
        private static readonly Object scheduleLock = new Object();
        private FormWindowState _lastWindowState;
        private string _emulatorExeFile;

        public FormMain()
        {
            Environment.CurrentDirectory = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            Settings.Default.SettingsSaving += Default_SettingsSaving;
            Editors = new List<FormEditor>();
            InitializeComponent();
            InitializeGui();

            // Recent files
            Utilities.UpdateRecentFiles();

            // Open files from arguments
            foreach (var f in Environment.GetCommandLineArgs().SubArray(1))
                OpenFile(f);

            // Pipe server
            backgroundWorkerServer.RunWorkerAsync();
        }

        public List<FormEditor> Editors { get; private set; }

        private void Default_SettingsSaving(object sender, CancelEventArgs e)
        {
            _parameters = null; // Invalidate parameters
        }

        public string EmulatorExeFile 
        {
            get { return File.Exists(_emulatorExeFile) ? _emulatorExeFile : null; }
        }

            public bool IsWorkFolderAvailable
        {
            get { return Directory.Exists(_emulatorFolder); }
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

            _emulatorFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"HP_Prime");
            sendToEmulatorKitToolStripMenuItem.Enabled = IsWorkFolderAvailable;
            emulatorToolStripMenuItem.Enabled = sendToEmulatorKitToolStripMenuItem.Enabled;
            exploreVirtualHPPrimeWorkingFolderToolStripMenuItem.Enabled = sendToEmulatorKitToolStripMenuItem.Enabled;

            _emulatorExeFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
                @"Hewlett-Packard\HP Prime Virtual Calculator\HPPrime.exe");

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
            if (m.Msg == 0x0219 && _calculator != null)
            {
                _calculator.CheckForChanges();
            }
            base.WndProc(ref m); // Pass message on to base form
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
                    labelStatusSubtitle.Text = String.IsNullOrEmpty(_sendingStatus)
                        ? Resources.StatusSending
                        : _sendingStatus;
                else
                    labelStatusSubtitle.Text = IsDeviceConnected
                        ? Resources.StatusConnected +
                          (_receivingData ? Environment.NewLine + Environment.NewLine +
                                (_receivedData.Count > 0
                                    ? String.Format(Resources.StatusReceived, GetKilobytes(_receivedData.Count), 1)
                                    : Resources.StatusWaiting)
                              : "")
                        : Resources.StatusNotConnected;

                if (!IsBusy)
                    IsBusy = _receivedData.Count > 0;

                buttonReceive.Enabled = IsDeviceConnected && !IsBusy;
                buttonReceive.Text = _receivingData? "&Cancel" : "&Receive";
                receiveToolStripMenuItem.Enabled = buttonReceive.Enabled;
                cancelReceiveToolStripMenuItem.Enabled = _receivingData;

                var canSend = IsDeviceConnected && !IsBusy;

                buttonSend.Text = canSend ? "&Send..." : "&Open...";
                buttonSend.Image = canSend ? Resources.editor_send_to_device : Resources.editor_open;
                sendFileToolStripMenuItemopenToolStripMenuItemContextual.Visible = canSend;
                sendFileToolStripSeparator.Visible = canSend;
                sendFilesToolStripMenuItem.Enabled = canSend;
                sendClipboardToolStripMenuItem.Enabled = canSend;
                sendClipboardToolStripMenuItemContextual.Visible = canSend;

                buttonCaptureScreen.Enabled = IsDeviceConnected && !IsBusy;
                captureScreenToolStripMenuItem.Enabled = buttonCaptureScreen.Enabled;

                if (Editors != null)
                    foreach (var n in Editors.Where(ed => !ed.IsDisposed))
                        n.UpdateGui();

                if (_receivingData == false)
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
            return p*_calculator.OutputChunkSize/1024;
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
            if (_checker == null)
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
            if (_receivedFile == null)
                _receivedFile = new PrimeUsbData(_receivedData.Peek(), Parameters);

            if (_receivedFile.IsValid)
            {
                _receivedData.Dequeue();

                while (_receivedData.Count > 0)
                {
                    var tmp = _receivedData.Dequeue();
                    _receivedFile.Chunks.Add(tmp.SubArray(1, tmp.Length - 1));
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

        public PrimeParameters Parameters
        {
            get { return _parameters ?? new PrimeParameters(Settings.Default); }
            set { _parameters = value; }
        }

        private void buttonOpenSend_Click(object sender, EventArgs e)
        {
            if(IsDeviceConnected)
                SendDataTo(Destinations.Calculator);
            else
                OpenFile();
        }

        private void SendDataTo(Destinations destination)
        {
            StopReceiving();

            if (openFilesDialogProgram.ShowDialog() == DialogResult.OK)
            {
                var fileSet = PrimeFileSet.Create(openFilesDialogProgram.FileNames,
                    new PrimeParameters(Settings.Default));

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
            if (!backgroundWorkerSend.IsBusy)
            {
                IsBusy = true;
                _sending = true;
                backgroundWorkerSend.RunWorkerAsync(files);
            }
            UpdateGui();
        }

        private void buttonStopReceive_Click(object sender, EventArgs e)
        {
            if(_receivingData)
                StopReceiving();
            else
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
            var fs = (PrimeFileSet) e.Argument;
            var res = new SendResults(fs.Files.Length, fs.Destination);
            var nullFile = new PrimeUsbData(new byte[] {0x00}, null);
            foreach (var file in fs.Files)
            {
                try
                {
                    var b = new PrimeProgramFile(file, Settings.Default);

                    try
                    {
                        if (b.IsValid)
                        {
                            var primeFile = new PrimeUsbData(b.Name, b.Data,
                                fs.Destination == Destinations.Calculator ? _calculator.OutputChunkSize : 0, Parameters);

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
                                    primeFile.Save(Path.Combine(fs.CustomDestination, primeFile.Name + ".hpprgm"));
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
                ((SendResults) e.Result).ShowMsg(false, this);
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
                            StringComparison.OrdinalIgnoreCase)
                            ? 2
                            : 1;

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
            new FormAbout().ShowDialog();
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
            SendTextTo(Destinations.UserFolder);
        }

        public void SendTextTo(Destinations destination, String text = null)
        {
            var f = Utilities.CreateTemporalFileFromText(text);
            var res = new SendResults(1, destination);

            if (f != null)
            {
                var fileSet = PrimeFileSet.Create(new[] {f}, new PrimeParameters(Settings.Default));
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
                res.Add(SendResult.Success);
            }
            else
            {
                res.Add(SendResult.ErrorInvalidInput);
                res.ShowMsg(false, this);
            }
        }

        private void browseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendTextTo(Destinations.Custom);
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
            SendTextTo(Destinations.Calculator);
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
            var n = new FormEditor(this, null);
            Editors.Add(n);
            try
            {
                n.Show();
            }
            catch
            {
            }
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

        private void captureScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormScreen().ShowDialog();
        }

        private void virtualHPPrimeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void connectivityKitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void commandLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("cmd.exe", "/K title PrimeCmd&color 0A&cls&primecmd");
        }


        private void primeSkinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("primeskin.exe");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void OpenFile()
        {
            if (openFileDialogProgram.ShowDialog() == DialogResult.OK)
                OpenFile(openFileDialogProgram.FileName);
        }

        private void OpenFile(string filename)
        {
            UseWaitCursor = true;
            Application.DoEvents();
            var n = new FormEditor(this, filename);
            Editors.Add(n);
            n.Show();
            UseWaitCursor = false;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CheckIfThereIsActiveEditors())
            {
                if (
                    MessageBox.Show("There are active editors. Do you want to exit and lose all the changes?",
                        "Close " + Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private bool CheckIfThereIsActiveEditors()
        {
            return Editors != null && Editors.Any(n => n != null && !n.IsDisposed && !n.IsClosed);
        }

        private void newFromTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var n = new FormEditor(this);
            Editors.Add(n);
            n.Show();
        }

        private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            recentToolStripMenuItem.DropDown = Utilities.RecentFiles;
            recentToolStripMenuItem.Visible = recentToolStripMenuItem.HasDropDownItems;
        }

        private void recentToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            fileToolStripMenuItem.HideDropDown();
            OpenFile(e.ClickedItem.Tag as string);
        }

        internal void CheckEditorStates()
        {
            try
            {
                if (CheckIfThereIsActiveEditors())
                {
                    if (WindowState != FormWindowState.Minimized && Settings.Default.EditorMinimizesPrimeComm)
                        WindowState = FormWindowState.Minimized;
                }
                else if (WindowState == FormWindowState.Minimized && Settings.Default.EditorRestoresPrimeComm)
                    RestoreWindow();
            }
            catch
            {
            }
        }

        private void notifyIconMain_DoubleClick(object sender, EventArgs e)
        {
            RestoreWindow();
        }

        private void RestoreWindow()
        {
            ShowInTaskbar = true;
            Visible = true;
            WindowState = _lastWindowState;
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                notifyIconMain.Visible = false;
                Application.DoEvents();

                _lastWindowState = WindowState;
            }
            else if (Settings.Default.HideAsNotificationIcon)
            {
                const string tip = "Double click this icon to restore the main program window";

                ShowInTaskbar = false;
                Visible = false;
                notifyIconMain.Visible = true;
                notifyIconMain.Text = Text;

                if (!_notificationHintAlreadyShown)
                {
                    _notificationHintAlreadyShown = true;
                    notifyIconMain.ShowBalloonTip(3, Application.ProductName + " is running here", tip, ToolTipIcon.Info);
                }
            }
        }

        private void backgroundWorkerServer_DoWork(object sender, DoWorkEventArgs e)
        {
            do
            {
                // Create a name pipe
                try
                {
                    using (var pipeStream = new NamedPipeServerStream(Application.ProductName, PipeDirection.In))
                    {
                        // Wait for a connection
                        pipeStream.WaitForConnection();

                        using (var sr = new StreamReader(pipeStream))
                        {
                            string temp;

                            // We read a line from the pipe and print it together with the current time
                            while ((temp = sr.ReadLine()) != null)
                                if (temp.Contains(Utilities.CommandToken))
                                    backgroundWorkerServer.ReportProgress(0, temp);
                        }
                    }
                }
                catch
                {
                }
            } while (true);
        }

        private void backgroundWorkerServer_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var cmd = e.UserState as string;
            if (String.IsNullOrEmpty(cmd)) return;

            var args = cmd.Split(new[] {Utilities.CommandToken}, 2, StringSplitOptions.None);

            switch (args[0])
            {
                case "open":
                    OpenFile(args[1]);
                    break;

                case "show":
                    RestoreWindow();
                    break;
            }
        }

        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetFormats().Any(f => f == "FileDrop"))
            {
                e.Effect = sender == buttonSend ? DragDropEffects.Move:  DragDropEffects.Copy;
            }
        }

        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("FileDrop"))
            {
                var f = e.Data.GetData("FileDrop") as string[];

                if (f == null) return;
                var shouldOpen = true;

                if (sender == buttonSend && IsDeviceConnected)
                {
                    StopReceiving();

                    if (!IsBusy)
                    {
                        SendDataTo(new PrimeFileSet(f, _parameters));
                        shouldOpen = false;
                    }
                }

                if (shouldOpen)
                    foreach (var file in f)
                        OpenFile(file);
            }
        }

        private void checkForANewVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            automaticUpdater.ForceCheckForUpdate();
        }

        private void primeRPLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("primerpl.exe");
        }
    }
}