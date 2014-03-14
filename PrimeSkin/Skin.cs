﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using PrimeSkin.Properties;

namespace PrimeSkin
{
    class Skin
    {
        private List<VirtualComponent> _components;
        internal Point[] _borderPoints;
        private string _imagePath;
        internal Image _background;
        internal ComponentType[] _visibleTypes;

        public Skin(string filePath)
        {
            _components = new List<VirtualComponent>();
            Settings = new Dictionary<string, string>();
            BasePath = Path.GetDirectoryName(filePath);

            var keyRegex = new Regex(@"(?<value>"".*"")?,?(?<id>[0-9]+),(?<left>[0-9]+),(?<top>[0-9]+),(?<right>[0-9]+),(?<bottom>[0-9]+),\{(?<modifier1>\d?[\d,]*)\},\{(?<modifier2>\d?[\d,]*)\},\{(?<modifier3>\d?[\d,]*)\}(?:,\[(?<mappings>.*)\])?(?:[\t #]+(?<comment>.*))?$");
            foreach (var p in from l in File.ReadAllLines(filePath, Encoding.Default) where l.Contains('=') select l.Split(new[] { '=' }, 2))
            {
                var k = p[0];

                if (k.StartsWith("MAXIMIZED"))
                    k = "MAXIMIZED";

                switch (k)
                {
                    case "key":
                        {
                            var m = keyRegex.Match(p[1]);

                            if (m.Success)
                                _components.Add(new VirtualKey
                                {
                                    Id = int.Parse(m.Groups["id"].Value),
                                    Value = m.Groups["value"].Value,
                                    Rectangle = Utilities.ParseRectangle(p[1].Substring(m.Groups["left"].Index, (m.Groups["bottom"].Index + m.Groups["bottom"].Length) - m.Groups["left"].Index), true),
                                    Modifiers = new[] { m.Groups["modifier1"].Value, m.Groups["modifier2"].Value, m.Groups["modifier3"].Value },
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

                    case "MAXIMIZED":
                        {
                            var s = p[1].Split(new[] { ',' });

                            switch (s.Length)
                            {
                                case (4):
                                    _components.Add(new VirtualMaximized
                                    {
                                        Rectangle = Utilities.ParseRectangle(p[1]),
                                        Id = 0
                                    });
                                    break;

                                case (6):
                                    _components.Add(new VirtualMaximized
                                    {
                                        Rectangle = Utilities.ParseRectangle(String.Join(",", s, 0, 4)),
                                        RelativeLocation = Utilities.ParsePoint(String.Join(",", s, 4, 2)),
                                        Id = int.Parse(p[0].Remove(0, k.Length))
                                    });
                                    break;
                            }

                        }
                        break;

                    case "screen":
                        _components.Add(new VirtualScreen { Rectangle = Utilities.ParseRectangle(p[1]) });
                        break;

                    default:
                        if (!Settings.ContainsKey(k))
                            Settings.Add(k, p[1]);
                        break;
                }
            }

            SkinSize = GetSetting<Size>("size");
        }

        public Size SkinSize { get; set; }

        public List<VirtualComponent> Components
        {
            get { return GetComponents(_visibleTypes); }
            set { _components = value; }
        }

        internal List<VirtualComponent> GetComponents(ComponentType[] types)
        {
            var t = new List<VirtualComponent>();
            if (types == null || types.Length == 0)
                return t;

            t.AddRange(_components.Where(c => types.Contains(c.Type)));

            return t;
        }

        public Dictionary<string, string> Settings { get; set; }

        public T GetSetting<T>(string key)
        {
            if (Settings != null && Settings.ContainsKey(key))
            {
                var t = typeof(T);

                if (t == typeof(Size))
                {
                    var s = Settings[key].Split(new[] { ',' });
                    return (T)(object)(new Size(int.Parse(s[0]), int.Parse(s[1])));
                }

                if (t == typeof(Rectangle))
                    return (T)(object)Utilities.ParseRectangle(Settings[key]);
            }

            return default(T);
        }

        public VirtualComponent GetComponent(Point location)
        {
            // Search for the nearest
            for (var i = 0; i < 10; i += 5)
            {
                var r = Components.FirstOrDefault(k => k.Rectangle.Inflate(i).Contains(location));

                if (r != null)
                    return r;
            }
            return null;
        }

        internal void Refresh(Rectangle _pictureBox, bool recalculateBounds = false)
        {
            if (recalculateBounds)
            {
                foreach (var k in Components)
                {
                    if (!_pictureBox.Contains(k.Rectangle) || k.Rectangle.Height < 0 || k.Rectangle.Width < 0)
                    {
                        // Adjust position and size
                        var p = new Point(Math.Min(_pictureBox.Width, Math.Max(0, k.Rectangle.Location.X)),
                            Math.Min(_pictureBox.Height, Math.Max(k.Rectangle.Location.Y, 0)));

                        var s = new Size(Math.Max(0, k.Rectangle.Size.Width), Math.Max(0, k.Rectangle.Size.Height));

                        if (p.X + s.Width > _pictureBox.Width)
                            s.Width = _pictureBox.Width - p.X;

                        if (p.Y + s.Height > _pictureBox.Height)
                            s.Height = _pictureBox.Height - p.Y;

                        k.Rectangle = new Rectangle(p, s);
                    }
                }
            }
        }


        /// <summary>
        /// Base directory 
        /// </summary>
        public string BasePath { get; private set; }

        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                var f = Path.Combine(BasePath, value);
                _background = null;
                _imagePath = null;

                if (!File.Exists(f)) return;

                try
                {
                    _background = Image.FromFile(f);
                    SkinSize = _background.Size;
                    _imagePath = f.Replace(BasePath, String.Empty).TrimStart(new[] { ' ', '\\', '/' });
                }
                catch
                {
                }
            }
        }

        public string Border
        {
            get
            {
                return _borderPoints != null ? String.Join(",", _borderPoints.Select(p => p.X + "," + p.Y).ToList()) : "";
            }
            set
            {
                _borderPoints = String.IsNullOrEmpty(value) ? new[]{new Point(0, 0), new Point(SkinSize.Width, 0), 
                    new Point(SkinSize.Width, SkinSize.Height),new Point(0, SkinSize.Height)} : Utilities.ParsePointArray(value);
            }
        }

        /// <summary>
        /// Find the border of the image
        /// </summary>
        internal void FindBorder()
        {
            _borderPoints = new MarchingSquares().DoMarch(new Bitmap(_background));
        }

        internal VirtualMaximized AddMaximizedRegion(Rectangle _pictureBox)
        {
            var last = RemoveMaximizedRegion(false);

            if (last == null)
                return null;

            var offset = new Point(0, last.Id == 0 ? 0 : _pictureBox.Height - last.Rectangle.Bottom > 0 ? last.Rectangle.Height : 0);
            var v = new VirtualMaximized
            {
                Rectangle = new Rectangle(new Point(last.Rectangle.Location.X + offset.X,
                    last.Rectangle.Location.Y + offset.Y), last.Rectangle.Size),
                Id = last.Id + 1,
                RelativeLocation = offset
            };

            _components.Add(v);
            Refresh(_pictureBox, true);

            return v;
        }

        public VirtualMaximized RemoveMaximizedRegion(bool removeNow)
        {
            var m = -1;
            VirtualMaximized v = null;

            foreach (VirtualMaximized c in GetComponents(new[] { ComponentType.Maximized }))
            {
                if (c.Id > m)
                {
                    m = c.Id;
                    v = c;
                }
            }

            if (removeNow && m > 0)
            {
                _components.Remove(v);
                return null;
            }

            return v;
        }
    }
}
