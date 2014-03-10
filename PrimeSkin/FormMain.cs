using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using PrimeSkin.Properties;

namespace PrimeSkin
{
    public partial class FormMain : Form
    {
        private Skin _currentSkin;
        private bool _dirty;
        private readonly string _initialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"Hewlett-Packard\HP Prime Virtual Calculator\");

        public FormMain()
        {
            InitializeComponent();
            UpdateGui();

            // Initial window title includes the version
            var v = Assembly.GetExecutingAssembly().GetName().Version;
            Text = String.Format("{0} v{1} b{2}", Application.ProductName, v.ToString(2), v.Build);
        }

        private void UpdateGui()
        {
            var isSkinLoaded = _currentSkin != null;
            
            panelSkin.Enabled = isSkinLoaded;
            groupBoxComponents.Enabled = isSkinLoaded;
            groupBoxVisuals.Enabled = isSkinLoaded;
            buttonSave.Enabled = isSkinLoaded && _dirty;
            buttonSaveAs.Enabled = isSkinLoaded;
            buttonBorderFind.Enabled = isSkinLoaded;
            buttonBorderReset.Enabled = isSkinLoaded;

            Text = (_dirty?"* ":"")+(isSkinLoaded ? Path.GetFileNameWithoutExtension(_currentSkin.SkinPath) + ": " : String.Empty) + Application.ProductName;
        }

        private void LoadSkin(string path)
        {
            if (AskForSave())
            {
                try
                {
                    panelSkin.Controls.Clear();
                    var pictureBoxSkin = new PictureBox
                    {
                        Parent = panelSkin,
                        Location = new Point(panelSkin.Margin.Left, panelSkin.Margin.Right),
                        Anchor = AnchorStyles.Left | AnchorStyles.Top
                    };
                    _currentSkin = new Skin(path, pictureBoxSkin);

                    comboBoxSelection.Items.Clear();
                    comboBoxSelection.Items.AddRange(_currentSkin.Components.ToArray());

                    _currentSkin.SelectedComponentChange += _currentSkin_SelectedComponentChange;
                    _currentSkin.Selected = null;

                    UpdateProperties();
                    _dirty = false;
                }
                catch
                {
                    _currentSkin = null;
                    MessageBox.Show("Error loading the skin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            UpdateGui();
        }

        void _currentSkin_SelectedComponentChange(object sender, SelectedComponentEventArgs e)
        {
            if(comboBoxSelection.SelectedItem != e.Selected)
                comboBoxSelection.SelectedItem = e.Selected;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            var f = new OpenFileDialog
            {
                Filter = Resources.FilterInput,
                InitialDirectory = _initialDirectory
            };

            if (f.ShowDialog() == DialogResult.OK)
                try
                {
                    LoadSkin(f.FileName);
                }
                catch
                {
                }
        }

        private void comboBoxSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProperties();
        }

        private void UpdateProperties()
        {
            if (_currentSkin != null)
            {
                _currentSkin.Selected = comboBoxSelection.SelectedItem as Component;
                propertyGridComponent.SelectedObject = _currentSkin.Selected;

                propertyGridComponent.ExpandAllGridItems();
            }
        }

        private void propertyGridComponent_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            _currentSkin.Refresh(true);

            _dirty = true;
            UpdateGui();
        }

        private bool AskForSave()
        {
            if (_dirty)
            {
                switch (
                    MessageBox.Show(String.Format("Save the changes to '{0}'?", Path.GetFileNameWithoutExtension(_currentSkin.SkinPath)), "Save changes",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Exclamation))
                {
                    case DialogResult.Yes:
                        if (_currentSkin.Save())
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

        private void buttonBackground_Click(object sender, EventArgs e)
        {
            var f = new OpenFileDialog
            {
                Filter = "Bitmap (*.bmp)|*.bmp",
                InitialDirectory = _currentSkin.BasePath
            };

            if (f.ShowDialog() == DialogResult.OK)
            {
                _currentSkin.ImagePath = f.FileName;
                _currentSkin.Refresh(true);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save(String path="")
        {
            path = String.IsNullOrEmpty(path) ? _currentSkin.SkinPath : path;

            if (_currentSkin.Save(path))
            {
                _dirty = false;
                LoadSkin(path);
            }
            else
                MessageBox.Show("Error saving the skin (check if you have privileges in the destination folder and retry)", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonSaveAs_Click(object sender, EventArgs e)
        {
            var f = new SaveFileDialog
            {
                Filter = Resources.FilterInput,
                InitialDirectory = _initialDirectory
            };

            if (f.ShowDialog() == DialogResult.OK)
                Save(f.FileName);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!AskForSave())
                e.Cancel = true;
        }

        private void buttonBorderReset_Click(object sender, EventArgs e)
        {
            ChangeBorder();
        }

        private void ChangeBorder(bool findBorder=false)
        {
            if (findBorder)
                _currentSkin.FindBorder();
            else
                _currentSkin.Border = null;
            _dirty = true;

            _currentSkin.Refresh();
            UpdateGui();
        }

        private void buttonBorderFind_Click(object sender, EventArgs e)
        {
            ChangeBorder(true);
        }
    }
}
