
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using PrimeComm.Properties;
using PrimeLib;
using ScintillaNET;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Clipboard = System.Windows.Forms.Clipboard;

namespace PrimeComm
{
    public partial class FormEditor : Form
    {
        private bool _dirty;
        private readonly FormMain _parent;
        private string _currentFile, _currentName;
        private const string EditorName = "PrimePad";
        private FormHelpWindow _helpWindow;
        private FormCharmapWindow _charmapWindow;
        private PrivateFontCollection fontCollection;

        /// <summary>
        /// Creates a new editor window
        /// </summary>
        /// <param name="p">Parent window</param>
        /// <param name="openFile">File to open, null if template should be used, empty if blank should be used</param>
        public FormEditor(FormMain p, string openFile = "")
        {
            IsClosed = false;
            InitializeComponent();

            // Docking
            //dockPanel.Controls.Add(editor);
            var ed = new DockContent {CloseButton = false, CloseButtonVisible = false};
            ed.Controls.Add(editor);
            editor.Dock = DockStyle.Fill;
            ed.Show(dockPanel);

            _parent = p;
            LoadEditorSettings();

            if (openFile == null)
                New(true);
            else
            {
                if (!String.IsNullOrEmpty(openFile))
                    OpenFile(openFile);
            }

            UpdateGui();

            // Sorting the toolstrips
            toolStripMain.Location = new Point(0, menuStripMain.Height);
            toolStripSendTo.Location = new Point(toolStripMain.Width + 3, menuStripMain.Height);

            // Adjusting the dock
            dockPanel.DockBottomPortion = 0.4;
            dockPanel.DockLeftPortion = 0.3;
            dockPanel.DockTopPortion = 0.4;
            dockPanel.DockRightPortion = 0.3;

            // Adding the charmap
            _charmapWindow = new FormCharmapWindow(this, fontCollection.Families[0]);
            _charmapWindow.Show(dockPanel, DockState.DockBottomAutoHide);

            // Adding the help
            _helpWindow = new FormHelpWindow(Resources.commands, fontCollection.Families[0]);
            _helpWindow.Show(dockPanel, DockState.DockBottomAutoHide);
            _helpWindow.ReferenceLoaded += (o, args) => SearchReference(true);
        }

        private void LoadEditorSettings()
        {
            // Editor configuration
            /*if (File.Exists("hpppl.xml"))
            {
                var config = new Configuration(XmlReader.Create("hpppl.xml"), "hpppl");
                scintillaEditor.ConfigurationManager.Configure(config);
            }*/

            //scintillaEditor.Snippets.List.Add(new Snippet("if", "IF THEN END"));
            //scintillaEditor.Snippets.IsEnabled = true;

            // Editor font
            foreach (var f in Directory.GetFiles(".", "*.ttf"))
            {
                try
                {
                    fontCollection = new PrivateFontCollection();
                    fontCollection.AddFontFile(f);
                    editor.Font = new Font(fontCollection.Families[0], (int) Settings.Default.EditorFontSize);

                    //foreach (StylesCommon s in Enum.GetValues(typeof (StylesCommon)))
                    foreach (var s in editor.Lexing.StyleNameMap.Keys)
                    {
                        editor.Styles[s].Font = new Font(fontCollection.Families[0],
                            (int) Settings.Default.EditorFontSize, editor.Styles[s].Font.Style);
                    }
                    break;
                }
                catch
                {
                }
            }

            // Editor font colors
            //editor.Styles[editor.Lexing.StyleNameMap["LINENUMBER"]].ForeColor = Color.Azure;

            // Word wrap
            editor.LineWrapping.Mode = Settings.Default.EditorWordWrap ? LineWrappingMode.Word : LineWrappingMode.None;
        }

        private void OpenFile(string fileName)
        {
            if (AskForSave())
            {
                try
                {
                    if (!File.Exists(fileName))
                    {
                        MessageBox.Show("Can't load '" + fileName + "'", "File does not exist", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        Utilities.UpdateRecentFiles();
                        Close();
                    }
                    else
                    {
                        var tmp = new PrimeProgramFile(fileName, _parent.Parameters);
                        _currentFile = String.Empty;
                        _currentName = String.Empty;
                        editor.Text = new PrimeUsbData(tmp.SafeName, tmp.Data).ToString();
                        _dirty = false;

                        if (tmp.IsConversion)
                        {
                            if (Settings.Default.AddCommentOnConversion)
                                editor.InsertText(0, "// Converted by PrimeComm from " + fileName + Environment.NewLine);
                        }
                        else
                        {
                            _currentFile = fileName;
                            _currentName = String.Empty;
                        }

                        // Check file length
                        AdjustScrollbarWidth();
                        editor.UndoRedo.EmptyUndoBuffer();

                        // Recent files
                        Utilities.AppendToRecentFiles(fileName);
                    }
                }
                catch
                {
                    MessageBox.Show("Error loading '" + fileName + "'", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void AdjustScrollbarWidth()
        {
            var m = 200;
            var line = -1;
            foreach (Line l in editor.Lines)
                if (l.Length > m)
                {
                    m = l.Length;
                    line = l.Number;
                }

            if (line >= 0)
                m = TextRenderer.MeasureText(editor.Lines[line].Text, editor.Font).Width;
            editor.Scrolling.HorizontalWidth = m;
        }

        private bool AskForSave()
        {
            if (_dirty)
            {
                switch (
                    MessageBox.Show(String.Format("Save the changes to '{0}'?", CurrentProgramName), "Save changes",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Exclamation))
                {
                    case DialogResult.Yes:
                        if (Save())
                            _dirty = false;
                        break;
                    case DialogResult.No:
                        _dirty = false;
                        break;
                    default:
                        return false; // Cancel 
                }
            }
            return true;
        }

        private bool Save(bool forceNewName = false)
        {
            try
            {
                if (String.IsNullOrEmpty(_currentFile) || forceNewName)
                {
                    _parent.saveFileDialogProgram.FileName = CurrentProgramName;
                    if (_parent.saveFileDialogProgram.ShowDialog() == DialogResult.OK)
                    {
                        _currentFile = _parent.saveFileDialogProgram.FileName;
                        _currentName = String.Empty;
                    }
                    else
                        return false; // Cancel
                }

                if (!String.IsNullOrEmpty(_currentFile))
                {
                    new PrimeUsbData(CurrentProgramName, Encoding.Unicode.GetBytes(editor.Text)).Save(_currentFile);

                    // Recent files
                    Utilities.AppendToRecentFiles(_currentFile);
                    _dirty = false;
                    UpdateGui();
                    return true;
                }
            }
            catch
            {
                MessageBox.Show("Error saving the program", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            return false;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FormAbout()).ShowDialog();
        }

        internal void UpdateGui()
        {
            undoToolStripMenuItem.Enabled = editor.UndoRedo.CanUndo;
            toolStripButtonUndo.Enabled = editor.UndoRedo.CanUndo;

            redoToolStripMenuItem.Enabled = editor.UndoRedo.CanRedo;
            toolStripButtonRedo.Enabled = editor.UndoRedo.CanRedo;

            copyToolStripMenuItem.Enabled = editor.Clipboard.CanCopy;
            toolStripButtonCopy.Enabled = editor.Clipboard.CanCopy;

            cutToolStripMenuItem.Enabled = editor.Clipboard.CanCut;
            toolStripButtonCut.Enabled = editor.Clipboard.CanCut;

            pasteToolStripMenuItem.Enabled = editor.Clipboard.CanPaste;
            toolStripButtonPaste.Enabled = editor.Clipboard.CanPaste;

            propertiesToolStripMenuItem.Enabled = !String.IsNullOrEmpty(_currentFile);

            var textSelected = editor.Selection.Length > 0;
            var textNotEmpty = editor.TextLength > 0;
            deleteToolStripMenuItem.Enabled = textSelected;
            commentSelectionToolStripMenuItem.Enabled = textNotEmpty;
            uncommentSelectionToolStripMenuItem.Enabled = textNotEmpty;

            sendToDeviceToolStripMenuItem.Enabled = _parent.IsDeviceConnected && !_parent.IsBusy;
            toolStripButtonSendToDevice.Enabled = sendToDeviceToolStripMenuItem.Enabled;

            sendToVirtualToolStripMenuItem.Enabled = _parent.IsWorkFolderAvailable && !_parent.IsBusy;
            toolStripButtonSendToVirtual.Enabled = sendToVirtualToolStripMenuItem.Enabled;

            /*searchReferenceToolStripMenuItem.Enabled = _helpWindow != null && _helpWindow.DockState != DockState.DockBottomAutoHide &&
                                                       _helpWindow.DockState != DockState.DockLeftAutoHide &&
                                                       _helpWindow.DockState != DockState.DockRightAutoHide &&
                                                       _helpWindow.DockState != DockState.DockTopAutoHide;
            */
            Text = String.Format("{2}{0}: {1}", CurrentProgramName, EditorName, _dirty ? "* " : string.Empty);
            //toolStripTextBoxName.Text = CurrentProgramName;
        }

        public String CurrentProgramName
        {
            get
            {
                _currentName = (String.IsNullOrEmpty(_currentName)
                    ? (String.IsNullOrEmpty(_currentFile)
                        ? String.Empty
                        : Path.GetFileName(_currentFile))
                    : _currentName).Trim();
                return String.IsNullOrEmpty(_currentName) ? "Untitled" : _currentName;
            }
            set { _currentName = value; }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.UndoRedo.Undo();
            UpdateGui();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.UndoRedo.Redo();
            UpdateGui();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Clipboard.Cut();
            UpdateGui();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Clipboard.Copy();
        }

        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            UpdateGui();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Clipboard.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Selection.Text = "";
            UpdateGui();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PreparePrint();
            editor.Printing.Print(true);
        }

        private void PreparePrint()
        {
            editor.Printing.PrintDocument.DocumentName = CurrentProgramName;
            //scintillaEditor
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PreparePrint();
            editor.Printing.PrintPreview(this);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void scintillaEditor_SelectionChanged(object sender, EventArgs e)
        {
            UpdateGui();
            SearchReference();
        }

        private void SearchReference(bool forced=false)
        {
            if (editor.Selection.Length == 0)
            {
                // Check nearby word
                if (forced || Settings.Default.EditorSearchReferenceTextChanged)
                    _helpWindow.SearchReference(GetSelectedWord(editor), false);
            }
            else if (forced || Settings.Default.EditorSearchReferenceSelectionChanged)
                if (editor.Selection.Length < 30)
                    _helpWindow.SearchReference(editor.Selection.Text.Trim(), false);
        }

        private static string GetSelectedWord(Scintilla editor)
        {
            var ini = Math.Min(editor.Text.Length,editor.Selection.Start) - 1;
            for (var i = 0; i < 30; i++)
            {
                var pos = ini - i;

                if (pos < 0 || IsWordEndChar(editor.CharAt(pos)))
                {
                    ini = pos + 1;
                    break;
                }
            }

            var end = editor.Selection.Start;
            for (var i = 0; i < 30; i++)
            {
                var pos = end + i;

                if (pos > editor.Text.Length - 1 || IsWordEndChar(editor.CharAt(pos)))
                {
                    end = pos;
                    break;
                }
            }

            if (end - ini > 0)
                return editor.Text.Substring(ini, Math.Min(editor.Text.Length,end) - ini);
            return String.Empty;
        }

        private static bool IsWordEndChar(char c)
        {
            return "\r\n :;,.{}[]()=\"+-*/^|".Any(f => f == c);
        }

        private void sendToDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendCodeTo(Destinations.Calculator);
        }

        private void SendCodeTo(Destinations destination)
        {
            if (String.IsNullOrEmpty(editor.Text))
                MessageBox.Show("Nothing to send!", "Program is empty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else _parent.SendTextTo(destination, editor.Text);
        }

        private void scintillaEditor_TextChanged(object sender, EventArgs e)
        {
            _dirty = editor.UndoRedo.CanUndo;
            UpdateGui();
        }

        private void browseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendCodeTo(Destinations.Custom);
        }

        private void sendToVirtualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendCodeTo(Destinations.UserFolder);
        }

        private void actionsToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            UpdateGui();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AskForSave())
            {
                if (_parent.openFileDialogProgram.ShowDialog() == DialogResult.OK)
                    OpenFile(_parent.openFileDialogProgram.FileName);
            }
        }

        private void FormEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!AskForSave())
                e.Cancel = true;
            else
            {
                IsClosed = true;
                _parent.CheckEditorStates();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save(true);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New(true);
        }

        private void New(bool template = false)
        {
            if (AskForSave())
            {
                _currentName = String.Empty;
                _currentFile = String.Empty;
                editor.Text = template ? Settings.Default.ProgramTemplate : String.Empty;

                // Find cursor location
                const string cursorToken = "%cursor%";
                do
                {
                    var c = editor.Text.IndexOf(cursorToken);

                    if (c > 0)
                    {
                        editor.Text = editor.Text.Substring(0, c) + editor.Text.Substring(c + cursorToken.Length);
                        editor.CurrentPos = c;
                    }
                    else
                        break;
                } while (true);

                editor.UndoRedo.EmptyUndoBuffer();
                _dirty = false;
            }

            UpdateGui();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSettings();
        }

        private void OpenSettings(int p = 0)
        {
            if (new FormSettings(p).ShowDialog() == DialogResult.OK)
            {
                LoadEditorSettings();
                editor.Lexing.Colorize();
                UpdateGui();
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Selection.SelectAll();
        }

        private void newFromtemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New();
        }

        private void programPreferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSettings(2);
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.FindReplace.ShowReplace();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.FindReplace.ShowFind();
        }

        private void programToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            recentToolStripMenuItem.DropDown = Utilities.RecentFiles;
            recentToolStripMenuItem.Visible = recentToolStripMenuItem.HasDropDownItems;
        }

        private void recentToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var f = e.ClickedItem.Tag as string;
            if (f != null)
                OpenFile(f);
        }

        private void commentSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommentEditorLines(true);
        }

        private void CommentEditorLines(bool p)
        {
            const string commentsPrefix = "// ";
            var range = editor.Selection.Range;
            int f = range.StartingLine.Number, t = range.EndingLine.Number;

            editor.UndoRedo.BeginUndoAction();

            for (var i = f; i <= t; i++)
            {
                if (p)
                    editor.InsertText(editor.Lines[i].StartPosition, commentsPrefix);
                else
                {
                    editor.Lines[i].Text = editor.Lines[i].Text.TrimEnd(new[] {'\r', '\n'})
                        .TrimStart(commentsPrefix, false);
                }
            }

            editor.Selection.Start = editor.Lines[f].StartPosition;
            editor.Selection.End = editor.Lines[t].EndPosition;

            editor.UndoRedo.EndUndoAction();
        }

        private void uncommentSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommentEditorLines(false);
        }

        private void FormEditor_Shown(object sender, EventArgs e)
        {
            _parent.CheckEditorStates();
            editor.Select();
            editor.Visible = true;
        }

        public bool IsClosed { get; private set; }

        private void editorPreferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSettings(1);
        }

        private void editor_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("FileName"))
            {
                var f = e.Data.GetData("FileName") as string[];

                if (f != null && f.Any())
                    OpenFile(f[0]);
            }
        }

        private void editor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetFormats().Any(f => f == "FileName"))
                e.Effect = DragDropEffects.Copy;
        }

        private void formatDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var code = (from Line l in editor.Lines select l.Text).ToList();

            var openedBlock = Refactoring.FormatLines(ref code, new String(editor.Indentation.UseTabs ? '\t' : ' ',
                    editor.Indentation.UseTabs ? editor.Indentation.TabWidth : editor.Indentation.IndentWidth));

            if (openedBlock != null)
            {
                MessageBox.Show("Can't format the code because missing closing statements after:\n" + (openedBlock.Line+1) + ": '" +
                    editor.Lines[openedBlock.Line].Text.Trim().Trim(new[] { '\n', '\r' }) + "'\n\nPlease check your code and retry.", "Format document", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                editor.Selection.Start = editor.Lines[openedBlock.Line].StartPosition;
                editor.Selection.End = editor.Lines[openedBlock.Line].EndPosition;
                editor.Scrolling.ScrollToCaret();
            }
            else
            {
                int selectionStart = editor.Selection.Start, selectionEnd = editor.Selection.End;
                var first = editor.Lines.FirstVisibleIndex;
                editor.Text = String.Join(Environment.NewLine, code);
                editor.Lines.FirstVisibleIndex = first;
                editor.Selection.Start = Math.Min(selectionStart, editor.TextLength);
                editor.Selection.End = Math.Min(selectionEnd, editor.TextLength);
                editor.Refresh();
            }
        }

        public void InsertText(string text)
        {
            editor.InsertText(text);
        }

        private void exportToASCII7BitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var f = new SaveFileDialog {Filter = "txt|*.txt"};
                var txt = editor.Text;

                if (f.ShowDialog() == DialogResult.OK)
                {
                    // Convert editor text
                    File.WriteAllText(f.FileName,
                        Utilities.ASCII7Codes.Aggregate(txt, (current, r) => current.Replace(r.Key, r.Value)),
                        Encoding.ASCII);
                }
            }
            catch
            {
                MessageBox.Show("Error exporting the data", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void importFromASCII7BitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var f = new OpenFileDialog {Filter = "txt|*.txt"};

                if (f.ShowDialog() == DialogResult.OK)
                {
                    // Convert editor text
                    var t = File.ReadAllText(f.FileName, Encoding.ASCII);

                    if (!String.IsNullOrEmpty(t))
                    {
                        t = Utilities.ASCII7Codes.Aggregate(t, (current, r) => current.Replace(r.Value, r.Key));
                        editor.InsertText(t);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error importing data", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(File.Exists(_currentFile))
                Utilities.ShowFileProperties(_currentFile);
            else
                MessageBox.Show("File '" + _currentFile + "' was not found", "Properties", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
        }

        private void exportAsUSBDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO: Move to external file
                var f = new SaveFileDialog {Filter = "bin|*.bin"};

                if (f.ShowDialog() == DialogResult.OK)
                {
                    var n = 0;
                    var name = Path.Combine(Path.GetDirectoryName(f.FileName),
                        Path.GetFileNameWithoutExtension(f.FileName));
                    var ext = Path.GetExtension(f.FileName);
                    var prog = new PrimeProgramFile(Utilities.CreateTemporalFileFromText(editor.Text));
                    var p = new PrimeUsbData(prog.SafeName, prog.Data);
                    p.GenerateChunks(p.Data.ToList(), 64);
                    foreach (var c in p.Chunks)
                    {
                        File.WriteAllBytes(name + (n++ > 0 ? n + "" : String.Empty) + ext, c);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error exporting the data", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void searchReferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (_helpWindow.DockState)
            {
                case DockState.DockTopAutoHide:
                    _helpWindow.DockState = DockState.DockTop;
                    break;
                case DockState.DockLeftAutoHide:
                    _helpWindow.DockState = DockState.DockLeft;
                    break;
                case DockState.DockBottomAutoHide:
                    _helpWindow.DockState = DockState.DockBottom;
                    break;
                case DockState.DockRightAutoHide:
                    _helpWindow.DockState = DockState.DockRight;
                    break;
                default:
                    SearchReference(true);
                    break;
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
            APPCOMMAND_PASTE = 38, WM_SYSKEYDOWN = 0x0104, WM_SYSKEYUP = 0x0105, WM_COMMAND =0x0111;
        const string processName = "HPPrime";
        private Random _random = new Random();

        public void SendCommandToEmulator(String command)
        {
            var emulatorNotFound = true;
            foreach (var p in Process.GetProcesses())
            {
                if (!p.ProcessName.Equals(processName)) continue;

                emulatorNotFound = false;
                var emulator = p.MainWindowHandle;

                // Decode the keypresses
                foreach (var k in command.Split(new[] {','}))
                {
                    var key = k.Trim();

                    if (key.Length == 0) continue;

                    switch (key)
                    {
                        case "{Text}":
                        case "{Selection}":
                        case "{CopyText}":
                        case "{CopySelection}":
                            var tmp = key.EndsWith("Text}") ? editor.Text : editor.Selection.Text;
                            if (key.StartsWith("{Copy"))
                                Clipboard.SetText(tmp);
                            else
                                foreach (var c in tmp)
                                    SendKeyToWindow(emulator, IntPtr.Zero, c);
                            break;

                        case "{Nop}":
                            Thread.Sleep(1);
                            break;

                        case "{Focus}":
                            SetForegroundWindow(emulator);
                            break;

                        case "{Show}":
                            ShowWindow(emulator,1);
                            break;

                        case "{Paste}":
                            PostMessage(emulator, WM_COMMAND, (IntPtr)32801, IntPtr.Zero);
                            break;

                        case "{Wait}":
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
                                    case "{ProgramName}":
                                        key = "\"" + CurrentProgramName + "\"";
                                        break;

                                    case "{RandomChar}":
                                        key = "\"" + (char) _random.Next('a', 'z' + 1) + "\"";
                                        break;

                                    case "{RandomCHAR}":
                                        key = "\"" + (char) _random.Next('A', 'Z' + 1) + "\"";
                                        break;

                                    case "{RandomNumber}":
                                        key = "\"" + (char) _random.Next('0', '9' + 1) + "\"";
                                        break;
                                }
                            }

                            if (key.StartsWith("\"") && key.EndsWith("\""))
                            {
                                foreach (var c in key.Substring(1,key.Length-2))
                                    SendKeyToWindow(emulator, IntPtr.Zero, c);
                            }

                            /*bool keyUp = true, keyDown = true;
                            if (key.EndsWith("_up"))
                            {
                                keyDown = false;
                                key = key.Substring(0, key.Length - 3);
                            }
                            else if (key.EndsWith("_down"))
                            {
                                keyUp = false;
                                key = key.Substring(0, key.Length - 5);
                            }*/
                            Keys pressedKey;
                            if (Enum.TryParse(key, out pressedKey))
                                SendKeyToWindow(emulator, (IntPtr) pressedKey, char.MinValue);
                            break;
                    }
                }
            }

            if (emulatorNotFound)
            {
                if (!String.IsNullOrEmpty(_parent.EmulatorExeFile))
                {
                    var p = Process.Start(_parent.EmulatorExeFile);
                    p.WaitForInputIdle(1000);
                    Thread.Sleep(100);
                    SendCommandToEmulator(command);
                }
                else
                    MessageBox.Show("The emulator is not running, and it seems it is not available in this system.",
                        "Run Emulator", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
            }
        }

        private static void SendKeyToWindow(IntPtr emulator, IntPtr key, char character)
        {
            if (key == IntPtr.Zero)
            {
                PostMessage(emulator, WM_CHAR, (IntPtr)character, IntPtr.Zero);
                Thread.Sleep(1);
            }
            else
            {
                PostMessage(emulator, WM_KEYDOWN, key, IntPtr.Zero);
                Thread.Sleep(1);
                PostMessage(emulator, WM_KEYUP, key, IntPtr.Zero);
            }
        }


        private void convertSymbolsToPlainTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertSymbolsToPlain(false);
        }

        private void convertPlainTextToSymbolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertSymbolsToPlain(true);
        }

        private void ConvertSymbolsToPlain(bool reverse)
        {
            if (editor.TextLength == 0)
                return;

            editor.UndoRedo.BeginUndoAction();

            if (editor.Selection.Length == 0)
            {
                var t = Utilities.MathSymbols.Aggregate(editor.Text,
                    (current, r) => current.Replace(reverse ? r.Key : r.Value, reverse ? r.Value : r.Key));

                if (t != editor.Text)
                    editor.Text = t;
            }
            else
            {
                var t = Utilities.MathSymbols.Aggregate(editor.Selection.Text,
                    (current, r) => current.Replace(reverse ? r.Key : r.Value, reverse ? r.Value : r.Key));

                if (t != editor.Selection.Text)
                    editor.Selection.Text = t;
            }

            editor.UndoRedo.EndUndoAction();
        }

        private void emulatorCommandsStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            emulatorCommandsToolStripMenuItem.DropDownItems.Clear();

            foreach (var c in Utilities.EditorCommands)
            {
                if (c.Separator)
                    emulatorCommandsToolStripMenuItem.DropDownItems.Add(c.Name);
                else
                {
                    var currentCommand = c.Command;
                    var tmp = emulatorCommandsToolStripMenuItem.DropDownItems.Add(c.Name, null, (o, args) => SendCommandToEmulator(currentCommand));

                    if (c.RequiresSelection)
                        tmp.Enabled = editor.Selection.Length > 0;
                    else
                        if(c.RequiresText)
                            tmp.Enabled = editor.Text.Length > 0;
                }
            }

            if(emulatorCommandsToolStripMenuItem.DropDownItems.Count>0)
                emulatorCommandsToolStripMenuItem.DropDownItems.Add("-");
            emulatorCommandsToolStripMenuItem.DropDownItems.Add("Emulator commands settings...", Resources.settings, (o, args)=> OpenSettings(4));
        }

        private void toolStripTextBoxName_TextChanged(object sender, EventArgs e)
        {
            /*CurrentProgramName = toolStripTextBoxName.Text;
            _currentFile = null;
            _dirty = true;

            UpdateGui();*/
        }
    }
}
