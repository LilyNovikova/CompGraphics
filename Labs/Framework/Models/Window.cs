using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace Framework.Models
{
    public class Window : Polygon
    {
        private const double Tolerance = 0.001;
        public Window(List<Point3> points) : base(points)
        {
        }

        public Section GetVisiblePart(Section section, double tolerance = 0)
        {
            var tol = tolerance == 0 ? Tolerance : tolerance;
            var s = section;
            var dir = Convexity;
            if (dir == 0)
            {
                throw new NotImplementedException("It is not a convex window");
            }
            var t0 = 0.0;
            var t1 = 1.0;
            var isVisible = true;
            var vector = s.Vector;
            var dx = vector.X;
            var dy = vector.Y;
            foreach (Section b in Boundaries)
            {
                var q = new Point3(
                                s.A.X - b.A.X,
                                s.A.Y - b.A.Y,
                                0
                                );
                var n = b.GetNormal2D(dir < 0);
                var nV = n.Vector;
                var pN = dx * nV.X + dy * nV.Y;
                var qN = q.X * nV.X + q.Y * nV.Y;

                if (Math.Abs(pN) < tolerance)
                {            /* Паралл ребру или точка */
                    if (qN < 0)
                    {
                        isVisible = false;
                        break;
                    }
                }
                else
                {
                    var r = -qN / pN;
                    if (pN < 0)
                    {          /* Поиск верхнего предела t */
                        if (r < t0)
                        {
                            isVisible = false;
                            break;
                        }
                        if (r <= t1)
                        {
                            t1 = r;
                        }
                    }
                    else
                    {               /* Поиск нижнего предела t */
                        if (r > t1)
                        {
                            isVisible = false;
                            break;
                        }
                        if (r >= t0)
                        {
                            t0 = r;
                        }
                    }
                }
            }
            double x0, y0, x1, y1;
            if (isVisible)
            {
                if (t0 > t1)
                {
                    isVisible = false;
                    return default;
                }
                else
                {
                    Point3 p0;
                    Point3 p1;
                    if (t0 > 0)
                    {
                        x0 = s.A.X + t0 * dx;
                        y0 = s.A.Y + t0 * dy;
                        p0 = new Point3(x0, y0, 0);
                    }
                    else
                    {
                        p0 = s.A;
                    }
                    if (t1 < 1)
                    {
                        x1 = s.A.X + t1 * dx;
                        y1 = s.A.Y + t1 * dy;
                        p1 = new Point3(x1, y1, 0);
                    }
                    else
                    {
                        p1 = s.B;
                    }
                    return new Section(p0, p1);
                }
            }
            return default;

        }

        public Polygon GetVisiblePart(Polygon polygon, double tolerance = 0)
        {
            var visible = polygon.Boundaries.Where(b => GetVisiblePart(b, tolerance) != default(Section)).ToList();
            if (visible.Count == 0)
            {
                return default;
            }
            var newPolygon = new List<Section>();
            var IsVisiblePartEndFound = false;
            int VisPartEndIndex = -1;
            for (var i = 1; i < visible.Count; i++)
            {
                var s1 = visible[i - 1];
                var s2 = visible[i];
                if (!s1.B.Equals(s2.A))
                {
                    IsVisiblePartEndFound = true;
                    VisPartEndIndex = visible.IndexOf(s1);
                }
            }
            //соединяем отрезки в единую ломаную
            if (VisPartEndIndex != -1)
            {
                for (var i = VisPartEndIndex + 1; i < visible.Count; i++)
                {
                    newPolygon.Add(visible[i]);
                }
                for (var i = 0; i < VisPartEndIndex + 1; i++)
                {
                    newPolygon.Add(visible[i]);
                }
            }
            //добавляем часть окна, чтобы образовать многоугольник, который видим в окне
            //находим отрезки с точками пересечения
            var intersection1 = Boundaries.Where(b => b.IsPointOnSection(newPolygon.First().A)).First();
            var intersection2 = Boundaries.Where(b => b.IsPointOnSection(newPolygon.Last().B)).First();

            //находим номера этих отрезков
            var index1 = Boundaries.IndexOf(intersection1);
            var index2 = Boundaries.IndexOf(intersection2);

            //берём 2 ломаных окна 
            var IsFirstGreater = index1 > index2;
            var max = Math.Max(index1, index2);
            var min = Math.Min(index1, index2);

            var listIn = Boundaries.Where(b =>
             {
                 var num = Boundaries.IndexOf(b);
                 if (num < min || num > max)
                 {
                     return false;
                 }
                 return true;
             }).ToList();

            var listOut = Boundaries.Where(b =>
            {
                var num = Boundaries.IndexOf(b);
                if (num >= max)
                {
                    return true;
                }
                return false;
            }).ToList();
            for (var i = 0; i <= index1; i++)
            {
                listOut.Add(Boundaries[i]);
            }

            var polyIn = GetJoinedList(listIn);
            var polyOut = GetJoinedList(listOut);

            return new Polygon(polyIn).Convexity != 0 ? new Polygon(polyIn) : new Polygon(polyOut);

            //соединяем многоугольник с окном
            List<Section> GetJoinedList(List<Section> windowPart)
            {
                //listIn
                var newList = windowPart.Where(i => true).ToList();
                Section connectionB = null;
                Section connectionA = null;
                if (windowPart.Last().IsPointOnSection(newPolygon.Last().B))
                {
                    connectionB = new Section(windowPart.Last().A, newPolygon.Last().B);
                    connectionA = new Section(newPolygon.First().B, windowPart.First().A);
                    newList.RemoveAt(listIn.Count - 1);
                    newList.Add(connectionB);
                    for (var i = newPolygon.Count - 1; i >= 0; i--)
                    {
                        var section = new Section(newPolygon[i].B, newPolygon[i].A);
                        newList.Add(section);
                    }
                    newList.Add(connectionA);
                }
                else
                {
                    connectionB = new Section(windowPart.Last().B, newPolygon.Last().B);
                    connectionA = new Section(newPolygon.First().A, windowPart.First().A);
                    newList.RemoveAt(listIn.Count - 1);
                    newList.Add(connectionB);
                    for (var i = 0; i < newPolygon.Count; i++)
                    {
                        var section = new Section(newPolygon[i].B, newPolygon[i].A);
                        newList.Add(section);
                    }
                    newList.Add(connectionA);
                }
                return newList;
            }



        }

        private double GetP(Section boundary, Section section)
        {
            return boundary.GetNormal2D(Convexity < 0) * section;
        }

        private double GetQ(Section boundary, Section section, double t)
        {
            var pointF = boundary.A;
            return Section.ScalarMul(boundary.GetNormal2D(Convexity < 0), new Section(section.GetVFunc(t), pointF));
        }
    }
}
