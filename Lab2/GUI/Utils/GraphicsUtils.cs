using GUI.Models;
using System.Drawing;

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
    }
}
