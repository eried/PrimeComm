using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace PrimeSkin
{
    static internal class Utilities
    {
        internal static Point GetCenter(this Rectangle control)
        {
            return new Point(control.X + (control.Width/2), control.Y + (control.Height/2));
        }

        internal static Rectangle ParseRectangle(string s, bool secondTupleIsRightDown = false)
        {
            var p = s.Split(new[] { ',' });
            int x1 = Int32.Parse(p[0]), y1 = Int32.Parse(p[1]), x2 = Int32.Parse(p[2]), y2 = Int32.Parse(p[3]);

            if (!secondTupleIsRightDown) return new Rectangle(x1, y1, x2, y2); // Direct output

            int xmin = Math.Min(x1, x2), ymin = Math.Min(y1, y2);
            return new Rectangle(xmin, ymin, Math.Max(x1, x2) - xmin,Math.Max(y1, y2) - ymin);
        }

        internal static Rectangle Inflate(this Rectangle rectangle, int size)
        {
            if (size == 0 || (rectangle.Width >size && rectangle.Height > size))
                return rectangle;

            var r = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
            r.Inflate(size, size);
            return r;
        }

        internal static Point[] ParsePointArray(string s)
        {
            var p = s.Split(new[] { ',' });
            var tmp = new List<Point>();
            for (var i = 0; i < p.Length; i += 2)
                tmp.Add(new Point(Int32.Parse(p[i]), Int32.Parse(p[i + 1])));

            return tmp.ToArray();
        }

        public static Point ParsePoint(string s)
        {
            var p = s.Split(new[] {','}, 2);

            if (p.Length < 2)
                return Point.Empty;

            return new Point(Int32.Parse(p[0]), Int32.Parse(p[1]));
        }

        internal static string GetProgramVersion()
        {
            var v = Assembly.GetExecutingAssembly().GetName().Version;
            return String.Format("{0} v{1} b{2}", Application.ProductName, v.ToString(2), v.Build);
        }
    }
}