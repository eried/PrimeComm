using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using PrimeLib;

static internal class Refactoring
{
    private const string EncodePrefix = "____[";
    private const string EncodePostfix = "]____";

    public static string ApplyCodeRefactoring(string programCode, PrimeParameters programParameters)
    {
        var regexStrings = new Regex(programParameters.GetValue("RegexStrings"));
        var regexComments = new Regex(programParameters.GetValue("RegexComments"));
        var operators = programParameters.GetValue("RegexOperators");
        var regexOperators = new Regex(operators);

        // Encode strings and comments
        programCode = regexStrings.Replace(programCode, (MatchEvaluator) EncodeElement);
        programCode = regexComments.Replace(programCode,
            programParameters.GetFlag("RemoveComments") ? (m => String.Empty) : (MatchEvaluator) EncodeElement);

        if (programParameters.GetFlag("CompressSpaces"))
        {
            var o = new StringBuilder();
            var extractedOperators = Regex.Unescape(operators.Replace(@"\s", "")
                .Substring(0, operators.Length - (operators.EndsWith("])") ? 3 : 1))
                .Substring(operators.StartsWith("([") ? 2 : 0));
            foreach (var l in programCode.Replace(Environment.NewLine, "\n")
                .Replace("\r", String.Empty)
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
                    o.Append('\n');
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
                    var v1 = v.Split(new[] {'='}, 2)[0].Trim();

                    if (v1.Length <= 2) continue;

                    if (!variables.Contains(v1))
                        variables.Add(v1);
                }
            }

            if (variables.Count > 0)
            {
                // Replacement variables
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
                var regexEncodedPlain =
                    new Regex("(" + Regex.Escape(EncodePrefix) + programParameters.GetValue("RegexBase64") +
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
        programCode = regexEncoded.Replace(programCode, (MatchEvaluator) DecodeElement);
        return programCode;
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
        return Encoding.Unicode.GetString(Convert.FromBase64String(match.Groups["data"].Value));
    }

    private static string EncodeElement(Match match)
    {
        return EncodePrefix + Convert.ToBase64String(Encoding.Unicode.GetBytes(match.Value)) + EncodePostfix;
    }
}