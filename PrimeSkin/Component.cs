using System;
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

        public bool Selected { get; set; }
        public ComponentType Type { get; set; }
        public string Value { get; set; }
        public Rectangle ClientRectangle { get; set; }
        public string[] Modifiers { get; set; }
        public string Mappings { get; set; }
        public string Comments { get; set; }
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