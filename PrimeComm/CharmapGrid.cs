using System;
using System.Drawing;
using System.Windows.Forms;

namespace PrimeComm
{
    class CharmapGrid : Panel
    {
        public CharmapGrid()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
            BorderStyle = BorderStyle.FixedSingle;

            CellHeight = 28;
            CellWidth = 28;
            Click += CharmapGrid_Click;
        }

        void CharmapGrid_Click(object sender, EventArgs e)
        {
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var b = new Pen(Brushes.Black, 1);

            e.Graphics.FillRectangle(Brushes.White, e.ClipRectangle);

            var w = Math.Floor(e.ClipRectangle.Width/CellWidth);
            CellWidth = ClientRectangle.Width/w;

            for (var x = CellWidth; x < ClientRectangle.Right - (CellWidth/2); x += CellWidth)
                e.Graphics.DrawLine(b, (int) x, ClientRectangle.Top, (int) x, ClientRectangle.Bottom);

            var h = Math.Floor(ClientRectangle.Height/CellHeight);
            CellHeight = ClientRectangle.Height/h;

            for (var y = CellHeight; y < ClientRectangle.Bottom - (CellHeight/2); y += CellHeight)
                e.Graphics.DrawLine(b, ClientRectangle.Left, (int) y, ClientRectangle.Right, (int) y);

            var chr = 30;
            for (var y = CellHeight/2; y < ClientRectangle.Bottom; y += CellHeight)
                for (var x = CellWidth/2; x < ClientRectangle.Right; x += CellWidth)
                {
                    var m = e.Graphics.MeasureString("" + ((char) chr), Font);
                    e.Graphics.DrawString("" + ((char) chr++), Font, Brushes.Black, (int) x - m.Width/2,(int) y - Font.Height/2);
                }
        }

        public double CellHeight { get; private set; }

        public double CellWidth { get; private set; }
    }
}