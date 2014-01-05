using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using PrimeLib;
using ScintillaNET.Configuration;

namespace PrimeComm
{
    public partial class FormEditor : Form
    {
        private bool _dirty;
        private string _filepath;
        private readonly FormMain _parent;
        private string _currentFile, _currentName;
        private const string _editorName = "PrimePad";

        public FormEditor(FormMain p, string fileName="")
        {
            InitializeComponent();
            var config = new Configuration(XmlReader.Create("hpppl.xml"), "hpppl");
            scintillaEditor.ConfigurationManager.Configure(config);
            
            _parent = p;

            if (!String.IsNullOrEmpty(fileName) && File.Exists(fileName))
                OpenFile(fileName);

            _dirty = false;
            UpdateGui();
        }

        private void OpenFile(string fileName)
        {
            if (AskForSave())
            {
                try
                {
                    var tmp = new PrimeProgramFile(fileName);
                    _currentName = tmp.SafeName;
                    scintillaEditor.Text = new PrimeUsbData(_currentName,tmp.Data).ToString();
                    scintillaEditor.UndoRedo.EmptyUndoBuffer();
                    _currentFile = fileName;
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
                switch (
                    MessageBox.Show(String.Format("Save the changes to '{0}'?", CurrentProgramName), "Save changes", MessageBoxButtons.YesNoCancel,
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

        private bool Save()
        {
            throw new NotImplementedException();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FormAbout()).ShowDialog();
        }

        private void UpdateGui()
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

            sendToDeviceToolStripMenuItem.Enabled = _parent.IsDeviceConnected && !_parent.IsBusy;
            Text = String.Format("{2}{0}: {1}",CurrentProgramName, _editorName, _dirty ? "* ":string.Empty);
        }

        public String CurrentProgramName
        {
            get { return String.IsNullOrEmpty(_currentName) ? "Untitled" : _currentName; }
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
            scintillaEditor.Printing.PrintPreview();
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
            if (!String.IsNullOrEmpty(_filepath))
            {

            }
            else
            {
                // Temporal file
                _parent.SendTextTo(destination, scintillaEditor.Text);
            }
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

        private void virtualHPPrimeWorkingFolderToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
