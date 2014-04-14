using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;

namespace ScintillaNet.Forms.Configuration
{
    public partial class FontBrowser : UserControl
    {
        // Fields
        private ComboBox cb;
        private ListBox lb;

        private int iSelectedIndex;
        private string m_SampleText;
        private string m_SelectedFont;
        private bool m_ShowName;
        private bool m_ShowSample;
        private Styles m_Style;

        // Events
        public event EventHandler<FontBrowserEventArgs> FontSelected;

        // Methods
        public FontBrowser()
        {
            this.m_SampleText = "AaBbCc123";
            this.m_ShowName = true;
            this.m_ShowSample = true;
            this.m_Style = Styles.ListBox;
            this.components = null;
            this.InitializeComponent();
            this.m_SelectedFont = "";
            this.iSelectedIndex = -1;
            this.CreateListBox();
            this.FillListBox();

        }

        private void xxcbDrawItem(object sender, DrawItemEventArgs e)
        {
            //drawItems here
            if (sender == null)
                return;
            if (e.Index < 0)
                return;
            //Get the Combo from the sender object
            ComboBox cbo = (ComboBox)sender;
            //Get the FontFamily from put in constructor
            FontFamily ff = new FontFamily(cbo.Items[e.Index].ToString());
            //Set font style
            FontStyle fs = FontStyle.Regular;
            if (!ff.IsStyleAvailable(fs))
                fs = FontStyle.Italic;
            if (!ff.IsStyleAvailable(fs))
                fs = FontStyle.Bold;
            //Set font for drawing with (wich is the font itself)
            Font font = new Font(ff, 8, fs);

            //draw the background and focus rectangle
            e.DrawBackground();
            e.DrawFocusRectangle();
            //get graphics
            Graphics g = e.Graphics;
            //And draw with whatever font and brush we wish
            g.DrawString(font.Name, font, Brushes.ForestGreen, e.Bounds.X, e.Bounds.Y);

        }

        private void cbDrawItem(object sender, DrawItemEventArgs e)
        {
            Font font1;
            Rectangle rectangle1 = e.Bounds;
            int num1 = rectangle1.X;
            rectangle1 = e.Bounds;
            int num2 = rectangle1.Y;

            if (e.Index < 0)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                return;
            }

            e.DrawBackground();
            e.DrawFocusRectangle();


            Brush colorbrush = SystemBrushes.ControlText;


            if ((e.State & System.Windows.Forms.DrawItemState.Selected) == System.Windows.Forms.DrawItemState.Selected)
                colorbrush = SystemBrushes.HighlightText;


            if (this.m_ShowName)
            {
                e.Graphics.DrawString(this.cb.Items[e.Index].ToString(), base.Font, colorbrush, ((float)num1), ((float)num2));
                num1 += 160;

            }
            if (!this.m_ShowSample)
            {
                return;

            }
            FontFamily family1 = new FontFamily(this.cb.Items[e.Index].ToString());
            if (family1.IsStyleAvailable(FontStyle.Regular))
            {
                font1 = new Font(this.cb.Items[e.Index].ToString(), 10f, FontStyle.Regular);

            }
            else
            {
                if (family1.IsStyleAvailable(FontStyle.Bold))
                {
                    font1 = new Font(this.cb.Items[e.Index].ToString(), 10f, FontStyle.Bold);
                }
                else if (family1.IsStyleAvailable(FontStyle.Italic))
                {
                    font1 = new Font(this.cb.Items[e.Index].ToString(), 10f, FontStyle.Italic);
                }
                else
                    font1 = new Font(this.cb.Items[e.Index].ToString(), 10f, (FontStyle.Italic | FontStyle.Bold));
            }

            e.Graphics.DrawString(this.cb.Items[e.Index].ToString(), font1, colorbrush, ((float)num1), ((float)num2));
            font1.Dispose();

        }

        private void cbSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.FontSelected != null)
            {

                FontSelected(this, new FontBrowserEventArgs(this.cb.SelectedItem.ToString()));

            }

        }


        private void CreateDropdown()
        {
            this.cb = new ComboBox();
            cb.DropDownStyle = ComboBoxStyle.DropDownList;

            this.cb.Dock = DockStyle.Fill;
            this.cb.DrawMode = DrawMode.OwnerDrawFixed;
            this.cb.DrawItem += new DrawItemEventHandler(this.cbDrawItem);
            this.cb.SelectedIndexChanged += new System.EventHandler(this.cbSelectedIndexChanged);
            base.Controls.Add(this.cb);

        }


        private void CreateListBox()
        {
            this.lb = new ListBox();
            this.lb.Dock = DockStyle.Fill;
            this.lb.DrawMode = DrawMode.OwnerDrawFixed;
            this.lb.DrawItem += new DrawItemEventHandler(this.lbDrawItem);
            this.lb.SelectedIndexChanged += new System.EventHandler(this.lbSelectedIndexChanged);
            base.Controls.Add(this.lb);

        }


        private void DestroyControl()
        {
            base.Controls.Clear();
            Styles styles1 = this.m_Style;
            switch (styles1)
            {
                case Styles.ListBox:
                    {
                        this.lb.Dispose();
                        return;

                    }
                case Styles.DropdownListBox:
                    {
                        this.cb.Dispose();
                        return;

                    }

            }

        }

        private void FillDropdown()
        {
            int num2;
            InstalledFontCollection collection1 = new InstalledFontCollection();
            int num1 = 0;
            num1 = collection1.Families.GetLength(0);
            for (num2 = 0; (num2 < num1); num2 += 1)
            {
                String s = collection1.Families[num2].Name;
                switch (s)
                {
                    case "":
                        break;
                    default:
                        this.cb.Items.Add(s);
                        this.cb.Text = this.m_SelectedFont;
                        break;
                }

            }

        }

        private void FillListBox()
        {
            int num2;
            InstalledFontCollection collection1 = new InstalledFontCollection();
            int num1 = 0;
            num1 = collection1.Families.GetLength(0);
            for (num2 = 0; (num2 < num1); num2 += 1)
            {
                this.lb.Items.Add(collection1.Families[num2].Name);

            }

        }

        private void FontControl_Load(object sender, EventArgs e)
        {

        }

        private void lbDrawItem(object sender, DrawItemEventArgs e)
        {
            Brush brush1;
            Brush brush2;
            Font font1;
            Rectangle rectangle1 = e.Bounds;
            int num1 = rectangle1.X;
            rectangle1 = e.Bounds;
            int num2 = rectangle1.Y;
            if (this.lb.SelectedIndex == e.Index)
            {
                brush1 = SystemBrushes.ActiveCaption;
                brush2 = SystemBrushes.HighlightText;

            }
            else
            {
                brush1 = SystemBrushes.Window;
                brush2 = SystemBrushes.ControlText;

            }
            e.Graphics.FillRectangle(brush1, e.Bounds);
            if (this.m_ShowName)
            {
                e.Graphics.DrawString(this.lb.Items[e.Index].ToString(), base.Font, brush2, ((float)num1), ((float)num2));
                num1 += 160;

            }
            if (!this.m_ShowSample)
            {
                return;

            }
            FontFamily family1 = new FontFamily(this.lb.Items[e.Index].ToString());
            if (family1.IsStyleAvailable(FontStyle.Regular))
            {
                font1 = new Font(this.lb.Items[e.Index].ToString(), 10f, FontStyle.Regular);

            }
            else
            {
                if (family1.IsStyleAvailable(FontStyle.Bold))
                {
                    font1 = new Font(this.lb.Items[e.Index].ToString(), 10f, FontStyle.Bold);
                    goto Label_0194;

                }
                if (family1.IsStyleAvailable(FontStyle.Italic))
                {
                    font1 = new Font(this.lb.Items[e.Index].ToString(), 10f, FontStyle.Italic);
                    goto Label_0194;

                }
                font1 = new Font(this.lb.Items[e.Index].ToString(), 10f, (FontStyle.Italic | FontStyle.Bold));

            }

        Label_0194:
            e.Graphics.DrawString(this.m_SampleText, font1, brush2, ((float)num1), ((float)num2));
            font1.Dispose();

        }

        private void lbSelectedIndexChanged(object sender, EventArgs e)
        {
            Rectangle rectangle1;
            Rectangle rectangle2;
            Size size1 = this.lb.ClientSize;
            rectangle1 = new Rectangle(0, ((this.iSelectedIndex - this.lb.TopIndex) * this.lb.ItemHeight), size1.Width, this.lb.ItemHeight);
            this.lb.Invalidate(rectangle1);
            this.iSelectedIndex = this.lb.SelectedIndex;
            size1 = this.lb.ClientSize;
            rectangle2 = new Rectangle(0, ((this.iSelectedIndex - this.lb.TopIndex) * this.lb.ItemHeight), size1.Width, this.lb.ItemHeight);
            this.lb.Invalidate(rectangle2);
            if (this.FontSelected != null)
            {
                FontSelected(this, new FontBrowserEventArgs(this.lb.SelectedItem.ToString()));

            }

        }


        private void ReDrawControl()
        {
            if (this.m_Style == Styles.DropdownListBox)
            {
                this.cb.Invalidate();
                return;

            }
            this.lb.Invalidate();

        }



        // Properties
        public string SampleText
        {
            get
            {
                return this.m_SampleText;

            }
            set
            {
                this.m_SampleText = value;
                this.ReDrawControl();

            }

        }


        public string SelectedFont
        {
            get
            {
                return this.m_SelectedFont;

            }
            set
            {
                this.m_SelectedFont = value;

                if (m_SelectedFont == string.Empty)
                {
                    if (this.cb != null) this.cb.SelectedIndex = -1;
                    if (this.lb != null) this.lb.SelectedIndex = -1;
                }
                else
                {
                    if (this.cb != null)
                    {
                        this.cb.SelectedItem = this.m_SelectedFont;

                    }
                    if (this.lb != null)
                    {
                        this.lb.SelectedItem = this.m_SelectedFont;

                    }
                }
            }

        }

        public bool ShowName
        {
            get
            {
                return this.m_ShowName;

            }
            set
            {
                this.m_ShowName = value;
                this.ReDrawControl();

            }

        }

        public bool ShowSample
        {
            get
            {
                return this.m_ShowSample;

            }
            set
            {
                this.m_ShowSample = value;
                this.ReDrawControl();

            }

        }

        public Styles Style
        {
            get
            {
                return this.m_Style;

            }
            set
            {
                this.DestroyControl();
                this.m_Style = value;
                Styles styles1 = this.m_Style;
                switch (styles1)
                {
                    case Styles.ListBox:
                        {
                            this.CreateListBox();
                            this.FillListBox();
                            return;

                        }
                    case Styles.DropdownListBox:
                        {
                            this.CreateDropdown();
                            this.FillDropdown();
                            return;

                        }

                }

            }

        }

        /* // Nested Types
        private class LOGFONT
        {
            // Methods
            public LOGFONT()
            {
            }

            // Fields
            public byte lfCharSet;
            public byte lfClipPrecision;
            public int lfEscapement;
            public string lfFaceName;
            public int lfHeight;
            public byte lfItalic;
            public int lfOrientation;
            public byte lfOutPrecision;
            public byte lfPitchAndFamily;
            public byte lfQuality;
            public byte lfStrikeOut;
            public byte lfUnderline;
            public int lfWeight;
            public int lfWidth;
 
        }
*/
        public enum Styles
        {
            // Fields
            DropdownListBox = 1,
            ListBox = 0

        }
    }

    public class FontBrowserEventArgs : EventArgs
    {
        // Fields
        private string m_SelectedFont;

        // Methods
        public FontBrowserEventArgs(string pSelFont)
        {
            this.m_SelectedFont = pSelFont;

        }

        // Properties
        public string SelectedFont
        {
            get { return this.m_SelectedFont; }
            set { this.m_SelectedFont = value; }
        }
    }
}
