using PrimeHelp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace PrimeHelp
{
    public partial class FormMain : Form
    {
        private readonly List<ReferenceDefinition> _help;

        public FormMain()
        {
            Environment.CurrentDirectory = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            InitializeComponent();

            _help = new List<ReferenceDefinition>();

            if(File.Exists(Resources.ReferenceFile))
                backgroundWorkerLoad.RunWorkerAsync(File.ReadAllText(Resources.ReferenceFile, Encoding.Default));
        }

        private void backgroundWorkerLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            using (var r = new CsvFileReader(new MemoryStream(Encoding.UTF8.GetBytes(e.Argument as string ?? "")),
                EmptyLineBehavior.EndOfFile))
            {
                r.Delimiter = ';';

                var t = new List<String>();
                while (r.ReadRow(t))
                    if (t.Count > 1)
                    {
                        if (String.IsNullOrEmpty(t[0]))
                            break;
                        _help.Add(new ReferenceDefinition { Command = t[0], Description = t[1] });
                    }
                    else
                        break;
            }
        }

        private void backgroundWorkerLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ResetHelpList();
        }

        private void ResetHelpList()
        {
            listBoxTerms.SuspendDrawing();
            listBoxTerms.Items.Clear();

            foreach (var r in _help)
            {
                r.Bold = false;
                r.Italic = false;
                listBoxTerms.Items.Add(r);
            }

            listBoxTerms.ResumeDrawing();
        }

        private void listBoxTerms_SelectedValueChanged(object sender, EventArgs e)
        {
            var r = listBoxTerms.SelectedItem as ReferenceDefinition;

            if (r != null)
                textBoxView.Text = r.Description;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            timerSearch.Stop();
            timerSearch.Start();
        }

        private void timerSearch_Tick(object sender, EventArgs e)
        {
            if (backgroundWorkerSearch.IsBusy)
            {
                if(!backgroundWorkerSearch.CancellationPending)
                    backgroundWorkerSearch.CancelAsync();
            }
            else
            {
                backgroundWorkerSearch.RunWorkerAsync(textBoxSearch.Text);
                timerSearch.Stop();
            }
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            var searchString = e.Argument as String;
            var results = new Dictionary<String, ReferenceDefinition>();

            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.Trim().ToLower();

                // Start with
                foreach (var r in _help.Where(r => r.Command.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)).Where(r => !results.ContainsKey(r.Command)))
                {
                    r.Bold = true;
                    r.Italic = false;
                    results.Add(r.Command, r);
                }

                // Contains
                foreach (var r in _help.Where(r => r.Command.ToLower().Contains(searchString)).Where(r => !results.ContainsKey(r.Command)))
                {
                    r.Bold = false;
                    r.Italic = false;
                    results.Add(r.Command, r);
                }

                // Content
                if(searchString.Length > 1)
                    foreach (var r in _help.Where(r => r.Description.ToLower().Contains(searchString)).Where(r => !results.ContainsKey(r.Command)))
                    {
                        r.Bold = false;
                        r.Italic = true;
                        results.Add(r.Command, r);
                    }
            }

            e.Result = results;
        }

        private void ShowHelpResults(Dictionary<String, ReferenceDefinition> results)
        {
            if (results == null) return;

            listBoxTerms.SuspendDrawing();

            listBoxTerms.Items.Clear();
            foreach (var r in results)
                listBoxTerms.Items.Add(r.Value);

            listBoxTerms.ResumeDrawing();
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var r = e.Result as Dictionary<String, ReferenceDefinition>;

            if (r.Count == 0 && textBoxSearch.Text.Trim().Length == 0)
                ResetHelpList();
            else
                ShowHelpResults(r);
        }

        private void listBoxTerms_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index >= 0)
            {
                var s = (ReferenceDefinition) listBoxTerms.Items[e.Index];

                var style = FontStyle.Regular;
                if (s.Bold) style |= FontStyle.Bold;
                if (s.Italic) style |= FontStyle.Italic;

                e.Graphics.DrawString(s.Command, new Font(Font.FontFamily, Font.Size, style), Brushes.Black,
                    e.Bounds);
            }

            if(listBoxTerms.Items.Count > 0)
                e.DrawFocusRectangle();
        }

        private void textBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue) // Up and down arrows, plus enter
            {
                case 40: 
                case 38:
                case 13:
                    if (listBoxTerms.Items.Count > 0)
                    {
                        listBoxTerms.Select();

                        if(listBoxTerms.SelectedIndex==-1)
                            listBoxTerms.SelectedIndex = 0;
                    }
                    break;
            }
        }

        private void control_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13) return;

            textBoxSearch.SelectAll();
            textBoxSearch.Select();
        }
    }

    /// <summary>
    /// http://stackoverflow.com/questions/487661/how-do-i-suspend-painting-for-a-control-and-its-children
    /// </summary>
    static class DrawingControl
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        private const int WM_SETREDRAW = 11;

        public static void SuspendDrawing(this Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
        }

        public static void ResumeDrawing(this Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
            parent.Refresh();
        }
    }

    internal class ReferenceDefinition
    {
        public string Command, Description;
        public bool Bold { get; set; }
        public bool Italic { get; set; }

        public override string ToString()
        {
            return Command;
        }
    }
}
