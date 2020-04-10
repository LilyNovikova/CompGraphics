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

        public Section GetVisiblePart(Section section)
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
                        for (var i = 0.0; i < 1; i += 0.001)
                        {
                            if(Math.Abs(GetQ(b, section, i))<Tolerance)
                            {
                                t0 = i;
                                isVisible = true;
                            }
                        }
                    }
                    else
                    {
                        for (var i = 1.0; i > 0; i -= 0.001)
                        {
                            if (Math.Abs(GetQ(b, section, i)) < Tolerance)
                            {
                                t0 = i;
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

        private double GetP(Section boundary, Section section)
        {
            return boundary.GetNormal2D(Convexity < 0) * section;
        }

        private double GetQ(Section boundary, Section section, double t)
        {
            var pointF = boundary.A;
            return boundary.GetNormal2D(Convexity < 0) * new Section(section.GetVFunc(t), pointF);
        }
    }
}
