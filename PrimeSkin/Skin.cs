using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PrimeSkin
{
    /// <summary>
    /// Represents, parses and handles a skin for the Prime Emulator
    /// </summary>
    public class Skin
    {
        private readonly PictureBox _pictureBox;
        private Image _background;
        private const int Alpha = 100;
        private readonly Brush _brushKey= new SolidBrush(Color.FromArgb(Alpha, Color.Blue)),
            _brushScreen = new SolidBrush(Color.FromArgb(Alpha, 0, 255, 0)),
            _brushLabel = new SolidBrush(Color.FromArgb(255, Color.Black)),
            _brushLabelBackground = new SolidBrush(Color.FromArgb(255, Color.Yellow));

        private readonly Pen _penBorder = new Pen(new SolidBrush(Color.FromArgb(Alpha, Color.Magenta)), 4),
            _penLegend = new Pen(new SolidBrush(Color.FromArgb(255, Color.Blue)), 1),
            _penLegendSelected = new Pen(new SolidBrush(Color.FromArgb(255, Color.White)), 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot };

        private readonly bool _dirty;
        private Point[] _borderPoints;
        private readonly Font _fontLabel = new Font("Arial", 8);
        private Component _selected;

        public Skin(string filePath, PictureBox pictureBox)
        {
            _pictureBox = pictureBox;
            _dirty = true;

            // Base path
            Settings = new Dictionary<string, string>();
            Components = new List<Component>();

            SkinPath = filePath;
            BasePath = Path.GetDirectoryName(filePath);
            var keyRegex = new Regex(@"(?<key>.*?),??(?<id>\d{1,9}),(?<left>\d{1,9}),(?<up>\d{1,9}),(?<right>\d{1,9}),(?<down>\d{1,9}),\{(?<modifier1>[\d,]*)\},\{(?<modifier2>[\d,]*)\},\{(?<modifier3>[\d,]*)\},?\[?(?<mappings>[\w""]*)\]?.*?[\s#]*(?<comment>.*)");

            foreach (var p in from l in File.ReadAllLines(filePath) where l.Contains('=') select l.Split(new[] {'='}, 2))
            {
                switch (p[0])
                {
                    case "key":
                    {
                        var m = keyRegex.Match(p[1]);

                        if (m.Success)
                            Components.Add(new Component
                            {
                                Id = int.Parse(m.Groups["id"].Value),
                                Value = m.Groups["key"].Value,
                                ClientRectangle =
                                    ParseRectangle(
                                        p[1].Substring(m.Groups["left"].Index,
                                            (m.Groups["down"].Index + m.Groups["down"].Length) - m.Groups["left"].Index),
                                        true),
                                Modifiers =
                                    new[]
                                    {m.Groups["modifier1"].Value, m.Groups["modifier2"].Value, m.Groups["modifier3"].Value},
                                Mappings = m.Groups["mappings"].Value,
                                Comments = m.Groups["comment"].Value
                            });
                    }
                        break;

                    case "screen":
                        Components.Add(new Component(ComponentType.Screen) {ClientRectangle = ParseRectangle(p[1])});
                        break;

                    default:
                        if (!Settings.ContainsKey(p[0]))
                            Settings.Add(p[0], p[1]);
                        break;
                }
            }

            // PictureBox events
            _pictureBox.Size = GetSetting<Size>("size");
            pictureBox.Paint += (o, args) => Paint(args.Graphics);
            pictureBox.MouseDown += pictureBox_MouseDown;
        }

        void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Selected = GetComponent(e.Location);
        }

        public Component Selected
        {
            get 
            { 
                return _selected; 
            }
            set 
            { 
                _selected = value;

                if (_selected != null)
                    SelectComponent(_selected);
                else
                    DeselectAll();

                _pictureBox.Invalidate();
                OnSelectedComponentChange();
            }
        }

        public List<Component> Components { get; set; }

        /// <summary>
        /// Skin file path
        /// </summary>
        public string SkinPath { get; private set; }

        /// <summary>
        /// Base directory 
        /// </summary>
        public string BasePath { get; private set; }

        public Dictionary<string, string> Settings { get; set; }

        public T GetSetting<T>(string key)
        {
            if (Settings != null && Settings.ContainsKey(key))
            {
                var t = typeof (T);

                if (t == typeof (Size))
                {
                    var s = Settings[key].Split(new [] { ',' });
                    return (T)(object)(new Size(int.Parse(s[0]), int.Parse(s[1])));
                }

                if (t == typeof (Image))
                    return (T)(object)Image.FromFile(Path.Combine(BasePath, Settings[key]));

                if (t == typeof (Point[]))
                {
                    var p = Settings[key].Split(new[] {','});
                    var tmp = new List<Point>();
                    for (var i = 0; i < p.Length; i += 2)
                        tmp.Add(new Point(int.Parse(p[i]), int.Parse(p[i + 1])));

                    return (T)(object)tmp.ToArray();
                }

                if (t == typeof (Rectangle))
                    return (T)(object)ParseRectangle(Settings[key]);
            }

            return default(T);
        }

        private static Rectangle ParseRectangle(string s, bool secondTupleIsRightDown = false)
        {
            var p = s.Split(new[] { ',' });
            int x = int.Parse(p[0]), y = int.Parse(p[1]);
            return new Rectangle(x, y, int.Parse(p[2]) - (secondTupleIsRightDown ? x : 0), int.Parse(p[3]) - (secondTupleIsRightDown ? y : 0));
        }

        public void Paint(Graphics g)
        {
            if (_dirty)
            {
                _background = GetSetting<Image>("picture");
                _borderPoints = GetSetting<Point[]>("border");
            }

            g.DrawImage(_background, 0, 0, _pictureBox.Width, _pictureBox.Height);
            g.DrawPolygon(_penBorder, _borderPoints);
            
            foreach (var k in Components.Where(k => !k.Selected))
                DrawComponent(g, k);

            foreach (var k in Components.Where(k => k.Selected))
                DrawComponent(g, k);

        }

        private void DrawComponent(Graphics g, Component k)
        {
            g.FillRectangle(_brushKey, k.ClientRectangle);
            DrawLegend(g, k.ClientRectangle, k.Type == ComponentType.Key ? "id:" + k.Id : "screen", k.Selected);
        }

        private void DrawLegend(Graphics g, Rectangle rect, string label = "", bool selected = false)
        {
            DrawLegend(g, rect.Left, rect.Top, rect.Width, rect.Height, label, selected);
        }

        private void DrawLegend(Graphics g, int x, int y, int w, int h, string label="", bool selected=false)
        {
            g.DrawRectangle(selected?_penLegendSelected:_penLegend, x, y, w, h);
            var m = g.MeasureString(label, _fontLabel);
            var rect = new Rectangle((int)(x + ((w - m.Width) / 2)), (int)(y + ((h - m.Height) / 2)), (int)m.Width, (int)m.Height);
            g.FillRectangle(_brushLabelBackground, rect);
            g.DrawString(label, _fontLabel, _brushLabel, rect.Left-1, rect.Top);
        }

        public Component GetComponent(Point location)
        {
            return Components.FirstOrDefault(k => k.ClientRectangle.Contains(location));
        }

        internal void SelectComponent(Component k)
        {
            DeselectAll();
            k.Selected = true;
        }

        private void DeselectAll()
        {
            foreach (var k in Components)
                k.Selected = false;
        }

        public event EventHandler<SelectedComponentEventArgs> SelectedComponentChange;

        protected virtual void OnSelectedComponentChange()
        {
            EventHandler<SelectedComponentEventArgs> handler = SelectedComponentChange;
            if (handler != null) handler(this, new SelectedComponentEventArgs(Selected));
        }
    }

    public class SelectedComponentEventArgs : EventArgs
    {
        public Component Selected { get; set; }

        public SelectedComponentEventArgs(Component selected)
        {
            Selected = selected;
        }
    }
}