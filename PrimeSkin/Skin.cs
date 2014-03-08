using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace PrimeSkin
{
    /// <summary>
    /// Represents, parses and handles a skin for the Prime Emulator
    /// </summary>
    public class Skin
    {
        private Image _background;
        private const int Alpha = 100;
        private readonly Brush _brushKey= new SolidBrush(Color.FromArgb(Alpha, Color.Blue)),
            _brushScreen = new SolidBrush(Color.FromArgb(Alpha, 0, 255, 0)),
            _brushLabel = new SolidBrush(Color.FromArgb(255, Color.Black)),
            _brushLabelBackground = new SolidBrush(Color.FromArgb(255, Color.Yellow));
        private readonly Pen _penBorder = new Pen(new SolidBrush(Color.FromArgb(Alpha, Color.Magenta)), 4),
            _penLegend = new Pen(new SolidBrush(Color.FromArgb(255, Color.Blue)), 1);
        private readonly bool _dirty;
        private Point[] _borderPoints;
        private Rectangle _screen;
        private readonly Font _fontLabel = new Font("Arial", 8);

        public Skin(string filePath)
        {
            _dirty = true;

            // Base path
            Settings = new Dictionary<string, string>();
            Keys = new Dictionary<int, KeyDefinition>();

            SkinPath = filePath;
            BasePath = Path.GetDirectoryName(filePath);
            var keyRegex = new Regex(@"(?<key>.*?),??(?<id>\d{1,9}),(?<left>\d{1,9}),(?<up>\d{1,9}),(?<right>\d{1,9}),(?<down>\d{1,9}),\{(?<modifier1>[\d,]*)\},\{(?<modifier2>[\d,]*)\},\{(?<modifier3>[\d,]*)\},?\[?(?<mappings>[\w""]*)\]?.*?[\s#]*(?<comment>.*)");

            foreach (var l in File.ReadAllLines(filePath))
            {
                if (!l.Contains('=')) continue;

                var p = l.Split(new[] { '=' }, 2);

                if (p[0] == "key")
                {
                    var m = keyRegex.Match(p[1]);

                    if (m.Success)
                        Keys.Add(int.Parse(m.Groups["id"].Value), new KeyDefinition {
                            Value = m.Groups["key"].Value,
                            Left = int.Parse(m.Groups["left"].Value),
                            Up = int.Parse(m.Groups["up"].Value),
                            Right = int.Parse(m.Groups["right"].Value),
                            Down = int.Parse(m.Groups["down"].Value),
                            Modifiers = new[] { m.Groups["modifier1"].Value, m.Groups["modifier2"].Value, m.Groups["modifier3"].Value },
                            Mappings = m.Groups["mappings"].Value,
                            Comments = m.Groups["comment"].Value
                        });
                }
                else
                    if(!Settings.ContainsKey(p[0]))
                        Settings.Add(p[0], p[1]);
            }
        }

        public Dictionary<int, KeyDefinition> Keys { get; set; }

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
                {
                    return (T)(object)Image.FromFile(Path.Combine(BasePath, Settings[key]));
                }

                if (t == typeof (Point[]))
                {
                    var p = Settings[key].Split(new[] {','});
                    var tmp = new List<Point>();
                    for (var i = 0; i < p.Length; i += 2)
                        tmp.Add(new Point(int.Parse(p[i]), int.Parse(p[i + 1])));

                    return (T)(object)tmp.ToArray();
                }

                if (t == typeof (Rectangle))
                {
                    var p = Settings[key].Split(new[] { ',' });
                    return (T)(object)new Rectangle(int.Parse(p[0]),int.Parse(p[1]),int.Parse(p[2]),int.Parse(p[3]));
                }
            }

            return default(T);
        }

        public void Paint(Graphics g, Size size)
        {
            if (_dirty)
            {
                _background = GetSetting<Image>("picture");
                _borderPoints = GetSetting<Point[]>("border");
                _screen = GetSetting<Rectangle>("screen");
            }

            g.DrawImage(_background, 0, 0, size.Width, size.Height);
            
            g.FillRectangle(_brushScreen, _screen);
            DrawLegend(g, _screen, "screen");

            g.DrawPolygon(_penBorder, _borderPoints);
            
            foreach (var k in Keys)
            {
                g.FillRectangle(_brushKey, k.Value.ClientRectangle);
                DrawLegend(g, k.Value.ClientRectangle, "id:"+k.Key);
            }
        }

        private void DrawLegend(Graphics g, Rectangle rect, string label)
        {
            DrawLegend(g, rect.Left, rect.Top, rect.Width, rect.Height, label);
        }

        private void DrawLegend(Graphics g, int x, int y, int w, int h, string label)
        {
            g.DrawRectangle(_penLegend, x,y,w,h);
            //g.DrawLines(_penLegend, new[] { new Point(x+w-4, y+h), new Point(x+w, y+h), new Point(x+w, y+h-4) });
            var m = g.MeasureString(label, _fontLabel);
            var rect = new Rectangle((int)(x + ((w - m.Width) / 2)), (int)(y + ((h - m.Height) / 2)), (int)m.Width, (int)m.Height);
            g.FillRectangle(_brushLabelBackground, rect);
            g.DrawString(label, _fontLabel, _brushLabel, rect.Left-1, rect.Top);
        }
    }
}