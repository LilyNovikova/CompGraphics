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
        private const int vectorLenght = 100;

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
            startXEdge = new Point3(vectorLenght, 0, 0);
            startYEdge = new Point3(0, vectorLenght, 0);
            startZEdge = new Point3(0, 0, vectorLenght);
            XEdge = startXEdge;
            YEdge = startYEdge;
            ZEdge = startZEdge;
        }

        public void Turn(double angleX = 0, double angleY = 0, double angleZ = 0)
        {
            XEdge = startXEdge.TurnAroundAxis(Point3.Axes.X, angleX);
            YEdge = startYEdge.TurnAroundAxis(Point3.Axes.X, angleX);
            ZEdge = startZEdge.TurnAroundAxis(Point3.Axes.X, angleX);
            XEdge = XEdge.TurnAroundAxis(Point3.Axes.Y, angleY);
            YEdge = YEdge.TurnAroundAxis(Point3.Axes.Y, angleY);
            ZEdge = ZEdge.TurnAroundAxis(Point3.Axes.Y, angleY);
            XEdge = XEdge.TurnAroundAxis(Point3.Axes.Z, angleZ);
            YEdge = YEdge.TurnAroundAxis(Point3.Axes.Z, angleZ);
            ZEdge = ZEdge.TurnAroundAxis(Point3.Axes.Z, angleZ);
        }

        public void Draw(Graphics g, Pen pen, Brush brush, Font font, int offset)
        {
            var center = Center.GetDrawingPoint(scrWidth, scrHeight);
            var gPen = new Pen(Brushes.Green, 2);
            var bPen = new Pen(Brushes.Blue, 2);
            var mPen = new Pen(Brushes.DarkMagenta, 2);
            //X
            g.DrawLine(gPen, center, XEdge.GetDrawingPoint(scrWidth, scrHeight));
            g.DrawString("X", font, brush, new Point3(XEdge.X - offset, XEdge.Y, XEdge.Z).GetDrawingPoint(scrWidth, scrHeight));
            //Y
            g.DrawLine(bPen, YEdge.GetDrawingPoint(scrWidth, scrHeight), center);
            g.DrawString("Y", font, brush, new Point3(YEdge.X, YEdge.Y - offset, YEdge.Z).GetDrawingPoint(scrWidth, scrHeight));
            //Z
            g.DrawLine(mPen, center, ZEdge.GetDrawingPoint(scrWidth, scrHeight));
            g.DrawString("Z", font, brush, new Point3(ZEdge.X, ZEdge.Y, ZEdge.Z - offset).GetDrawingPoint(scrWidth, scrHeight));
        }
    }
}
