using GUI.Utils;
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

        public Point3 GetBezierPoint1(double u, double v)
        {
            Point3 point = null;
            var n = Points.Count;
            var m = Points[0].Count;
            for (int i = 1; i <= n; i++)
            {
                Point3 rowSumm = null;
                for (int j = 1; j <= m; j++)
                {
                    var plus = B(n, i, u) * B(m, j, v) * Points[i - 1][j - 1];
                    if (rowSumm == null)
                    {
                        rowSumm = plus;
                    }
                    else
                    {
                        rowSumm += plus;
                    }
                    rowSumm += plus;
                }
                if (point == null)
                {
                    point = rowSumm;
                }
                else
                {
                    point += rowSumm;
                }
            }

            double B(int a, int b, double t)
            {
                var factorial = MathUtils.Factorial(a) / MathUtils.Factorial(a - b) / MathUtils.Factorial(b);
                var pow = Math.Pow(t, b) * Math.Pow(1 - t, a - b);
                return factorial * pow;
            }
            return point;
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
                        var r0 = new Section(Subpoints[k][i][j], Subpoints[k][i + 1][j]).GetBezierPoint(u);
                        var r1 = new Section(Subpoints[k][i][j + 1], Subpoints[k][i + 1][j + 1]).GetBezierPoint(u);
                        var point = new Section(r0, r1).GetBezierPoint(v);
                        newRow.Add(point);
                        if (Subpoints[k].Count > 2 && Subpoints[k][i].Count == 2)
                        {
                            newRow.Add(point);
                        }
                    }
                    newLevel.Add(newRow);
                    if (Subpoints[k].Count == 2 && Subpoints[k][i].Count > 2)
                    {
                        newLevel.Add(newRow);
                    }
                }
                Subpoints.Add(newLevel);
            }
            return Subpoints.Last().Last().First();
        }

        public List<List<Point3>> GetSurfacePoints(double tolerance = 0.001)
        {
            if (Points.Count < 1 && Points[0].Count < 2)
            {
                throw new InvalidOperationException("Not enough points to build a surface (min 1 row and 2 columns)");
            }
            var points = new List<List<Point3>>();
            for (double u = 0; u < 1 + tolerance; u += tolerance)
            {
                var row = new List<Point3>();
                for (double v = 0; v < 1 + tolerance; v += tolerance)
                {
                    row.Add(GetBezierPoint(u, v));
                }
                points.Add(row);
            }
            return points;
        }

        public List<List<Point3>> GetSurfaceGridPoints(double tolerance = 0.001, int rows = 100, int columns = 100)
        {
            var surface = GetSurfacePoints(tolerance);
            var columnStep = surface[0].Count / columns;
            columnStep = columnStep == 0 ? 1 : columnStep;
            var rowStep = surface.Count / rows;
            rowStep = rowStep == 0 ? 1 : rowStep;
            if (columnStep == 1 && rowStep == 1)
            {
                return surface;
            }
            var points = new List<List<Point3>>();
            for (int r = 0; r <= surface.Count - 1; r += rowStep)
            {
                var row = new List<Point3>();
                for (int c = 0; c <= surface[r].Count - 1; c += columnStep)
                {
                    row.Add(surface[r][c]);
                }
                points.Add(row);
            }
            return points;
        }
    }
}
