using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Models
{
    public class Coordinates3D
    {
        private int scrHeight;
        private int scrWidth;

        private readonly Point3 startXEdge;
        private readonly Point3 startYEdge;
        private readonly Point3 startZEdge;

        public Point3 XEdge { get; private set; }
        public Point3 YEdge { get; private set; }
        public Point3 ZEdge { get; private set; }
        public Point3 Center { get; private set; }

        public Coordinates3D(int screenWidth = 0, int screenHeight = 0)
        {
            scrHeight = screenHeight;
            scrWidth = screenWidth;

            Center = new Point3(0, 0, 0);
            startXEdge = new Point3(scrWidth / 2, 0, 0);
            startYEdge = new Point3(0, scrHeight / 2, 0);
            startZEdge = new Point3(0, 0, scrWidth / 2);
            XEdge = startXEdge;
            YEdge = startYEdge;
            ZEdge = startZEdge;
        }

        public void Turn(Point3.Axes axis, double angle)
        {
            XEdge = startXEdge.TurnAroundAxis(axis, angle);
            YEdge = startYEdge.TurnAroundAxis(axis, angle);
            ZEdge = startZEdge.TurnAroundAxis(axis, angle);
        }

        public void Draw(Graphics g, Pen pen, Brush brush, Font font, int offset)
        {
            var center = Center.GetDrawingPoint(scrWidth, scrHeight);
            //X
            g.DrawLine(pen, center, XEdge.GetDrawingPoint(scrWidth, scrHeight));
            g.DrawString("X", font, brush, new Point3(XEdge.X - offset, XEdge.Y, XEdge.Z).GetDrawingPoint(scrWidth, scrHeight));
            //Y
            g.DrawLine(pen, YEdge.GetDrawingPoint(scrWidth, scrHeight), center);
            g.DrawString("Y", font, brush, scrWidth / 2, 0);
            //Z
            g.DrawLine(pen, center, ZEdge.GetDrawingPoint(scrWidth, scrHeight));
            g.DrawString("Z", font, brush, new Point3(ZEdge.X, ZEdge.Y, ZEdge.Z - offset).GetDrawingPoint(scrWidth, scrHeight));
        }
    }
}
