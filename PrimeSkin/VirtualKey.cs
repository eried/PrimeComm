using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PrimeSkin
{
    /// <summary>
    /// Properties of a button in the Prime emulator
    /// </summary>
    public class VirtualKey : VirtualComponent
    {
        public VirtualKey()
        {
            Type = ComponentType.Key;
            Modifiers = new string[3];
        }

        [Category("Data"), Description("(Optional) Quoted ASCII representation of the key")]
        public string Value { get; set; }

        [Category("Data"), Description("Decimal ASCII representations of the key (if they are control characters) in various states (shifted, uppercased, lowercased)")]
        public string[] Modifiers { get; set; }

        [Category("Data"), Description("(Optional) Direct mappings of this key with the keyboard")]
        public string Mappings { get; set; }

        [Category("Data"), ReadOnly(true), Description("ID of the key (Range: 0-50)")]
        public int Id { get; set; }

        public override string ToString()
        {
            return "Key: " + Id + GetDetails();
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
    }
}