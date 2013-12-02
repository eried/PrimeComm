using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace PrimeCmd
{
    static internal class Utilities
    {
        public static void InvokeIfRequired(this Control c, MethodInvoker action)
        {
            if (c.InvokeRequired) c.Invoke(action); else action();
        }

        public static void ShowAbout(Form parent)
        {
            var f = new Form
            {
                Text = "About " + parent.Text,
                Icon = parent.Icon,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                StartPosition = FormStartPosition.CenterParent,
                MinimizeBox = false,
                MaximizeBox = false,
                Font = parent.Font,
                Height = 150,
                Width = 300
            };
            //79, 23
            var l1 = new Label
            {
                Text = "Erwin Ried",
                Width = f.DisplayRectangle.Width,
                TextAlign = ContentAlignment.MiddleCenter
            };
            l1.Top = 25;
            f.Controls.Add(l1);

            const string p = "http://ried.cl";
            var l2 = new LinkLabel
            {
                Text = p,
                Width = f.DisplayRectangle.Width,
                TextAlign = ContentAlignment.MiddleCenter
            };
            l2.Top = l1.Top + 15;
            l2.Click += (o, args) => Process.Start(p);
            f.Controls.Add(l2);


            var b1 = new Button {Text = "OK", Width = 79, Height = 23};

            b1.Location = new System.Drawing.Point(f.ClientRectangle.Right - b1.Width - 12,
                f.ClientRectangle.Bottom - b1.Height - 12);
            b1.Click += (o, args) => f.Close();
            f.Controls.Add(b1);
            f.ShowDialog();
        }
    }
}