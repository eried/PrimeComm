using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PrimeComm.Properties;

namespace PrimeComm
{
    public partial class FormScreen : Form
    {
        public FormScreen()
        {
            InitializeComponent();
            SetFullscreen(false);
        }

        private void buttonFullscreen_Click(object sender, EventArgs e)
        {
            if (!Settings.Default.SkipFullscreenWarning)
            {
                MessageBox.Show("You are enabling Fullscreen mode now. Right click and uncheck fullscreen to exit.",
                    "Fullscreen mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Settings.Default.SkipFullscreenWarning = true;
                Settings.Default.Save();
            }

            SetFullscreen(true);
        }

        private void SetFullscreen(bool p)
        {
            IsFullscreen = p;
            panelOptions.Visible = !p;
            statusStripMain.Visible = !p;
            FormBorderStyle = !p ? FormBorderStyle.Sizable: FormBorderStyle.None;
            TopMost = p;
            
            if (p)
            {
                LastWindowState = WindowState;
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = LastWindowState;
                pictureBoxScreen.Width = Width - 40;
                pictureBoxScreen.Height = Height - 110;
                pictureBoxScreen.Location = new Point(12, 12);
                pictureBoxScreen.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            }

            pictureBoxScreen.Dock = p ? DockStyle.Fill : DockStyle.None;
        }

        public FormWindowState LastWindowState { get; set; }

        public bool IsFullscreen { get; set; }

        private void contextMenuStripMain_Opening(object sender, CancelEventArgs e)
        {
            fullscreenToolStripMenuItem.Checked = IsFullscreen;
        }

        private void fullscreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetFullscreen(!IsFullscreen);
        }
    }
}
