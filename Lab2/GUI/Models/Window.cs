using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Models
{
    public class Window : Polygon
    {
        private const double Tolerance = 0.001;
        public Window(List<Point3> points) : base(points)
        {
        }

        public Section GetVisiblePart1(Section section)
        {
            var dir = Convexity;
            if (dir == 0)
            {
                throw new NotImplementedException("It is not a convex window");
            }

            var t0 = 0.0;
            var t1 = 1.0;
            var isVisible = false;
            foreach (Section b in Boundaries)
            {
                var p = GetP(b, section);
                var q = GetQ(b, section, t0);
                if (p == 0 && q < 0)
                {
                    break;
                }
                else if (p != 0)
                {
                    if (p > 0)
                    {
                        for (var i = 0.0; i < 1; i += 0.000001)
                        {
                            if (Math.Abs(GetQ(b, section, i)) < Tolerance)
                            {
                                t0 = i > t0 ? i : t0;
                                isVisible = true;
                            }
                        }
                    }
                    else
                    {
                        for (var i = 1.0; i > 0; i -= 0.000001)
                        {
                            if (Math.Abs(GetQ(b, section, i)) < Tolerance)
                            {
                                t0 = i < t1 ? i : t1;
                                isVisible = true;
                            }
                        }
                    }
                }
            }
            if (isVisible)
            {
                return new Section(section.GetVFunc(t0), section.GetVFunc(t1));
            }
            else return default;
        }

        public Section GetVisiblePart(Section section)
        {
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

                if (Math.Abs(pN) < Tolerance)
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
                        if (r < t1)
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
                        if (r > t0)
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
