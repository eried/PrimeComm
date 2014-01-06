using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using PrimeComm.Properties;
using PrimeLib;
using ScintillaNET;
using ScintillaNET.Configuration;

namespace PrimeComm
{
    public partial class FormEditor : Form
    {
        private bool _dirty;
        private readonly FormMain _parent;
        private string _currentFile, _currentName;
        private const string EditorName = "PrimePad";

        /// <summary>
        /// Creates a new editor window
        /// </summary>
        /// <param name="p">Parent window</param>
        /// <param name="openFile">File to open, null if template should be used, empty if blank should be used</param>
        public FormEditor(FormMain p, string openFile = "")
        {
            InitializeComponent();
            _parent = p;

            LoadEditorSettings();

            if (openFile == null)
                New(true);
            else
            {
                if (!String.IsNullOrEmpty(openFile) && File.Exists(openFile))
                    OpenFile(openFile);
            }

            UpdateGui();

            // Sorting the toolstrips
            toolStripMain.Location = new Point(0, menuStrip1.Height);
            toolStripSendTo.Location = new Point(toolStripMain.Width + 3, menuStrip1.Height);
        }

        private void LoadEditorSettings()
        {
            // Editor configuration
            if (File.Exists("hpppl.xml"))
            {
                var config = new Configuration(XmlReader.Create("hpppl.xml"), "hpppl");
                scintillaEditor.ConfigurationManager.Configure(config);
            }

            // Editor font
            foreach (var f in Directory.GetFiles(".", "*.ttf"))
            {
                try
                {
                    var fontCollection = new PrivateFontCollection();
                    fontCollection.AddFontFile(f);
                    scintillaEditor.Font = new Font(fontCollection.Families[0], (int)Settings.Default.EditorFontSize);

                    //foreach (StylesCommon s in Enum.GetValues(typeof (StylesCommon)))
                    foreach (var s in scintillaEditor.Lexing.StyleNameMap.Keys)
                    {
                        scintillaEditor.Styles[s].Font = scintillaEditor.Font;
                    }
                    break;
                }
                catch
                {
                }
            }
        }

        private void OpenFile(string fileName)
        {
            if (AskForSave())
            {
                try
                {
                    var tmp = new PrimeProgramFile(fileName, _parent.Parameters);
                    _currentName = tmp.SafeName;
                    _currentFile = String.Empty;
                    scintillaEditor.Text = new PrimeUsbData(_currentName, tmp.Data).ToString();

                    if (tmp.IsConversion)
                    {
                        if (Settings.Default.AddCommentOnConversion)
                            scintillaEditor.InsertText(0,"// Converted by PrimeComm from " + fileName + Environment.NewLine);
                    }
                    else
                        _currentFile = fileName;

                    _dirty = false;
                    scintillaEditor.UndoRedo.EmptyUndoBuffer();
                }
                catch
                {
                    MessageBox.Show("Error loading '" + fileName + "'", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
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
                    new PrimeUsbData(CurrentProgramName, Encoding.Unicode.GetBytes(scintillaEditor.Text)).Save(_currentFile);
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
            undoToolStripMenuItem.Enabled = scintillaEditor.UndoRedo.CanUndo;
            toolStripButtonUndo.Enabled = scintillaEditor.UndoRedo.CanUndo;

            redoToolStripMenuItem.Enabled = scintillaEditor.UndoRedo.CanRedo;
            toolStripButtonRedo.Enabled = scintillaEditor.UndoRedo.CanRedo;

            copyToolStripMenuItem.Enabled = scintillaEditor.Clipboard.CanCopy;
            toolStripButtonCopy.Enabled = scintillaEditor.Clipboard.CanCopy;

            cutToolStripMenuItem.Enabled = scintillaEditor.Clipboard.CanCut;
            toolStripButtonCut.Enabled = scintillaEditor.Clipboard.CanCut;

            pasteToolStripMenuItem.Enabled = scintillaEditor.Clipboard.CanPaste;
            toolStripButtonPaste.Enabled = scintillaEditor.Clipboard.CanPaste;

            deleteToolStripMenuItem.Enabled = scintillaEditor.Selection.Length > 0;

            sendToDeviceToolStripMenuItem.Enabled = _parent.IsDeviceConnected && !_parent.IsBusy;
            toolStripButtonSendToDevice.Enabled = sendToDeviceToolStripMenuItem.Enabled;

            sendToVirtualToolStripMenuItem.Enabled = _parent.IsEmulatorAvailable && !_parent.IsBusy;
            toolStripButtonSendToVirtual.Enabled = sendToVirtualToolStripMenuItem.Enabled;

            Text = String.Format("{2}{0}: {1}",CurrentProgramName, EditorName, _dirty ? "* ":string.Empty);
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
            scintillaEditor.UndoRedo.Undo();
            UpdateGui();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintillaEditor.UndoRedo.Redo();
            UpdateGui();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintillaEditor.Clipboard.Cut();
            UpdateGui();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintillaEditor.Clipboard.Copy();
        }

        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            UpdateGui();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintillaEditor.Clipboard.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintillaEditor.Selection.Text = "";
            UpdateGui();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PreparePrint();
            scintillaEditor.Printing.Print(true);
        }

        private void PreparePrint()
        {
            scintillaEditor.Printing.PrintDocument.DocumentName = CurrentProgramName;
            //scintillaEditor
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PreparePrint();
            scintillaEditor.Printing.PrintPreview(this);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void scintillaEditor_SelectionChanged(object sender, EventArgs e)
        {
            UpdateGui();
        }

        private void sendToDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendCodeTo(Destinations.Calculator);
        }

        private void SendCodeTo(Destinations destination)
        {
            if (String.IsNullOrEmpty(scintillaEditor.Text))
                MessageBox.Show("Nothing to send!", "Program is empty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else _parent.SendTextTo(destination, scintillaEditor.Text);
        }

        private void scintillaEditor_TextChanged(object sender, EventArgs e)
        {
            _dirty = scintillaEditor.UndoRedo.CanUndo;
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
                scintillaEditor.Text = template? Settings.Default.ProgramTemplate: String.Empty;
                scintillaEditor.UndoRedo.EmptyUndoBuffer();
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
                scintillaEditor.Lexing.Colorize();
                UpdateGui();
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintillaEditor.Selection.SelectAll();
        }

        private void newFromtemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New();
        }

        private void programPreferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSettings(1);
        }
    }
}
