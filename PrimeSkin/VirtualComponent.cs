using System;
using System.ComponentModel;
using System.Drawing;

namespace PrimeSkin
{
    /// <summary>
    /// Generic class for any component in the skin file
    /// </summary>
    
    [Serializable]
    public class VirtualComponent
    {
        [Category("Layout"), Description("Location and size in pixels")]
        public Rectangle Rectangle { get; set; }

        [ReadOnly(true), Description("Internal component type used by the PrimeSkin")]
        protected internal ComponentType Type { get; set; }

        internal void Move(ref Point oldReference, Point newPosition, Rectangle bounds)
        {
            Transform(ref oldReference, newPosition, bounds);
        }

        internal void Resize(ref Point oldReference, Point newPosition, Rectangle bounds)
        {
            Transform(ref oldReference, newPosition, bounds, false);
        }

        internal void Transform(ref Point oldReference, Point newPosition, Rectangle bounds, bool isMove = true)
        {
            var x = newPosition.X - oldReference.X;
            var y = newPosition.Y - oldReference.Y;

            Rectangle = isMove ? new Rectangle(Rectangle.X + x, Rectangle.Y + y, Rectangle.Width, Rectangle.Height) :
                new Rectangle(Rectangle.X, Rectangle.Y, Rectangle.Width + x, Rectangle.Height + y);

            oldReference = newPosition;
            RecalculateLayout(bounds);
        }

        public string Comments { get; set; }

        internal virtual void RecalculateLayout(Rectangle bounds)
        {
            if (!bounds.Contains(Rectangle) || Rectangle.Height < 0 || Rectangle.Width < 0)
            {
                // Adjust position and size
                var p = new Point(Math.Min(bounds.Width, Math.Max(0, Rectangle.Location.X)),
                    Math.Min(bounds.Height, Math.Max(Rectangle.Location.Y, 0)));

                var s = new Size(Math.Max(0, Rectangle.Size.Width), Math.Max(0, Rectangle.Size.Height));

                if (p.X + s.Width > bounds.Width)
                    s.Width = bounds.Width - p.X;

                if (p.Y + s.Height > bounds.Height)
                    s.Height = bounds.Height - p.Y;

                Rectangle = new Rectangle(p, s);
            }
        }
    }
}