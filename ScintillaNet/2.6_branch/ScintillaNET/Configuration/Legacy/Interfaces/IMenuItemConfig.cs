using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ScintillaNet.Configuration.Legacy
{
    public interface IMenuItemConfig
    {
        string Text { get; set; }

        string Value { get; set; }

        Keys ShortcutKeys { get; set; }
    }
}
