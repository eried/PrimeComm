using System;
using System.ComponentModel;
using System.Drawing;

namespace PrimeSkin
{
    /// <summary>
    /// Generic class for any component in the skin file
    /// </summary>
    public class VirtualComponent
    {
        [Category("Layout"), Description("Location and size in pixels")]
        public Rectangle Rectangle { get; set; }

        [ReadOnly(true), Description("Internal component type used by the PrimeSkin")]
        protected internal ComponentType Type { get; set; }

        internal void Move(ref Point oldReference, Point newPosition)
        {
            Transform(ref oldReference, newPosition);
        }

        internal void Resize(ref Point oldReference, Point newPosition)
        {
            Transform(ref oldReference, newPosition, false);
        }

        internal void Transform(ref Point oldReference, Point newPosition, bool isMove = true)
        {
            var x = newPosition.X - oldReference.X;
            var y = newPosition.Y - oldReference.Y;

            Rectangle = isMove ? new Rectangle(Rectangle.X + x, Rectangle.Y + y, Rectangle.Width, Rectangle.Height) :
                new Rectangle(Rectangle.X, Rectangle.Y, Rectangle.Width + x, Rectangle.Height + y);

            oldReference = newPosition;
        }

        public string Comments { get; set; }

    }
}