using System;
using System.Collections.Generic;
using System.Text;

namespace ScintillaNet.Configuration.Legacy
{
    public interface ILanguageConfigCollection
    {
        ILanguageConfig this[string name] { get; }
    }
}
