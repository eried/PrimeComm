using System;
using System.ComponentModel;
using System.Drawing;

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
                    return "Key: " + Id;
                case ComponentType.Screen:
                    return "Screen";
                default:
                    return "(None selected)";
            }
        }
    }

    public enum ComponentType
    {
        None=0, Key, Screen,
    }
}