using PrimeSkin.Properties;
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
        private readonly Brush _brushLabel = new SolidBrush(Color.FromArgb(255, Color.Black)),
            _brushLabelBackground = new SolidBrush(Color.FromArgb(255, Color.Yellow));

        private readonly Pen _penBorder = new Pen(new SolidBrush(Color.FromArgb(Alpha, Color.Magenta)), 4),
            _penLegend = new Pen(new SolidBrush(Color.FromArgb(255, Color.Blue)), 1),
            _penLegendSelected = new Pen(new SolidBrush(Color.FromArgb(255, Color.White)), 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot };

        private readonly Dictionary<ComponentType, Brush> _brushPerType;
        private Point[] _borderPoints;
        private readonly Font _fontLabel = new Font("Arial", 8);
        private VirtualComponent _selected;
        private string _imagePath;
        private Image _background;
        public event EventHandler<SelectedComponentEventArgs> SelectedComponentChanged;
        private Rectangle _controlMove, _controlResize;
        private bool _isMoving, _isResizing;
        private Point _lastPosition;
        private Size _controlDefaultSize = new Size(20, 20);
        private ComponentType[] _visibleTypes;
        private List<VirtualComponent> _components;
        private Size _skinSize;

        public Skin(string filePath, PictureBox pictureBox)
        {
            _pictureBox = pictureBox;

            // Brushes
            _brushPerType = new Dictionary<ComponentType, Brush>
            {
                {ComponentType.Key, new SolidBrush(Color.FromArgb(Alpha, Color.Blue))},
                {ComponentType.Screen, new SolidBrush(Color.FromArgb(Alpha, Color.Red))},
                {ComponentType.Maximized, new SolidBrush(Color.FromArgb(Alpha, Color.Green))}
            };

            // Base path
            Settings = new Dictionary<string, string>();
            _components = new List<VirtualComponent>();

            SkinPath = filePath;
            BasePath = Path.GetDirectoryName(filePath);

            var keyRegex = new Regex(@"(?<value>"".*"")?,?(?<id>[0-9]+),(?<left>[0-9]+),(?<top>[0-9]+),(?<right>[0-9]+),(?<bottom>[0-9]+),\{(?<modifier1>\d?[\d,]*)\},\{(?<modifier2>\d?[\d,]*)\},\{(?<modifier3>\d?[\d,]*)\}(?:,\[(?<mappings>.*)\])?(?:[\t #]+(?<comment>.*))?$");
            foreach (var p in from l in File.ReadAllLines(filePath, Encoding.Default) where l.Contains('=') select l.Split(new[] {'='}, 2))
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
                                Rectangle =Utilities.ParseRectangle(p[1].Substring(m.Groups["left"].Index, (m.Groups["bottom"].Index + m.Groups["bottom"].Length) - m.Groups["left"].Index),true),
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

                    case "MAXIMIZED":
                    {
                        var s = p[1].Split(new[] {','});

                        switch (s.Length)
                        {
                            case(4):
                                _components.Add(new VirtualMaximized
                                {
                                    Rectangle = Utilities.ParseRectangle(p[1]),
                                    Id = 0
                                });
                                break;

                            case(6):
                                _components.Add(new VirtualMaximized
                                {
                                    Rectangle = Utilities.ParseRectangle(String.Join(",",s,0,4)),
                                    RelativeLocation = Utilities.ParsePoint(String.Join(",", s, 4, 2)),
                                    Id  = int.Parse(p[0].Remove(0,k.Length))
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

            // PictureBox events
            SkinSize = GetSetting<Size>("size");
            pictureBox.Paint += (o, args) => Paint(args.Graphics);
            pictureBox.MouseDown += pictureBox_MouseDown;
            pictureBox.MouseUp += pictureBox_MouseUp;
            pictureBox.MouseLeave += pictureBox_MouseLeave;
            pictureBox.MouseMove += pictureBox_MouseMove;
        }

        public Size SkinSize
        {
            get { return _skinSize; }
            set
            {
                _skinSize = value;
                _pictureBox.Size = new Size(SkinSize.Width * 3, SkinSize.Height * 3);
            }
        }

        void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            ReleaseMouseActions();
        }

        private void ReleaseMouseActions()
        {
            if (!_isMoving && !_isResizing) return;

            _isMoving = false;
            _isResizing = false;
            OnSelectedComponentPropertiesChanged();
        }

        void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            ReleaseMouseActions();
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            _pictureBox.Parent.Focus(); // Fix the mouse wheel scroll

            if (Selected == null) return;

            if (_isMoving)
            {
                if (!_controlMove.Contains(e.Location))
                    _lastPosition = _controlMove.GetCenter();

                Selected.Move(ref _lastPosition, e.Location);
                Refresh(true);

            }
            else if (_isResizing)
            {
                if (!_controlResize.Contains(e.Location))
                    _lastPosition = _controlResize.GetCenter();

                Selected.Resize(ref _lastPosition, e.Location);
                Refresh(true);
            }
            else
            {
                // Change the cursor only for the resize, move mouse looks weird
                _pictureBox.Cursor = _controlResize.Contains(e.Location) ? Cursors.SizeNWSE : Cursors.Default;
            }

        }

        void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Move and resize
                _lastPosition = e.Location;
                _isMoving = _controlMove.Contains(e.Location);
                if (_isMoving) return;

                // Selected
                _isResizing = _controlResize.Contains(e.Location);

                if(!_isResizing)
                    Selected = GetComponent(e.Location);
            }
        }

        public VirtualComponent Selected
        {
            get 
            { 
                return _selected; 
            }
            set 
            { 
                _selected = value;
                _pictureBox.Invalidate();
                OnSelectedComponentChange();
            }
        }

        public List<VirtualComponent> Components
        {
            get { return GetComponents(_components, VisibleTypes); }
            set { _components = value; }
        }

        internal List<VirtualComponent> GetComponents(List<VirtualComponent> components, ComponentType[] types)
        {
            var t = new List<VirtualComponent>();
            if (types == null || types.Length == 0)
                    return t;

            t.AddRange(_components.Where(c => types.Contains(c.Type)));

            return t;
        }

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
                    return (T)(object)Utilities.ParseRectangle(Settings[key]);
            }

            return default(T);
        }

        public void Paint(Graphics g)
        {
            _controlMove = Rectangle.Empty;
            _controlResize = Rectangle.Empty;

            if(_background!=null)
                g.DrawImage(_background, 0, 0, SkinSize.Width, SkinSize.Height);

            g.DrawPolygon(_penBorder, _borderPoints);
            
            foreach (var k in Components.Where(k => k!=Selected))
                DrawComponent(g, k);

            foreach (var k in Components.Where(k => k==Selected))
                DrawComponent(g, k);

        }

        private void DrawComponent(Graphics g, VirtualComponent k)
        {
            g.FillRectangle(_brushPerType[k.Type], k.Rectangle);
            DrawLegend(g, k.Rectangle, k.Type == ComponentType.Key ? "id:" + ((VirtualKey)k).Id : (k.Type == ComponentType.Maximized?"maximized: "+(((VirtualMaximized)k).Id):"screen"), k==Selected);
        }

        private void DrawLegend(Graphics g, Rectangle rect, string label = "", bool selected = false)
        {
            DrawLegend(g, rect.Left, rect.Top, rect.Width, rect.Height, label, selected);
        }

        private void DrawLegend(Graphics g, int x, int y, int w, int h, string label="", bool selected=false)
        {
            if (selected)
            {
                // Draw move and resize controls
                _controlMove = new Rectangle(Math.Max(0, x - _controlDefaultSize.Width), Math.Max(0, y - _controlDefaultSize.Height),_controlDefaultSize.Width, _controlDefaultSize.Height);
                _controlResize = new Rectangle(Math.Min(x + w, _pictureBox.Width - _controlDefaultSize.Width),
                    Math.Min(y + h, _pictureBox.Height - _controlDefaultSize.Height), _controlDefaultSize.Width, _controlDefaultSize.Height);
            }

            g.DrawRectangle(selected?_penLegendSelected:_penLegend, x, y, Math.Max(1,w), Math.Max(1,h));
            var m = g.MeasureString(label, _fontLabel);
            var rect = new Rectangle((int)(x + ((w - m.Width) / 2)), (int)(y + ((h - m.Height) / 2)), (int)m.Width, (int)m.Height);

            // Draw the label only when is not selected or when is not touching the selection controls
            if (!selected || (!rect.IntersectsWith(_controlMove) && !rect.IntersectsWith(_controlResize)))
            {
                g.FillRectangle(_brushLabelBackground, rect);
                g.DrawString(label, _fontLabel, _brushLabel, rect.Left - 1, rect.Top);
                //g.DrawString(label, _fontLabel, SystemBrushes.Control, rect.Left - 1, rect.Top);
            }

            if(selected)
            {
                // Draw the controls
                g.FillRectangle(SystemBrushes.Control, _controlResize);
                g.DrawRectangle(SystemPens.ControlDark, _controlResize);
                g.DrawImage(Resources.resize, _controlResize.Location.X + 2, _controlResize.Location.Y + 2);

                g.FillRectangle(SystemBrushes.Control, _controlMove);
                g.DrawRectangle(SystemPens.ControlDark, _controlMove);
                g.DrawImage(Resources.move, _controlMove.Location.X + 2, _controlMove.Location.Y + 2);
            }
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

        internal void SelectComponent(VirtualComponent k)
        {
            DeselectAll();
            Selected = k;
        }

        private void DeselectAll()
        {
            Selected = null;
        }

        protected virtual void OnSelectedComponentChange()
        {
            var handler = SelectedComponentChanged;
            if (handler != null) handler(this, new SelectedComponentEventArgs(Selected));
        }

        internal void Refresh(bool recalculateBounds=false)
        {
            if (recalculateBounds)
            {
                foreach (var k in Components)
                {
                    if (!_pictureBox.ClientRectangle.Contains(k.Rectangle) || k.Rectangle.Height <0 || k.Rectangle.Width < 0)
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

                if (!File.Exists(f)) return;

                try
                {
                    _background = Image.FromFile(f);
                    SkinSize = _background.Size;
                    _imagePath = f.Replace(BasePath,String.Empty).TrimStart(new [] { ' ', '\\', '/'}); 
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
                return _borderPoints != null? String.Join(",",_borderPoints.Select(p => p.X + "," + p.Y).ToList()):""; 
            }
            set 
            {
                _borderPoints = String.IsNullOrEmpty(value) ? new[]{new Point(0, 0), new Point(SkinSize.Width, 0), 
                    new Point(SkinSize.Width, SkinSize.Height),new Point(0, SkinSize.Height)} : Utilities.ParsePointArray(value);
            }
        }

        public ComponentType[] VisibleTypes
        {
            get { return _visibleTypes; }
            set 
            {
                if (_visibleTypes != value)
                {
                    if (Selected != null && !value.Contains(Selected.Type))
                        Selected = null;

                    _visibleTypes = value;

                    OnComponentsChanged();
                    Refresh();
                }
            }
        }

        internal bool Save(string path="")
        {
            try
            {
                if (!String.IsNullOrEmpty(path) || (!String.IsNullOrEmpty(SkinPath) && File.Exists(SkinPath)))
                {
                    var f = new List<String>(new[]{"# File created by PrimeScreen", "# Part of PrimeComm: http://servicios.ried.cl/primecomm/", ""});
                    Settings["size"] = SkinSize.Width + "," + SkinSize.Height;

                    // Picture
                    if (Settings.ContainsKey("picture"))
                        Settings["picture"] = ImagePath;
                    else
                        Settings.Add("picture", ImagePath);

                    f.AddRange(Settings.Select(c => c.Key + "=" + c.Value).ToList());
                    f.Add("border=" + Border);

                    const int linesPerGroup = 6;
                    var lines = linesPerGroup;

                    foreach (var c in _components)
                    {
                        switch (c.Type)
                        {
                            case ComponentType.Key:
                            {
                                var key = (VirtualKey)c;
                                var value = String.IsNullOrEmpty(key.Value) ? String.Empty : key.Value + ",";
                                var mapped = String.IsNullOrEmpty(key.Mappings) ? String.Empty : ",[" + key.Mappings + "]";
                                var comments = String.IsNullOrEmpty(c.Comments) ? String.Empty : " #" + c.Comments;

                                if (++lines >= linesPerGroup)
                                {
                                    f.Add(String.Empty);
                                    lines = 0;
                                }

                                f.Add(String.Format("key={0}{1},{2},{3},{4},{5},{{{6}}},{{{7}}},{{{8}}}{9}{10}",
                                    value, key.Id, c.Rectangle.Left, c.Rectangle.Top, c.Rectangle.Right,
                                    c.Rectangle.Bottom,
                                    key.Modifiers[0], key.Modifiers[1], key.Modifiers[2], mapped, comments));
                                break;
                            }

                            case ComponentType.Maximized:
                            {
                                var m = (VirtualMaximized)c;
                                f.Add("MAXIMIZED=" + c.Rectangle.Left + "," + c.Rectangle.Top + "," + c.Rectangle.Width +
                                    "," + c.Rectangle.Height + (m.Id>0?","+m.RelativeLocation.X+","+m.RelativeLocation.Y:""));
                            }
                                break;

                            case ComponentType.Screen:
                                f.Add("screen=" + c.Rectangle.Left + "," + c.Rectangle.Top + "," + c.Rectangle.Width +
                                      "," + c.Rectangle.Height +
                                      (String.IsNullOrEmpty(c.Comments) ? String.Empty : " #" + c.Comments));
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

        public event EventHandler<EventArgs> SelectedComponentPropertiesChanged;

        protected virtual void OnSelectedComponentPropertiesChanged()
        {
            EventHandler<EventArgs> handler = SelectedComponentPropertiesChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        internal void AddMaximizedRegion(bool focus)
        {
            var last = RemoveMaximizedRegion(false);

            if (last == null)
                return;

            var offset = new Point(0, last.Id == 0 ? 0 : _pictureBox.Height - last.Rectangle.Bottom > 0? last.Rectangle.Height:0);
            var v = new VirtualMaximized
            {
                Rectangle = new Rectangle(new Point(last.Rectangle.Location.X + offset.X,
                    last.Rectangle.Location.Y + offset.Y), last.Rectangle.Size),
                Id = last.Id + 1,
                RelativeLocation = offset
            };

            _components.Add(v);
            OnComponentsChanged();

            if (focus)
                Selected = v;

            Refresh(true);
        }

        public VirtualMaximized RemoveMaximizedRegion(bool removeNow)
        {
            var m = -1;
            VirtualMaximized v = null;

            foreach (VirtualMaximized c in GetComponents(Components, new[] {ComponentType.Maximized}))
            {
                if (c.Id > m)
                {
                    m = c.Id;
                    v = c;
                }
            }

            if (removeNow && m>0)
            {
                if (v == Selected)
                    Selected = null;

                _components.Remove(v);
                OnComponentsChanged();
            }

            return v;
        }

        public event EventHandler<EventArgs> ComponentsChanged;

        protected virtual void OnComponentsChanged()
        {
            EventHandler<EventArgs> handler = ComponentsChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}