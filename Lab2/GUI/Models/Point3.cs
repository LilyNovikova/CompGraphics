using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Models
{
    public class Point3
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

        public Point3(double x, double y, double z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point3(int x, int y, int z = 0) : this((double)x, (double)y, (double)z) { }

        public Point GetDrawingPoint()
        {
            return new Point((int)Math.Round(X), (int)Math.Round(Y));
        }

        public static Point3 operator *(double alpha, Point3 point)
        {
            return new Point3(
                point.X * alpha,
                point.Y * alpha,
                point.Z * alpha
                );
        }

        public static Point3 operator +(Point3 point1, Point3 point2)
        {
            return new Point3(
                point1.X + point2.X,
                point1.Y + point2.Y,
                point1.Z + point2.Z
                );
        }
    }
}
