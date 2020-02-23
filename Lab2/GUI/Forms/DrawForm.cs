using GUI.Models;
using GUI.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace GUI.Forms
{
    public partial class DrawForm : Form
    {
        private const int pointRadius = 2;
        private int count;
        private BezierCurve curve;
        private double tolerance;
        private List<Point3> curvePoints;
        private List<Point3> points;
        private double t;
        private bool isSlowDrawSelected;

        public DrawForm()
        {
            InitializeComponent();
            count = 0;
            curvePoints = new List<Point3>();
            points = new List<Point3>
            {
                new Point3(21*2,74*2,30),
                new Point3(5*2,6*2,30),
                new Point3(101*2,5*2,30),
                new Point3(139*2, 74*2,30),
                new Point3(176*2,17*2,30),
                new Point3(189*2, 124*2,30),
                new Point3(226*2,67*2,30)
            };
            curve = new BezierCurve();
            curve.AddPoints(points);

            curvePoints.Clear();
            tolerance = 0.001;
            t = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            if (isSlowDrawSelected)
            {
                DrawCurveSlow(t, e.Graphics);
            }
            else
            {
                DrawCurve(points, e.Graphics);
            }
        }

        private void PaintBtn_Click(object sender, EventArgs e)
        {
            isSlowDrawSelected = BtflCbx.Checked;
            if (isSlowDrawSelected)
            {
                points = new List<Point3>
            {
                new Point3(21*2,74*2,30),
                new Point3(5*2,6*2,30),
                new Point3(101*2,5*2,30),
                new Point3(139*2, 74*2,30),
                new Point3(176*2,17*2,30),
                new Point3(189*2, 124*2,30),
                new Point3(226*2,67*2,30)
            };
                curve = new BezierCurve();
                curve.AddPoints(points);

                curvePoints.Clear();
                tolerance = 0.001;
                t = 0;
                for (; t <= 1; t += tolerance)
                {
                    if (t < 1)
                    {
                        Canvas.Refresh();
                    }
                }
            }
            else
            {
                Canvas.Refresh();
            }
        }

        private Pen GetPen(int i)
        {
            switch (i % 7)
            {
                case 0:
                    return Pens.Red;
                case 1:
                    return Pens.Blue;
                case 2:
                    return Pens.Green;
                case 3:
                    return Pens.Orange;
                case 4:
                    return Pens.Violet;
                case 5:
                    return Pens.Coral;
                case 6:
                    return Pens.Gray;
                default:
                    return Pens.Black;
            }
        }

        private void DrawCurve(List<Point3> points, Graphics g)
        {
            var curve = new BezierCurve();
            curve.AddPoints(points);

            var curvePoints = curve.GetCurvePoints(0.0001);

            foreach (Point3 p in points)
            {
                g.FillEllipse(Brushes.Black, p.GetDrawingPoint(), pointRadius);
                g.DrawString($"{points.IndexOf(p)}", SystemFonts.CaptionFont, Brushes.Black, p.GetDrawingPoint());
            }

            g.DrawLines(GetPen(count), curvePoints.Select(p => p.GetDrawingPoint()).ToArray());
            count++;
        }

        private void DrawCurveSlow(double t, Graphics g)
        {
            curvePoints.Add(curve.GetBezierPoint(t));

            //draw main points
            foreach (Point3 p in points)
            {
                g.FillEllipse(Brushes.Black, p.GetDrawingPoint(), pointRadius);
                g.DrawString($"{points.IndexOf(p)}", SystemFonts.CaptionFont, Brushes.Black, p.GetDrawingPoint());
            }

            DrawCurveStep(curve.Subpoints, g);
            if (curvePoints.Count != 1)
            {
                g.DrawLines(Pens.Black, curvePoints.Select(p => p.GetDrawingPoint()).ToArray());
            }
            //Thread.Sleep(100);
        }

        private void DrawCurveStep(List<List<Point3>> subpoints, Graphics g)
        {
            var colorIndex = 0;
            for (int i = 0; i < subpoints.Count - 1; i++)
            {
                var points = subpoints[i];
                foreach (Point3 p in points)
                {
                    g.FillEllipse(Brushes.Black, p.GetDrawingPoint(), pointRadius);
                    g.DrawString($"{subpoints.IndexOf(points)}:{points.IndexOf(p)}", SystemFonts.CaptionFont, Brushes.Black, p.GetDrawingPoint());
                }
                g.DrawLines(GetPen(colorIndex), points.Select(p => p.GetDrawingPoint()).ToArray());
                colorIndex++;
            }
        }
    }
}
