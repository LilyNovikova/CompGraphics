using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class DrawForm : Form
    {
        private static bool side = true;
        public DrawForm()
        {
            InitializeComponent();
        }

        private void DrawTangentBtn_Click(object sender, EventArgs e)
        {
            Canvas.Refresh();
        }

        private void PivotPointAroundPoint(double alpha, int centerX, int centerY, int pointX, int pointY, out int newX, out int newY)
        {
            newX = Convert.ToInt32((pointX - centerX) * Math.Cos(alpha) - (pointY - centerY) * Math.Sin(alpha) + centerX);
            newY = Convert.ToInt32((pointX - centerX) * Math.Sin(alpha) + (pointY - centerY) * Math.Cos(alpha) + centerY);
        }


        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            //circle A
            var aX = Decimal.ToInt32(pointAXUpdn.Value);
            var aY = Decimal.ToInt32(pointAYUpdn.Value);
            var aR = Decimal.ToInt32(radiusAUpdn.Value);
            e.Graphics.DrawEllipse(Pens.Green, aX - aR, aY - aR, aR * 2, aR * 2);

            //circle B
            var bX = Decimal.ToInt32(pointBXUpdn.Value);
            var bY = Decimal.ToInt32(pointBYUpdn.Value);
            var bR = Decimal.ToInt32(radiusBUpdn.Value);
            e.Graphics.DrawEllipse(Pens.Blue, bX - bR, bY - bR, bR * 2, bR * 2);

            //point of intersection of two tangents
            var oX = aX + (bX - aX) * aR / (aR + bR);
            var oY = aY + (bY - aY) * aR / (aR + bR);

            var AOLength = Math.Sqrt((oY - aY) * (oY - aY) + (oX - aX) * (oX - aX));
            var ABLength = Math.Sqrt((bY - aY) * (bY - aY) + (bX - aX) * (bX - aX));

            //check if circles are intersecting
            if (ABLength > aR + bR)
            {
                label7.Text = "";
                var alpha = Math.PI / 2 - Math.Asin(aR / AOLength);

                var aX1 = aX + Convert.ToInt32((oX - aX) * (aR / AOLength));
                var aY1 = aY + Convert.ToInt32((oY - aY) * (aR / AOLength));
                var bX1 = bX + Convert.ToInt32((oX - bX) * (bR / AOLength));
                var bY1 = bY + Convert.ToInt32((oY - bY) * (bR / AOLength));

                if (side == false)
                {
                    PivotPointAroundPoint(alpha, aX, aY, aX1, aY1, out aX1, out aY1);
                    PivotPointAroundPoint(alpha, bX, bY, bX1, bY1, out bX1, out bY1);
                    e.Graphics.DrawLine(Pens.Red, aX1, aY1, bX1, bY1);
                }
                else
                {
                    PivotPointAroundPoint(-alpha, aX, aY, aX1, aY1, out aX1, out aY1);
                    PivotPointAroundPoint(-alpha, bX, bY, bX1, bY1, out bX1, out bY1);
                    e.Graphics.DrawLine(Pens.Red, aX1, aY1, bX1, bY1);
                }
            }
            else
            {
                label7.Text = "Circles are intersecting.\nPlease, change radiuses or the distance between the centers.";
            }
        }

        private void FlipSideBtn_Click(object sender, EventArgs e)
        {
            if (side == true)
            {
                side = false;
                SideLbl.Text = "right side";
            }
            else
            {
                side = true;
                SideLbl.Text = " left side";
            }
            Canvas.Refresh();
        }
    }
}
