using System;
using System.Drawing.Text;
using WeifenLuo.WinFormsUI.Docking;

namespace PrimeComm
{
    public partial class FormCharmapWindow : DockContent
    {
        private readonly FormEditor _parent;

        public FormCharmapWindow(FormEditor parent, FontCollection fontCollection)
        {
            _parent = parent;
            InitializeComponent();

            charmap.SetFontCollection(fontCollection);
            charmap.SelectedChar = (char)0;
            charmap.CellCountChanged += charmap_CellCountChanged;
            charmap.SelectedCharChanged += charmap_SelectedCharChanged;
            comboBoxPage.SelectedIndexChanged += comboBoxPage_SelectedIndexChanged;
        }

        private void comboBoxPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            var c = comboBoxPage.SelectedItem as CharacterPage;

            if (c != null)
                charmap.FirstCellChar = (char)c.StartChar;
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

                    comboBoxPage.SelectedIndexChanged -= comboBoxPage_SelectedIndexChanged;
                    CharacterPage selected = null;
                    foreach (CharacterPage c in comboBoxPage.Items)
                    {
                        if (c.StartChar > charmap.FirstCellChar)
                            break;
                        selected = c;
                    }
                    comboBoxPage.SelectedItem = selected;
                    comboBoxPage.SelectedIndexChanged += comboBoxPage_SelectedIndexChanged;
                }
            });
        }

        void charmap_CellCountChanged(object sender, EventArgs e)
        {
            vScrollBarChars.Minimum = 32;
            vScrollBarChars.SmallChange = charmap.Columns;
            vScrollBarChars.LargeChange = charmap.Columns*charmap.Rows;

            var max = (int)(Math.Floor(65533 / (double)vScrollBarChars.SmallChange)) * vScrollBarChars.SmallChange;
            if(vScrollBarChars.Value > max)
                vScrollBarChars.Value = max;
            vScrollBarChars.Maximum = max;

        }

        private void FormCharmapWindow_Resize(object sender, EventArgs e)
        {
            panelSelectedChar.Visible = labelInsertChar.Left > panelSelectedChar.Left + panelSelectedChar.Width;
            comboBoxPage.Visible = labelInsertChar.Left > comboBoxPage.Left + comboBoxPage.Width;
        }

        private void buttonDec_Click(object sender, EventArgs e)
        {
            _parent.InsertText("" + (int)charmap.SelectedChar);
        }

        private void buttonHex_Click(object sender, EventArgs e)
        {
            _parent.InsertText("#" + ((int)charmap.SelectedChar).ToString("X") + "h");
        }

        private void buttonChar_Click(object sender, EventArgs e)
        {
            _parent.InsertText("" + charmap.SelectedChar);
        }

        private void charmap_DoubleClick(object sender, EventArgs e)
        {
            _parent.InsertText("" + charmap.SelectedChar);
        }

        private void FormCharmapWindow_Shown(object sender, EventArgs e)
        {
            comboBoxPage.Items.AddRange(new object[]
            {
                new CharacterPage("Latin", 32),
                new CharacterPage("Latin Sup.", 160),
                new CharacterPage("Latin Ext-A", 256),
                new CharacterPage("Latin Ext-B", 402),
                new CharacterPage("IPA Extensions", 592),
                new CharacterPage("Space Modifiers", 688),
                new CharacterPage("Combining Diacritics", 768),
                new CharacterPage("Greek and Coptic", 900),
                new CharacterPage("Cyrillic", 1024),
                new CharacterPage("Cyrillic Sup.", 1280),
                new CharacterPage("Hangul Jamo", 4352),
                new CharacterPage("Phonetic Extns.", 7431),
                new CharacterPage("Latin Ext. Additional", 7680),
                new CharacterPage("General Punctuation", 8201),
                new CharacterPage("Subscript/Superscript", 8304),
                new CharacterPage("Currency", 8352),
                new CharacterPage("Letterlike Symb.", 8450),
                new CharacterPage("Number Forms", 8531),
                new CharacterPage("Arrows", 8592),
                new CharacterPage("Math Operators", 8704),
                new CharacterPage("Misc. Technical", 8968),
                new CharacterPage("Encl. Alphanumerics", 9312),
                new CharacterPage("Box Drawing", 9472),
                new CharacterPage("Block Elements", 9601),
                new CharacterPage("Geometric Shapes", 9632),
                new CharacterPage("Misc. Symbols", 9733),
                new CharacterPage("Dingbats", 9985),
                new CharacterPage("Sup. Arrows-B", 10552),
                new CharacterPage("CJK Symb. and Punc.", 12288),
                new CharacterPage("Hiragana", 12353),
                new CharacterPage("Katakana", 12448),
                new CharacterPage("Bopomofo", 12549),
                new CharacterPage("Hangul Comp. Jamo", 12593),
                new CharacterPage("Enc. CJK Letters & Months", 12832),
                new CharacterPage("CJK Comp.", 13059),
                new CharacterPage("CJK Uni. Ideographs Ext-A", 13312),
                new CharacterPage("CJK Uni. Ideographs", 19968),
                new CharacterPage("Hangul Syllables", 44032),
                new CharacterPage("Private Use Area", 57344),
                new CharacterPage("CJK Comp. Ideographs", 63744),
                new CharacterPage("Vertical Forms", 65040),
                new CharacterPage("CJK Com. Forms", 65072),
                new CharacterPage("Small Form Variants", 65104),
                new CharacterPage("Halfwidth & Fullwidth Forms", 65281),
                new CharacterPage("Specials", 65533),
            });
            comboBoxPage.SelectedIndex = 0;
        }

        private void vScrollBarChars_ValueChanged(object sender, EventArgs e)
        {
            charmap.FirstCellChar = (char)(vScrollBarChars.Minimum + (int)(Math.Floor((double)(vScrollBarChars.Value - vScrollBarChars.Minimum) / vScrollBarChars.SmallChange) * vScrollBarChars.SmallChange));
            UpdateGui();
        }
    }

    internal class CharacterPage
    {
        public string Name { get; private set; }
        public int StartChar { get; private set; }

        public CharacterPage(string name, int startChar)
        {
            Name = name;
            StartChar = startChar;
        }

        public override String ToString()
        {
            return Name;
        }
    }
}
