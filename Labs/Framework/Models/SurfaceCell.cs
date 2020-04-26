using Framework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Models
{
    public class SurfaceCell
    {
        public Point3 A1 { get; set; }
        public Point3 A2 { get; set; }
        public Point3 B1 { get; set; }
        public Point3 B2 { get; set; }

        public Section Diagonal1 => new Section(A1, B2);
        public Section Diagonal2 => new Section(A2, B1);

        public Section Normal => Section.VectorMul(Diagonal1, Diagonal2);

        public double FurthestDistance => ToList().Max(p1 => p1.Distance(Const.ViewPoint));

        public double ClosestDistance => ToList().Min(p1 => p1.Distance(Const.ViewPoint));


        public bool IsFront
        {
            get
            {
                var distanceBegin = Normal.A.Distance(Const.ViewPoint);
                var distanceEnd = Normal.B.Distance(Const.ViewPoint);
                if (distanceBegin >= distanceEnd)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static SurfaceCell FromList(IEnumerable<Point3> points)
        {
            if (points.Count() != 4)
            {
                throw new ArgumentException($"Cannot convert to surface cell. List length is {points.Count()}");
            }
            var list = points.ToList();
            return new SurfaceCell
            {
                A1 = list[0],
                A2 = list[1],
                B1 = list[3],
                B2 = list[2]
            };
        }

        public List<Point3> ToList()
        {
            return new List<Point3>
            {
                A1,
                A2,
                B2,
                B1
            };
        }

        public override string ToString()
        {
            return $"a1:{A1} a2:{A2} b1:{B1} b2:{B2}";
        }
    }
}
