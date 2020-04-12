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
        private string pointsFilename = "0points.txt";
        private const string pointsFilePath = "Resources\\";
        private const int axesWidth = 2;
        private const int axesNameOffset = 10;
        private const int pointRadius = 2;
        private BezierSurface surface;
        private double tolerance = 0.05;
        private int rows = 15;
        private int columns = 15;
        private List<List<Point3>> points;
        private List<List<Point3>> startPoints;
        private List<List<Point3>> startSurfaceGrid;
        private List<List<Point3>> surfaceGridPoints;

        public DrawForm()
        {
            InitializeComponent();
            inputFileCmb.SelectedItem = inputFileCmb.Items[1];
            SetPoints();
            coordinates = new Coordinates3D(Canvas.Size.Width, Canvas.Size.Height);
            surface = new BezierSurface();
            startSurfaceGrid = new List<List<Point3>>();
            surface.SetPoints(points);
            SavePoints(pointsFilename);
            startSurfaceGrid.Clear();
            inputFileCmb.Enabled = false;
        }

        private List<Point3> GetSquare()
        {
            return new List<Point3>
                {
                    new Point3(0, 0, 0),
                    new Point3(100, 0, 0),
                    new Point3(100, 0, 100),
                    new Point3(0, 0, 100)
                };
        }

        private List<Point3> GetPentagon()
        {
            return new List<Point3>
                {
                    new Point3(150, 20, 0),
                    new Point3(250, 120, 0),
                    new Point3(200, 220, 0),
                    new Point3(100, 220, 0),
                    new Point3(50, 120, 0)
                };
        }

        private void SetPoints()
        {
            pointsFilename = pointsFilePath + inputFileCmb.SelectedItem.ToString();
            startPoints = GetSavedPoints(pointsFilename);
            points = startPoints;
        }

        private void DrawForm_Load(object sender, EventArgs e)
        {
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            var rect = new Rectangle(Canvas.Location.X, Canvas.Location.Y, Canvas.Size.Width, Canvas.Size.Height);
            // DrawXYZAxes(e.Graphics, rect);
            DrawXYAxes(e.Graphics, rect);
            var window = new Window(GetPentagon());
            var toDrawPolygon = window.Points;
            toDrawPolygon.Add(window.Points.First());
            var points = Point3Utils.GetCurveProjection(window.Points, Canvas.Size.Width, Canvas.Size.Height, isIsometric: false).ToArray();
            var section = new Section(new Point3(200, 50, 0), new Point3(-50, 100, 0));
            e.Graphics.DrawLines(Pens.Black, points);
            e.Graphics.DrawSection(Pens.Red, section, Canvas.Size.Width, Canvas.Size.Height, isIsometric: false);
            var visibleSection = window.GetVisiblePart(section);
            e.Graphics.DrawSection(new Pen(Brushes.Black, 2), visibleSection, Canvas.Size.Width, Canvas.Size.Height, isIsometric: false);
        }

        private void PaintBtn_Click(object sender, EventArgs e)
        {
            startSurfaceGrid.Clear();
            Canvas.Refresh();
        }

        private void SavePoints(string pointsFilename)
        {
            var pStr = JsonConvert.SerializeObject(startPoints).Replace("},", "},\n").Replace("],", "],\n\n");
            var writer = File.CreateText(pointsFilename);
            writer.WriteLine(pStr);
            writer.Close();
        }

        private List<List<Point3>> GetSavedPoints(string pointsFilename)
        {
            var pStr = File.ReadAllText(pointsFilename);
            return JsonConvert.DeserializeObject<List<List<Point3>>>(pStr);
        }

        private void DrawXYAxes(Graphics g, Rectangle field)
        {
            var brush = Brushes.Black;
            var font = SystemFonts.CaptionFont;
            var pen = new Pen(Brushes.DimGray, axesWidth);
            g.DrawLine(pen, 0, field.Height / 2, field.Width, field.Height / 2);
            g.DrawString("X", font, brush,
                new Point(field.Width - axesNameOffset, field.Height / 2));
            g.DrawLine(pen, field.Width / 2, 0, field.Width / 2, field.Height + axesNameOffset);
            g.DrawString("Y", font, brush,
               new Point(field.Width / 2 - axesNameOffset, axesNameOffset));
        }

        private void DrawForm_ResizeEnd(object sender, EventArgs e)
        {
            Canvas.Refresh();
        }

        private void ResetAngleBtn_Click(object sender, EventArgs e)
        {
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
