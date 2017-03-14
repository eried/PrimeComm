using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeMon
{
    public partial class FormMain : Form
    {
        private string currentFile;
        const string processName = "HPPrime";
        private Random _random = new Random();
        private static string _commandsFile;
        private string currentProgramName;

        public FormMain()
        {
            InitializeComponent();
        }

        private void labelDragHere_DragEnter(object sender, DragEventArgs e)
        {
          
            e.Effect = DragDropEffects.All;
            
        }

        private void labelDragHere_DragDrop(object sender, DragEventArgs e)
        {
            foreach (var f in (String[]) e.Data.GetData("FileName"))
            {
                currentFile = f;
                currentProgramName = Path.GetFileNameWithoutExtension(f);
                labelDragHere.Text = "Monitoring '" + currentProgramName + "'";
                fileSystemWatcherMonitor.Path = Path.GetDirectoryName(f);
                fileSystemWatcherMonitor.EnableRaisingEvents = true;
                break;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        Stopwatch lastRead = Stopwatch.StartNew();
        object checking = new object();

        private void fileSystemWatcherMonitor_Changed(object sender, FileSystemEventArgs e)
        {
            lock(checking)
            { 
                if (lastRead.ElapsedMilliseconds>5000)
                {

                    lastRead.Restart();

                    if (string.Compare(e.FullPath, currentFile, true) == 0)
                    {
                        var p = "\"" + string.Join("\",{Wait},\"", currentProgramName.ToLower().ToCharArray()) + "\"";
                        SendCommandToEmulator("{Show},{Focus},Escape,Escape,Escape,ControlKey_up,{Wait},NumPad1,ControlKey_down," + p);

                        if (checkBoxStep2Edit.Checked)
                        {
                            SendCommandToEmulator("Enter");

                            if (checkBoxStep3Escape.Checked)
                            {
                                SendCommandToEmulator("Escape");
                            }
                        }
                    }
                }
            }
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, Int16 nCmdShow);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        const uint WM_KEYDOWN = 0x100, WM_KEYUP = 0x0101, WM_CHAR = 0x0102, WM_PASTE = 0x0302, WM_APPCOMMAND = 0x0319,
            APPCOMMAND_PASTE = 38, WM_SYSKEYDOWN = 0x0104, WM_SYSKEYUP = 0x0105, WM_COMMAND = 0x0111;

        private void buttonRun_Click(object sender, EventArgs e)
        {
            SendCommandToEmulator("ControlKey");
        }

        private void buttonDebug_Click(object sender, EventArgs e)
        {
            SendCommandToEmulator("ControlKey_down");
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
        }

        public void SendCommandToEmulator(String command)
        {
            var emulatorNotFound = true;
            foreach (var p in Process.GetProcesses())
            {
                if (!p.ProcessName.Equals(processName)) continue;

                emulatorNotFound = false;
                var emulator = p.MainWindowHandle;

                // Decode the keypresses
                foreach (var k in command.Split(new[] { ',' }))
                {
                    var key = k.Trim();
                    if (key.Length == 0) continue;

                    switch (key)
                    {
                        /*case "{Text}":
                        case "{Selection}":
                        case "{CopyText}":
                        case "{CopySelection}":
                            var tmp = key.EndsWith("Text}") ? editor.Text : editor.Selection.Text;
                            if (key.StartsWith("{Copy"))
                                Clipboard.SetText(tmp);
                            else
                                foreach (var c in tmp)
                                    SendKeyToWindow(emulator, IntPtr.Zero, c);
                            break;*/

                        case "{Nop}":
                            Thread.Sleep(1);
                            break;

                        case "{Focus}":
                            SetForegroundWindow(emulator);
                            break;

                        case "{Show}":
                            ShowWindow(emulator, 1);
                            break;

                        case "{Paste}":
                            PostMessage(emulator, WM_COMMAND, (IntPtr)32801, IntPtr.Zero);
                            break;

                        case "{Wait}":
                                Thread.Sleep(10);
                                Application.DoEvents();
                            break;

                        case "{Wait100}":
                            for (int i = 0; i < 10; i++)
                            {
                                Thread.Sleep(10);
                                Application.DoEvents();
                            }
                            break;

                        default:
                            if (key.EndsWith("}"))
                            {
                                if (key.StartsWith("{Alert:"))
                                {
                                    MessageBox.Show(key.Substring(7, key.Length - 8), "Alert");
                                    continue;
                                }

                                if (key.StartsWith("{Question:"))
                                {
                                    if (
                                        MessageBox.Show(key.Substring(10, key.Length - 11), "Question",
                                            MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                                        return;
                                    continue;
                                }

                                switch (key)
                                {
                                    /*case "{ProgramName}":
                                        key = "\"" + CurrentProgramName + "\"";
                                        break;*/

                                    case "{RandomChar}":
                                        key = "\"" + (char)_random.Next('a', 'z' + 1) + "\"";
                                        break;

                                    case "{RandomCHAR}":
                                        key = "\"" + (char)_random.Next('A', 'Z' + 1) + "\"";
                                        break;

                                    case "{RandomNumber}":
                                        key = "\"" + (char)_random.Next('0', '9' + 1) + "\"";
                                        break;
                                }
                            }

                            if (key.StartsWith("\"") && key.EndsWith("\""))
                            {
                                foreach (var c in key.Substring(1, key.Length - 2))
                                    SendKeyToWindow(emulator, IntPtr.Zero, c);
                            }

                            bool keyUp = true, keyDown = true;
                            if (key.EndsWith("_up"))
                            {
                                keyDown = false;
                                key = key.Substring(0, key.Length - 3);
                            }
                            else if (key.EndsWith("_down"))
                            {
                                keyUp = false;
                                key = key.Substring(0, key.Length - 5);
                            }

                            Keys pressedKey;
                            if (Enum.TryParse(key, out pressedKey))
                                SendKeyToWindow(emulator, (IntPtr)pressedKey, char.MinValue, keyUp, keyDown);
                            break;
                    }
                }
            }

            if (emulatorNotFound)
            {
                /*if (!String.IsNullOrEmpty(_parent.EmulatorExeFile))
                {
                    var p = Process.Start(_parent.EmulatorExeFile);
                    p.WaitForInputIdle(1000);
                    Thread.Sleep(100);
                    SendCommandToEmulator(command);
                }
                else*/
                    MessageBox.Show("The emulator is not running, and it seems it is not available in this system.",
                        "Run Emulator", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
            }
        }

        private static void SendKeyToWindow(IntPtr emulator, IntPtr key, char character, bool keyDown = true, bool keyUp = true)
        {
            if (key == IntPtr.Zero)
            {
                PostMessage(emulator, WM_CHAR, (IntPtr)character, IntPtr.Zero);
                Thread.Sleep(1);
            }
            else
            {
                if (keyDown)
                {
                    PostMessage(emulator, WM_KEYDOWN, key, IntPtr.Zero);
                    Thread.Sleep(1);
                }

                if (keyUp)
                    PostMessage(emulator, WM_KEYUP, key, IntPtr.Zero);
            }
        }

    }
}
