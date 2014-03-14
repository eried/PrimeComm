using System.Diagnostics;
using System.Windows.Forms;

namespace PrimeSkin
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();

            Text = "About " + Utilities.GetProgramVersion();
        }

        private void linkLabelOpenLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start((sender as Control).Text);
        }
    }
}
