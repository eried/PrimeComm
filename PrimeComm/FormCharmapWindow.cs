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



            charmap.CellCountChanged += charmap_CellCountChanged;
            charmap.SelectedCharChanged += charmap_SelectedCharChanged;
        }

        void charmap_SelectedCharChanged(object sender, EventArgs e)
        {
            UpdateGui();
        }

        private void UpdateGui()
        {
            this.InvokeIfRequired(() =>
            {
                if (charmap.SelectedChar > 0)
                {
                    var s = (int) charmap.SelectedChar;
                    labelChar.Text =  s+ " (#" + s.ToString("X") + "h)";
                    buttonChar.Enabled = true;
                    buttonDec.Enabled = true;
                    buttonHex.Enabled = true;


                }
            });
        }

        void charmap_CellCountChanged(object sender, EventArgs e)
        {
            vScrollBar1.Minimum = 32;
            vScrollBar1.SmallChange = charmap.Columns;
            vScrollBar1.LargeChange = charmap.Columns*charmap.Rows;

            var max = (int)(Math.Floor(65533 / (double)vScrollBar1.SmallChange)) * vScrollBar1.SmallChange;
            if(vScrollBar1.Value > max)
                vScrollBar1.Value = max;
            vScrollBar1.Maximum = max;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            charmap.FirstCellChar = (char)vScrollBar1.Value;
        }
    }
}
