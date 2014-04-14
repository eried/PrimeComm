using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ScintillaNet;

namespace ScintillaNet.Configuration.Legacy
{
    public class ScintillaPropertiesHelper
    {
        private static IScintillaConfig config;

        private ScintillaPropertiesHelper() { }

        public static void Populate(IScintillaConfig scintillaConfig, FileInfo file)
        {
            config = scintillaConfig;
            if (config != null)
            {
                PropertiesReader.Read(new ConfigResource(file), PropertyRead);
            }
        }

        public static void Populate(IScintillaConfig scintillaConfig, ConfigResource resource)
        {
            config = scintillaConfig;
            if (config != null)
            {
                PropertiesReader.Read(resource, PropertyRead);
            }
        }

        private static bool PropertyRead(ConfigResource resource, PropertyType propertyType, Queue<string> keyQueue, string key, string val)
        {
            bool success = false;
            if (config != null)
            {
                switch (propertyType)
                {
                    case PropertyType.Property:
                        success = true;
                        ApplyProperty(keyQueue, key, val);
                        break;
                    case PropertyType.If:
                        if (config.Properties.ContainsKey(val))
                        {
                            success = !Convert.ToBoolean(config.Properties[val]);
                        }
                        break;
                    case PropertyType.Import:
                        ConfigResource res = resource.GetLocalConfigResource(string.Format(@"{0}.properties", val));
                        success = res.Exists;
                        break;
                }
            }

            return success;
        }

        private static void ApplyProperty(Queue<string> keyQueue, string key, string val)
        {
            string tokenKey = keyQueue.Dequeue();
            switch (tokenKey)
            {
                case "lang":
                    ApplyLanguageProperty(keyQueue, val);
                    break;
                case "global":
                    ApplyGlobalProperty(keyQueue, val);
                    break;
                case "lex":
                    ApplyLexerProperty(keyQueue, val);
                    break;
                case "var":
                    config.Properties[key.Substring(4)] = Evaluate(val);
                    break;
                default:
                    ApplyGeneralProperty(key, val);
                    break;
            }
        }

        private static void ApplyGeneralProperty(string key, string var)
        {
            string val = Evaluate(var);
            switch (key)
            {
                case "menu-language":
                    string[] menuItems = val.Split('|');
                    for (int i = 2; i < menuItems.Length; i += 3)
                    {
                        MenuItemConfig menuItem = new MenuItemConfig();
                        menuItem.Text = menuItems[i - 2];
                        menuItem.Value = menuItems[i - 1];
                        menuItem.ShortcutKeys = GetKeys(menuItems[i]);

                        config.LanguageMenuItems.Add(menuItem);
                    }
                    break;
                case "language-names":
                    config.LanguageNames.AddRange(val.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                    break;
                case "extension-languages":
                    PropertiesReader.GetKeyValuePairs(val, config.ExtensionLanguages);
                    break;
                case "open-filter":
                    config.FileOpenFilter = val;
                    break;
                case "default-file-ext":
                    config.DefaultFileExtention = val;
                    break;
                default:
                    config.Properties[key] = Evaluate(val);
                    break;
            }
        }

        #region Apply Lexer Properties
        private static void ApplyLexerProperty(Queue<string> keyQueue, string val)
        {
            if (keyQueue.Count > 1)
            {
                string lexerName = keyQueue.Dequeue();
                string key = keyQueue.Dequeue();

                ILexerConfig lexerConf = config.Lexers[lexerName];
                switch (key)
                {
                    case "style":
                        ApplyStyle(lexerConf.Type, lexerConf.Styles, keyQueue, val);
                        break;
                    default:
                        config.Lexers[lexerName].Properties[key] = Evaluate(val);
                        break;
                }
            }
        }
        #endregion

        #region Apply Language Properties
        private static void ApplyGlobalProperty(Queue<string> keyQueue, string val)
        {
            if (keyQueue.Count >= 1)
            {
                ApplyLanguageProperty(config.LanguageDefaults, keyQueue, val);
            }
        }

        private static void ApplyLanguageProperty(Queue<string> keyQueue, string val)
        {
            if (keyQueue.Count > 1)
            {
                string langName = keyQueue.Dequeue();
                ILanguageConfig langConf = config.Languages[langName];

                ApplyLanguageProperty(langConf, keyQueue, val);
            }
        }

        private static void ApplyLanguageProperty(ILanguageConfig langConf, Queue<string> keyQueue, string val)
        {
            if (keyQueue.Count > 0)
            {
                string key = keyQueue.Dequeue();

                switch (key)
                {
                    case "style":
                        ApplyStyle(langConf.Lexer.Type, langConf.Styles, keyQueue, val);
                        break;
                    case "keywords":
                        ApplyKeywords(langConf, keyQueue, val);
                        break;
                    case "lexer":
                        langConf.Lexer = config.Lexers[Evaluate(val)];
                        break;
                    case "word-characters":
                        langConf.WordCharacters = Evaluate(val);
                        break;
                    case "whitespace-characters":
                        langConf.WhitespaceCharacters = Evaluate(val);
                        break;
                    case "code-page":
                        langConf.CodePage = GetInt(val);
                        break;
                    case "selection-alpha":
                        langConf.SelectionAlpha = GetInt(val);
                        break;
                    case "selection-back":
                        langConf.SelectionBackColor = GetColor(val, Color.Empty);
                        break;
                    case "tabsize":
                        langConf.TabSize = GetInt(val);
                        break;
                    case "indent-size":
                        langConf.IndentSize = GetInt(val);
                        break;
                    case "fold":
                        langConf.Fold = GetBool(val);
                        break;
                    case "fold-compact":
                        langConf.FoldCompact = GetBool(val);
                        break;
                    case "fold-symbols":
                        langConf.FoldSymbols = GetBool(val);
                        break;
                    case "fold-comment":
                        langConf.FoldComment = GetBool(val);
                        break;
                    case "fold-on-open":
                        langConf.FoldOnOpen = GetBool(val);
                        break;
                    case "fold-preprocessor":
                        langConf.FoldPreprocessor = GetBool(val);
                        break;
                    case "fold-html":
                        langConf.HtmlFold = GetBool(val);
                        break;
                    case "fold-html-preprocessor":
                        langConf.HtmlFoldPreprocessor = GetBool(val);
                        break;
                    case "fold-flags":
                        langConf.FoldFlags = GetInt(val);
                        break;
                    case "fold-margin-width":
                        langConf.FoldMarginWidth = GetInt(val);
                        break;
                    case "fold-margin-color":
                        langConf.FoldMarginColor = GetColor(val, Color.Empty);
                        break;
                    case "fold-margin-highlight-color":
                        langConf.FoldMarginHighlightColor = GetColor(val, Color.Empty);
                        break;
                    default:
                        config.Properties[key] = Evaluate(val);
                        break;
                }
            }
        }

        private static void ApplyKeywords(ILanguageConfig langConf, Queue<string> keyQueue, string var)
        {
            int styleIndex;
            if (keyQueue.Count == 1)
            {
                string strIndex = keyQueue.Dequeue();
                if (!int.TryParse(strIndex, out styleIndex))
                {
                    styleIndex = 0;
                }
            }
            else
            {
                styleIndex = 0;
            }

            langConf.KeywordLists[styleIndex] = Evaluate(var);
        }

        private static void ApplyStyle(Lexer lexerType, SortedDictionary<int, ILexerStyle> styles, Queue<string> keyQueue, string var)
        {
            int styleIndex;
            if (keyQueue.Count == 1)
            {
                string strIndex = keyQueue.Dequeue();
                if (!int.TryParse(strIndex, out styleIndex))
                {
                    if (lexerType != Lexer.Null)
                    {
                        object lexStyle = lexerType;
                        styleIndex = (int)lexStyle;
                    }
                    else
                    {
                        styleIndex = 0;
                    }
                }
            }
            else
            {
                styleIndex = 0;
            }

            ILexerStyle style = new LexerStyle(styleIndex);
            string styleData = Evaluate(var);
            Dictionary<string, string> dict = PropertiesReader.GetKeyValuePairs(styleData);
            foreach (string styleKey in dict.Keys)
            {
                styleData = dict[styleKey];
                switch (styleKey)
                {
                    case "font":
                        style.FontName = styleData;
                        break;
                    case "size":
                        style.FontSize = Convert.ToInt32(styleData);
                        break;
                    case "fore":
                        style.ForeColor = ColorTranslator.FromHtml(styleData);
                        break;
                    case "back":
                        style.BackColor = ColorTranslator.FromHtml(styleData);
                        break;
                    case "italics":
                        style.Italics = true;
                        break;
                    case "notitalics":
                        style.Italics = false;
                        break;
                    case "bold":
                        style.Bold = true;
                        break;
                    case "notbold":
                        style.Bold = false;
                        break;
                    case "eolfilled":
                        style.EOLFilled = true;
                        break;
                    case "noteolfilled":
                        style.EOLFilled = false;
                        break;
                    case "underlined":
                        style.Underline = true;
                        break;
                    case "notunderlined":
                        style.Underline = false;
                        break;
                    case "case":
                        style.CaseVisibility = ((styleData == "m") ? StyleCase.Mixed : ((styleData == "u") ? StyleCase.Upper : StyleCase.Lower));
                        break;
                }
            }
            styles[styleIndex] = style;
        }
        #endregion

        #region Evaluating valiables helper methods
        private static string Evaluate(string data)
        {
            return PropertiesReader.Evaluate(data, GetByKey, ContainsKey);
        }

        private static bool ContainsKey(string key)
        {
            return config.Properties.ContainsKey(key);
        }

        private static string GetByKey(string key)
        {
            return config.Properties[key];
        }
        #endregion

        #region Helper Methods for pulling data out of the scite config files
        private static System.Windows.Forms.Keys GetKeys(string data)
        {
            System.Windows.Forms.Keys shortcutKeys = System.Windows.Forms.Keys.None;
            if (!string.IsNullOrEmpty(data))
            {
                string[] keys = data.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string key in keys)
                {
                    shortcutKeys = shortcutKeys | (System.Windows.Forms.Keys)Enum.Parse(
                        typeof(System.Windows.Forms.Keys),
                        (key.Equals("Ctrl", StringComparison.CurrentCultureIgnoreCase) ? "Control" : key),
                        true);
                }
            }
            return shortcutKeys;
        }

        private static Color GetColor(string data, Color colorIfNull)
        {
            Color val = colorIfNull;
            string sval = data;
            if (sval != null) val = ColorTranslator.FromHtml(sval);
            return val;
        }

        private static int? GetInt(string data)
        {
            int? val = null;
            string sval = data;
            if (sval != null) val = Convert.ToInt32(sval);
            return val;
        }

        private static bool? GetBool(string data)
        {
            bool? val = null;
            string sval = data;
            if (sval != null)
            {
                sval = sval.ToLower();
                switch (sval)
                {
                    case "1":
                    case "y":
                    case "t":
                    case "yes":
                    case "true":
                        val = true;
                        break;
                    default:
                        val = false;
                        break;

                }
            }
            return val;
        }
        #endregion
    }
}
