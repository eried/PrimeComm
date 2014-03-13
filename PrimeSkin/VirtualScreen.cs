namespace PrimeSkin
{
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