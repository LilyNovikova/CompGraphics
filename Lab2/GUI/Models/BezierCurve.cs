using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Models
{
    public class BezierCurve
    {
        public List<Point3> Points { get; private set; }
        public List<Point3> Subpoints { get; private set; }

        public List<Point3> CurvePoints { get; private set; }

        public BezierCurve()
        {
            Points = new List<Point3>();
        }

        public void AddPoints(List<Point3> points)
        {
            Points = points;
        }


    }
}
