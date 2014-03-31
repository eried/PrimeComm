using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PrimeLib;
using PrimeRPL.Properties;

namespace PrimeRPL
{
    public partial class FormMain : Form
    {
        private PrimeLanguageConverter _converter;

        public FormMain()
        {
            InitializeComponent();

            // Initialize the converter
            _converter = new PrimeLanguageConverter
            {
                Header =
                    "// File created by " + Application.ProductName + Environment.NewLine +
                    "// Part of PrimeComm: http://servicios.ried.cl/primecomm/" + Environment.NewLine 
            };
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var f = new OpenFileDialog {Filter = "txt file|.txt"};

            if (f.ShowDialog() == DialogResult.OK)
                File.WriteAllText(f.FileName, editor.Text);
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            var f = new OpenFileDialog {Filter = "hpprgm file|.hpprgm"};

            if (f.ShowDialog() == DialogResult.OK)
                new PrimeUsbData(null, Encoding.Unicode.GetBytes(_converter.Convert(editor.Text))).Save(f.FileName);
        }

        private void buttonPreview_Click(object sender, EventArgs e)
        {
            GeneratePreview();
        }

        private void GeneratePreview()
        {
            textBoxPreview.Text = _converter.Convert(editor.Text);
            textBoxPreview.SelectionLength = 0;
            textBoxPreview.SelectionStart = textBoxPreview.TextLength - 1;
            textBoxPreview.ScrollToCaret();
        }

        private void buttonPreviewAndCopy_Click(object sender, EventArgs e)
        {
            GeneratePreview();
            Clipboard.SetText(textBoxPreview.Text);
        }
    }

    public class PrimeLanguageConverter
    {
        private readonly Regex regexStrings, regexComments;
        private const string EncodePrefix = "____[", EncodePostfix = "]____";

        public PrimeLanguageConverter()
        {
            regexStrings = new Regex(@"""[^""""\\]*(?:\\.[^""""\\]*)*""");
            regexComments = new Regex(@"^\s*.*@.*", RegexOptions.Multiline);
        }

        /// <summary>
        /// This converts RPL code into a code compatible with the Prime calculator language (HPPPL)
        /// </summary>
        /// <param name="programCode">RPL code source</param>
        /// <returns>HPPPL code</returns>
        public string Convert(string programCode)
        {
            var r = new StringBuilder(Header);

            // Remove comments and encode strings
            programCode = regexStrings.Replace(regexComments.Replace(programCode, String.Empty), EncodeElement);

            // Remove empty lines and spaces
            programCode = programCode.Replace("\r\n", "\n").Replace("\n\r", "\n").Replace("\r", "\n").Replace("\n", " ").Replace("  ", " ").Replace("  ", " ");
            
            // Add default program code
            var token = "sz";
            
            // Process code
            var sentences = new List<String>();
            foreach (var b in programCode.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries))
            {
                switch (b.ToUpper())
                {
                    case "+":
                    case "-":
                    case "/":
                    case "*":
                    case "^":
                    case "%":
                    case "MOD":
                        sentences.Add(token + "evaluateAsOperator(\"" + b + "\");"); // Operators
                        break;

                    case "ASC":
                    case "CHAR":
                    case "DIM":
                    case "TYPE":
                        sentences.Add(token + "evaluateAsFunction(\"" + b + "\",1,false);"); // Functions with 1 param
                        break;

                    case "MSGBOX":
                    case "PRINT":
                        sentences.Add(token + "evaluateAsFunction(\"" + b + "\",1,true);"); // Functions with 1 param, void
                        break;

                    case "INSTRING":
                    case "LEFT":
                    case "RIGHT":
                    case "CONCAT":
                        sentences.Add(token + "evaluateAsFunction(\"" + b + "\",2,false);"); // Functions with 2 param
                        break;

                    case "REPLACE":
                        sentences.Add(token + "evaluateAsFunction(\"" + b + "\",3,false);"); // Functions with 3 param
                        break;

                    case "->STR":
                        sentences.Add(token + "evaluateAsFunction(\"STRING\",1,false);"); // Functions with 1 param
                        break;

                    case "SWAP":
                        sentences.Add(token + "swap();"); // Functions with 1 param
                        break;

                    case "DUP":
                        sentences.Add(token + "dup();"); // Functions with 1 param
                        break;

                    case "DROP":
                        sentences.Add(token + "pop();"); // Functions with 1 param
                        break;

                    default:
                    {
                        bool shouldPush;
                        string toPush = b;

                        // Check for strings
                        if (b.StartsWith(EncodePrefix) && b.EndsWith(EncodePostfix))
                        {
                            toPush = DecodeString(b.Substring(EncodePrefix.Length, b.Length - EncodePrefix.Length - EncodePostfix.Length));
                            shouldPush = true;
                        }
                        else
                        {
                            double t;
                            shouldPush = double.TryParse(b, out t);
                        }

                        if(shouldPush)
                            sentences.Add(token + "push(" + toPush + ");");
                    }
                        break;
                }
            }

            r.AppendLine(Resources.DefaultProgram.Replace("{token}", token).Replace("{code}",String.Join(" ",sentences)));

            r.AppendLine(Footer);
            return r.ToString();
        }


        private static string DecodeElement(Match match)
        {
            try
            {
                return DecodeString(match.Groups["data"].Value);
            }
            catch
            {
            }
            return null;
        }

        private static string DecodeString(string value)
        {
            return Encoding.Unicode.GetString(System.Convert.FromBase64String(value));
        }

        private static string EncodeElement(Match match)
        {
            return EncodePrefix + System.Convert.ToBase64String(Encoding.Unicode.GetBytes(match.Value)) + EncodePostfix;
        }

        public string Header { get; set; }

        public string Footer { get; set; }
    }
}
