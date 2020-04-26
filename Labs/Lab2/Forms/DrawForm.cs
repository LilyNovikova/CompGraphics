using Framework.Models;
using Framework.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Lab2.Forms
{
    public partial class DrawForm : Form
    {
        private string pointsFilename = "4points.txt";
        private const string pointsFilePath = "Lab2Resources\\";
        private const int axesWidth = 2;
        private const int axesNameOffset = 10;
        private const int pointRadius = 2;
        private BezierCurve curve;
        private double tolerance = 0.005;
        private List<Point3> curvePoints;
        private List<Point3> points;
        private List<Point3> startPoints;
        private double t;
        private bool isSlowDrawSelected;
        private Coordinates3D coordinates;
        private bool isPaintBtnClicked = false;

        public DrawForm()
        {
            InitializeComponent();
            inputFileCmb.SelectedItem = inputFileCmb.Items[0];
            curvePoints = new List<Point3>();
            SetPoints();
            coordinates = new Coordinates3D(Canvas.Size.Width, Canvas.Size.Height);
            curve = new BezierCurve();
            curve.AddPoints(points);
            SavePoints(pointsFilename);
            curvePoints.Clear();
            t = 0;
        }
        private void SetPoints()
        {
            pointsFilename = pointsFilePath + inputFileCmb.SelectedItem.ToString();
            startPoints = GetSavedPoints(pointsFilename);
            /* startPoints = new List<Point3>
             {
                 new Point3(21  ,74  ,-100),
                 new Point3(5  ,6  ,-50),
                 new Point3(101  ,5  ,-10),
                 new Point3(139  , 74  ,0),
                 new Point3(176  ,17  ,30),
                 new Point3(189  , 124  ,80),
                 new Point3(226  ,67  ,150)
             };*/
            points = startPoints;
        }

        private void DrawForm_Load(object sender, EventArgs e)
        {
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            var rect = new Rectangle(Canvas.Location.X, Canvas.Location.Y, Canvas.Size.Width, Canvas.Size.Height);

            if (!isSlowDrawSelected || (!isPaintBtnClicked && isSlowDrawSelected))
            {
                DrawCurve(points, e.Graphics, rect);
            }
            else if (isSlowDrawSelected)
            {
                DrawCurveSlow(t, e.Graphics, rect);
            }
        }

        private void PaintBtn_Click(object sender, EventArgs e)
        {
            isSlowDrawSelected = BtflCbx.Checked;
            isPaintBtnClicked = true;
            if (isSlowDrawSelected)
            {
                curve = new BezierCurve();
                curve.AddPoints(points);

                curvePoints.Clear();
                for (; t <= 1; t += tolerance)
                {
                    if (t < 1)
                    {
                        Canvas.Refresh();
                    }
                }
                t = 0;
            }
            else
            {
                Canvas.Refresh();
            }
            isPaintBtnClicked = false;
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
            DrawXYZAxes(g, field);
            var curve = new BezierCurve();
            curve.AddPoints(points);

            var curvePoints = curve.GetCurvePoints(0.0001);
            var startDrawingPoints = points.Select(p => p.GetDrawingPoint(field.Width, field.Height)).ToArray();
            g.DrawLines(Pens.Black, startDrawingPoints);
            g.DrawPoints(Brushes.Black, startDrawingPoints, pointRadius);
            foreach (Point3 p in points)
            {
                //g.FillEllipse(Brushes.Black, p.GetDrawingPoint(field.Width, field.Height), pointRadius);
                g.DrawString($"{points.IndexOf(p)}", SystemFonts.CaptionFont, Brushes.Black, p.GetDrawingPoint(field.Width, field.Height));
            }
            var projection = (curvePoints as IEnumerable<Point3>).GetCurveProjection(field.Width, field.Height);
            g.DrawLines(Pens.Red, projection.ToArray());
        }

        private void DrawCurveSlow(double t, Graphics g, Rectangle field)
        {
            DrawXYZAxes(g, field);

            //draw main points
            foreach (Point3 p in points)
            {
                g.FillEllipse(Brushes.Black, p.GetDrawingPoint(field.Width, field.Height), pointRadius);
                g.DrawString($"{points.IndexOf(p)}", SystemFonts.CaptionFont, Brushes.Black, p.GetDrawingPoint(field.Width, field.Height));
            }
            if (isPaintBtnClicked)
            {
                curvePoints.Add(curve.GetBezierPoint(t));
                DrawCurveStep(curve.Subpoints, g, field);

                if (curvePoints.Count != 1)
                {
                    g.DrawLines(new Pen(Brushes.Black, 2), curvePoints.Select(p => p.GetDrawingPoint(field.Width, field.Height)).ToArray());
                }
            }
            Thread.Sleep(5);
        }

        private void DrawCurveStep(List<List<Point3>> subpoints, Graphics g, Rectangle field)
        {
            var colorIndex = 0;
            for (int i = 0; i < subpoints.Count - 1; i++)
            {
                var points = subpoints[i];
                foreach (Point3 p in points)
                {
                    g.FillEllipse(Brushes.Black, p.GetDrawingPoint(field.Width, field.Height), pointRadius);
                    //g.DrawString($"{subpoints.IndexOf(points)}:{points.IndexOf(p)}", SystemFonts.CaptionFont, Brushes.Black, p.GetDrawingPoint(field.Width, field.Height));
                }
                var projection = (points as IEnumerable<Point3>).GetCurveProjection(field.Width, field.Height);
                g.DrawLines(GetPen(colorIndex), projection.ToArray());
                colorIndex++;
            }
            g.FillEllipse(Brushes.Black, subpoints.Last().First().GetDrawingPoint(field.Width, field.Height), pointRadius * 2);
        }

        private void SavePoints(string pointsFilename)
        {
            var pStr = JsonConvert.SerializeObject(points).Replace("},", "},\n");
            var writer = File.CreateText(pointsFilename);
            writer.WriteLine(pStr);
            writer.Close();
        }

        private List<Point3> GetSavedPoints(string pointsFilename)
        {
            var pStr = File.ReadAllText(pointsFilename);
            return JsonConvert.DeserializeObject<List<Point3>>(pStr);
        }

        private void XTurnTrb_Scroll(object sender, EventArgs e)
        {
            YTurnTrb.Value = 0;
            ZTurnTrb.Value = 0;

            XUdn.Value = XTurnTrb.Value;
            YUdn.Value = YTurnTrb.Value;
            ZUdn.Value = ZTurnTrb.Value;
            TurnView();
        }

        private void YTurnTrb_Scroll(object sender, EventArgs e)
        {
            XTurnTrb.Value = 0;
            ZTurnTrb.Value = 0;

            YUdn.Value = YTurnTrb.Value;
            XUdn.Value = XTurnTrb.Value;
            ZUdn.Value = ZTurnTrb.Value;
            TurnView();
        }

        private void ZTurnTrb_Scroll(object sender, EventArgs e)
        {
            YTurnTrb.Value = 0;
            XTurnTrb.Value = 0;

            ZUdn.Value = ZTurnTrb.Value;
            XUdn.Value = XTurnTrb.Value;
            YUdn.Value = YTurnTrb.Value;
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

        private void DrawXYZAxes(Graphics g, Rectangle field)
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

        private void XUdn_ValueChanged(object sender, EventArgs e)
        {
            XTurnTrb.Value = (int)XUdn.Value;
            XTurnTrb_Scroll(sender, e);
        }

        private void YUdn_ValueChanged(object sender, EventArgs e)
        {
            YTurnTrb.Value = (int)YUdn.Value;
            YTurnTrb_Scroll(sender, e);
        }

        private void ZUdn_ValueChanged(object sender, EventArgs e)
        {
            ZTurnTrb.Value = (int)ZUdn.Value;
            ZTurnTrb_Scroll(sender, e);
        }

        private void inputFileCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPoints();
            XTurnTrb.Value = 0;
            YTurnTrb.Value = 0;
            ZTurnTrb.Value = 0;
            DrawForm_ResizeEnd(sender, e);
        }
    }
}
