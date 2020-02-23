using System;
using System.Drawing;
using Newtonsoft.Json;

namespace GUI.Models
{
    [Serializable]
    public class Point3
    {
        [JsonProperty("X")]
        public double X { get; private set; }
        [JsonProperty("Y")]
        public double Y { get; private set; }
        [JsonProperty("Z")]
        public double Z { get; private set; }

        [JsonConstructor]
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
