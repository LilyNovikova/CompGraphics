using System;

namespace GUI.Models
{
    public class Section
    {
        public Point3 A { get; private set; }
        public Point3 B { get; private set; }

        public Section(Point3 a, Point3 b)
        {
            A = a;
            B = b;
        }

        public Point3 GetBezierPoint(double t)
        {
            return (1 - t) * A + t * B;
        }
    }
}
