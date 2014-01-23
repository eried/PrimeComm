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
            var ed = new DockContent { CloseButton = false, CloseButtonVisible = false };
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
            //_charmapWindow = new FormCharmapWindow(this, fontCollection.Families[0]);
            //_charmapWindow.Show(dockPanel, DockState.DockBottomAutoHide);

            // Adding the help
            _helpWindow = new FormHelpWindow(Resources.commands, fontCollection.Families[0]);
            //_helpWindow.Show(_charmapWindow.Pane, DockAlignment.Right, 0.6);
            _helpWindow.Show(dockPanel, DockState.DockBottomAutoHide);
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
                    editor.Font = new Font(fontCollection.Families[0], (int)Settings.Default.EditorFontSize);

                    //foreach (StylesCommon s in Enum.GetValues(typeof (StylesCommon)))
                    foreach (var s in editor.Lexing.StyleNameMap.Keys)
                    {
                        editor.Styles[s].Font = new Font(fontCollection.Families[0], (int)Settings.Default.EditorFontSize, editor.Styles[s].Font.Style);
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
                        MessageBox.Show("Can't load '" + fileName + "'", "File does not exist", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        Utilities.UpdateRecentFiles();
                        Close();
                    }
                    else
                    {
                        var tmp = new PrimeProgramFile(fileName, _parent.Parameters);
                        _currentName = tmp.SafeName;
                        _currentFile = String.Empty;
                        editor.Text = new PrimeUsbData(_currentName, tmp.Data).ToString();
                        

                        if (tmp.IsConversion)
                        {
                            if (Settings.Default.AddCommentOnConversion)
                                editor.InsertText(0,
                                    "// Converted by PrimeComm from " + fileName + Environment.NewLine);
                        }
                        else
                            _currentFile = fileName;

                        _dirty = false;

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
                switch (MessageBox.Show(String.Format("Save the changes to '{0}'?", CurrentProgramName), "Save changes", MessageBoxButtons.YesNoCancel,
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

            var textSelected = editor.Selection.Length > 0;
            var textNotEmpty = editor.TextLength > 0;
            deleteToolStripMenuItem.Enabled = textSelected;
            commentSelectionToolStripMenuItem.Enabled = textNotEmpty;
            uncommentSelectionToolStripMenuItem.Enabled = textNotEmpty;

            sendToDeviceToolStripMenuItem.Enabled = _parent.IsDeviceConnected && !_parent.IsBusy;
            toolStripButtonSendToDevice.Enabled = sendToDeviceToolStripMenuItem.Enabled;

            sendToVirtualToolStripMenuItem.Enabled = _parent.IsEmulatorAvailable && !_parent.IsBusy;
            toolStripButtonSendToVirtual.Enabled = sendToVirtualToolStripMenuItem.Enabled;

            Text = String.Format("{2}{0}: {1}", CurrentProgramName, EditorName, _dirty ? "* " : string.Empty);
        }

        public String CurrentProgramName
        {
            get
            {
                _currentName = (String.IsNullOrEmpty(_currentName) ? (String.IsNullOrEmpty(_currentFile)
                            ? "Untitled" : Path.GetFileNameWithoutExtension(_currentFile)): _currentName).Trim();
                return _currentName;
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

            if (editor.Selection.Length == 0)
            {
                // Check nearby word
                _helpWindow.SearchReference(GetSelectedWord(editor), false);
            }
            else
            {
                if(editor.Selection.Length < 30)
                    _helpWindow.SearchReference(editor.Selection.Text.Trim(), false);
            }

        }

        private string GetSelectedWord(Scintilla ed)
        {
            var ini = editor.Selection.Start-1;
            for (var i = 0; i < 30; i++)
            {
                var pos = ini-i;

                if (pos < 0 || IsWordEndChar(editor.CharAt(pos)))
                {
                    ini = pos+1;
                    break;
                }
            }

            var end = editor.Selection.Start;
            for (var i = 0; i < 30; i++)
            {
                var pos = end + i;

                if (pos > editor.TextLength-1 || IsWordEndChar(editor.CharAt(pos)))
                {
                    end = pos;
                    break;
                }
            }

            if (end - ini > 0)
                return editor.Text.Substring(ini, end - ini);
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

        private void New(bool template=false)
        {
            if (AskForSave())
            {
                _currentName = String.Empty;
                _currentFile = String.Empty;
                editor.Text = template? Settings.Default.ProgramTemplate: String.Empty;

                // Find cursor location
                const string cursorToken = "%cursor%";
                do
                {
                    var c = editor.Text.IndexOf(cursorToken);

                    if (c > 0)
                    {
                        editor.Text = editor.Text.Substring(0, c) + editor.Text.Substring(c+cursorToken.Length);
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

        private void OpenSettings(int p=0)
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
            if (f!=null)
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
                    editor.Lines[i].Text = editor.Lines[i].Text.TrimEnd(new []{'\r','\n'}).TrimStart(commentsPrefix, false);
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

        private void FormEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            
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
            // Remove indentation
            foreach (Line l in editor.Lines)
                l.Text = l.Text.Trim(new[] {'\t', ' ', '\n', '\r'});

            var indentation = new String(editor.Indentation.UseTabs ? '\t' : ' ',
                editor.Indentation.UseTabs ? editor.Indentation.TabWidth : editor.Indentation.IndentWidth);

            // Find code blocks

        }

        private void formatselectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dockPanel1.DockPaneFactory.CreateDockPane(new HelpPane(), DockState.DockBottom, true);
        }

        public void InsertText(string text)
        {
            editor.InsertText(text);
        }
    }
}
