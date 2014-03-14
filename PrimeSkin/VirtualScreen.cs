using System;

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
        }

        public override string ToString()
        {
            return "Screen";
        }
    }
}