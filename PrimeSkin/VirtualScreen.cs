namespace PrimeSkin
{
    /// <summary>
    /// Represents the Screen in the skin file
    /// </summary>
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