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
            _currentSkin = new Skin(path);
            pictureBoxSkin.Size = _currentSkin.GetSetting<Size>("size");

            foreach (var k in _currentSkin.Components)
                comboBoxSelection.Items.Add(k);

            pictureBoxSkin.Invalidate();
        }

        private void pictureBoxSkin_Paint(object sender, PaintEventArgs e)
        {
            if (_currentSkin != null)
                _currentSkin.Paint(e.Graphics, pictureBoxSkin.Size);
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            var f = new OpenFileDialog
            {
                Filter = "Skin file (*.skin)|*.skin",
                InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),@"Hewlett-Packard\HP Prime Virtual Calculator\")
            };

            if(f.ShowDialog() == DialogResult.OK)
                try
                {
                    LoadSkin(f.FileName);
                }
                catch
                {
                }

        }

        private void pictureBoxSkin_MouseDown(object sender, MouseEventArgs e)
        {
            if (_currentSkin == null)
                return;

            if (e.Button == MouseButtons.Left)
            {
                var k = _currentSkin.GetComponent(e.Location);
                if (k !=null)
                {
                    comboBoxSelection.Text = k + "";
                    propertyGrid1.PropertyTabs.AddTabType(typeof (Button));
                }
            }
        }



    }
}
