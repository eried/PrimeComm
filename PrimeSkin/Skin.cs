using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
        private string _imagePath;
        private Image _background;

        public Skin(string filePath, PictureBox pictureBox)
        {
            _pictureBox = pictureBox;
            _dirty = true;

            // Base path
            Settings = new Dictionary<string, string>();
            Components = new List<Component>();

            SkinPath = filePath;
            BasePath = Path.GetDirectoryName(filePath);

            var keyRegex = new Regex(@"(?<value>"".*"")?,?(?<id>[0-9]+),(?<left>[0-9]+),(?<top>[0-9]+),(?<right>[0-9]+),(?<bottom>[0-9]+),\{(?<modifier1>\d?[\d,]*)\},\{(?<modifier2>\d?[\d,]*)\},\{(?<modifier3>\d?[\d,]*)\}(?:,\[(?<mappings>.*)\])?(?:[\t #]+(?<comment>.*))?$");
            foreach (var p in from l in File.ReadAllLines(filePath, Encoding.Default) where l.Contains('=') select l.Split(new[] {'='}, 2))
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
                                Value = m.Groups["value"].Value,
                                Rectangle =ParseRectangle(p[1].Substring(m.Groups["left"].Index, (m.Groups["bottom"].Index + m.Groups["bottom"].Length) - m.Groups["left"].Index),true),
                                Modifiers =new[]{m.Groups["modifier1"].Value, m.Groups["modifier2"].Value, m.Groups["modifier3"].Value},
                                Mappings = m.Groups["mappings"].Value,
                                Comments = m.Groups["comment"].Value
                            });
                    }
                        break;

                    case "border":
                        Border = p[1];
                        break;

                    case "picture":
                        ImagePath = p[1];
                        break;

                    case "screen":
                        Components.Add(new Component(ComponentType.Screen) {Rectangle = ParseRectangle(p[1])});
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
            pictureBox.MouseMove += (o, args) => _pictureBox.Parent.Focus(); // Fix the mouse wheel scroll
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

                if (t == typeof (Rectangle))
                    return (T)(object)ParseRectangle(Settings[key]);
            }

            return default(T);
        }

        private static Rectangle ParseRectangle(string s, bool secondTupleIsRightDown = false)
        {
            var p = s.Split(new[] { ',' });
            int x1 = int.Parse(p[0]), y1 = int.Parse(p[1]), x2 = int.Parse(p[2]), y2 = int.Parse(p[3]);

            if (!secondTupleIsRightDown) return new Rectangle(x1, y1, x2, y2); // Direct output

            int xmin = Math.Min(x1, x2), ymin = Math.Min(y1, y2);
            return new Rectangle(xmin, ymin, Math.Max(x1, x2) - xmin,Math.Max(y1, y2) - ymin);
        }

        public void Paint(Graphics g)
        {
            if(_background!=null)
                g.DrawImage(_background, 0, 0, _pictureBox.Width, _pictureBox.Height);

            g.DrawPolygon(_penBorder, _borderPoints);
            
            foreach (var k in Components.Where(k => !k.Selected))
                DrawComponent(g, k);

            foreach (var k in Components.Where(k => k.Selected))
                DrawComponent(g, k);

        }

        private void DrawComponent(Graphics g, Component k)
        {
            g.FillRectangle(_brushKey, k.Rectangle);
            DrawLegend(g, k.Rectangle, k.Type == ComponentType.Key ? "id:" + k.Id : "screen", k.Selected);
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
            // Search for the nearest
            for (int i = 0; i < 10; i += 5)
            {
                var r = Components.FirstOrDefault(k => Inflate(k.Rectangle, i).Contains(location));

                if (r != null)
                    return r;
            }
            return null;
        }

        private static Rectangle Inflate(Rectangle rectangle, int size)
        {
            if (size == 0 || (rectangle.Width >size && rectangle.Height > size))
                return rectangle;

            var r = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
            r.Inflate(size, size);
            return r;
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
            var handler = SelectedComponentChange;
            if (handler != null) handler(this, new SelectedComponentEventArgs(Selected));
        }

        internal void Refresh(bool recalculateBounds=false)
        {
            if (recalculateBounds)
            {
                foreach (var k in Components)
                {
                    if (!_pictureBox.ClientRectangle.Contains(k.Rectangle))
                    {
                        // Adjust position and size
                        var p = new Point(Math.Min(_pictureBox.Width, Math.Max(0, k.Rectangle.Location.X)), 
                            Math.Min(_pictureBox.Height, Math.Max(k.Rectangle.Location.Y, 0)));
                        
                        var s = k.Rectangle.Size;

                        if (p.X + s.Width > _pictureBox.Width)
                            s.Width = _pictureBox.Width - p.X;

                        if (p.Y + s.Height > _pictureBox.Height)
                            s.Height = _pictureBox.Height - p.Y;

                        k.Rectangle = new Rectangle(p, s);
                    }
                }
            }

            _pictureBox.Invalidate();
        }

        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                var f = Path.Combine(BasePath, value);
                _background = null;
                _imagePath = null; 

                if (File.Exists(f))
                {
                    try
                    {
                        _background = Image.FromFile(f);
                        _pictureBox.Size = _background.Size;
                        _imagePath = f.Replace(BasePath,String.Empty).TrimStart(new [] { ' ', '\\', '/'}); 
                    }
                    catch
                    {
                    }
                }
            }
        }

        public string Border
        {
            get 
            {
                return _borderPoints != null? String.Join(",",_borderPoints.Select(p => p.X + "," + p.Y).ToList()):""; 
            }
            set 
            { 
                if (String.IsNullOrEmpty(value))
                    _borderPoints = new[]{new Point(0, 0), new Point(_pictureBox.Width, 0), new Point(_pictureBox.Width, _pictureBox.Height),new Point(0, _pictureBox.Height)};
                else
                    _borderPoints = ParsePointArray(value);
            }
        }

        private static Point[] ParsePointArray(string s)
        {
            var p = s.Split(new[] { ',' });
            var tmp = new List<Point>();
            for (var i = 0; i < p.Length; i += 2)
                tmp.Add(new Point(int.Parse(p[i]), int.Parse(p[i + 1])));

            return tmp.ToArray();
        }

        internal bool Save(string path="")
        {
            try
            {
                if (String.IsNullOrEmpty(path) && (String.IsNullOrEmpty(SkinPath) || !File.Exists(SkinPath)))
                {
                    // No file to save
                }
                else
                {
                    var f = new List<String>(new[]{"# File created by PrimeScreen", "# Part of PrimeComm: http://servicios.ried.cl/primecomm/", ""});
                    Settings["size"] = _pictureBox.Width + "," + _pictureBox.Height;

                    // Picture
                    if (Settings.ContainsKey("picture"))
                        Settings["picture"] = ImagePath;
                    else
                        Settings.Add("picture", ImagePath);

                    f.AddRange(Settings.Select(c => c.Key + "=" + c.Value).ToList());
                    f.Add("border="+Border);

                    foreach (var c in Components)
                    {
                        switch (c.Type)
                        {
                            case ComponentType.Key:
                            {
                                var value = String.IsNullOrEmpty(c.Value) ? String.Empty : c.Value + ",";
                                var mapped = String.IsNullOrEmpty(c.Mappings) ? String.Empty : ",[" + c.Mappings + "]";
                                var comments = String.IsNullOrEmpty(c.Comments) ? String.Empty : " #" + c.Comments;

                                f.Add(String.Format("key={0}{1},{2},{3},{4},{5},{{{6}}},{{{7}}},{{{8}}}{9}{10}",
                                    value, c.Id, c.Rectangle.Left, c.Rectangle.Top, c.Rectangle.Right,
                                    c.Rectangle.Bottom,
                                    c.Modifiers[0], c.Modifiers[1], c.Modifiers[2], mapped, comments));
                                break;
                            }
                            case ComponentType.Screen:
                                f.Add("screen=" + c.Rectangle.Left + "," + c.Rectangle.Top + "," + c.Rectangle.Width +
                                      "," + c.Rectangle.Height + (String.IsNullOrEmpty(c.Comments) ? String.Empty : " #" + c.Comments));
                                break;
                        }
                    }

                    f.Add("end");

                    File.WriteAllLines(path, f, Encoding.Default);
                    return true;
                }
            }
            catch
            {
            }
            return false;
        }

        /// <summary>
        /// Find the border of the image
        /// </summary>
        internal void FindBorder()
        {
            _borderPoints = new MarchingSquares().DoMarch(new Bitmap(_background));
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