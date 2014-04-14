#region Using Directives

using System;
using System.ComponentModel;
using System.Windows.Forms;

#endregion Using Directives


namespace ScintillaNET
{
    [TypeConverterAttribute(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class Printing : TopLevelHelper
    {
        #region Fields

        private PrintDocument _printDocument;

        #endregion Fields


        #region Methods

        public bool Print()
        {
            return Print(true);
        }


        public bool Print(bool showPrintDialog)
        {
            if (showPrintDialog)
            {
                PrintDialog pd = new PrintDialog();
                pd.Document = PrintDocument;
                pd.UseEXDialog = true;
                pd.AllowCurrentPage = true;
                pd.AllowSelection = true;
                pd.AllowSomePages = true;
                pd.PrinterSettings = PageSettings.PrinterSettings;

                if (pd.ShowDialog(Scintilla) == DialogResult.OK)
                {
                    PrintDocument.PrinterSettings = pd.PrinterSettings;
                    PrintDocument.Print();
                    return true;
                }

                return false;
            }

            PrintDocument.Print();
            return true;
        }


        public DialogResult PrintPreview()
        {
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.WindowState = FormWindowState.Maximized;

            ppd.Document = PrintDocument;
            return ppd.ShowDialog();
        }


        public DialogResult PrintPreview(IWin32Window owner)
        {
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.WindowState = FormWindowState.Maximized;

            if (owner is Form)
                ppd.Icon = ((Form)owner).Icon;

            ppd.Document = PrintDocument;
            return ppd.ShowDialog(owner);
        }


        internal bool ShouldSerialize()
        {
            return ShouldSerializePageSettings() || ShouldSerializePrintDocument();
        }


        private bool ShouldSerializePageSettings()
        {
            return PageSettings.ShouldSerialize();
        }


        private bool ShouldSerializePrintDocument()
        {
            return PrintDocument.ShouldSerialize();
        }


        public DialogResult ShowPageSetupDialog()
        {
            PageSetupDialog psd = new PageSetupDialog();
            psd.PageSettings = PageSettings;
            psd.PrinterSettings = PageSettings.PrinterSettings;
            return psd.ShowDialog();
        }


        public DialogResult ShowPageSetupDialog(IWin32Window owner)
        {
            PageSetupDialog psd = new PageSetupDialog();
            psd.AllowPrinter = true;
            psd.PageSettings = PageSettings;
            psd.PrinterSettings = PageSettings.PrinterSettings;

            return psd.ShowDialog(owner);
        }

        #endregion Methods


        #region Properties

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PageSettings PageSettings
        {
            get
            {
                return PrintDocument.DefaultPageSettings as PageSettings;
            }
            set
            {
                PrintDocument.DefaultPageSettings = value;
            }
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PrintDocument PrintDocument
        {
            get
            {
                if (_printDocument == null)
                {
                    // Lazy load
                    _printDocument = new PrintDocument(Scintilla);
                }

                return _printDocument;
            }
            set
            {
                _printDocument = value;
            }
        }

        #endregion Properties


        #region Constructors

        internal Printing(Scintilla scintilla) : base(scintilla)
        {
        }

        #endregion Constructors
    }
}
