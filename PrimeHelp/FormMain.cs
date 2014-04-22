using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using PrimeHelp.Properties;

namespace PrimeHelp
{
    public partial class FormMain : Form
    {
        private readonly List<ReferenceDefinition> _reference;
        private bool _searchAgain;

        public FormMain()
        {
            Environment.CurrentDirectory = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            InitializeComponent();

            _reference = new List<ReferenceDefinition>();

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

        private void backgroundWorkerLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ResetCommandList();
        }

        private void ResetCommandList()
        {
            listBoxTerms.SuspendDrawing();
            listBoxTerms.Items.Clear();

            foreach (var r in _reference)
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
            _searchAgain = true;

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
                searchString = searchString.ToLower();
                //backgroundWorkerSearch.ReportProgress(0);

                // Start with
                foreach (var r in _reference)
                {
                    if (r.Command.StartsWith(searchString, StringComparison.OrdinalIgnoreCase))
                        if (!results.ContainsKey(r.Command))
                        {
                            r.Bold = true;
                            r.Italic = false;
                            results.Add(r.Command, r);
                        }
                }

                // Contains
                foreach (var r in _reference)
                {
                    if (r.Command.ToLower().Contains(searchString))
                        if (!results.ContainsKey(r.Command))
                        {
                            r.Bold = false;
                            r.Italic = false;
                            results.Add(r.Command, r);
                        }
                }

                // Content
                if(searchString.Length > 1)
                    foreach (var r in _reference)
                    {
                        if (r.Description.ToLower().Contains(searchString))
                            if (!results.ContainsKey(r.Command))
                            {
                                r.Bold = false;
                                r.Italic = true;
                                results.Add(r.Command, r);
                            }
                    }
            }

            e.Result = results;
        }

        private void AppendResults(Dictionary<String, ReferenceDefinition> results)
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

            if (r.Count == 0)
                ResetCommandList();
            else
            {
                AppendResults(r);
            }
        }

        private void listBoxTerms_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            var s = listBoxTerms.Items[e.Index] as ReferenceDefinition;

            if (s != null)
            {
                var style = FontStyle.Regular;

                if (s.Bold)
                    style |= FontStyle.Bold;

                if (s.Italic)
                    style |= FontStyle.Italic;

                e.Graphics.DrawString(s.ToString(), new Font(Font.FontFamily, Font.Size, style), Brushes.Black, e.Bounds);
            }
            e.DrawFocusRectangle();
        }

        private void textBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 40:
                case 38:
                case 13:
                    if (listBoxTerms.Items.Count > 0)
                    {
                        listBoxTerms.Select();
                        listBoxTerms.SelectedIndex = 0;
                    }
                    break;
            }
        }

        private void listBoxTerms_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                textBoxSearch.SelectAll();
                textBoxSearch.Select();
            }
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
