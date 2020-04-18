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
        private int rows = 10;
        private int columns = 10;
        private List<List<Point3>> points;
        private List<List<Point3>> startPoints;
        private List<List<Point3>> startSurfaceGrid;
        private List<SurfaceCell> startSurfaceCells;
        private List<List<Point3>> surfaceGridPoints;
        private List<SurfaceCell> surfaceCells;
        private Coordinates3D coordinates;

        public DrawForm()
        {
            InitializeComponent();
            inputFileCmb.SelectedItem = inputFileCmb.Items[1];
            SetPoints();
            coordinates = new Coordinates3D(Canvas.Size.Width, Canvas.Size.Height);
            surface = new BezierSurface();
            startSurfaceGrid = new List<List<Point3>>();
            startSurfaceCells = new List<SurfaceCell>();
            surface.SetPoints(points);
            SavePoints(pointsFilename);
            startSurfaceGrid.Clear();
            //inputFileCmb.Enabled = false;
        }

        private List<List<Point3>> GetSurfacePoints3x3()
        {
            return new List<List<Point3>>
            {
                new List<Point3>
                {
                    new Point3(0, 0, 0),
                    new Point3(50, 0, 120),
                    new Point3(100, 0, 0)
                },
                new List<Point3>
                {
                    new Point3(0, 50, 0),
                    new Point3(50, 50, 120),
                    new Point3(100, 50, 0)
                },
                new List<Point3>
                {
                    new Point3(0, 100, 0),
                    new Point3(50, 100, 120),
                    new Point3(100, 100, 0)
                }
            };
        }

        private List<List<Point3>> GetSurfacePoints4x5()
        {
            return new List<List<Point3>>
            {
               new List<Point3>
                {
                    new Point3(150, 0, 0),
                    new Point3(150, 50, 0),
                    new Point3(150, 100, 0),
                    new Point3(150, 150, 0),
                    new Point3(150, 200, 150)
                },
                new List<Point3>
                {
                    new Point3(100, 0, 120),
                    new Point3(100, 50, 120),
                    new Point3(100, 100, 120),
                    new Point3(100, 150, 120),
                    new Point3(100, 200, 120)
                },
                new List<Point3>
                {
                    new Point3(50, 0, 120),
                    new Point3(50, 50, 120),
                    new Point3(50, 100, 120),
                    new Point3(50, 150, 120),
                    new Point3(50, 200, 30)
                },
                new List<Point3>
                {
                    new Point3(0, 0, 0),
                    new Point3(0, 50, 0),
                    new Point3(0, 100, 0),
                    new Point3(0, 150, 0),
                    new Point3(0, 200, 0)
                }
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
            DrawXYZAxes(e.Graphics, rect);
            var basePointsArray = points.Select(row => row.Select(point => point.GetDrawingPoint(rect.Width, rect.Height)).ToArray()).ToArray();
            e.Graphics.DrawPoints(Brushes.Black, basePointsArray, pointRadius);



            var innerBrush = Brushes.Cyan;
            var outerBrush = Brushes.Red;

            if (startSurfaceCells.Count == 0)
            {
                surface = new BezierSurface();
                surface.SetPoints(startPoints);
                startSurfaceCells = surface.GetSurfaceCells(tolerance, rows, columns);
                surfaceCells = null;
            }
            var check = startSurfaceCells;
            var inner = (surfaceCells ?? startSurfaceCells).Where(cell => !cell.IsFront);
            var outer = (surfaceCells ?? startSurfaceCells).Where(cell => cell.IsFront);
            foreach (SurfaceCell cell in inner)
            {
                var drawPoints = Point3Utils.GetCurveProjection(cell.ToList(), rect.Width, rect.Height).ToArray();
                e.Graphics.FillPolygon(innerBrush, drawPoints);
            }

            foreach (SurfaceCell cell in outer)
            {
                var drawPoints = Point3Utils.GetCurveProjection(cell.ToList(), rect.Width, rect.Height).ToArray();
                e.Graphics.FillPolygon(outerBrush, drawPoints);
            }



            if (startSurfaceGrid.Count == 0)
            {
                surface = new BezierSurface();
                surface.SetPoints(startPoints);
                startSurfaceGrid = surface.GetSurfaceGridPoints(tolerance, rows, columns);
                surfaceGridPoints = null;
                startSurfaceCells.Clear();
            }
            var drawGridPoints = Point3Utils.GetObjectProjection(surfaceGridPoints ?? startSurfaceGrid, rect.Width, rect.Height);
            e.Graphics.DrawGrid(Pens.Black, drawGridPoints);
        }

        private void PaintBtn_Click(object sender, EventArgs e)
        {
            if (startSurfaceGrid != null)
            {
                startSurfaceGrid.Clear();
            }
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

        private void TurnPoints()
        {
            var angleX = MathUtils.GradToRad(XTurnTrb.Value);
            var angleY = MathUtils.GradToRad(YTurnTrb.Value);
            var angleZ = MathUtils.GradToRad(ZTurnTrb.Value);

            coordinates.Turn(angleX, angleY, angleZ);

            var p = startPoints as IEnumerable<IEnumerable<Point3>>;
            p = p.TurnObject(Point3.Axes.X, angleX);
            p = p.TurnObject(Point3.Axes.Y, angleY);
            p = p.TurnObject(Point3.Axes.Z, angleZ);
            points = p.Select(row => row.ToList()).ToList();

            if (startSurfaceGrid != null && startSurfaceGrid.Count != 0)
            {
                p = startSurfaceGrid as IEnumerable<IEnumerable<Point3>>;
                p = p.TurnObject(Point3.Axes.X, angleX);
                p = p.TurnObject(Point3.Axes.Y, angleY);
                p = p.TurnObject(Point3.Axes.Z, angleZ);
                surfaceGridPoints = p.Select(row => row.ToList()).ToList();
            }

            if(startSurfaceCells != null && startSurfaceCells.Count != 0)
            {
                p = startSurfaceCells.Select(cell => cell.ToList());
                p = p.TurnObject(Point3.Axes.X, angleX);
                p = p.TurnObject(Point3.Axes.Y, angleY);
                p = p.TurnObject(Point3.Axes.Z, angleZ);
                surfaceCells = p.Select(cell => SurfaceCell.FromList(cell)).ToList();
            }
        }

        private void TurnView()
        {
            TurnPoints();
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
            PaintBtn_Click(this, e);
        }
    }
}
