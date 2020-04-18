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

        public Point3 Vector => B - A;

        public Point3 GetBezierPoint(double t)
        {
            return (1 - t) * A + t * B;
        }

        public static Section operator *(double alpha, Section section)
        {
            return new Section(alpha * section.A, alpha * section.B);
        }

        public static double operator *(Section section1, Section section2) => 
            VectorMul(section1, section2).Length;

        public static double ScalarMul(Section section1, Section section2)
        {
            var p1 = section1.A - section1.B;
            var p2 = section2.A - section2.B;
            return p1.X * p2.X + p1.Y * p2.Y + p1.Z * p2.Z;
        }

        public static Section VectorMul(Section section1, Section section2)
        {
            var p1 = section1.Vector;
            var p2 = section2.Vector;
            return new Section(
                new Point3(0, 0, 0), 
                new Point3(
                    p1.Y * p2.Z - p1.Z * p2.Y, 
                    p1.Z * p2.X - p1.X * p2.Z, 
                    p1.X * p2.Y - p1.Y * p2.X
                    )
                );
        }

        public static double CosAngle(Section section1, Section section2)
        {
            return ScalarMul(section1, section2)
                / section1.Length
                / section2.Length;
        }

        public static double SinAngle(Section section1, Section section2)
        {
            return ScalarMul(section1, section2)
                / section1.Length
                / section2.Length;
        }

        public Section GetNormal2D(bool isRightTurn)
        {
            return new Section(
                A,
                B.TurnAroundPoint2D(A, isRightTurn ? -Math.PI / 2 : Math.PI / 2)
                );
        }

        public Point3 GetVFunc(double t) => A + t * (B - A);

        public override string ToString()
        {
            return $"{A}; {B}";
        }
    }
}
