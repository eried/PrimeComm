using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ScintillaNet;

namespace ScintillaNet.Configuration.Legacy
{
    public class ScintillaConfig : IScintillaConfig
    {
        private IScintillaConfigProvider provider;
        private ILexerConfigCollection lexers;
        private ILanguageConfigCollection languages;
        private ILanguageConfig languageDefaults;
        private SortedDictionary<string, string> properties;
        private SortedDictionary<string, string> extensionLanguages;
        //private SortedDictionary<int, ILexerStyle> styles;
        private List<string> languageNames;
        private List<IMenuItemConfig> languageMenuItems;
        private string defaultFileExtention;
        private string fileOpenFilter;

        public ScintillaConfig()
        {
            this.provider = new ScintillaConfigProvider();
            provider.PopulateScintillaConfig(this);
        }

        public ScintillaConfig(IScintillaConfigProvider provider) 
        {
            if (provider == null)
                throw new Exception("IScintillaConfigProvider must be provided to the ScintillaConfig constructor!");

            this.provider = provider;
            provider.PopulateScintillaConfig(this);
        }

        public SortedDictionary<string, string> ExtensionLanguages
        {
            get
            {
                if (extensionLanguages == null)
                {
                    extensionLanguages = new SortedDictionary<string, string>();
                }
                return extensionLanguages;
            }
        }

        public SortedDictionary<string, string> Properties
        {
            get
            {
                if (properties == null)
                {
                    properties = new SortedDictionary<string, string>();
                }
                return properties;
            }
        }

        public ILanguageConfig LanguageDefaults
        {
            get
            {
                if (languageDefaults == null)
                {
                    languageDefaults = new LanguageConfig(this, "global");
                }
                return languageDefaults;
            }
        }

        public ILanguageConfigCollection Languages
        {
            get
            {
                if (languages == null)
                {
                    languages = new LanguageConfigCollection(this, provider, Lexers);
                }
                return languages;
            }
        }

        public List<string> LanguageNames
        {
            get
            {
                if (languageNames == null)
                {
                    languageNames = new List<string>();
                }
                return languageNames;
            }
        }

        public ILexerConfigCollection Lexers
        {
            get 
            {
                if (lexers == null)
                {
                    lexers = new LexerConfigCollection(this, provider);
                }
                return lexers; 
            }
        }

        public List<IMenuItemConfig> LanguageMenuItems
        {
            get
            {
                if (languageMenuItems == null)
                {
                    languageMenuItems = new List<IMenuItemConfig>();
                }
                return languageMenuItems;
            }
        }

        public string DefaultFileExtention
        {
            get { return defaultFileExtention; }
            set { defaultFileExtention = value; }
        }

        public string FileOpenFilter
        {
            get { return fileOpenFilter; }
            set { fileOpenFilter = value; }
        }

        #region Configure Scintilla
        public void Configure(ScintillaNet.Scintilla scintilla, string language)
        {
            scintilla.Styles.ClearAll();
            scintilla.Folding.IsEnabled = false;

            IScintillaConfig conf = this;
            ILanguageConfig lang = conf.Languages[language];
            if (lang != null)
            {
                lang = lang.CombinedLanguageConfig;

                //CauseError;
                //FIND THE MAP FOR THE NEXT 2 LINES
                if (lang.CodePage.HasValue) scintilla.NativeInterface.SetCodePage(lang.CodePage.Value);
                //if (lang.SelectionAlpha.HasValue) scintilla.Selection.ForeColor = lang.SelectionAlpha.Value;
                if (lang.SelectionBackColor != Color.Empty) scintilla.Selection.BackColor = lang.SelectionBackColor;
                if (lang.TabSize.HasValue) scintilla.Indentation.TabWidth = lang.TabSize.Value;
                if (lang.IndentSize.HasValue) scintilla.Indentation.IndentWidth = lang.IndentSize.Value;

                // Enable line numbers
                scintilla.Margins.Margin0.Width = 40;

                bool enableFolding = false;
                if (lang.Fold.HasValue) enableFolding = lang.Fold.Value;
                if (enableFolding)
                {
                    // Lexer specific properties
                    scintilla.PropertyBag.Add("fold", "1");

                    //CAUSE ERROR;
                    //this Is TO CAUSE AN ERROR TO REMIND ME TO CHECK ALL OF THESE ELEMENTS!!!;

                    if (lang.FoldAtElse.HasValue) 
                        scintilla.PropertyBag.Add("fold.at.else", (lang.FoldAtElse.Value ? "1" : "0"));
                    if (lang.FoldCompact.HasValue)
                        scintilla.PropertyBag.Add("fold.compact", (lang.FoldCompact.Value ? "1" : "0"));
                    if (lang.FoldComment.HasValue)
                        scintilla.PropertyBag.Add("fold.comment", (lang.FoldComment.Value ? "1" : "0"));
                    if (lang.FoldPreprocessor.HasValue)
                        scintilla.PropertyBag.Add("fold.preprocessor", (lang.FoldPreprocessor.Value ? "1" : "0"));
                    if (lang.StylingWithinPreprocessor.HasValue)
                        scintilla.PropertyBag.Add("styling.within.preprocessor", (lang.PythonFoldQuotes.Value ? "1" : "0"));

                    if (lang.HtmlFold.HasValue)
                        scintilla.PropertyBag.Add("fold.html", (lang.HtmlFold.Value ? "1" : "0"));
                    if (lang.HtmlFoldPreprocessor.HasValue)
                        scintilla.PropertyBag.Add("fold.html.preprocessor", (lang.HtmlFoldPreprocessor.Value ? "1" : "0"));
                    if (lang.HtmlTagsCaseSensitive.HasValue)
                        scintilla.PropertyBag.Add("html.tags.case.sensitive", (lang.HtmlTagsCaseSensitive.Value ? "1" : "0"));

                    if (lang.PythonFoldComment.HasValue) 
                        scintilla.PropertyBag.Add("fold.comment.python", (lang.PythonFoldComment.Value ? "1" : "0"));
                    if (lang.PythonFoldQuotes.HasValue)
                        scintilla.PropertyBag.Add("fold.quotes.python", (lang.PythonFoldQuotes.Value ? "1" : "0"));
                    if (lang.PythonWhingeLevel.HasValue) 
                        scintilla.PropertyBag.Add("tab.timmy.whinge.level", lang.PythonWhingeLevel.Value.ToString());

                    if (lang.SqlBackslashEscapes.HasValue)
                        scintilla.PropertyBag.Add("sql.backslash.escapes", (lang.SqlBackslashEscapes.Value ? "1" : "0"));
                    if (lang.SqlBackticksIdentifier.HasValue)
                        scintilla.PropertyBag.Add("lexer.sql.backticks.identifier", (lang.SqlBackticksIdentifier.Value ? "1" : "0"));
                    if (lang.SqlFoldOnlyBegin.HasValue) 
                        scintilla.PropertyBag.Add("fold.sql.only.begin", (lang.SqlFoldOnlyBegin.Value ? "1" : "0"));

                    if (lang.PerlFoldPod.HasValue) 
                        scintilla.PropertyBag.Add("fold.perl.pod", (lang.PerlFoldPod.Value ? "1" : "0"));
                    if (lang.PerlFoldPackage.HasValue)
                        scintilla.PropertyBag.Add("fold.perl.package", (lang.PerlFoldPackage.Value ? "1" : "0"));

                    if (lang.NsisIgnoreCase.HasValue) 
                        scintilla.PropertyBag.Add("nsis.ignorecase", (lang.NsisIgnoreCase.Value ? "1" : "0"));
                    if (lang.NsisUserVars.HasValue)
                        scintilla.PropertyBag.Add("nsis.uservars", (lang.NsisUserVars.Value ? "1" : "0"));
                    if (lang.NsisFoldUtilCommand.HasValue) 
                        scintilla.PropertyBag.Add("nsis.foldutilcmd", (lang.NsisFoldUtilCommand.Value ? "1" : "0"));
                    if (lang.CppAllowDollars.HasValue)
                        scintilla.PropertyBag.Add("lexer.cpp.allow.dollars", (lang.CppAllowDollars.Value ? "1" : "0"));

                    //for HTML lexer: "asp.default.language"
                    //enum script_type { eScriptNone = 0, eScriptJS, eScriptVBS, eScriptPython, eScriptPHP, eScriptXML, eScriptSGML, eScriptSGMLblock };

                    scintilla.Margins.Margin1.Width = 0;
                    scintilla.Margins.Margin1.Type = MarginType.Symbol;
                    scintilla.Margins.Margin1.Mask = unchecked((int)0xFE000000);
                    scintilla.Margins.Margin1.IsClickable = true;

                    if (lang.FoldMarginWidth.HasValue)
                        scintilla.Margins.Margin1.Width = lang.FoldMarginWidth.Value;
                    else scintilla.Margins.Margin1.Width =  20;

                    //if (lang.FoldMarginColor != Color.Empty)
                    //    scintilla.Margins.SetFoldMarginColor(true, lang.FoldMarginColor);
                    //if (lang.FoldMarginHighlightColor != Color.Empty)
                    //    scintilla.SetFoldMarginHiColor(true, lang.FoldMarginHighlightColor);
                    //if (lang.FoldFlags.HasValue)
                    //    scintilla.SetFoldFlags(lang.FoldFlags.Value);

                    scintilla.Markers.Folder.Symbol = MarkerSymbol.Plus;
                    scintilla.Markers.FolderOpen.Symbol = MarkerSymbol.Minus;
                    scintilla.Markers.FolderEnd.Symbol = MarkerSymbol.Empty;
                    scintilla.Markers.FolderOpenMidTail.Symbol = MarkerSymbol.Empty;
                    scintilla.Markers.FolderOpenMid.Symbol = MarkerSymbol.Minus;
                    scintilla.Markers.FolderSub.Symbol = MarkerSymbol.Empty;
                    scintilla.Markers.FolderTail.Symbol = MarkerSymbol.Empty;

                    //scintilla.EnableMarginClickFold();
                }

                if (!string.IsNullOrEmpty(lang.WhitespaceCharacters))
                    scintilla.Lexing.WhitespaceChars = lang.WhitespaceCharacters;

                if (!string.IsNullOrEmpty(lang.WordCharacters))
                    scintilla.Lexing.WordChars = lang.WordCharacters;

                ILexerConfig lexer = lang.Lexer;

                scintilla.Lexing.Lexer = Utilities.LexerLookupByID(lexer.LexerID);
                scintilla.Lexing.LexerName = lang.Name;

                SortedDictionary<int, ILexerStyle> styles = lang.Styles;
                foreach (ILexerStyle style in styles.Values)
                {
                    if (style.ForeColor != Color.Empty)
                        scintilla.Styles[style.StyleIndex].ForeColor = style.ForeColor;

                    if (style.BackColor != Color.Empty)
                        scintilla.Styles[style.StyleIndex].BackColor = style.BackColor;
                    
                    if (!string.IsNullOrEmpty(style.FontName))
                        scintilla.Styles[style.StyleIndex].FontName = style.FontName;

                    if (style.FontSize.HasValue)
                        scintilla.Styles[style.StyleIndex].Size = style.FontSize.Value;

                    if (style.Bold.HasValue)
                        scintilla.Styles[style.StyleIndex].Bold = style.Bold.Value;
                    
                    if (style.Italics.HasValue)
                        scintilla.Styles[style.StyleIndex].Italic = style.Italics.Value;

                    if (style.EOLFilled.HasValue)
                        scintilla.Styles[style.StyleIndex].IsSelectionEolFilled = style.EOLFilled.Value;

                    scintilla.Styles[style.StyleIndex].Case = style.CaseVisibility;
                }

                
                for (int j = 0; j < 9; j++)
                {
                    if (lang.KeywordLists.ContainsKey(j))
                        scintilla.Lexing.SetKeywords(j, lang.KeywordLists[j]);
                    else
                        scintilla.Lexing.SetKeywords(j, string.Empty);
                }
            }

            scintilla.Lexing.Colorize(0, scintilla.Text.Length);
        }
        #endregion
    }
}
