using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using PrimeSkin.Properties;

namespace PrimeSkin
{
    [Serializable]
    public class Skin : ICloneable
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

            if (!File.Exists(filePath))
                return;

            BasePath = Path.GetDirectoryName(filePath);

            var keyRegex = new Regex(@"(?<value>"".*"")?,?(?<id>[0-9]+),(?<left>[0-9]+),(?<top>[0-9]+),(?<right>[0-9]+),(?<bottom>[0-9]+),\{(?<modifier1>\d?[\d,]*)\},\{(?<modifier2>\d?[\d,]*)\},\{(?<modifier3>\d?[\d,]*)\}(?:,\[(?<mappings>.*)\])?(?:[\t #]+(?<comment>.*))?$");
            var generalRegex = new Regex(@"(?<value>.*?) ?(?:[\t #]+(?<comment>.*))?$");
            foreach (
                var p in
                    from l in File.ReadAllLines(filePath, Encoding.Default)
                    where l.Contains('=')
                    select l.Split(new[] {'='}, 2))
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
                                Rectangle =
                                    Utilities.ParseRectangle(
                                        p[1].Substring(m.Groups["left"].Index,
                                            (m.Groups["bottom"].Index + m.Groups["bottom"].Length) -
                                            m.Groups["left"].Index), true),
                                Modifiers =
                                    new[]
                                    {
                                        m.Groups["modifier1"].Value, m.Groups["modifier2"].Value,
                                        m.Groups["modifier3"].Value
                                    },
                                Mappings = m.Groups["mappings"].Value,
                                Comments = m.Groups["comment"].Value
                            });
                    }
                        break;

                    case "border":
                        Border = generalRegex.Match(p[1]).Groups["value"].Value;
                        break;

                    case "picture":
                        ImagePath = generalRegex.Match(p[1]).Groups["value"].Value;
                        break;

                    case "MAXIMIZED":
                    {
                        var m = generalRegex.Match(p[1]);
                        var v = m.Groups["value"].Value;
                        var s = v.Split(new[] {','});
                        var comments = m.Groups["comment"].Value;

                        switch (s.Length)
                        {
                            case (4):
                                _components.Add(new VirtualMaximized
                                {
                                    Rectangle = Utilities.ParseRectangle(v),
                                    Id = 0,
                                    Comments = comments
                                });
                                break;

                            case (6):
                                _components.Add(new VirtualMaximized
                                {
                                    Rectangle = Utilities.ParseRectangle(String.Join(",", s, 0, 4)),
                                    RelativeLocation = Utilities.ParsePoint(String.Join(",", s, 4, 2)),
                                    Id = int.Parse(p[0].Remove(0, k.Length)),
                                    Comments = comments
                                });
                                break;
                        }

                    }
                        break;

                    case "screen":
                    {
                        var m = generalRegex.Match(p[1]);
                        _components.Add(new VirtualScreen
                        {
                            Rectangle = Utilities.ParseRectangle(m.Groups["value"].Value),
                            Comments = m.Groups["comment"].Value
                        });
                    }
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

        internal void RecalculateLayouts(Rectangle bounds)
        {
            foreach (var k in Components)
                k.RecalculateLayout(bounds);
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

        internal VirtualMaximized AddMaximizedRegion(Rectangle bounds)
        {
            var last = RemoveMaximizedRegion(false);

            if (last == null)
                return null;

            var offset = new Point(0, last.Id == 0 ? 0 : bounds.Height - last.Rectangle.Bottom > 0 ? last.Rectangle.Height : 0);
            var v = new VirtualMaximized
            {
                Rectangle = new Rectangle(new Point(last.Rectangle.Location.X + offset.X,
                    last.Rectangle.Location.Y + offset.Y), last.Rectangle.Size),
                Id = last.Id + 1,
                RelativeLocation = offset
            };

            _components.InsertAfter(last,v);
            RecalculateLayouts(bounds);

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

        public object Clone()
        {
            return GenericCopier<Skin>.DeepCopy(this);
        }
    }

    public static class GenericCopier<T>
    {
        public static T DeepCopy(object objectToCopy)
        {
            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, objectToCopy);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return (T)binaryFormatter.Deserialize(memoryStream);
            }
        }
    }
}
