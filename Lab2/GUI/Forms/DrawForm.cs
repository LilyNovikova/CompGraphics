using GUI.Models;
using GUI.Utils;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace GUI.Forms
{
    public partial class DrawForm : Form
    {
        private const string pointsFilename = "data.txt";
        private const int axesWidth = 2;
        private const int axesNameOffset = 10;
        private const int pointRadius = 2;
        private int count;
        private BezierCurve curve;
        private double tolerance = 0.0005;
        private List<Point3> curvePoints;
        private List<Point3> points;
        private readonly List<Point3> startPoints;
        private double t;
        private bool isSlowDrawSelected;
        private Coordinates3D coordinates;
        private int currentXAngle;
        private int currentYAngle;
        private int currentZAngle;

        public DrawForm()
        {
            InitializeComponent();
            count = 0;
            curvePoints = new List<Point3>();
            startPoints = new List<Point3>
            {
                new Point3(21  ,74  ,-100),
                new Point3(5  ,6  ,-50),
                new Point3(101  ,5  ,-10),
                new Point3(139  , 74  ,0),
                new Point3(176  ,17  ,30),
                new Point3(189  , 124  ,80),
                new Point3(226  ,67  ,150)
            };
            points = startPoints;
            //points = GetSavedPoints();
            coordinates = new Coordinates3D(Canvas.Size.Width, Canvas.Size.Height);
            currentXAngle = 0;
            currentYAngle = 0;
            currentZAngle = 0;
            curve = new BezierCurve();
            curve.AddPoints(points);
            //SavePoints();
            curvePoints.Clear();
            t = 0;
        }

        private void DrawForm_Load(object sender, EventArgs e)
        {
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            var rect = new Rectangle(Canvas.Location.X, Canvas.Location.Y, Canvas.Size.Width, Canvas.Size.Height);
            if (isSlowDrawSelected)
            {
                DrawCurveSlow(t, e.Graphics, rect);
            }
            else
            {
                DrawCurve(points, e.Graphics, rect);
            }
        }

        private void PaintBtn_Click(object sender, EventArgs e)
        {
            isSlowDrawSelected = BtflCbx.Checked;
            if (isSlowDrawSelected)
            {
                curve = new BezierCurve();
                curve.AddPoints(points);

                curvePoints.Clear();
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

        private void DrawCurve(List<Point3> points, Graphics g, Rectangle field)
        {
            DrawAxes(g, field);
            var curve = new BezierCurve();
            curve.AddPoints(points);

            var curvePoints = curve.GetCurvePoints(0.0001);

            foreach (Point3 p in points)
            {
                g.FillEllipse(Brushes.Black, p.GetDrawingPoint(field.Width, field.Height), pointRadius);
                g.DrawString($"{points.IndexOf(p)}", SystemFonts.CaptionFont, Brushes.Black, p.GetDrawingPoint(field.Width, field.Height));
            }
            var projection = (curvePoints as IEnumerable<Point3>).GetProjection(field.Width, field.Height);
            g.DrawLines(GetPen(count), projection.ToArray());
            //count++;
        }

        private void DrawCurveSlow(double t, Graphics g, Rectangle field)
        {
            ResetAngleBtn_Click(this, new EventArgs());
            DrawAxes(g, field);
            curvePoints.Add(curve.GetBezierPoint(t));

            //draw main points
            foreach (Point3 p in points)
            {
                g.FillEllipse(Brushes.Black, p.GetDrawingPoint(field.Width, field.Height), pointRadius);
                g.DrawString($"{points.IndexOf(p)}", SystemFonts.CaptionFont, Brushes.Black, p.GetDrawingPoint(field.Width, field.Height));
            }

            DrawCurveStep(curve.Subpoints, g, field);
            if (curvePoints.Count != 1)
            {
                g.DrawLines(new Pen(Brushes.Black, 2), curvePoints.Select(p => p.GetDrawingPoint(field.Width, field.Height)).ToArray());
            }
            //Thread.Sleep(5);
        }

        private void DrawCurveStep(List<List<Point3>> subpoints, Graphics g, Rectangle field)
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
                var projection = (points as IEnumerable<Point3>).GetProjection(field.Width, field.Height);
                g.DrawLines(GetPen(colorIndex), projection.ToArray());
                colorIndex++;
            }
            g.FillEllipse(Brushes.Black, subpoints.Last().First().GetDrawingPoint(field.Width, field.Height), pointRadius * 2);
        }

        private void SavePoints()
        {
            var pStr = JsonConvert.SerializeObject(points).Replace("},", "},\n");
            var writer = File.CreateText(pointsFilename);
            writer.WriteLine(pStr);
            writer.Close();
        }

        private List<Point3> GetSavedPoints()
        {
            var pStr = File.ReadAllText(pointsFilename);
            return JsonConvert.DeserializeObject<List<Point3>>(pStr);
        }

        private void XTurnTrb_Scroll(object sender, EventArgs e)
        {
            TurnView();
        }

        private void YTurnTrb_Scroll(object sender, EventArgs e)
        {
            TurnView();
        }

        private void ZTurnTrb_Scroll(object sender, EventArgs e)
        {
            TurnView();
        }

        private void TurnView()
        {
            var angleX = MathUtils.GradToRad(XTurnTrb.Value);
            var angleY = MathUtils.GradToRad(YTurnTrb.Value);
            var angleZ = MathUtils.GradToRad(ZTurnTrb.Value);

            coordinates.Turn(angleX, angleY, angleZ);

            var p = startPoints as IEnumerable<Point3>;
            p = p.TurnObject(Point3.Axes.X, angleX);
            p = p.TurnObject(Point3.Axes.Y, angleY);
            p = p.TurnObject(Point3.Axes.Z, angleZ);
            points = p.ToList();

            Canvas.Refresh();
        }

        private void DrawAxes(Graphics g, Rectangle field)
        {
            var brush = Brushes.Black;
            var font = SystemFonts.CaptionFont;
            var pen = new Pen(Brushes.DimGray, axesWidth);
            coordinates.Draw(g, pen, brush, font, axesNameOffset);
        }

        private void DrawForm_ResizeEnd(object sender, EventArgs e)
        {
            coordinates = new Coordinates3D(Canvas.Width, Canvas.Height);
            XTurnTrb_Scroll(sender, e);
            YTurnTrb_Scroll(sender, e);
            ZTurnTrb_Scroll(sender, e);
            Canvas.Refresh();
        }

        private void ResetAngleBtn_Click(object sender, EventArgs e)
        {
            XTurnTrb.Value = 0;
            YTurnTrb.Value = 0;
            ZTurnTrb.Value = 0;
            XTurnTrb_Scroll(sender, e);
            YTurnTrb_Scroll(sender, e);
            ZTurnTrb_Scroll(sender, e);
        }
    }
}
