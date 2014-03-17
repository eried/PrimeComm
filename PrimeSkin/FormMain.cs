using System.Diagnostics;
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
        private SkinManager _currentSkin;
        private bool _dirty;
        private readonly string _initialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"Hewlett-Packard\HP Prime Virtual Calculator\");

        public FormMain()
        {
            InitializeComponent();
            UpdateGui();

            // Size of the window relative to the screen
            Size = new Size((int) (Screen.PrimaryScreen.WorkingArea.Size.Width*0.6),(int)(Screen.PrimaryScreen.WorkingArea.Size.Height*0.9));
            
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
            buttonSave.Enabled = isSkinLoaded && _dirty;
            buttonSaveAs.Enabled = isSkinLoaded;
            buttonBorderFind.Enabled = isSkinLoaded;
            buttonBorderReset.Enabled = isSkinLoaded;
            buttonBackground.Enabled = isSkinLoaded;

            // View menu
            keysToolStripMenuItem.Enabled = isSkinLoaded;
            screenToolStripMenuItem.Enabled = isSkinLoaded;
            regionsToolStripMenuItem.Enabled = isSkinLoaded;
            allComponentsToolStripMenuItem.Enabled = isSkinLoaded;
            hideAllToolStripMenuItem.Enabled = isSkinLoaded;
            addANewRegionToolStripMenuItem.Enabled = isSkinLoaded;
            removeTheLastRegionToolStripMenuItem.Enabled = isSkinLoaded;

            UpdateUndoRedoMenu();

            Text = (_dirty?"* ":"")+(isSkinLoaded ? Path.GetFileNameWithoutExtension(_currentSkin.SkinPath) + ": " : String.Empty) + Application.ProductName;
        }

        private void UpdateUndoRedoMenu()
        {
            var isSkinLoaded = _currentSkin != null;
            undoToolStripMenuItem.Enabled = isSkinLoaded && _currentSkin.CanUndo;
            redoToolStripMenuItem.Enabled = isSkinLoaded && _currentSkin.CanRedo;
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
                    _currentSkin = new SkinManager(path, pictureBoxSkin);

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
            comboBoxSelection.Items.AddRange(_currentSkin.Components);
        }

        void _currentSkin_ComponentsChanged(object sender, EventArgs e)
        {
            UpdatePropertiesCombo();
            comboBoxSelection.SelectedItem = _currentSkin.Selected;
            UpdateGui();
        }

        void _currentSkin_SelectedComponentPropertiesChanged(object sender, EventArgs e)
        {
            SomethingChanged();
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
            SomethingChanged();
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

            SomethingChanged();
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
                _currentSkin.FindBorder(true);
            else
                _currentSkin.FindBorder(false);

            _currentSkin.Refresh();
            SomethingChanged();
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

                addANewRegionToolStripMenuItem.Enabled = true;
                var tmp = _currentSkin.RemoveMaximizedRegion(false); // Check for the last maximized region
                removeTheLastRegionToolStripMenuItem.Enabled = tmp!=null && tmp.Id > 0;
            }
            else
            {
                addANewRegionToolStripMenuItem.Enabled = false;
                removeTheLastRegionToolStripMenuItem.Enabled = false;
            }

            // Update Gui
            linkLabelRegionAdd.Enabled = addANewRegionToolStripMenuItem.Enabled;
            linkLabelRegionRemove.Enabled = removeTheLastRegionToolStripMenuItem.Enabled;
            keysToolStripMenuItem.Checked = checkBoxViewKeys.Checked;
            screenToolStripMenuItem.Checked = checkBoxViewScreen.Checked;
            regionsToolStripMenuItem.Checked = checkBoxViewRegions.Checked;

            if (checkBoxViewScreen.Checked)
                r.Add(ComponentType.Screen);

            checkBoxViewAll.CheckedChanged -= checkBoxViewAll_CheckedChanged;

            checkBoxViewAll.CheckState = r.Count == 0
                ? CheckState.Unchecked
                : (r.Count == 3 ? CheckState.Checked : CheckState.Indeterminate);

            checkBoxViewAll.CheckedChanged += checkBoxViewAll_CheckedChanged;

            _currentSkin.VisibleTypes = r.ToArray();
        }

        private void SomethingChanged()
        {
            if (!_dirty)
            {
                _dirty = true;
                UpdateGui();
            }
        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
            _currentSkin.Undo();
            UpdateView();
        }

        private void buttonRedo_Click(object sender, EventArgs e)
        {
            _currentSkin.Redo();
            UpdateView();
        }

        private void addANewRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRegion();
        }

        private void AddRegion()
        {
            _currentSkin.AddMaximizedRegion();
            SomethingChanged();
            UpdateView();
        }

        private void removeTheLastRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveRegion();
        }

        private void RemoveRegion()
        {
            var r = _currentSkin.RemoveMaximizedRegion(false);

            if (r == null) return;

            if (MessageBox.Show("This will remove the last region '" + r + "'. Do you want to continue?",
                "Remove region", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                _currentSkin.RemoveMaximizedRegion(true);
                SomethingChanged();
                UpdateView();
            }
        }

        private void linkLabelRegionAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddRegion();
        }

        private void linkLabelRegionRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RemoveRegion();
        }

        private void keysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkBoxViewKeys.Checked = !checkBoxViewKeys.Checked;
        }

        private void screenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkBoxViewScreen.Checked = !checkBoxViewScreen.Checked;
        }

        private void regionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkBoxViewRegions.Checked = !checkBoxViewRegions.Checked;
        }

        private void allComponentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkBoxViewAll.Checked = true;
        }

        private void hideAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkBoxViewAll.Checked = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormAbout().ShowDialog();
        }
    }
}
