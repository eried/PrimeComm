using PrimeSkin.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

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

            // Size of the window relative to the screen
            Size = new Size((int) (Screen.PrimaryScreen.WorkingArea.Size.Width*0.6),(int)(Screen.PrimaryScreen.WorkingArea.Size.Height*0.9));

            // Initial window title includes the version
            var v = Assembly.GetExecutingAssembly().GetName().Version;
            Text = String.Format("{0} v{1} b{2}", Application.ProductName, v.ToString(2), v.Build);

            // Initial view checkboxes
            checkBoxViewKeys.Checked = true;
            checkBoxViewScreen.Checked = true;
            checkBoxViewAll.CheckState = CheckState.Indeterminate;
        }

        private void UpdateGui()
        {
            var isSkinLoaded = _currentSkin != null;
            
            panelSkin.Enabled = isSkinLoaded;
            groupBoxProperties.Enabled = isSkinLoaded;
            groupBoxView.Enabled = isSkinLoaded;
            groupBoxLayout.Enabled = isSkinLoaded;
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

                    UpdatePropertiesCombo();
                    
                    _currentSkin.SelectedComponentChanged += _currentSkin_SelectedComponentChanged;
                    _currentSkin.ComponentsChanged += _currentSkin_ComponentsChanged;
                    _currentSkin.SelectedComponentPropertiesChanged += _currentSkin_SelectedComponentPropertiesChanged;
                    _currentSkin.Selected = null;

                    UpdateProperties();
                    UpdateView();

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

        private void UpdatePropertiesCombo()
        {
            comboBoxSelection.Items.Clear();
            comboBoxSelection.Items.AddRange(_currentSkin.Components.ToArray());
        }

        void _currentSkin_ComponentsChanged(object sender, EventArgs e)
        {
            UpdatePropertiesCombo();
            comboBoxSelection.SelectedItem = _currentSkin.Selected;
            //UpdateProperties();
        }

        void _currentSkin_SelectedComponentPropertiesChanged(object sender, EventArgs e)
        {
            if (!_dirty)
            {
                _dirty = true;
                UpdateGui();
            }

            UpdateProperties();
        }

        void _currentSkin_SelectedComponentChanged(object sender, SelectedComponentEventArgs e)
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
                _currentSkin.Selected = comboBoxSelection.SelectedItem as VirtualComponent;
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
                switch (MessageBox.Show(String.Format("Save the changes to '{0}'?", Path.GetFileNameWithoutExtension(_currentSkin.SkinPath)), "Save changes",
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

            if (f.ShowDialog() != DialogResult.OK) return;

            var p = Path.Combine(_currentSkin.BasePath, Path.GetFileName(f.FileName));
            if (!File.Exists(p))
            {
                switch (MessageBox.Show("The selected image isn't in the same directory of the skin file. This might cause issues. What do you want to do?" +
                                        Environment.NewLine + Environment.NewLine + "Click Yes to copy the image" + Environment.NewLine +
                                        "Click No to change the image anyway" + Environment.NewLine + "Click Cancel to keep the current background image", "Image location",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
                {
                    case DialogResult.Cancel:
                        return;

                    case DialogResult.Yes:
                        var wasCopied = false;
                        do
                        {
                            try
                            {
                                File.Copy(f.FileName, p);
                                wasCopied = true;
                            }
                            catch
                            {
                            }

                            if (wasCopied)
                            {
                                f.FileName = p;
                                continue;
                            }

                            if (MessageBox.Show("Error copying the image (check if you have privileges in the destination folder and retry). Do you want to retry?",
                                "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                                return;
                        }while(wasCopied==false);
                        break;
                }
            }

            _currentSkin.ImagePath = f.FileName;
            _currentSkin.Refresh(true);

            _dirty = true;
            UpdateGui();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save(String path="")
        {
            var realPath = String.IsNullOrEmpty(path) ? _currentSkin.SkinPath : path;

            if (_currentSkin.Save(realPath))
            {
                _dirty = false;

                if (path == realPath)
                    LoadSkin(path);
                else
                    UpdateGui(); // Just remove the 'unsaved' symbol
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

        private void checkBoxViewAll_CheckedChanged(object sender, EventArgs e)
        {
            var checks = new[] {checkBoxViewKeys, checkBoxViewRegions, checkBoxViewScreen};

            foreach(var c in checks)
                c.CheckedChanged -= checkBoxView_CheckedChanged;

            foreach (var c in checks)
            {
                switch (checkBoxViewAll.CheckState)
                {
                    case CheckState.Checked:
                        c.Checked = true;
                        break;

                    case CheckState.Unchecked:
                        c.Checked = false;
                        break;
                }

                c.CheckedChanged += checkBoxView_CheckedChanged;
            }

            UpdateView();
        }

        private void checkBoxView_CheckedChanged(object sender, EventArgs e)
        {
            UpdateView();
        }

        private void UpdateView()
        {
            if (_currentSkin == null)
                return;

            var r = new List<ComponentType>();

            if (checkBoxViewKeys.Checked)
                r.Add(ComponentType.Key);

            if (checkBoxViewRegions.Checked)
            {
                r.Add(ComponentType.Maximized);

                linkLabelRegionAdd.Enabled = true;
                var tmp = _currentSkin.RemoveMaximizedRegion(false); // Check for the last maximized region
                linkLabelRegionRemove.Enabled = tmp!=null && tmp.Id > 0;
            }
            else
            {
                linkLabelRegionAdd.Enabled = false;
                linkLabelRegionRemove.Enabled = false;
            }

            if (checkBoxViewScreen.Checked)
                r.Add(ComponentType.Screen);

            checkBoxViewAll.CheckedChanged -= checkBoxViewAll_CheckedChanged;

            checkBoxViewAll.CheckState = r.Count == 0
                ? CheckState.Unchecked
                : (r.Count == 3 ? CheckState.Checked : CheckState.Indeterminate);

            checkBoxViewAll.CheckedChanged += checkBoxViewAll_CheckedChanged;

            _currentSkin.VisibleTypes = r.ToArray();
        }

        private void linkLabelRegionAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _currentSkin.AddMaximizedRegion(true);
            _dirty = true;

            UpdateView();
        }

        private void linkLabelRegionRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var r = _currentSkin.RemoveMaximizedRegion(false);

            if (r == null) return;

            if (MessageBox.Show("This will remove the last region '" + r + "'. Do you want to continue?",
                "Remove region", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                _currentSkin.RemoveMaximizedRegion(true);
                _dirty = true;

                UpdateView();
            }
        }
    }
}
