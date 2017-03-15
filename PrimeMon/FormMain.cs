using Keyboard;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace PrimeMon
{
    public partial class FormMain : Form
    {
        private string currentFile;
        const string processName = "HPPrime", referenceName = "PrimeHelp.exe";
        private string currentProgramName;

        public FormMain()
        {
            InitializeComponent();

            Environment.CurrentDirectory = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            if (File.Exists(referenceName))
                buttonReference.Visible = true;
        }

        private void labelDragHere_DragEnter(object sender, DragEventArgs e)
        {
            foreach (var f in (String[])e.Data.GetData("FileName"))
            {
                if (Path.GetExtension(f).ToLower() == ".hpprgm")
                {
                    e.Effect = DragDropEffects.All;
                }
            }
        }

        private void labelDragHere_DragDrop(object sender, DragEventArgs e)
        {
            foreach (var f in (String[]) e.Data.GetData("FileName"))
            {
                if (Path.GetExtension(f).ToLower() == ".hpprgm")
                {
                    currentFile = f;
                    currentProgramName = Path.GetFileNameWithoutExtension(f);
                    labelDragHere.Text = "Now monitoring '" + currentProgramName + "'";
                    fileSystemWatcherMonitor.Path = Path.GetDirectoryName(f);
                    fileSystemWatcherMonitor.EnableRaisingEvents = true;
                    buttonEdit.Enabled = true;
                    break;
                }
            }
        }

        private void fileSystemWatcherMonitor_Changed(object sender, FileSystemEventArgs e)
        {
            if (string.Compare(e.FullPath, currentFile, true) == 0)
                timerExecute.Start();
        }

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, Int16 nCmdShow);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        const uint WM_KEYDOWN = 0x100, WM_KEYUP = 0x0101, WM_CHAR = 0x0102, WM_PASTE = 0x0302, WM_APPCOMMAND = 0x0319,
            APPCOMMAND_PASTE = 38, WM_SYSKEYDOWN = 0x0104, WM_SYSKEYUP = 0x0105, WM_COMMAND = 0x0111;

        private void checkBoxTopMost_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = checkBoxTopMost.Checked;
        }

        private void checkBoxStep2Edit_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxStep3Escape.Enabled = checkBoxStep2Edit.Checked;
        }

        private void buttonReference_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(referenceName);
            }
            catch { }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            SendActionsToCalculator(true, false);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timerExecute_Tick(object sender, EventArgs e)
        {
            SendActionsToCalculator(checkBoxStep2Edit.Checked, checkBoxStep3Escape.Checked);
            timerExecute.Stop();
        }

        public void SendActionsToCalculator(bool pressEnter, bool pressEscape)
        {
            var emulatorNotFound = true;
            foreach (var p in Process.GetProcesses())
            {
                if (!p.ProcessName.Equals(processName)) continue;

                emulatorNotFound = false;
                var emulator = p.MainWindowHandle;

                ShowWindow(emulator, 1);
                SetForegroundWindow(emulator);

                var k = new List<Key>();

                for(var v=0;v<5;v++)
                    k.Add(new Key(Messaging.VKeys.KEY_ESCAPE));

                k.Add(new Key(Messaging.VKeys.KEY_CONTROL));
                k.Add(new Key('1'));

                foreach (var c in currentProgramName)
                    k.Add(new Key(c));

                if (pressEnter)
                {
                    k.Add(new Key(Messaging.VKeys.KEY_RETURN));

                    if(pressEscape)
                        k.Add(new Key(Messaging.VKeys.KEY_ESCAPE));
                }

                foreach (Key key in k)
                    key.Press(emulator,true);
            }

            if (emulatorNotFound)
            {
                MessageBox.Show("The emulator is not running",
                    "Run Emulator", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }
    }
}
