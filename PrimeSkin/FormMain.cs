using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace PrimeSkin
{
    public partial class FormMain : Form
    {
        private Skin _currentSkin;

        public FormMain()
        {
            var v = Assembly.GetExecutingAssembly().GetName().Version;
            Text = String.Format("{0} v{1} b{2}", Application.ProductName, v.ToString(2), v.Build);

            InitializeComponent();
        }

        private void LoadSkin(string path)
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
                Filter = "Skin file (*.skin)|*.skin",
                InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"Hewlett-Packard\HP Prime Virtual Calculator\")
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
            if (_currentSkin != null)
            {
                _currentSkin.Selected = comboBoxSelection.SelectedItem as Component;
                propertyGridComponent.SelectedObject = _currentSkin.Selected;
                propertyGridComponent.ExpandAllGridItems();
            }
        }
    }
}
