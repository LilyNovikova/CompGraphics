using GUI.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GUI.Utils
{
    public static class GraphicsUtils
    {
        public static void DrawEllipse(this Graphics g, Pen pen, Point center, int radius)
        {
            g.DrawEllipse(pen, center.X - radius, center.Y - radius, radius * 2, radius * 2);
        }
        public static void FillEllipse(this Graphics g, Brush brush, Point center, int radius)
        {
            g.FillEllipse(brush, center.X - radius, center.Y - radius, radius * 2, radius * 2);
        }

        public static void DrawSection(this Graphics g, Pen pen, Section section)
        {
            g.DrawLine(pen, section.A.GetDrawingPoint(), section.B.GetDrawingPoint());
        }

        public static void DrawGrid(this Graphics g, Pen pen, IEnumerable<IEnumerable<Point>> points)
        {
            var pointArray = points.Select(row => row.ToArray()).ToArray();
            var rowLength = pointArray[0].Length;
            for(int i = 0; i < rowLength; i++)
            {
                var column = pointArray.Select(row => row[i]).ToArray();
                g.DrawLines(pen, column);
            }
            foreach(Point[] row in pointArray)
            {
                g.DrawLines(pen, row);
            }
        }
    }
}
