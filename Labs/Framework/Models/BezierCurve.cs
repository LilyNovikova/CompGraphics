using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Models
{
    public class BezierCurve
    {
        public List<Point3> Points { get; private set; }
        public List<List<Point3>> Subpoints { get; private set; }

        public List<Point3> CurvePoints { get; private set; }

        public BezierCurve()
        {
            Points = new List<Point3>();
        }

        public void AddPoints(List<Point3> points)
        {
            Points = Points.Concat(points).ToList();
            Subpoints = new List<List<Point3>>();
        }

        public Point3 GetBezierPoint(double t)
        {
            Subpoints.Clear();
            Subpoints.Add(Points);
            for (int i = 0; i < Points.Count - 1; i++)
            {
                var nextLevel = new List<Point3>();
                for (int j = 0; j < Subpoints[i].Count - 1; j++)
                {
                    var point = new Section(Subpoints[i][j], Subpoints[i][j + 1]).GetBezierPoint(t);
                    nextLevel.Add(point);
                }
                Subpoints.Add(nextLevel);
            }
            return Subpoints.Last().First();
        }

        public List<Point3> GetCurvePoints(double tolerance = 0.001)
        {
            if (Points.Count < 2)
            {
                throw new InvalidOperationException("Not enough points to build a curve (min 2)");
            }
            var points = new List<Point3>();
            for (double t = 0; t < 1; t += tolerance)
            {
                points.Add(GetBezierPoint(t));
            }
            return points;
        }
    }
}
