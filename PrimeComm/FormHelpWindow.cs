using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using PrimeComm.Properties;
using WeifenLuo.WinFormsUI.Docking;

namespace PrimeComm
{
    public partial class FormHelpWindow : DockContent
    {
        private readonly string _commands;
        private readonly List<ReferenceDefinition> _reference;

        public FormHelpWindow(string commands = null, FontFamily fontFamily = null)
        {
            _commands = commands;

            InitializeComponent();

            if (fontFamily != null)
                textBoxHelp.Font = new Font(fontFamily, (int)Settings.Default.EditorFontSize);

            _reference = new List<ReferenceDefinition>();
        }

        private void backgroundWorkerHelp_DoWork(object sender, DoWorkEventArgs e)
        {
            using (var r = new CsvFileReader(new MemoryStream(Encoding.UTF8.GetBytes(e.Argument as string ?? "")),
                EmptyLineBehavior.EndOfFile))
            {
                r.Delimiter = ';';

                var t = new List<String>();
                while (r.ReadRow(t))
                {
                    if (t.Count > 1)
                    {
                        if (String.IsNullOrEmpty(t[0]))
                            break;
                        _reference.Add(new ReferenceDefinition { Command = t[0], Description = t[1] });
                    }
                    else
                        break;
                }
            }
        }

        private void backgroundWorkerHelp_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (var r in _reference)
                comboBoxCommand.Items.Add(r);

            comboBoxCommand.Enabled = comboBoxCommand.Items.Count > 0;
            comboBoxCommand.Select();

            buttonSearch.Enabled = comboBoxCommand.Enabled;
        }

        private void comboBoxCommand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCommand.SelectedItem != null)
            {
                textBoxHelp.Text = ((ReferenceDefinition) comboBoxCommand.SelectedItem).Description;
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SearchReference(comboBoxCommand.Text);
        }

        public void SearchReference(string searchString, bool tryPartial = true, bool partialMatch = false)
        {
            if (String.IsNullOrEmpty(searchString))
                return;

            var found = false;
            foreach (var r in _reference)
                if (partialMatch ? r.Command.StartsWith(searchString, StringComparison.OrdinalIgnoreCase): 
                    r.Command.Equals(searchString, StringComparison.OrdinalIgnoreCase))
                {
                    comboBoxCommand.SelectedItem = r;
                    found = true;
                    break;
                }

            if (!found && tryPartial && !partialMatch)
                SearchReference(searchString, false, true);
        }

        private void comboBoxCommand_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchReference(comboBoxCommand.Text);
                comboBoxCommand.SelectAll();
            }
        }

        private void FormHelpWindow_Shown(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(_commands))
                backgroundWorkerHelp.RunWorkerAsync(_commands);
        }
    }

    internal struct ReferenceDefinition
    {
        public string Command, Description;

        public override string ToString()
        {
            return Command;
        }
    }
}
