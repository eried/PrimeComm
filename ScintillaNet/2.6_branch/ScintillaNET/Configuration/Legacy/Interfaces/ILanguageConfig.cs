using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ScintillaNet;

namespace ScintillaNet.Configuration.Legacy
{
    public interface ILanguageConfig
    {
        ILanguageConfig CombinedLanguageConfig { get;}

        SortedDictionary<int, string> KeywordLists { get; }

        SortedDictionary<string, string> Properties { get; }

        SortedDictionary<int, ILexerStyle> Styles { get; }

        IScintillaConfig ScintillaConfig { get; }
        
        ILexerConfig Lexer { get; set; }

        string Name { get; set; }

        string WordCharacters { get; set; }

        string WhitespaceCharacters { get; set; }

        string PreprocessorSymbol { get; set; }

        string PreprocessorStart { get; set; }

        string PreprocessorMiddle { get; set; }

        string PreprocessorEnd { get; set; }

        string FilePattern { get; set; }

        string FileFilter { get; set; }

        string Extension { get; set; }

        string ExtensionList { get; set; }

        int? CodePage { get; set; }

        int? TabSize { get; set; }

        int? IndentSize { get; set; }

        bool? Fold { get; set; }

        bool? FoldCompact { get; set; }

        int? FoldFlags { get; set; }

        bool? FoldAtElse { get; set; }

        bool? FoldComment { get; set; }

        bool? FoldPreprocessor { get; set; }

        bool? FoldSymbols { get; set; }

        bool? FoldOnOpen { get; set; }

        bool? HtmlFold { get; set; }

        bool? HtmlFoldPreprocessor { get; set; }

        bool? HtmlTagsCaseSensitive { get; set; }

        bool? PythonFoldComment { get; set; }

        bool? PythonFoldQuotes { get; set; }

        int? PythonWhingeLevel { get; set; }

        bool? StylingWithinPreprocessor { get; set; }

        bool? SqlBackslashEscapes { get; set; }

        bool? SqlBackticksIdentifier { get; set; }

        bool? SqlFoldOnlyBegin { get; set; }

        bool? PerlFoldPod { get; set; }

        bool? PerlFoldPackage { get; set; }

        bool? NsisIgnoreCase { get; set; }

        bool? NsisUserVars { get; set; }

        bool? NsisFoldUtilCommand { get; set; }

        bool? CppAllowDollars { get; set; }

        int? FoldMarginWidth { get; set; }

        Color FoldMarginColor { get; set; }

        Color FoldMarginHighlightColor { get; set; }

        int? SelectionAlpha { get; set; }

        Color SelectionBackColor { get; set; }
    }
}
