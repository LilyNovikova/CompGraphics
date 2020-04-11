using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Models
{
    public class Polygon
    {
        public List<Point3> Points { get; private set; }

        public List<Section> Boundaries { get; private set; }

        public Polygon(List<Point3> points)
        {
            if (points.Count < 3)
            {
                throw new ArgumentException("More points required. It is not a polygon");
            }
            Points = points;
            Boundaries = new List<Section>();
            for (int i = 0; i < Points.Count - 1; i++)
            {
                Boundaries.Add(new Section(Points[i], Points[i + 1]));
            }
            Boundaries.Add(new Section(Points.Last(), Points.First()));
        }

        public double Convexity
        {
            get
            {
                double sign = 0;
                for (int i = 0; i < Boundaries.Count - 1; i++)
                {
                    var currentSign = GetMulSign(Boundaries[i], Boundaries[i + 1]);
                    if (!IsSignChanged(currentSign))
                    {
                        return 0;
                    }
                }

                if (!IsSignChanged(
                    GetMulSign(
                        Boundaries.Last(),
                        Boundaries.First())
                    ))
                {
                    return 0;
                }
                return sign;

                int GetMulSign(Section section1, Section section2)
                {
                    var mul = section1 * section2;
                    return mul > 0 ? 1
                        : ((mul < 0) ? -1 : 0);
                }

                bool IsSignChanged(int current)
                {
                    if (current != 0)
                    {
                        if (sign == 0)
                        {
                            sign = current;
                        }
                        else
                        {
                            if (sign != current)
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
            }
        }

        public IList<Section> InnerNormals
        {
            get
            {
                var convexity = Convexity;
                if (convexity == 0)
                {
                    throw new NotImplementedException("It is not a convex window");
                }
                return Boundaries.Select(b => b.GetNormal2D(convexity < 0)).ToList();
            }
        }
    }
}
