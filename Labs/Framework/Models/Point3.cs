﻿using Newtonsoft.Json;
using System;
using System.Drawing;

namespace Framework.Models
{
    [Serializable]
    public class Point3
    {
        public enum Axes
        {
            X,
            Y,
            Z
        }

        [JsonProperty("X")]
        public double X { get; private set; }
        [JsonProperty("Y")]
        public double Y { get; private set; }
        [JsonProperty("Z")]
        public double Z { get; private set; }

        [JsonConstructor]
        public Point3(double x, double y, double z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point3(int x, int y, int z = 0) : this((double)x, (double)y, (double)z) { }

        public override string ToString()
        {
            return $"X: {(int)Math.Round(X)}, Y: {(int)Math.Round(Y)}, Z: {(int)Math.Round(Z)}";
        }

        public double Distance(Point3 point)
        {
            return Math.Sqrt(
                Math.Pow(X - point.X, 2) +
                Math.Pow(Y - point.Y, 2) +
                Math.Pow(Z - point.Z, 2)
                );
        }

        public Point GetDrawingPoint(int screenWidth = 0, int screenHeight = 0, bool isIsometric = true)
        {
            if (!isIsometric)
            {
                return new Point(
                screenWidth / 2 + (int)Math.Round(X),
                screenHeight / 2 - (int)Math.Round(Y)
                );
            }
            return new Point(
                screenWidth / 2 + GetPlainXCoordinate(),
                screenHeight / 2 + GetPlainYCoordinate()
                );
        }

        public static Point3 operator *(double alpha, Point3 point)
        {
            return new Point3(
                point.X * alpha,
                point.Y * alpha,
                point.Z * alpha
                );
        }

        public static Point3 operator +(Point3 point1, Point3 point2)
        {
            return new Point3(
                point1.X + point2.X,
                point1.Y + point2.Y,
                point1.Z + point2.Z
                );
        }

        public static Point3 operator -(Point3 point1, Point3 point2)
        {
            return new Point3(
                point1.X - point2.X,
                point1.Y - point2.Y,
                point1.Z - point2.Z
                );
        }

        public Point3 TurnAroundAxis(Axes axis, double angle)
        {
            var c = Math.Cos(angle);
            var s = Math.Sin(angle);
            switch (axis)
            {
                case Axes.X:
                    return new Point3(
                        X,
                        Y * c + Z * s,
                        Z * c - Y * s
                        );
                case Axes.Y:
                    return new Point3(
                        X * c - Z * s,
                        Y,
                        X * s + Z * c
                        );
                case Axes.Z:
                    return new Point3(
                        X * c + Y * s,
                        Y * c - X * s,
                        Z
                        );
                default:
                    throw new ArgumentException($"Unknown argument '{axis}' in turning method");
            }
        }

        public Point3 TurnAroundPoint2D(Point3 center, double angle)
        {
            var point = new Point3(X - center.X, Y - center.Y, Z - center.Z);
            return center + new Point3(
                point.X * Math.Cos(angle) - point.Y * Math.Sin(angle),
                point.X * Math.Sin(angle) + point.Y * Math.Cos(angle),
                0
                );
        }

        private int GetPlainXCoordinate()
        {
            return (int)Math.Round(Math.Sin(Math.PI / 3) * (Y - X));
        }
        private int GetPlainYCoordinate()
        {
            return (int)Math.Round(-Z + Math.Cos(Math.PI / 3) * (X + Y));
        }
    }
}
