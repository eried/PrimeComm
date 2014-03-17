using PrimeSkin.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrimeSkin
{
    /// <summary>
    /// Represents, parses and handles a skin for the Prime Emulator
    /// </summary>
    public class SkinManager
    {
        private readonly PictureBox _pictureBox;
        private const int Alpha = 100;
        private readonly Brush _brushLabel = new SolidBrush(Color.FromArgb(255, Color.Black)),
            _brushLabelBackground = new SolidBrush(Color.FromArgb(255, Color.Yellow));

        private readonly Pen _penBorder = new Pen(new SolidBrush(Color.FromArgb(Alpha, Color.Magenta)), 4),
            _penLegend = new Pen(new SolidBrush(Color.FromArgb(255, Color.Blue)), 1),
            _penLegendSelected = new Pen(new SolidBrush(Color.FromArgb(255, Color.White)), 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot };

        private readonly Dictionary<ComponentType, Brush> _brushPerType;
        private readonly Font _fontLabel = new Font("Arial", 8);
        private bool _isMoving, _isResizing;
        private Rectangle _controlMove, _controlResize;
        private Point _lastPosition;
        private VirtualComponent _selected;
        private Size _controlDefaultSize = new Size(20, 20);
        private Skin _skin;
        private readonly UndoRedoManager<Skin> _undo;

        public SkinManager(string filePath, PictureBox pictureBox)
        {
            _pictureBox = pictureBox;

            // Brushes
            _brushPerType = new Dictionary<ComponentType, Brush>
            {
                {ComponentType.Key, new SolidBrush(Color.FromArgb(Alpha, Color.Blue))},
                {ComponentType.Screen, new SolidBrush(Color.FromArgb(Alpha, Color.Red))},
                {ComponentType.Maximized, new SolidBrush(Color.FromArgb(Alpha, Color.Green))}
            };

            // Path
            SkinPath = filePath;

            _undo = new UndoRedoManager<Skin>(10);
            _skin = new Skin(SkinPath);
            _undo.SaveState(_skin);
            _undo.UndoRedoStateChanged += (o, args) => OnComponentsChanged();

            _pictureBox.Size = new Size(_skin.SkinSize.Width * 3, _skin.SkinSize.Height * 3);

            // PictureBox events
            pictureBox.Paint += (o, args) => Paint(args.Graphics);
            pictureBox.MouseDown += pictureBox_MouseDown;
            pictureBox.MouseUp += pictureBox_MouseUp;
            pictureBox.MouseLeave += pictureBox_MouseLeave;
            pictureBox.MouseMove += pictureBox_MouseMove;
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

            _undo.SaveState(_skin);

            OnSelectedComponentPropertiesChanged();
        }

        void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            ReleaseMouseActions();
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

        internal void SelectComponent(VirtualComponent k)
        {
            DeselectAll();
            Selected = k;
        }

        private void DeselectAll()
        {
            Selected = null;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            _pictureBox.Parent.Focus(); // Fix the mouse wheel scroll

            if (Selected != null)
            {
                if (_isMoving)
                {
                    if (!_controlMove.Contains(e.Location))
                        _lastPosition = _controlMove.GetCenter();

                    Selected.Move(ref _lastPosition, e.Location);
                    _skin.Refresh(_pictureBox.ClientRectangle, true);
                    _pictureBox.Invalidate();

                }
                else if (_isResizing)
                {
                    if (!_controlResize.Contains(e.Location))
                        _lastPosition = _controlResize.GetCenter();

                    Selected.Resize(ref _lastPosition, e.Location);
                    _skin.Refresh(_pictureBox.ClientRectangle, true);
                    _pictureBox.Invalidate();
                }
                else
                {
                    // Change the cursor only for the resize, move mouse looks weird
                    _pictureBox.Cursor = _controlResize.Contains(e.Location) ? Cursors.SizeNWSE : Cursors.Default;
                }
            }
            else
                _pictureBox.Cursor = Cursors.Default;
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
                    Selected = _skin.GetComponent(e.Location);
            }
        }

        internal bool Save(string path = "")
        {
            try
            {
                if (!String.IsNullOrEmpty(path) || (!String.IsNullOrEmpty(SkinPath) && File.Exists(SkinPath)))
                {
                    var f = new List<String>(new[] { "# File created by "+Utilities.GetProgramVersion(), "# Part of PrimeComm: http://servicios.ried.cl/primecomm/", "" });
                    _skin.Settings["size"] = _skin.SkinSize.Width + "," + _skin.SkinSize.Height;

                    // Picture
                    if (_skin.Settings.ContainsKey("picture"))
                        _skin.Settings["picture"] = _skin.ImagePath;
                    else
                        _skin.Settings.Add("picture", _skin.ImagePath);

                    f.AddRange(_skin.Settings.Select(c => c.Key + "=" + c.Value).ToList());
                    f.Add("border=" + _skin.Border);

                    const int linesPerGroup = 6;
                    var lines = linesPerGroup;

                    foreach (var c in _skin.GetComponents((ComponentType[]) Enum.GetValues(typeof (ComponentType))))
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
                                        "," + c.Rectangle.Height + (m.Id > 0 ? "," + m.RelativeLocation.X + "," + m.RelativeLocation.Y : ""));
                                }
                                break;

                            case ComponentType.Screen:
                                f.Add("screen=" + c.Rectangle.Left + "," + c.Rectangle.Top + "," + c.Rectangle.Width +
                                      "," + c.Rectangle.Height +
                                      (String.IsNullOrEmpty(c.Comments) ? String.Empty : " #" + c.Comments));
                                break;
                        }
                    }

                    f.Add(String.Empty);
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

        private void DrawComponent(Graphics g, VirtualComponent k)
        {
            g.FillRectangle(_brushPerType[k.Type], k.Rectangle);
            DrawLegend(g, k.Rectangle, k.Type == ComponentType.Key ? "id:" + ((VirtualKey)k).Id : (k.Type == ComponentType.Maximized ? "maximized: " + (((VirtualMaximized)k).Id) : "screen"), k == Selected);
        }

        private void DrawLegend(Graphics g, Rectangle rect, string label = "", bool selected = false)
        {
            DrawLegend(g, rect.Left, rect.Top, rect.Width, rect.Height, label, selected);
        }

        private void DrawLegend(Graphics g, int x, int y, int w, int h, string label = "", bool selected = false)
        {
            if (selected)
            {
                // Draw move and resize controls
                _controlMove = new Rectangle(Math.Max(0, x - _controlDefaultSize.Width), Math.Max(0, y - _controlDefaultSize.Height), _controlDefaultSize.Width, _controlDefaultSize.Height);
                _controlResize = new Rectangle(Math.Min(x + w, _pictureBox.Width - _controlDefaultSize.Width),
                    Math.Min(y + h, _pictureBox.Height - _controlDefaultSize.Height), _controlDefaultSize.Width, _controlDefaultSize.Height);
            }

            g.DrawRectangle(selected ? _penLegendSelected : _penLegend, x, y, Math.Max(1, w), Math.Max(1, h));
            var m = g.MeasureString(label, _fontLabel);
            var rect = new Rectangle((int)(x + ((w - m.Width) / 2)), (int)(y + ((h - m.Height) / 2)), (int)m.Width, (int)m.Height);

            // Draw the label only when is not selected or when is not touching the selection controls
            if (!selected || (!rect.IntersectsWith(_controlMove) && !rect.IntersectsWith(_controlResize)))
            {
                g.FillRectangle(_brushLabelBackground, rect);
                g.DrawString(label, _fontLabel, _brushLabel, rect.Left - 1, rect.Top);
                //g.DrawString(label, _fontLabel, SystemBrushes.Control, rect.Left - 1, rect.Top);
            }

            if (selected)
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

        public ComponentType[] VisibleTypes
        {
            get { return _skin._visibleTypes; }
            set
            {
                if (_skin._visibleTypes != value)
                {
                    if (Selected != null && !value.Contains(Selected.Type))
                        Selected = null;

                    _skin._visibleTypes = value;

                    OnComponentsChanged();
                    _pictureBox.Invalidate();
                }
            }
        }

        /// <summary>
        /// Skin file path
        /// </summary>
        public string SkinPath { get; private set; }

        public VirtualComponent[] Components 
        {
            get { return _skin.Components.ToArray(); }
        }

        public string ImagePath 
        {
            set { _skin.ImagePath = value; }
        }

        public string BasePath 
        {
            get { return _skin.BasePath; }
        }

        public bool CanUndo 
        {
            get { return _undo.CanUndo; }
        }

        public bool CanRedo
        {
            get { return _undo.CanRedo; }
        }

        public event EventHandler<EventArgs> SelectedComponentPropertiesChanged;

        protected virtual void OnSelectedComponentPropertiesChanged()
        {
            EventHandler<EventArgs> handler = SelectedComponentPropertiesChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public event EventHandler<EventArgs> ComponentsChanged;

        protected virtual void OnComponentsChanged()
        {
            EventHandler<EventArgs> handler = ComponentsChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public event EventHandler<SelectedComponentEventArgs> SelectedComponentChanged;

        protected virtual void OnSelectedComponentChange()
        {
            var handler = SelectedComponentChanged;
            if (handler != null) handler(this, new SelectedComponentEventArgs(Selected));
        }

        public void AddMaximizedRegion()
        {
            var v = _skin.AddMaximizedRegion(_pictureBox.ClientRectangle);

            if (v != null)
                Selected = v;

            _undo.SaveState(_skin);
        }

        public void Paint(Graphics g)
        {
            _controlMove = Rectangle.Empty;
            _controlResize = Rectangle.Empty;

            if (_skin._background != null)
                g.DrawImage(_skin._background, 0, 0, _skin.SkinSize.Width, _skin.SkinSize.Height);

            g.DrawPolygon(_penBorder, _skin._borderPoints);

            foreach (var k in _skin.Components.Where(k => k != Selected))
                DrawComponent(g, k);

            if (Selected == null)
                return;

            foreach (var k in _skin.Components.Where(k => k == Selected))
                DrawComponent(g, k);
        }

        public VirtualMaximized RemoveMaximizedRegion(bool removeNow)
        {
            var v = _skin.RemoveMaximizedRegion(removeNow);

            if (removeNow)
            {
                if (v == Selected)
                    Selected = null;

                _undo.SaveState(_skin);
            }

            OnComponentsChanged();
            return v;
        }

        public void Refresh(bool recalculateBounds=false)
        {
            if (!recalculateBounds)
                _pictureBox.Invalidate();
            else
            {
                _skin.Refresh(_pictureBox.ClientRectangle, true);
                _undo.SaveState(_skin);
                _pictureBox.Invalidate();
            }
        }

        public void FindBorder(bool optimized)
        {
            if (optimized)
                _skin.FindBorder();
            else
                _skin.Border = null;

            _undo.SaveState(_skin);
        }

        internal void Undo()
        {
            _undo.Undo();
            _skin = _undo.GetState();
            
            OnComponentsChanged();
            Selected = null;
        }

        internal void Redo()
        {
            _undo.Redo();
            _skin = _undo.GetState();

            OnComponentsChanged();
            Selected = null;
        }
    }
}