using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace PrimeSkin
{
    public class VirtualMaximized : VirtualComponent
    {
        [Category("Layout"),
         Description("Relative location of this Maximized region (if this region ID is 0, this will be always 0,0)")]
        public Point RelativeLocation { get; set; }

        [Category("Data"), ReadOnly(true), Description("ID of the Maximized region")]
        public int Id { get; set; }

        public VirtualMaximized()
        {
            Type = ComponentType.Maximized;
        }

        public override string ToString()
        {
            return "Maximized region" + (Id > 0 ? " (" + Id + ")" : " (Base)");
        }
    }
}