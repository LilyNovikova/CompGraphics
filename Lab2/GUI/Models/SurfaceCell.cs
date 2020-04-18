using GUI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Models
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

        public bool IsFront
        {
            get
            {
                /*var dirY1 = A1.GetDrawingPoint().Y - B1.GetDrawingPoint().Y;
                var dirY2 = A2.GetDrawingPoint().Y - B2.GetDrawingPoint().Y;
                var dirX1 = A1.GetDrawingPoint().X - B1.GetDrawingPoint().X;
                var dirX2 = A2.GetDrawingPoint().X - B2.GetDrawingPoint().X;
                if (dirY1 < 0 && dirY2 < 0)
                {
                    return true;
                }
                if (dirY1 > 0 && dirY2 > 0)
                {
                    return false;
                }
                throw new Exception($"Grid cell is invalid. Dir1 {dirY1}; dir2 {dirY2}");*/
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
