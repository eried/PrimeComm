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

            // Fill details 
            //textBoxAbout.AppendText(String.Format("{0} version {1} build {2}{3}{3}", Application.ProductName, v.ToString(2), v.Build, Environment.NewLine));
            textBoxAbout.AppendText(String.Join(Environment.NewLine, new[]{
                "Main icon by dAKirby309","http://dakirby309.deviantart.com","",
                "About image effects by Maurizio Pigliacampi","https://www.facebook.com/pigliacampi","",
                "Scintilla","http://scintilla.org","",
                "Scintilla.Net","http://scintillanet.codeplex.com","",
                "HidLibrary","https://github.com/mikeobrien/HidLibrary","",
                "Other icons from VisualPharm","http://www.visualpharm.com"}));
        }

        private void linkLabelOpenLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start((sender as Control).Text);
        }
    }
}
