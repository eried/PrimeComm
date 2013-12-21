using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PrimeComm.Properties;
using PrimeLib;

namespace PrimeComm
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveAndExit();
        }

        private void SaveAndExit()
        {
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
                SaveAndExit();
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

            // Image options
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
            // Load settings
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
        }
    }
}
