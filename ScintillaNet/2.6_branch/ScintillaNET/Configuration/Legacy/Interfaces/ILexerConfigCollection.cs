using System;
using System.Collections.Generic;
using System.Text;
using ScintillaNet;

namespace ScintillaNet.Configuration.Legacy
{
    public interface ILexerConfigCollection
    {
        ILexerConfig this[int lexerId] { get; }

        ILexerConfig this[Lexer lexer] { get; }

        ILexerConfig this[string lexerName] { get; }
    }
}
