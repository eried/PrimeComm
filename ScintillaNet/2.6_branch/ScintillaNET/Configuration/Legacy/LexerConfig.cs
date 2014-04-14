using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ScintillaNet;

namespace ScintillaNet.Configuration.Legacy
{
    public class LexerConfig : ILexerConfig
    {
        private SortedDictionary<string, string> properties;
        private SortedDictionary<int, ILexerStyle> styles;
        private IScintillaConfig scintillaConf;
        private Lexer lexerType;
        private string lexerName;

        public LexerConfig(IScintillaConfig scintillaConf, Lexer lexer)
        {
            this.scintillaConf = scintillaConf;
            this.lexerType = lexer;
            lexerName = GetLexerName(lexerType);
        }

        public LexerConfig(IScintillaConfig scintillaConf, int lexer)
        {
            this.scintillaConf = scintillaConf;
            this.lexerType = (Lexer)lexer;
            lexerName = GetLexerName(lexerType);
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

        public Lexer Type
        {
            get { return lexerType; }
        }

        public int LexerID
        {
            get { return (int)lexerType; }
        }

        public string LexerName
        {
            get { return lexerName; }
        }

        /*comment.block.lexer
comment.block.at.line.start.lexer
comment.stream.start.lexer
comment.stream.end.lexer
comment.box.start.lexer
comment.box.middle.lexer
comment.box.end.lexer */

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

        #region Lexer Name to Enum Translation
        public static string GetLexerName(Lexer lexer)
        {
            string lexerName = string.Empty;
            switch (lexer)
            {
                case Lexer.Hypertext:
                    lexerName = "hypertext";
                    break;
                case Lexer.Properties:
                    lexerName = "props";
                    break;
                default:
                    lexerName = lexer.ToString().ToLower();
                    break;
            }
            return lexerName;
        }

        public static Lexer GetLexerFromName(string lexerName)
        {
            Lexer lexer = Lexer.Null;
            switch (lexerName)
            {
                case "hypertext":
                    lexer = Lexer.Hypertext;
                    break;
                case "props":
                    lexer = Lexer.Properties;
                    break;
                default:
                    lexer = (Lexer)Enum.Parse(typeof(Lexer), lexerName, true);
                    break;
            }
            return lexer;
        }
        #endregion
    }
}
