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

        public double Length => A.Distance(B);


        public Point3 GetBezierPoint(double t)
        {
            return (1 - t) * A + t * B;
        }

        public static Section operator *(double alpha, Section section)
        {
            return new Section(alpha * section.A, alpha * section.B);
        }

        public static double operator *(Section section1, Section section2)
        {
            return section1.Length * section2.Length * Angle(section1, section2);
        }

        public static double ScalarMul(Section section1, Section section2)
        {
            var p1 = section1.A - section1.B;
            var p2 = section2.A - section2.B;
            return p1.X * p2.X + p1.Y * p2.Y + p1.Z * p2.Z;
        }

        public static double Angle(Section section1, Section section2)
        {
            return ScalarMul(section1, section2)
                * section1.Length
                * section2.Length;
        }

        public Section GetNormal2D()
        {
            var point = A - B;
            return new Section(
                A,
                new Point3(
                    point.X == 0 ? point.X : -point.Y / point.X,
                    A.Y + 1,
                    A.Z)
                );
        }


    }
}
