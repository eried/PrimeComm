using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ScintillaNet.Configuration.Legacy
{
    public class LanguageConfig : ILanguageConfig
    {
        private SortedDictionary<int, string> keywordLists;
        private SortedDictionary<int, ILexerStyle> styles;
        private ILexerConfig lexer;
        private IScintillaConfig scintillaConf;
        private SortedDictionary<string, string> properties;
        private string name;
        private string wordCharacters;
        private string whitespaceCharacters;
        private string preprocessorSymbol;
        private string preprocessorStart;
        private string preprocessorMiddle;
        private string preprocessorEnd;
        private string filePattern;
        private string fileFilter;
        private string extension;
        private string extensionList;
        private Color selectionBackColor = Color.Empty;
        private Color foldMarginColor = Color.Empty;
        private Color foldMarginHighlightColor = Color.Empty;
        private int? codePage;
        private bool? fold;
        private bool? foldAtElse;
        private bool? foldCompact;
        private bool? foldComment;
        private bool? foldPreprocessor;
        private bool? foldSymbols;
        private bool? foldOnOpen;
        private bool? foldHTML;
        private bool? foldHTMLPreprocessor;
        private bool? htmlTagsCaseSensitive;
        private bool? foldCommentPython;
        private bool? foldQuotesPython;
        private bool? stylingWithinPreprocessor;
        private bool? sqlBackslashEscapes;
        private bool? sqlBackticksIdentifier;
        private bool? sqlFoldOnlyBegin;
        private bool? perlFoldPod;
        private bool? perlFoldPackage;
        private bool? nsisIgnoreCase;
        private bool? nsisUserVars;
        private bool? nsisFoldUtilCommand;
        private bool? cppAllowDollars;
        private int? whingeLevelPython;
        private int? foldFlags;
        private int? foldMarginWidth;
        private int? selectionAlpha;
        private int? tabSize;
        private int? indentSize;

        public LanguageConfig(IScintillaConfig scintillaConf, string name)
        {
            this.scintillaConf = scintillaConf;
            this.name = name;
        }

        public IScintillaConfig ScintillaConfig
        {
            get
            {
                return scintillaConf;
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

        public ILexerConfig Lexer
        {
            get { return lexer; }
            set { lexer = value; }
        }

        public SortedDictionary<int, string> KeywordLists
        {
            get
            {
                if (keywordLists == null)
                {
                    keywordLists = new SortedDictionary<int, string>();
                }
                return keywordLists;
            }
        }

        public SortedDictionary<int, ILexerStyle> Styles
        {
            get
            {
                if (styles == null)
                {
                    styles = new SortedDictionary<int, ILexerStyle>();
                }
                return styles;
            }
        }

        public ILanguageConfig CombinedLanguageConfig
        {
            get
            {
                LanguageConfig combinedConfig = new LanguageConfig(this.scintillaConf, this.name);
                int lex = 0, lang = 0, sc = 0;
                bool lexUsedUp = false, langUsedUp = false, scUsedUp = false;
                SortedDictionary<int, ILexerStyle> combinedStyles = combinedConfig.Styles;
                for (int i = 0; i < 128; i++)
                {
                    if (lang >= Styles.Count) langUsedUp = true;
                    if (lex >= lexer.Styles.Count) lexUsedUp = true;
                    if (sc >= scintillaConf.LanguageDefaults.Styles.Count) scUsedUp = true;

                    if (langUsedUp && lexUsedUp && scUsedUp) break;

                    if (!langUsedUp && (Styles.ContainsKey(i)))
                    {
                        combinedStyles[i] = Styles[i];
                        lang++;
                    }
                    else if (!lexUsedUp && (lexer.Styles.ContainsKey(i)))
                    {
                        combinedStyles[i] = lexer.Styles[i];
                        lex++;
                    }
                    else if (!scUsedUp && (scintillaConf.LanguageDefaults.Styles.ContainsKey(i)))
                    {
                        combinedStyles[i] = scintillaConf.LanguageDefaults.Styles[i];
                        sc++;
                    }
                }

                combinedConfig.lexer = this.lexer;
                combinedConfig.keywordLists = this.keywordLists;
                combinedConfig.properties = this.properties;

                if (string.IsNullOrEmpty(this.WordCharacters)) combinedConfig.WordCharacters = scintillaConf.LanguageDefaults.WordCharacters;
                else combinedConfig.WordCharacters = this.WordCharacters;

                if (string.IsNullOrEmpty(this.WhitespaceCharacters)) combinedConfig.WhitespaceCharacters = scintillaConf.LanguageDefaults.WhitespaceCharacters;
                else combinedConfig.WhitespaceCharacters = this.WhitespaceCharacters;

                if (string.IsNullOrEmpty(this.PreprocessorSymbol)) combinedConfig.PreprocessorSymbol = scintillaConf.LanguageDefaults.PreprocessorSymbol;
                else combinedConfig.PreprocessorSymbol = this.PreprocessorSymbol;

                if (string.IsNullOrEmpty(this.PreprocessorStart)) combinedConfig.PreprocessorStart = scintillaConf.LanguageDefaults.PreprocessorStart;
                else combinedConfig.PreprocessorStart = this.PreprocessorStart;

                if (string.IsNullOrEmpty(this.PreprocessorMiddle)) combinedConfig.PreprocessorMiddle = scintillaConf.LanguageDefaults.PreprocessorMiddle;
                else combinedConfig.PreprocessorMiddle = this.PreprocessorMiddle;

                if (string.IsNullOrEmpty(this.PreprocessorEnd)) combinedConfig.PreprocessorEnd = scintillaConf.LanguageDefaults.PreprocessorEnd;
                else combinedConfig.PreprocessorEnd = this.PreprocessorEnd;

                if (string.IsNullOrEmpty(this.FilePattern)) combinedConfig.FilePattern = scintillaConf.LanguageDefaults.FilePattern;
                else combinedConfig.FilePattern = this.FilePattern;

                if (string.IsNullOrEmpty(this.FileFilter)) combinedConfig.FileFilter = scintillaConf.LanguageDefaults.FileFilter;
                else combinedConfig.FileFilter = this.FileFilter;

                if (string.IsNullOrEmpty(this.Extension)) combinedConfig.Extension = scintillaConf.LanguageDefaults.Extension;
                else combinedConfig.Extension = this.Extension;

                if (string.IsNullOrEmpty(this.ExtensionList)) combinedConfig.ExtensionList = scintillaConf.LanguageDefaults.ExtensionList;
                else combinedConfig.ExtensionList = this.ExtensionList;

                if (!this.CodePage.HasValue) combinedConfig.CodePage = scintillaConf.LanguageDefaults.CodePage;
                else combinedConfig.CodePage = this.CodePage;

                if (!this.TabSize.HasValue) combinedConfig.TabSize = scintillaConf.LanguageDefaults.TabSize;
                else combinedConfig.TabSize = this.TabSize;

                if (!this.IndentSize.HasValue) combinedConfig.IndentSize = scintillaConf.LanguageDefaults.IndentSize;
                else combinedConfig.IndentSize = this.IndentSize;

                if (!this.Fold.HasValue) combinedConfig.Fold = scintillaConf.LanguageDefaults.Fold;
                else combinedConfig.Fold = this.Fold;

                if (!this.FoldCompact.HasValue) combinedConfig.FoldCompact = scintillaConf.LanguageDefaults.FoldCompact;
                else combinedConfig.FoldCompact = this.FoldCompact;

                if (!this.FoldFlags.HasValue) combinedConfig.FoldFlags = scintillaConf.LanguageDefaults.FoldFlags;
                else combinedConfig.FoldFlags = this.FoldFlags;

                if (!this.FoldAtElse.HasValue) combinedConfig.FoldAtElse = scintillaConf.LanguageDefaults.FoldAtElse;
                else combinedConfig.FoldAtElse = this.FoldAtElse;

                if (!this.FoldComment.HasValue) combinedConfig.FoldComment = scintillaConf.LanguageDefaults.FoldComment;
                else combinedConfig.FoldComment = this.FoldComment;

                if (!this.FoldPreprocessor.HasValue) combinedConfig.FoldPreprocessor = scintillaConf.LanguageDefaults.FoldPreprocessor;
                else combinedConfig.FoldPreprocessor = this.FoldPreprocessor;

                if (!this.FoldSymbols.HasValue) combinedConfig.FoldSymbols = scintillaConf.LanguageDefaults.FoldSymbols;
                else combinedConfig.FoldSymbols = this.FoldSymbols;

                if (!this.FoldOnOpen.HasValue) combinedConfig.FoldOnOpen = scintillaConf.LanguageDefaults.FoldOnOpen;
                else combinedConfig.FoldOnOpen = this.FoldOnOpen;

                if (!this.HtmlFold.HasValue) combinedConfig.HtmlFold = scintillaConf.LanguageDefaults.HtmlFold;
                else combinedConfig.HtmlFold = this.HtmlFold;

                if (!this.HtmlFoldPreprocessor.HasValue) combinedConfig.HtmlFoldPreprocessor = scintillaConf.LanguageDefaults.HtmlFoldPreprocessor;
                else combinedConfig.HtmlFoldPreprocessor = this.HtmlFoldPreprocessor;

                if (!this.HtmlTagsCaseSensitive.HasValue) combinedConfig.HtmlTagsCaseSensitive = scintillaConf.LanguageDefaults.HtmlTagsCaseSensitive;
                else combinedConfig.HtmlTagsCaseSensitive = this.HtmlTagsCaseSensitive;

                if (!this.PythonFoldComment.HasValue) combinedConfig.PythonFoldComment = scintillaConf.LanguageDefaults.PythonFoldComment;
                else combinedConfig.PythonFoldComment = this.PythonFoldComment;

                if (!this.PythonFoldQuotes.HasValue) combinedConfig.PythonFoldQuotes = scintillaConf.LanguageDefaults.PythonFoldQuotes;
                else combinedConfig.PythonFoldQuotes = this.PythonFoldQuotes;

                if (!this.PythonWhingeLevel.HasValue) combinedConfig.PythonWhingeLevel = scintillaConf.LanguageDefaults.PythonWhingeLevel;
                else combinedConfig.PythonWhingeLevel = this.PythonWhingeLevel;

                if (!this.StylingWithinPreprocessor.HasValue) combinedConfig.StylingWithinPreprocessor = scintillaConf.LanguageDefaults.StylingWithinPreprocessor;
                else combinedConfig.StylingWithinPreprocessor = this.StylingWithinPreprocessor;

                if (!this.SqlBackslashEscapes.HasValue) combinedConfig.SqlBackslashEscapes = scintillaConf.LanguageDefaults.SqlBackslashEscapes;
                else combinedConfig.SqlBackslashEscapes = this.SqlBackslashEscapes;

                if (!this.SqlBackticksIdentifier.HasValue) combinedConfig.SqlBackticksIdentifier = scintillaConf.LanguageDefaults.SqlBackticksIdentifier;
                else combinedConfig.SqlBackticksIdentifier = this.SqlBackticksIdentifier;

                if (!this.SqlFoldOnlyBegin.HasValue) combinedConfig.SqlFoldOnlyBegin = scintillaConf.LanguageDefaults.SqlFoldOnlyBegin;
                else combinedConfig.SqlFoldOnlyBegin = this.SqlFoldOnlyBegin;

                if (!this.PerlFoldPod.HasValue) combinedConfig.PerlFoldPod = scintillaConf.LanguageDefaults.PerlFoldPod;
                else combinedConfig.PerlFoldPod = this.PerlFoldPod;

                if (!this.PerlFoldPackage.HasValue) combinedConfig.PerlFoldPackage = scintillaConf.LanguageDefaults.PerlFoldPackage;
                else combinedConfig.PerlFoldPackage = this.PerlFoldPackage;

                if (!this.NsisIgnoreCase.HasValue) combinedConfig.NsisIgnoreCase = scintillaConf.LanguageDefaults.NsisIgnoreCase;
                else combinedConfig.NsisIgnoreCase = this.NsisIgnoreCase;

                if (!this.NsisUserVars.HasValue) combinedConfig.NsisUserVars = scintillaConf.LanguageDefaults.NsisUserVars;
                else combinedConfig.NsisUserVars = this.NsisUserVars;

                if (!this.NsisFoldUtilCommand.HasValue) combinedConfig.NsisFoldUtilCommand = scintillaConf.LanguageDefaults.NsisFoldUtilCommand;
                else combinedConfig.NsisFoldUtilCommand = this.NsisFoldUtilCommand;

                if (!this.CppAllowDollars.HasValue) combinedConfig.CppAllowDollars = scintillaConf.LanguageDefaults.CppAllowDollars;
                else combinedConfig.CppAllowDollars = this.CppAllowDollars;

                if (!this.FoldMarginWidth.HasValue) combinedConfig.FoldMarginWidth = scintillaConf.LanguageDefaults.FoldMarginWidth;
                else combinedConfig.FoldMarginWidth = this.FoldMarginWidth;

                if (this.FoldMarginColor == Color.Empty) combinedConfig.FoldMarginColor = scintillaConf.LanguageDefaults.FoldMarginColor;
                else combinedConfig.FoldMarginColor = this.FoldMarginColor;

                if (this.FoldMarginHighlightColor == Color.Empty) combinedConfig.FoldMarginHighlightColor = scintillaConf.LanguageDefaults.FoldMarginHighlightColor;
                else combinedConfig.FoldMarginHighlightColor = this.FoldMarginHighlightColor;

                if (!this.SelectionAlpha.HasValue) combinedConfig.SelectionAlpha = scintillaConf.LanguageDefaults.SelectionAlpha;
                else combinedConfig.SelectionAlpha = this.SelectionAlpha;

                if (this.SelectionBackColor == Color.Empty) combinedConfig.SelectionBackColor = scintillaConf.LanguageDefaults.SelectionBackColor;
                else combinedConfig.SelectionBackColor = this.SelectionBackColor;

                return combinedConfig;
            }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string WordCharacters
        {
            get { return wordCharacters; }
            set { wordCharacters = value; }
        }

        public string WhitespaceCharacters
        {
            get { return whitespaceCharacters; }
            set { whitespaceCharacters = value; }
        }

        public string PreprocessorSymbol
        {
            get { return preprocessorSymbol; }
            set { preprocessorSymbol = value; }
        }

        public string PreprocessorStart
        {
            get { return preprocessorStart; }
            set { preprocessorStart = value; }
        }

        public string PreprocessorMiddle
        {
            get { return preprocessorMiddle; }
            set { preprocessorMiddle = value; }
        }

        public string PreprocessorEnd
        {
            get { return preprocessorEnd; }
            set { preprocessorEnd = value; }
        }

        public string FilePattern
        {
            get { return filePattern; }
            set { filePattern = value; }
        }

        public string FileFilter
        {
            get { return fileFilter; }
            set { fileFilter = value; }
        }

        public string Extension
        {
            get { return extension; }
            set { extension = value; }
        }

        public string ExtensionList
        {
            get { return extensionList; }
            set { extensionList = value; }
        }

        public int? CodePage
        {
            get { return codePage; }
            set { codePage = value; }
        }

        public int? TabSize
        {
            get { return tabSize; }
            set { tabSize = value; }
        }

        public int? IndentSize
        {
            get { return indentSize; }
            set { indentSize = value; }
        }

        //TODO: move folding into a subclass gouping if enabled?
        public bool? Fold
        {
            get { return fold; }
            set { fold = value; }
        }

        public bool? FoldCompact
        {
            get { return foldCompact; }
            set { foldCompact = value; }
        }

        public int? FoldFlags
        {
            get { return foldFlags; }
            set { foldFlags = value; }
        }

        public int? PythonWhingeLevel
        {
            get { return whingeLevelPython; }
            set { whingeLevelPython = value; }
        }

        public bool? FoldComment
        {
            get { return foldComment; }
            set { foldComment = value; }
        }

        public bool? FoldPreprocessor
        {
            get { return foldPreprocessor; }
            set { foldPreprocessor = value; }
        }

        public bool? FoldSymbols
        {
            get { return foldSymbols; }
            set { foldSymbols = value; }
        }

        public bool? FoldAtElse
        {
            get { return foldAtElse; }
            set { foldAtElse = value; }
        }

        public bool? FoldOnOpen
        {
            get { return foldOnOpen; }
            set { foldOnOpen = value; }
        }

        public bool? HtmlFold
        {
            get { return foldHTML; }
            set { foldHTML = value; }
        }

        public bool? HtmlFoldPreprocessor
        {
            get { return foldHTMLPreprocessor; }
            set { foldHTMLPreprocessor = value; }
        }

        public bool? HtmlTagsCaseSensitive
        {
            get { return htmlTagsCaseSensitive; }
            set { htmlTagsCaseSensitive = value; }
        }

        public bool? PythonFoldComment
        {
            get { return foldCommentPython; }
            set { foldCommentPython = value; }
        }

        public bool? PythonFoldQuotes
        {
            get { return foldQuotesPython; }
            set { foldQuotesPython = value; }
        }

        public bool? StylingWithinPreprocessor
        {
            get { return stylingWithinPreprocessor; }
            set { stylingWithinPreprocessor = value; }
        }

        public bool? SqlBackslashEscapes
        {
            get { return sqlBackslashEscapes; }
            set { sqlBackslashEscapes = value; }
        }

        public bool? SqlBackticksIdentifier
        {
            get { return sqlBackticksIdentifier; }
            set { sqlBackticksIdentifier = value; }
        }

        public bool? SqlFoldOnlyBegin
        {
            get { return sqlFoldOnlyBegin; }
            set { sqlFoldOnlyBegin = value; }
        }

        public bool? PerlFoldPod
        {
            get { return perlFoldPod; }
            set { perlFoldPod = value; }
        }

        public bool? PerlFoldPackage
        {
            get { return perlFoldPackage; }
            set { perlFoldPackage = value; }
        }

        public bool? NsisIgnoreCase
        {
            get { return nsisIgnoreCase; }
            set { nsisIgnoreCase = value; }
        }

        public bool? NsisUserVars
        {
            get { return nsisUserVars; }
            set { nsisUserVars = value; }
        }

        public bool? NsisFoldUtilCommand
        {
            get { return nsisFoldUtilCommand; }
            set { nsisFoldUtilCommand = value; }
        }

        public bool? CppAllowDollars
        {
            get { return cppAllowDollars; }
            set { cppAllowDollars = value; }
        }

        public int? FoldMarginWidth
        {
            get { return foldMarginWidth; }
            set { foldMarginWidth = value; }
        }

        public Color FoldMarginColor
        {
            get { return foldMarginColor; }
            set { foldMarginColor = value; }
        }

        public Color FoldMarginHighlightColor
        {
            get { return foldMarginHighlightColor; }
            set { foldMarginHighlightColor = value; }
        }

        public int? SelectionAlpha
        {
            get { return selectionAlpha; }
            set { selectionAlpha = value; }
        }

        public Color SelectionBackColor
        {
            get { return selectionBackColor; }
            set { selectionBackColor = value; }
        }


        /*private string tabSize;
        private string indentSize;
        private string useTabs;
        private string statementIndent;
        private string indentMaintain;
        private string statementEnd;
        private string statementLookback;
        private string blockStart;
        private string blockEnd;
        private string openPath;

        preprocessor.symbol.filepattern
        preprocessor.start.filepattern
        preprocessor.middle.filepattern
        preprocessor.end.filepattern 
        keywords.filepattern
        keywords2.filepattern
        keywords3.filepattern
        keywords4.filepattern
        keywords5.filepattern
        keywords6.filepattern
        keywords7.filepattern
        keywords8.filepattern
        keywords9.filepattern
        word.characters.filepattern 
        whitespace.characters.filepattern 
        tab.size.filepattern
        indent.size.filepattern
        use.tabs.filepattern
        statement.indent.filepattern
        indent.maintain.filepattern 
        statement.end.filepattern
        statement.lookback.filepattern
        block.start.filepattern
        block.end.filepattern 
        extension.filepattern 
        openpath.filepattern*/
    }
}
