using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace PrimeComm
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();

            var v = Assembly.GetExecutingAssembly().GetName().Version;
            Text = String.Format("About {0} v{1} b{2}", Application.ProductName, v.ToString(2), v.Build);
        }

        private void linkLabelOpenLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start((sender as Control).Text);
        }
    }
}
