using System;
using System.Collections.Generic;
using System.Text;
using ScintillaNet;

namespace ScintillaNet.Configuration.Legacy
{
    public class LanguageConfigCollection : ILanguageConfigCollection
    {
        private IScintillaConfigProvider provider;
        private ILexerConfigCollection lexers;
        private IScintillaConfig parent;
        private SortedDictionary<string, LanguageConfig> Languages = new SortedDictionary<string,LanguageConfig>();

        public LanguageConfigCollection(IScintillaConfig parent, IScintillaConfigProvider provider, ILexerConfigCollection lexers)
        {
            if (provider == null)
                throw new Exception("IScintillaConfigProvider must be provided in the LanguageConfigCollection constructor!");
            if (lexers == null)
                throw new Exception("The LexerConfigCollection must be provided in the LanguageConfigCollection constructor!");
            if (parent == null)
                throw new Exception("The ScintillaConfig must be provided in the LanguageConfigCollection constructor!");

            this.parent = parent;
            this.provider = provider;
            this.lexers = lexers;
        }

        public ILanguageConfig this[string name]
        {
            get
            {
                LanguageConfig config = null;
                if (!Languages.ContainsKey(name))
                {
                    config = new LanguageConfig(parent, name);
                    Languages[name] = config;
                    if (!provider.PopulateLanguageConfig(config, lexers))
                    {
                        config = null;
                        Languages.Remove(name);
                    }
                }
                else
                {
                    config = Languages[name];
                }
                return config;
            }
        }
    }
}
