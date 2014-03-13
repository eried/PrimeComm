using System;

namespace PrimeSkin
{
    public class SelectedComponentEventArgs : EventArgs
    {
        public VirtualComponent Selected { get; set; }

        public SelectedComponentEventArgs(VirtualComponent selected)
        {
            Selected = selected;
        }
    }
}