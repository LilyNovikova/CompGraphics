using System;
using System.Drawing;

namespace Lab1.Utils
{
    public static class GeometryUtils
    {
        public static double GetDistanсe(this Point startPoint, Point point)
        {
            return Math.Sqrt(Math.Pow(point.Y - startPoint.Y, 2) + Math.Pow(point.X - startPoint.X, 2));
        }
    }
}
