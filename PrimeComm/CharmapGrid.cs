using System;
using System.Drawing;
using System.Windows.Forms;

namespace PrimeComm
{
    class CharmapGrid : Panel
    {
        private char _firstCellChar;
        private char _selectedChar;

        public CharmapGrid()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
            BorderStyle = BorderStyle.FixedSingle;

            SelectedChar = char.MaxValue;
            FirstCellChar = (char)32;
            MouseClick += CharmapGrid_MouseClick;
        }

        void CharmapGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                float cellHeight, cellWidth;
                UpdateCellSize(out cellHeight, out cellWidth);

                SelectedChar = (char)(FirstCellChar + ((e.X / cellWidth) + (Columns * (int)(e.Y / cellHeight))));
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            float cellHeight, cellWidth;
            UpdateCellSize(out cellHeight, out cellWidth);

            const int lineWidth = 1;
            var linePen = new Pen(SystemBrushes.ControlDarkDark, lineWidth);
            e.Graphics.FillRectangle(Brushes.White, e.ClipRectangle);

            var chr = FirstCellChar;

            for (var y = 0; y < Rows; y++)
            {
                for (var x = 0; x < Columns; x++)
                {
                    if (chr > 65533)
                        break;

                    var isSelected = chr == SelectedChar;

                    var rect = new Rectangle((int)(x == 0 ? ClientRectangle.Left : Math.Floor((float)x * cellWidth)),
                         (int)(y == 0 ? ClientRectangle.Top : Math.Floor((float)y * cellHeight)),
                         (int)(x < Columns - 1 ? cellWidth : Math.Floor((float)ClientRectangle.Right - (cellWidth * (float)x))),
                         (int)(y < Rows - 1 ? cellHeight : Math.Floor((float)ClientRectangle.Bottom - (cellHeight * (float)y))));

                    if (isSelected)
                    {
                        e.Graphics.FillRectangle(SystemBrushes.Highlight, rect);
                    }

                    var m = e.Graphics.MeasureString("" + (chr), Font);
                    e.Graphics.DrawString("" + (chr++), Font, isSelected ? SystemBrushes.HighlightText: SystemBrushes.ControlText, rect.Left + (rect.Width- m.Width)/2, rect.Top + (rect.Height-Font.Height)/2);

                    if(x < Columns -1)
                        e.Graphics.DrawLine(linePen, rect.Right, rect.Top, rect.Right, rect.Bottom);

                    if(y < Rows-1)
                        e.Graphics.DrawLine(linePen, rect.Right, rect.Bottom, rect.Left, rect.Bottom);
                }

                if (chr > 65533)
                    break;
            }
        }

        private void UpdateCellSize(out float cellHeight, out float cellWidth)
        {
            int w = (int) (ClientRectangle.Width / 28.0);
            int h = (int) (ClientRectangle.Height / 28.0);

            cellWidth = ClientRectangle.Width / (float)w;
            cellHeight = ClientRectangle.Height / (float)h;


            UpdateCellCount(w, h);
        }

        private void UpdateCellCount(int columns, int rows)
        {
            if (Rows != rows || Columns != columns)
            {
                Rows = rows;
                Columns = columns;

                if(CellCountChanged != null)
                    CellCountChanged.Invoke(this, new EventArgs());
            }
        }

        public int Rows { get; private set; }

        public int Columns { get; private set; }

        public char FirstCellChar
        {
            get { return _firstCellChar; }
            set {
                if (value != _firstCellChar)
                {
                    _firstCellChar = value;
                    Invalidate();
                }
            }
        }

        public event EventHandler<EventArgs> CellCountChanged;

        public event EventHandler<EventArgs> SelectedCharChanged;


        public char SelectedChar
        {
            get { return _selectedChar; }
            private set
            {
                if (_selectedChar != value)
                {
                    _selectedChar = value;

                    if(SelectedCharChanged != null)
                        SelectedCharChanged.Invoke(this, new EventArgs());
                }
            }
        }
    }
}