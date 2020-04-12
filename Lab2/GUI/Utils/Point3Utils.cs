using GUI.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Utils
{
    public static class Point3Utils
    {
        public static IEnumerable<Point3> TurnObject(this IEnumerable<Point3> points, Point3.Axes axis, double angle)
        {
            return points.Select(point => point.TurnAroundAxis(axis, angle));
        }

        public static IEnumerable<IEnumerable<Point3>> TurnObject(this IEnumerable<IEnumerable<Point3>> points, Point3.Axes axis, double angle)
        {
            return points.Select(row 
                => row.Select(point 
                => point.TurnAroundAxis(axis, angle)
                )
                );
        }

        public static IEnumerable<Point> GetCurveProjection(this IEnumerable<Point3> points, int screenWidth = 0, int screenHeight = 0, bool isIsometric = true)
        {
            return points.Select(point => point.GetDrawingPoint(screenWidth, screenHeight, isIsometric));
        }

        public static IEnumerable<IEnumerable<Point>> GetObjectProjection(this IEnumerable<IEnumerable<Point3>> points, int screenWidth = 0, int screenHeight = 0, bool isIsometric = true)
        {
            return points.
                Select(
                row => row
                .Select(
                    point => point.GetDrawingPoint(screenWidth, screenHeight, isIsometric)
                    )
                );
        }
    }
}
