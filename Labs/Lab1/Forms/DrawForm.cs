using Framework.Models;
using Framework.Utils;
using Lab1.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab1.Forms
{
    public partial class DrawForm : Form
    {
        private const int centerPointRad = 2;
        private static bool side = true;
        public DrawForm()
        {
            InitializeComponent();
        }

        private void DrawTangentBtn_Click(object sender, EventArgs e)
        {
            Canvas.Refresh();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            //get circle A
            var circleA = Circle.FromUpDowns(pointAXUpdn, pointAYUpdn, radiusAUpdn);
            circleA.Name = "A";

            //get circle B
            var circleB = Circle.FromUpDowns(pointBXUpdn, pointBYUpdn, radiusBUpdn);
            circleB.Name = "B";

            //check if circles are intersecting and find tangent
            if (circleA.Center.GetDistanсe(circleB.Center) > circleA.Radius + circleB.Radius)
            {
                WarningLbl.Text = string.Empty;
                var tangentSection = circleA.GetCommonTangentPoints(circleB, side);
                e.Graphics.DrawSection(Pens.Red, tangentSection);
            }
            else
            {
                WarningLbl.Text = "Circles are intersecting.\nPlease, change radiuses or the distance between the centers.";
            }
            //draw circles
            e.Graphics.DrawEllipse(Pens.Green, circleA);
            e.Graphics.FillEllipse(Brushes.Black, circleA.Center, centerPointRad);
            e.Graphics.DrawString(circleA.Name, SystemFonts.CaptionFont, Brushes.Black, circleA.Center);

            e.Graphics.DrawEllipse(Pens.Blue, circleB);
            e.Graphics.FillEllipse(Brushes.Black, circleB.Center, centerPointRad);
            e.Graphics.DrawString(circleB.Name, SystemFonts.CaptionFont, Brushes.Black, circleB.Center);
        }

        private void FlipSideBtn_Click(object sender, EventArgs e)
        {
            SideLbl.Text = side ? "right side" : "left side";
            side = !side;
            Canvas.Refresh();
        }
    }
}
