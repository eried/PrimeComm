using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace PrimeSkin
{
    /// <summary>
    /// Properties of a button in the Prime emulator
    /// </summary>
    public class Component
    {
        public Component(ComponentType type = ComponentType.Key)
        {
            Type = type;
            Selected = false;
            Modifiers = new string[3];
        }

        [ReadOnly(true)]
        internal bool Selected { get; set; }

        [ReadOnly(true), Description("Internal component type used by the PrimeSkin")]
        public ComponentType Type { get; set; }

        [Category("Data"), Description("(Optional) Quoted ASCII representation of the key")]
        public string Value { get; set; }

        [Category("Layout"), Description("Location and size in pixels")]
        public Rectangle Rectangle { get; set; }

        [Category("Data"), Description("Decimal ASCII representations of the key (if they are control characters) in various states (shifted, uppercased, lowercased)")]
        public string[] Modifiers { get; set; }

        [Category("Data"), Description("(Optional) Direct mappings of this key with the keyboard")]
        public string Mappings { get; set; }

        public string Comments { get; set; }

        [Category("Data"), ReadOnly(true), Description("ID of the key (Range: 0-50)")]
        public int Id { get; set; }

        public override string ToString()
        {
            switch (Type)
            {
                case ComponentType.Key:
                    return "Key: " + Id + GetDetails();
                case ComponentType.Screen:
                    return "Screen";
            }
            return String.Empty;
        }

        private string GetDetails()
        {
            var r = new[]
            {
                !String.IsNullOrEmpty(Value) ? "value: " + Value : null,
                !String.IsNullOrEmpty(Comments) ?  "comments: " + Comments : null
            };

            if (r.Length == 0)
                return String.Empty;

            return "  (" + String.Join("; ", r.Where(m => m != null)) + ")";
        }

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
                new Rectangle(Rectangle.X, Rectangle.Y, Rectangle.Width+x, Rectangle.Height+y);

            oldReference = newPosition;
        }
    }

    public enum ComponentType
    {
        None=0, Key, Screen,
    }
}