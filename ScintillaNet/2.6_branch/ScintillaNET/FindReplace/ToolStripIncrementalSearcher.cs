using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ScintillaNet
{
    public class ToolStripIncrementalSearcher : ToolStripControlHost
    {
        public ToolStripIncrementalSearcher() : base(new IncrementalSearcher(true)) { }

        public IncrementalSearcher Searcher
        {
            get { return Control as IncrementalSearcher; }
        }

        public Scintilla Scintilla
        {
            get { return Searcher.Scintilla; }
            set { Searcher.Scintilla = value; }
        }
    }
}
