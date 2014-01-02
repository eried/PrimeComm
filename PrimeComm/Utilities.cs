using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace PrimeComm
{
    static internal class Utilities
    {
        public static void InvokeIfRequired(this Control c, MethodInvoker action)
        {
            if (c.InvokeRequired) c.Invoke(action); else action();
        }
    }
}