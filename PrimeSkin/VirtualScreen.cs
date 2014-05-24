using System;
using System.ComponentModel;
using System.Drawing;

namespace PrimeSkin
{
    /// <summary>
    /// Represents the Screen in the skin file
    /// </summary>
    [Serializable]
    public class VirtualScreen : VirtualComponent
    {
        public VirtualScreen()
        {
            Type = ComponentType.Screen;
            LockRatio = true;
        }

        public override string ToString()
        {
            return "Screen";
        }

        [Category("Layout"), Description("Calculates the height of the screen to match the required 4:3 proportion of the emulator")]
        public bool LockRatio { get; set; }

        internal override void RecalculateLayout(Rectangle bounds)
        {
            // Do base calculations first
            base.RecalculateLayout(bounds);

            if (!LockRatio)
                return;

            // Adjust to 4:3 restriction
            int w = Rectangle.Width/4, h = Rectangle.Height/3;

            if(w==h)
                return;

            var s = new Rectangle(Rectangle.Location,new Size(Rectangle.Width, w * 3));
            if (s.Bottom <= bounds.Bottom && s.Right <= bounds.Right)
                Rectangle = s;
            else
                Rectangle = new Rectangle(Rectangle.Location, new Size(h * 4, Rectangle.Height));
        }
    }
}