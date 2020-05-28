using Framework.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public List<Section> Edges => new List<Section>
        {
            new Section(A1, A2),
            new Section(A2, B2),
            new Section(B2, B1),
            new Section(B1, A1)
        };

        public List<Point3> Points =>
            new List<Point3>
            {
                A1, A2, B2, B1
            };

        public double FurthestDistance(Point3 point = null) => ToList().Max(p1 => p1.Distance(point ?? Const.ViewPoint));

        public double ClosestDistance(Point3 point = null) => ToList().Min(p1 => p1.Distance(point ?? Const.ViewPoint));

        public double WeightDistance(Point3 point = null) => ToList().Aggregate(new Point3(0, 0, 0), (res, next) => res = res + next).Distance(point ?? Const.ViewPoint);

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

        public bool IsFrontLight
        {
            get
            {
                var distanceBegin = Normal.A.Distance(Const.LightPoint);
                var distanceEnd = Normal.B.Distance(Const.LightPoint);
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

        public Polygon IsHiddenBy1(SurfaceCell cell)
        {
            var window = new Window(cell.Points);
            var visible = Edges.Where(e => window.GetVisiblePart(e) != default(Section));
            if (visible.Count() != 0 && ClosestDistance(Const.LightPoint) > cell.ClosestDistance(Const.LightPoint))
            {
                return window.GetVisiblePart(new Polygon(Edges));
            }
            return default;
        }
        public bool IsHiddenBy(SurfaceCell cell)
        {
            var light = Const.LightPoint;
            var view = Const.ViewPoint;
            var thisTurnedPoints = ToList()
                .Select(p => Point3.TurnToPoint(p, Const.LightPoint, Const.ViewPoint));
            var cellTurnedPoints = cell.ToList()
                .Select(p => Point3.TurnToPoint(p, Const.LightPoint, Const.ViewPoint));
            thisTurnedPoints = Point3Utils.GetCurveProjection(thisTurnedPoints).Select(p => new Point3(p));
            cellTurnedPoints = Point3Utils.GetCurveProjection(cellTurnedPoints).Select(p => new Point3(p));

            var newThis = FromList(thisTurnedPoints);
            var newCell = FromList(cellTurnedPoints);

            var window = new Window(newCell.Points);
            var avEdgeLength = Edges.Aggregate(0.0, (res, next) => res += next.Length) / Edges.Count;
            var visible = newThis.Edges.Where(e =>
            {
                try
                {
                    return window.GetVisiblePart(e) != default(Section);
                }
                catch (NotImplementedException)
                {
                    return false;
                }
            }
            ).Where(v => v.Length > avEdgeLength / 2);

            if (visible.Count() != 0
              && WeightDistance(Const.LightPoint) > cell.WeightDistance(Const.LightPoint))
            {
                return true;
            }
            return false;
        }
    }
}
