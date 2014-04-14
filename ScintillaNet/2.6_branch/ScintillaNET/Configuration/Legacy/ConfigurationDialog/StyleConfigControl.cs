using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

using ScintillaNet.Configuration;
using ScintillaNet.Configuration.Legacy;

namespace ScintillaNet.Forms.Configuration
{
    public partial class StyleConfigControl : UserControl
    {
        private enum ChangeStyle
        {
            MouseMove,
            RGB,
            HSV,
            None
        }

        private ChangeStyle changeType = ChangeStyle.None;
        private Point selectedPoint;
        private ColorWheel myColorWheel;
        private ColorHandler.RGB RGB;
        private ColorHandler.HSV HSV;
        //private FontBrowser fontBrowser1;
        private bool isInUpdate = false;
        private IScintillaConfig configuration;
       
        public StyleConfigControl()
        {
            InitializeComponent();

            this.colorChanged = new EventHandler(StyleConfigControl_ColorChanged);
            for (int i = 0; i < 128; i++)
            {
                this.comboBoxFontSize.Items.Add(i);
            }
        }

        public IScintillaConfig Configuration
        {
            get
            {
                return this.configuration;
            }
            set
            {
                this.configuration = value;
                BindConfigToForm();
            }
        }

        //private ILanguageConfig langConfig;
        private SortedDictionary<int, ILexerStyle> styles;
        private Type lexerType = null;
        private LexerStyle EmptyStyle = new LexerStyle(0);
        
        private void BindConfigToForm()
        {
            this.comboBoxLanguage.Items.Clear();
            this.comboBoxLexer.Items.Clear();
            this.comboBoxLanguage.Sorted = true;
            this.comboBoxLexer.Sorted = true;
            foreach (string language in this.configuration.LanguageNames)
            {
                this.comboBoxLanguage.Items.Add(language);
                this.comboBoxSample.Items.Add(language);

                ILanguageConfig lc = this.configuration.Languages[language];
                if (!comboBoxLexer.Items.Contains(lc.Lexer.LexerName))
                {
                    comboBoxLexer.Items.Add(lc.Lexer.LexerName);
                }
            }
            //langConfig = this.configuration.LanguageDefaults;

            this.radioButtonGlobal.Checked = true;

            this.lexerType = this.configuration.LanguageDefaults.Lexer.Type.GetType();
            this.styles = this.configuration.LanguageDefaults.Styles;

            BindStylesToForm(lexerType, styles);
        }

        private void BindStylesToForm(Type lexerType, SortedDictionary<int, ILexerStyle> styles)
        {
            Array values = Enum.GetValues(lexerType);

            this.checkedListBoxAvailableStyles.Items.Clear();
            foreach (int val in values)
            {
                string name = Enum.GetName(lexerType, val);
                if (styles.ContainsKey(val))
                {
                    this.checkedListBoxAvailableStyles.Items.Add(name, true);
                }
                else
                {
                    this.checkedListBoxAvailableStyles.Items.Add(name, false);
                }
            }
        }

        private void BindStyleToForm(ILexerStyle style)
        {
            this.checkBoxBold.Checked = !style.Bold.HasValue ? false : style.Bold.Value;
            this.checkBoxEolFilled.Checked = !style.EOLFilled.HasValue ? false : style.EOLFilled.Value;
            this.checkBoxItalics.Checked = !style.Italics.HasValue ? false : style.Italics.Value;
            this.checkBoxUnderline.Checked = !style.Underline.HasValue ? false : style.Underline.Value;
            this.comboBoxFontSize.SelectedIndex = !style.FontSize.HasValue ? -1 : style.FontSize.Value;
            
            if (!string.IsNullOrEmpty(style.FontName))
            {
                this.fontBrowserFont.SelectedFont = style.FontName;
            }
            else
            {
                this.fontBrowserFont.SelectedFont = string.Empty;
            }

            if (style.ForeColor != Color.Empty)
            {
                this.textBoxForeColor.BackColor = style.ForeColor;
            }
            else
            {
                this.textBoxForeColor.BackColor = this.BackColor;
            }

            if (style.BackColor != Color.Empty)
            {
                this.textBoxBackColor.BackColor = style.BackColor;
            }
            else
            {
                this.textBoxBackColor.BackColor = this.BackColor;
            }
        }

        private void radioButtonStyleLevel_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonGlobal.Checked)
            {
                this.lexerType = this.configuration.LanguageDefaults.Lexer.Type.GetType();
                this.styles = this.configuration.LanguageDefaults.Styles;

                BindStylesToForm(lexerType, styles);
            }
            else
            {
                comboBoxLexer_SelectedIndexChanged(sender, e);
                comboBoxLanguage_SelectedIndexChanged(sender, e);
            }
        }

        private void comboBoxLexer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radioButtonLexer.Checked) 
            {
                if ((comboBoxLexer.SelectedIndex) < 0 && (comboBoxLexer.Items.Count > 0))
                {
                    comboBoxLexer.SelectedIndex = 0;
                }
                else if (this.comboBoxLexer.SelectedIndex >= 0)
                {
                    ILexerConfig lex = Configuration.Lexers[comboBoxLexer.SelectedItem.ToString()];

                    this.lexerType = lex.Type.GetType();
                    this.styles = lex.Styles;
                    BindStylesToForm(lexerType, styles);
                }
            }
        }

        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radioButtonLanguage.Checked)
            {
                if ((comboBoxLanguage.SelectedIndex) < 0 && (comboBoxLanguage.Items.Count > 0))
                {
                    comboBoxLanguage.SelectedIndex = 0;
                }
                else if (comboBoxLanguage.SelectedIndex >= 0)
                {
                    ILanguageConfig lang = Configuration.Languages[comboBoxLanguage.SelectedItem.ToString()];
                    this.comboBoxLexer.SelectedIndex = this.comboBoxLexer.Items.IndexOf(lang.Lexer.LexerName);

                    this.lexerType = lang.Lexer.Type.GetType();
                    this.styles = lang.Styles;
                    BindStylesToForm(lexerType, styles);
                }
            }
        }

        private void checkedListBoxAvailableStyles_SelectedIndexChanged(object sender, EventArgs e)
        {            
            int s = this.checkedListBoxAvailableStyles.SelectedIndex;
            if (s > -1)
            {
                if (this.checkedListBoxAvailableStyles.CheckedIndices.Contains(s))
                {
                    string name = this.checkedListBoxAvailableStyles.Items[s].ToString();

                    int val = (int)Enum.Parse(lexerType, name);
                    BindStyleToForm(styles[val]);
                }
                else
                {
                    BindStyleToForm(EmptyStyle);
                }
            }
        }

        private void StyleConfigControl_Load(object sender, EventArgs e)
        {
            // Turn on double-buffering, so the form looks better. 
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);

            // These properties are set in design view, as well, but they
            // have to be set to false in order for the Paint
            // event to be able to display their contents.
            // Never hurts to make sure they're invisible.
            panelSelectedColor.Visible = false;
            panelBrightness.Visible = false;
            panelColor.Visible = false;

            // Calculate the coordinates of the three
            // required regions on the form.
            Rectangle SelectedColorRectangle =
                new Rectangle(panelSelectedColor.Location, panelSelectedColor.Size);
            Rectangle BrightnessRectangle =
                new Rectangle(panelBrightness.Location, panelBrightness.Size);
            Rectangle ColorRectangle =
                new Rectangle(panelColor.Location, panelColor.Size);

            // Create the new ColorWheel class, indicating
            // the locations of the color wheel itself, the
            // brightness area, and the position of the selected color.
            myColorWheel = new ColorWheel(
                ColorRectangle, BrightnessRectangle,
                SelectedColorRectangle);
            myColorWheel.ColorChanged += new EventHandler<ColorChangedEventArgs>(myColorWheel_ColorChanged);

            // Set the RGB and HSV values 
            // of the NumericUpDown controls.
            SetRGB(RGB);
            SetHSV(HSV);

            // load the dialogs from the config.
            /*_languageCategory.DataSource = configManager.Languages;
            _sampleLanguage.DataSource = configManager.Languages;

            _masterSetting.DataSource = configManager.MasterStyles;
            _inherits.DataSource = configManager.MasterStyles;

            _languageCategory_SelectedIndexChanged(null, null);*/
        }

        private void StyleConfigControl_ColorChanged(object o, EventArgs args)
        {
            if (this.textBoxBackColor.Focused)
            {
                this.textBoxBackColor.BackColor = (Color)o;
            }
            else if (this.textBoxForeColor.Focused)
            {
                this.textBoxForeColor.BackColor = (Color)o;
            }
        }

        private void TextBoxColor_Enter(object sender, EventArgs e)
        {
            Control c = sender as Control;
            this.Color = c.BackColor;
            this.SetRGB(RGB);
            this.SetHSV(HSV);
            this.Invalidate();
        }

        private void comboBoxSample_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lang = this.comboBoxSample.SelectedItem.ToString();
            this.scintillaControlSample.ConfigurationManager.Language = lang;
            
            ConfigResource resource = new ConfigResource(System.Reflection.Assembly.GetExecutingAssembly(), "Scintilla.Configuration.Samples", lang);
            if (resource.Exists)
            {
                StreamReader reader = new StreamReader(resource.OpenRead());
                this.scintillaControlSample.Text = reader.ReadToEnd();
                reader.Close();
            }
        }

        private void RefreshValue(NumericUpDown nud, int value)
        {
            // Update the value of the NumericUpDown control, 
            // if the value is different than the current value.
            // Refresh the control, causing an immediate repaint.
            if (nud.Value != value)
            {
                nud.Value = value;
                nud.Refresh();
            }
        }

        private void SetRGB(ColorHandler.RGB RGB)
        {
            // Update the RGB values on the form, but don't trigger
            // the ValueChanged event of the form. The isInUpdate
            // variable ensures that the event procedures
            // exit without doing anything.
            isInUpdate = true;
            RefreshValue(numericUpDownRed, RGB.Red);
            RefreshValue(numericUpDownGreen, RGB.Green);
            RefreshValue(numericUpDownBlue, RGB.Blue);
            textBoxHexColor.Text = "#" + Color.R.ToString("x").PadLeft(2, '0') + Color.G.ToString("x").PadLeft(2, '0') + Color.B.ToString("x").PadLeft(2, '0');
            isInUpdate = false;
        }

        private void SetHSV(ColorHandler.HSV HSV)
        {
            // Update the HSV values on the form, but don't trigger
            // the ValueChanged event of the form. The isInUpdate
            // variable ensures that the event procedures
            // exit without doing anything.
            isInUpdate = true;
            //RefreshValue(nudHue, HSV.Hue);
            //RefreshValue(nudSaturation, HSV.Saturation);
            //RefreshValue(nudBrightness, HSV.value);
            //textBoxHexColor.Text = ColorTranslator.ToHtml(Color);
            isInUpdate = false;
        }

        public Color Color
        {
            // Get or set the color to be
            // displayed in the color wheel.
            get
            {
                return myColorWheel.Color;
            }

            set
            {
                // Indicate the color change type. Either RGB or HSV
                // will cause the color wheel to update the position
                // of the pointer.
                changeType = ChangeStyle.RGB;
                RGB = new ColorHandler.RGB(value.R, value.G, value.B);
                HSV = ColorHandler.RGBtoHSV(RGB);
            }
        }

        private void HandleRGBChange(object sender, System.EventArgs e)
        {
            // If the R, G, or B values change, use this 
            // code to update the HSV values and invalidate
            // the color wheel (so it updates the pointers).
            // Check the isInUpdate flag to avoid recursive events
            // when you update the NumericUpdownControls.
            if (!isInUpdate)
            {
                changeType = ChangeStyle.RGB;
                RGB = new ColorHandler.RGB((int)numericUpDownRed.Value, (int)numericUpDownGreen.Value, (int)numericUpDownBlue.Value);
                SetHSV(ColorHandler.RGBtoHSV(RGB));
                this.OnColorChanged();
                this.Invalidate();
            }
        }

        private void HandleHSVChange(object sender, EventArgs e)
        {
            // If the H, S, or V values change, use this 
            // code to update the RGB values and invalidate
            // the color wheel (so it updates the pointers).
            // Check the isInUpdate flag to avoid recursive events
            // when you update the NumericUpdownControls.
            if (!isInUpdate)
            {
                changeType = ChangeStyle.HSV;
                //HSV = new ColorHandler.HSV((int)(nudHue.Value), (int)(nudSaturation.Value), (int)(nudBrightness.Value));
                SetRGB(ColorHandler.HSVtoRGB(HSV));
                this.OnColorChanged();
                this.Invalidate();
            }
        }

        private void myColorWheel_ColorChanged(object sender, ColorChangedEventArgs e)
        {
            SetRGB(e.RGB);
            SetHSV(e.HSV);

            this.OnColorChanged();
        }

        private void HandleMouse(object sender, MouseEventArgs e)
        {
            // If you have the left mouse button down, 
            // then update the selectedPoint value and 
            // force a repaint of the color wheel.
            if (e.Button == MouseButtons.Left)
            {
                changeType = ChangeStyle.MouseMove;
                selectedPoint = new Point(e.X, e.Y);
                this.Invalidate();
            }
        }

        private void HandleMouseUp(object sender, MouseEventArgs e)
        {
            myColorWheel.SetMouseUp();
            changeType = ChangeStyle.None;
        }

        private void textBoxHexColor_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!isInUpdate)
                {

                    Color c = ColorTranslator.FromHtml(textBoxHexColor.Text);
                    this.Color = c;
                    SetRGB(new ColorHandler.RGB(c.R, c.G, c.B));
                    SetHSV(ColorHandler.RGBtoHSV(RGB));
                    this.OnColorChanged();
                    this.Invalidate();
                }
            }
            catch
            {
                textBoxHexColor.Text = "#" + Color.R.ToString("x").PadLeft(2, '0') + Color.G.ToString("x").PadLeft(2, '0') + Color.B.ToString("x").PadLeft(2, '0');
            }
        }

        private void StyleConfigControl_Paint(object sender, PaintEventArgs e)
        {
            // Depending on the circumstances, force a repaint
            // of the color wheel passing different information.
            switch (changeType)
            {
                case ChangeStyle.HSV:
                    myColorWheel.Draw(e.Graphics, HSV);
                    break;
                case ChangeStyle.MouseMove:
                case ChangeStyle.None:
                    myColorWheel.Draw(e.Graphics, selectedPoint);
                    break;
                case ChangeStyle.RGB:
                    myColorWheel.Draw(e.Graphics, RGB);
                    break;
            }
        }

        private void OnColorChanged()
        {
            if (colorChanged != null) colorChanged(this.Color, EventArgs.Empty);
        }
        private EventHandler colorChanged;
    }
}
