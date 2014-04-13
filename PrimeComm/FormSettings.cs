using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PrimeComm.Properties;
using PrimeLib;

namespace PrimeComm
{
    public partial class FormSettings : Form
    {
        public FormSettings(int startTab = 0)
        {
            InitializeComponent();

            if (Environment.OSVersion.Version.Major < 6)
                groupBoxDithering.Visible = false;

            foreach (var d in Enum.GetValues(typeof(DitherType)))
                comboBoxImageDitheringMethod.Items.Add(d);

            comboBoxImageDitheringMethod.SelectedItem = Settings.Default.ImageDitheringMethod;

            if (startTab < tabControlPreferences.TabCount)
                tabControlPreferences.SelectedIndex = startTab;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveAndExit();
        }

        private void SaveAndExit()
        {
            Utilities.UpdateRecentFiles();

            // Manual update due performance
            Settings.Default.EmulatorCommands = textBoxCommands.Text;
            Utilities.UpdateEditorCommands();

            Settings.Default.Save();
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to reset all settings to the default value?", "Reset settings",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Settings.Default.Reset();
                LoadSettings();
                LoadFonts();
            }
        }

        private void something_Changed(object sender, EventArgs e)
        {
            UpdateGui();
        }

        private void UpdateGui()
        {
            // Program options
            checkBoxCompressSpaces.Enabled = checkBoxEnableAdditionalProgramProcessing.Checked;
            checkBoxObfuscateVariables.Enabled = checkBoxEnableAdditionalProgramProcessing.Checked;
            checkBoxRemoveComments.Enabled = checkBoxEnableAdditionalProgramProcessing.Checked;
            checkBoxCompressSpacesMore.Enabled = checkBoxCompressSpaces.Enabled && checkBoxCompressSpaces.Checked;

            // Image output
            if (radioButtonPixel.Checked)
                Settings.Default.ImageMethod = ImageProcessingMode.Pixels;
            else if (radioButtonIcon.Checked)
                Settings.Default.ImageMethod = ImageProcessingMode.Icon;
            else
                Settings.Default.ImageMethod = ImageProcessingMode.DimgrobPieces;

            checkBoxImageMethodDimgrobOptimizeBlacks.Enabled = Settings.Default.ImageMethod == ImageProcessingMode.DimgrobPieces;
            checkBoxImageMethodDimgrobOptimizeSimilar.Enabled = Settings.Default.ImageMethod == ImageProcessingMode.DimgrobPieces;
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            // Output method
            switch (Settings.Default.ImageMethod)
            {
                case ImageProcessingMode.Pixels:
                    radioButtonPixel.Checked = true;
                    break;

                case ImageProcessingMode.Icon:
                    radioButtonIcon.Checked = true;
                    break;

                default:
                    radioButtonDimgrob.Checked = true;
                    break;
            }

            // Image reduction
            comboBoxImageDitheringMethod.SelectedItem = Settings.Default.ImageDitheringMethod;

            // Emulator commands
            textBoxCommands.Text = Settings.Default.EmulatorCommands;
        }

        private void CreateAdvancedSettings(TabPage tabPage)
        {
            var advancedSettings = new List<String>(new[] { "VariableRefactoringStartingSeed", "ProgramTemplate" });
            foreach (SettingsProperty r in Settings.Default.Properties)
                if (r.Name.StartsWith("Regex"))
                    advancedSettings.Add(r.Name);

            advancedSettings.Sort();

            var table = new TableLayoutPanel {ColumnCount = 2, RowCount = advancedSettings.Count() + 1, Dock = DockStyle.Fill};
            
            var row = 0;
            foreach (var s in advancedSettings)
            {
                var l = new Label { Text = s, Anchor = AnchorStyles.Left, AutoSize = true };
                table.Controls.Add(l);
                table.SetRow(l, row);
                table.SetColumn(l, 0);

                var t = new TextBox { Dock = DockStyle.Fill, Multiline = true, ScrollBars = ScrollBars.Vertical, Height=38 };
                t.DataBindings.Add(new Binding("Text", Settings.Default, s, true,DataSourceUpdateMode.OnPropertyChanged));
                table.Controls.Add(t);
                table.SetRow(t, row++);
                table.SetColumn(t, 1);
            }


            for (var i = 0; i < table.ColumnCount; i++)
                table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            for (var i = 0; i < table.RowCount; i++)
                table.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            tabPage.Controls.Add(table);
        }

        private void UpdateTab(TabPage tabPage)
        {
            if (tabPage == tabPageEditor && comboBoxFontFile.Items.Count == 0)
            {
                LoadFonts();
            }
            else if (tabPage == tabPageAdvanced && tabPageAdvanced.Controls.Count == 0)
                CreateAdvancedSettings(tabPage);
            else if (tabPage == tabPageEmulator)
            {
                if (comboBoxCommandsKeys.Items.Count == 0)
                {
                    var keys = Enum.GetNames(typeof (Keys)).ToList();
                    keys.Sort();

                    foreach (var k in keys.Where(k => k != "NoName" && k != "None"))
                        comboBoxCommandsKeys.Items.Add(k);
                    ClearCombobox(comboBoxCommandsKeys);

                    var r = new[]
                    {
                        "Show", "Focus", "CopySelection", "Selection", "CopyText", "Text", "Paste", "Alert:<Text>",
                        "Question:<Text>", "Nop", "Wait", "ProgramName", "RandomNumber", "RandomChar", "RandomCHAR",
                    }.ToList();
                    r.Sort();
                    foreach (var k in r)
                        comboBoxCommandsSpecial.Items.Add("{" + k + "}");
                    ClearCombobox(comboBoxCommandsSpecial);

                    textBoxCommands.SelectionStart = textBoxCommands.TextLength;
                    textBoxCommands.SelectionLength = 0;
                }
                textBoxCommands.Select();
                textBoxCommands.ScrollToCaret();
            }
        }

        private void LoadFonts()
        {
            String selected = null;
            comboBoxFontFile.Items.Clear();

            foreach (var f in Directory.GetFiles(".", "*.ttf", SearchOption.AllDirectories))
            {
                comboBoxFontFile.Items.Add(f);

                if (f == Settings.Default.EditorPreferedFontFile)
                    selected = f;
            }

            // No fonts... try later again
            if (comboBoxFontFile.Items.Count <= 0) return;

            // Select default
            comboBoxFontFile.SelectedIndexChanged += (o, args) => Settings.Default.EditorPreferedFontFile = comboBoxFontFile.SelectedValue as string;

            if (!String.IsNullOrEmpty(selected))
                comboBoxFontFile.SelectedValue = selected;
            else
                comboBoxFontFile.SelectedIndex = 0;
        }

        private void ClearCombobox(ComboBox combo)
        {
            var label = combo == comboBoxCommandsKeys ? "(Insert Key)" : "(Insert Special)";

            if (combo.Items.Count == 0 || (String) combo.Items[0] != label)
                combo.Items.Insert(0, label);

            if (combo.SelectedIndex < 0)
                combo.SelectedIndex = 0;
        }

        private void linkLabelClearWarnings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Settings.Default.SkipFullscreenWarning = false;
            linkLabelClearWarnings.Enabled = false;
        }

        private void comboBoxImageDitheringMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.ImageDitheringMethod = (DitherType)comboBoxImageDitheringMethod.SelectedItem;
        }

        private void linkLabelDitheringInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://msdn.microsoft.com/en-us/library/windows/desktop/ms534106(v=vs.85).aspx");
        }

        private void linkLabelClearRecent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(Settings.Default.RecentOpenedFiles!=null)
                Settings.Default.RecentOpenedFiles.Clear();
            linkLabelClearRecent.Enabled = false;
        }

        private void comboBoxCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            var c = sender as ComboBox;
            if (c!=null && c.SelectedIndex >0)
            { 
                var txt = c.SelectedItem as string;

                if (!String.IsNullOrEmpty(txt))
                {
                    var selectionIndex = textBoxCommands.SelectionStart+textBoxCommands.SelectionLength;
                    var prefix = selectionIndex > 0 && textBoxCommands.Text[selectionIndex - 1] != ',' && 
                        textBoxCommands.Text[selectionIndex - 1] != '=' && textBoxCommands.Text[selectionIndex - 1] != '\n' && 
                        textBoxCommands.Text[selectionIndex - 1] != '\r';
                    txt = (prefix ? "," : "") + txt + (prefix ? "" : ",");
                    textBoxCommands.Text = textBoxCommands.Text.Insert(selectionIndex, txt);

                    if (txt.Contains("<") && txt.Contains(">"))
                    {
                        textBoxCommands.SelectionStart = selectionIndex + txt.LastIndexOf("<");
                        textBoxCommands.SelectionLength = txt.LastIndexOf(">") - txt.LastIndexOf("<")+1;
                    }
                    else
                    {
                        textBoxCommands.SelectionStart = selectionIndex + txt.Length;
                        textBoxCommands.SelectionLength = 0;
                    }
                    textBoxCommands.Select();
                    textBoxCommands.ScrollToCaret();
                    c.SelectedIndex = 0;
                }
            }
        }

        private void comboBoxCommands_DropDown(object sender, EventArgs e)
        {
            var c = sender as ComboBox;
            if (c != null && c.Items.Count > 0)
                c.Items.RemoveAt(0);
        }

        private void comboBoxCommands_DropDownClosed(object sender, EventArgs e)
        {
            ClearCombobox(sender as ComboBox);
        }

        private void FormSettings_Shown(object sender, EventArgs e)
        {
            UpdateTab(tabControlPreferences.SelectedTab);
        }

        private void tabControlPreferences_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTab(tabControlPreferences.SelectedTab);
        }
    }
}
