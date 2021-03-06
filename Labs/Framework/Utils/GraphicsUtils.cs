﻿using Framework.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Framework.Utils
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

        public static void DrawEllipse(this Graphics g, Pen pen, Circle circle)
        {
            var center = circle.Center;
            g.DrawEllipse(pen, center.X - circle.Radius, center.Y - circle.Radius, circle.Radius * 2, circle.Radius * 2);
        }
        public static void FillEllipse(this Graphics g, Brush brush, Circle circle)
        {
            var center = circle.Center;
            g.FillEllipse(brush, center.X - circle.Radius, center.Y - circle.Radius, circle.Radius * 2, circle.Radius * 2);
        }

        public static void DrawSection(this Graphics g, Pen pen, Section2D section)
        {
            g.DrawLine(pen, section.A, section.B);
        }

        public static void DrawPoints(this Graphics g, Brush brush, Point[] centers, int radius)
        {
            foreach (Point p in centers)
            {
                g.FillEllipse(brush, p.X - radius, p.Y - radius, radius * 2, radius * 2);
            }
        }

        public static void DrawPoints(this Graphics g, Brush brush, Point[][] centers, int radius)
        {
            foreach (Point[] row in centers)
            {
                foreach (Point p in row)
                {
                    g.FillEllipse(brush, p.X - radius, p.Y - radius, radius * 2, radius * 2);
                }
            }
        }

        public static void DrawSection(this Graphics g, Pen pen, Section section, int screenWidth = 0, int screenHeight = 0, bool isIsometric = true)
        {
            g.DrawLine(pen, section.A.GetDrawingPoint(screenWidth, screenHeight, isIsometric), section.B.GetDrawingPoint(screenWidth, screenHeight, isIsometric));
        }

        public static void DrawSections(this Graphics g, Pen pen, IEnumerable<Section> sections, int screenWidth = 0, int screenHeight = 0, bool isIsometric = true)
        {
            foreach (Section section in sections)
            {
                g.DrawLine(pen, section.A.GetDrawingPoint(screenWidth, screenHeight, isIsometric), section.B.GetDrawingPoint(screenWidth, screenHeight, isIsometric));
            }
        }

        public static void DrawGrid(this Graphics g, Pen pen, IEnumerable<IEnumerable<Point>> points)
        {
            var pointArray = points.Select(row => row.ToArray()).ToArray();
            var rowLength = pointArray[0].Length;
            for (int i = 0; i < rowLength; i++)
            {
                var column = pointArray.Select(row => row[i]).ToArray();
                g.DrawLines(pen, column);
            }
            foreach (Point[] row in pointArray)
            {
                g.DrawLines(pen, row);
            }
        }
    }
}
