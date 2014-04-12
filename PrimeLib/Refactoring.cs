using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PrimeLib
{
    /// <summary>
    /// Tools to modify and format the Program code
    /// </summary>
    public static class Refactoring
    {
        private static CodeBlock[] _codeBlocks;

        private const string EncodePrefix = "____[", EncodePostfix = "]____";

        /*public static string ApplyCodeRefactoring(string programCode, params RefactorFlag[] flags)
        {
            IEnumerable<KeyValuePair<string, object>> p;

            foreach (var f in flags)
            {
                switch (f)
                {
                    case RefactorFlag.RemoveComments:
                        break;
                }
            }

            return ApplyCodeRefactoring(programCode, new PrimeParameters(p));
        }*/

        public static string ApplyCodeRefactoring(string programCode, PrimeParameters programParameters)
        {
            var regexStrings = new Regex(programParameters.GetValue("RegexStrings"));
            var regexComments = new Regex(programParameters.GetValue("RegexComments"));
            var operators = programParameters.GetValue("RegexOperators");
            var regexOperators = new Regex(operators);

            // Encode strings and comments
            programCode = regexStrings.Replace(programCode, EncodeElement);
            programCode = regexComments.Replace(programCode,
                programParameters.GetFlag("RemoveComments") ? (m => String.Empty) : (MatchEvaluator) EncodeElement);

            if (programParameters.GetFlag("CompressSpaces"))
            {
                var o = new StringBuilder();
                var removeLineBreaks = programParameters.GetFlag("CompressSpacesMore");
                var extractedOperators = Regex.Unescape(operators.Replace(@"\s", "")
                    .Substring(0, operators.Length - (operators.EndsWith("])") ? 3 : 1))
                    .Substring(operators.StartsWith("([") ? 2 : 0));
                foreach (var l in programCode.Replace(Environment.NewLine, removeLineBreaks?" ":"\n")
                    .Replace("\r", String.Empty)
                    .Replace("   ", " ")
                    .Replace("   ", " ")
                    .Replace("  ", " ")
                    .Replace("  ", " ")
                    .Replace("  ", " ")
                    .Split(new[] {'\n'}, StringSplitOptions.RemoveEmptyEntries))
                {
                    var line = l.Trim(new[] {' ', '\t'});

                    // Spaces near operators
                    foreach (var c in extractedOperators)
                    {
                        var nline = line;
                        do
                        {
                            line = nline;
                            nline = line.Replace(" " + c, String.Empty + c).Replace(c + " ", String.Empty + c);
                        } while (line.CompareTo(nline) != 0);
                    }

                    o.Append(line);

                    if (!String.IsNullOrEmpty(line) && !line.EndsWith(";"))
                        o.Append(removeLineBreaks?' ':'\n');
                }
                programCode = o.ToString();
                //tmp = regexOperators.Replace(tmp, m => m.Value.Trim());
            }

            if (programParameters.GetFlag("ObfuscateVariables"))
            {
                // List variables
                var variables = new List<String>();
                foreach (Match l in Regex.Matches(programCode, programParameters.GetValue("RegexLocalVariables"), RegexOptions.IgnoreCase))
                {
                    foreach (var v in l.Groups["vars"].Value.Split(new[] {','}))
                    {
                        var v1 = v.Replace(" ", String.Empty).Replace(":=", "=").Split(new[] { '=' }, 2)[0].Trim();

                        if (v1.Length <= 2 || v1.Contains("#")) continue;

                        if (!variables.Contains(v1))
                            variables.Add(v1);
                    }
                }

                if (variables.Count > 0)
                {
                    // Replacement variables
                    variables.Sort((x, y) => y.Length.CompareTo(x.Length));
                    var replacements = new Dictionary<String, String>();
                    var v1 = programParameters.GetValue("VariableRefactoringStartingSeed");

                    foreach (var v in variables)
                    {
                        var replacement = new StringBuilder(v1);
                        while (variables.Contains(replacement.ToString()) || replacements.ContainsValue(replacement.ToString()))
                        {
                            // Advance last number
                            Next(ref replacement);
                        }
                        replacements.Add(v, replacement.ToString());
                    }

                    // Do the replacement
                    var final = new StringBuilder();
                    var regexEncodedPlain = new Regex("(" + Regex.Escape(EncodePrefix) + programParameters.GetValue("RegexBase64") +
                                                      Regex.Escape(EncodePostfix) + ")");

                    foreach (var l in regexEncodedPlain.Split(programCode))
                        if (l.StartsWith(EncodePrefix) && l.EndsWith(EncodePostfix))
                            final.Append(l);
                        else
                            foreach (var r in regexOperators.Split(l))
                            {
                                var append = true;
                                if (r.Length > 0)
                                    foreach (var replace in replacements)
                                        if (r == replace.Key)
                                        {
                                            final.Append(replace.Value);
                                            append = false;
                                            break;
                                        }

                                if (append)
                                    final.Append(r);
                            }

                    programCode = final.ToString();
                }
            }

            // Restore string and comments again
            var regexEncoded =
                new Regex(Regex.Escape(EncodePrefix) + "(?<data>" + programParameters.GetValue("RegexBase64") + ")" +
                          Regex.Escape(EncodePostfix));

            return regexEncoded.Replace(programCode, DecodeElement);
        }

        private static void Next(ref StringBuilder replacement)
        {
            if (replacement[replacement.Length - 1] < '9')
                replacement[replacement.Length - 1]++;
            else
            {
                for (var i = replacement.Length - 2; i >= 0; i--)
                {
                    if (replacement[i] < 'z')
                    {
                        replacement[i]++;
                        return;
                    }
                    if (replacement[i] == 'z')
                    {
                        replacement[i] = 'A';
                        return;
                    }
                    if (replacement[i] < 'Z')
                    {
                        replacement[i]++;
                        return;
                    }

                    if (i != 0) continue;

                    // No more options, add a letter and continue
                    replacement[replacement.Length - 1] = 'a';
                    replacement.Append('0');
                    Next(ref replacement);
                }
            }
        }

        private static string DecodeElement(Match match)
        {
            try
            {
                return Encoding.Unicode.GetString(Convert.FromBase64String(match.Groups["data"].Value));
            }
            catch
            {
            }
            return null;
        }

        private static string EncodeElement(Match match)
        {
            return EncodePrefix + Convert.ToBase64String(Encoding.Unicode.GetBytes(match.Value)) + EncodePostfix;
        }

        /// <summary>
        /// Formats the code indentation
        /// </summary>
        /// <param name="lines">Code lines to be changed</param>
        /// <param name="indentation">Indentation to add</param>
        /// <returns>Null if everything was closed, or the last opened block that prevented the code indentation</returns>
        public static CodeBlock FormatLines(ref List<string> lines, String indentation)
        {
            // Find code blocks
            if (_codeBlocks == null)
                _codeBlocks = new[]
                {
                    new CodeBlock("BEGIN"), new CodeBlock("CASE"), new CodeBlock("IFERR"), new CodeBlock("IF"),
                    new CodeBlock("FOR"), new CodeBlock("WHILE"), new CodeBlock("REPEAT", "UNTIL")
                };

            var opened = new Stack<CodeBlock>();
            var openedBlocks = 0;

            for (var l = 0; l < lines.Count; l++)
            {
                var line = lines[l].Trim(new[] {'\t', ' ', '\n', '\r'});

                var lineStart = 0;
                int tmpLine;
                bool repeat;

                do
                {
                    repeat = false;

                    if (line.Length == 0)
                        break;

                    foreach (var block in _codeBlocks)
                    {
                        tmpLine = block.MatchesOpen(line.Substring(Math.Min(line.Length - 1, lineStart)));

                        if (tmpLine > 0)
                        {
                            lineStart = tmpLine;
                            block.Line = l;
                            opened.Push(block);
                            repeat = true;
                        }
                    }
                } while (repeat);

                do
                {
                    repeat = false;

                    if (line.Length == 0)
                        break;

                    if (opened.Count > 0)
                    {
                        tmpLine = opened.Peek().MatchesClose(line.Substring(Math.Min(line.Length - 1, lineStart)));

                        if (tmpLine > 0)
                        {
                            lineStart = tmpLine;
                            opened.Pop();
                            openedBlocks = opened.Count;
                            repeat = true;
                        }
                    }
                } while (repeat);

                var tmp = "";
                for (var i = 0; i < openedBlocks; i++)
                    tmp += indentation;

                openedBlocks = opened.Count;
                lines[l] = tmp + line;
            }

            return opened.Count > 0 ? opened.Pop() : null;
        }
    }

    public class CodeBlock
    {
        private readonly Regex _blockOpen, _blockClose;
        private static Regex _regexComments;

        public CodeBlock(string blockOpen, string blockClose = @"\sEND[\s;]")
        {
            const string s = @"\s"; // Space or line ending
            const string o = @"[\(\s]"; // Space, line ending or open parenthesis
            _blockOpen = new Regex(blockOpen.Contains('\\') ? blockOpen : (s + blockOpen + o), RegexOptions.IgnoreCase);
            _blockClose = new Regex(blockClose.Contains('\\') ? blockClose : (s + blockClose + o), RegexOptions.IgnoreCase);
        }

        public int Line { get; set; }

        internal int MatchesOpen(string p)
        {
            return Match(p, _blockOpen);
        }

        internal int MatchesClose(string p)
        {
            return Match(p, _blockClose);
        }

        private static int Match(string p, Regex regexMatch)
        {
            if(_regexComments == null)
                _regexComments = new Regex(@"""[^""""\\]*(?:\\.[^""""\\]*)*""");

            // Remove comments and strings
            var m = regexMatch.Match(" " + (_regexComments.Replace(p, match => new String(' ', 
                match.Length)) + "//").Split(new[] { "//" }, 2, StringSplitOptions.None)[0] + " ");

            if (!m.Success)
                return 0;

            return m.Index + m.Value.Length - 1;
        }
    }
}