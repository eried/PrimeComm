using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using PrimeComm.Properties;
using ScintillaNET;
using WeifenLuo.WinFormsUI.Docking;

namespace PrimeComm
{
    public partial class FormCharmapWindow : DockContent
    {
        private readonly FormEditor _parent;

        public FormCharmapWindow(FormEditor parent, FontFamily fontFamily)
        {
            _parent = parent;
            InitializeComponent();

            if (fontFamily != null)
                charmap.Font = new Font(fontFamily, (int) Settings.Default.EditorFontSize);
        }
    }
}
