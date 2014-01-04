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

namespace PrimeComm
{
    public partial class FormEditor : Form
    {
        private bool _dirty;
        private string _filepath;
        private readonly FormMain _parent;

        public FormEditor(FormMain p)
        {
            InitializeComponent();
            var config = new ScintillaNET.Configuration.Configuration(XmlReader.Create("hpppl.xml"), "hpppl");
            scintillaEditor.ConfigurationManager.Configure(config);

            _parent = p;
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
            scintillaEditor.Printing.Print(true);
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            _dirty = true;
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
    }
}
