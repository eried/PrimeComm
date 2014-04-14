using System;
using System.Collections.Generic;
using System.Text;

namespace ScintillaNet.Configuration.Legacy
{
    public interface IScintillaConfigProvider
    {
        bool PopulateScintillaConfig(IScintillaConfig config);
        bool PopulateLexerConfig(ILexerConfig config);
        bool PopulateLanguageConfig(ILanguageConfig config, ILexerConfigCollection lexers);
    }
}
