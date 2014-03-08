using System.Drawing;

namespace PrimeSkin
{
    /// <summary>
    /// Properties of a button in the Prime emulator
    /// </summary>
    public class KeyDefinition
    {
        private bool _dirty = true;
        private Rectangle _rectangle;

        public KeyDefinition()
        {
            Modifiers = new string[3];
        }

        public string Value { get; set; }
        public int Left { get; set; }
        public int Up { get; set; }
        public int Down { get; set; }
        public int Right { get; set; }

        public Rectangle ClientRectangle
        {
            get
            {
                if (!_dirty) return _rectangle;

                _rectangle = new Rectangle(Left, Up, Right - Left, Down - Up);
                _dirty = false;
                return _rectangle;
            }
        }

        public string[] Modifiers { get; set; }
        public string Mappings { get; set; }
        public string Comments { get; set; }
    }
}