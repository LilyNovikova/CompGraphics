using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Models
{
    public class BezierSurface
    {
        public List<List<Point3>> Points { get; private set; }
        public List<List<List<Point3>>> Subpoints { get; private set; }

        public List<List<Point3>> CurvePoints { get; private set; }

        public BezierSurface()
        {
            Points = new List<List<Point3>>();
        }

        public void SetPoints(List<List<Point3>> points)
        {
            var rowLength = points[0].Count;
            foreach (List<Point3> row in points)
            {
                if (row.Count != rowLength)
                {
                    throw new ArgumentException("Rows must have equal length");
                }
            }
            Points = points;
            Subpoints = new List<List<List<Point3>>>();
        }

        public Point3 GetBezierPoint(double u, double v)
        {
            Subpoints.Clear();
            Subpoints.Add(Points);
            for (int k = 0; k < Math.Max(Points.Count, Points[0].Count) - 1; k++)
            {
                var newLevel = new List<List<Point3>>();
                for (int i = 0; i < Subpoints[k].Count - 1; i++)
                {
                    var newRow = new List<Point3>();
                    for (int j = 0; j < Subpoints[k][i].Count - 1; j++)
                    {
                        var pointI = new Section(Subpoints[k][i][j], Subpoints[k][i + 1][j]).GetBezierPoint(u);
                        var pointJ = new Section(Subpoints[k][i][j], Subpoints[k][i][j + 1]).GetBezierPoint(v);
                        var coordZ = u / (v + u) * pointI.Z + v / (v + u) * pointJ.Z;
                        var point = new Point3(pointI.X, pointJ.Y, coordZ);
                        newRow.Add(point);
                    }
                    newLevel.Add(newRow);
                }
                Subpoints.Add(newLevel);
            }
            return Subpoints.Last().Last().First();
        }

        public List<List<Point3>> GetCurvePoints(double tolerance = 0.001)
        {
            if (Points.Count < 1 && Points[0].Count < 2)
            {
                throw new InvalidOperationException("Not enough points to build a curve (min 1 row and 2 columns)");
            }
            var points = new List<List<Point3>>();
            for (double u = 0; u < 1; u += tolerance)
            {
                var row = new List<Point3>();
                for (double v = 0; v < 1; v += tolerance)
                {
                    row.Add(GetBezierPoint(u, v));
                }
                points.Add(row);
            }
            return points;
        }
    }
}
