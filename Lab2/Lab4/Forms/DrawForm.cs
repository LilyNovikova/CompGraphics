using Framework.Models;
using Framework.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lab4.Forms
{
    public partial class DrawForm : Form
    {
        private string windowFilename = "5window.txt";
        private string sectionsFilename = "2sections.txt";
        private const string pointsFilePath = "Lab4Resources\\";
        private const int axesWidth = 2;
        private const int axesNameOffset = 10;
        private const int pointRadius = 2;
        private double tolerance = 0.0001;
        private Window window;
        private List<Section> sections;
        private bool isVisibleHighlighted = false;

        public DrawForm()
        {
            InitializeComponent();
            windowInputFileCmb.SelectedItem = windowInputFileCmb.Items[0];
            SetWindow();
            sectionsInputFileCmb.SelectedItem = sectionsInputFileCmb.Items[1];
            SetSections();

            //SavePoints(windowFilename, sectionsFilename);
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

        private List<Point3> GetOctagon()
        {
            return new List<Point3>
                {
                    new Point3(10, 230, 0),
                    new Point3(-50, 180, 0),
                    new Point3(-10, 100, 0),
                    new Point3(70, 20, 0),
                    new Point3(120, 50, 0),
                    new Point3(170, 130, 0),
                    new Point3(150, 180, 0),
                    new Point3(100, 220, 0)
                };
        }

        private List<Point3> GetTriangle()
        {
            return new List<Point3>
                {
                    new Point3(-10, 100, 0),
                    new Point3(170, 130, 0),
                    new Point3(150, 180, 0)
                };
        }

        private List<Section> GetSections()
        {
            return new List<Section>
            {
                new Section(new Point3(200, 50, 0), new Point3(-50, 100, 0)),
                new Section(new Point3(200, 100, 0), new Point3(-50, 0, 0)),
                new Section(new Point3(-200, 50, 0), new Point3(200, 100, 0)),
                new Section(new Point3(100, -100, 0), new Point3(100, 500, 0)),
                new Section(new Point3(100, 400, 0), new Point3(300, -100, 0)),
                new Section(new Point3(75, 75, 0), new Point3(300, 75, 0)),
                new Section(new Point3(100, 100, 0), new Point3(50, 50, 0))
            };
        }

        private void SetWindow()
        {
            windowFilename = pointsFilePath + (windowInputFileCmb.SelectedItem ?? windowFilename).ToString();
            window = GetSavedWindow(windowFilename);
        }

        private void SetSections()
        {
            sectionsFilename = pointsFilePath + (sectionsInputFileCmb.SelectedItem ?? sectionsFilename).ToString();
            sections = GetSavedSections(sectionsFilename);
        }

        private void DrawForm_Load(object sender, EventArgs e)
        {
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            var rect = new Rectangle(Canvas.Location.X, Canvas.Location.Y, Canvas.Size.Width, Canvas.Size.Height);
            DrawXYAxes(e.Graphics, rect);
            var points = Point3Utils.GetCurveProjection(window.Points, Canvas.Size.Width, Canvas.Size.Height, isIsometric: false).ToArray();
            e.Graphics.DrawPolygon(Pens.Black, points);
            e.Graphics.DrawPoints(Brushes.Black, points, pointRadius);
            e.Graphics.DrawSections(Pens.Red, sections, Canvas.Size.Width, Canvas.Size.Height, isIsometric: false);

            if (isVisibleHighlighted)
            {
                HighlightVisible(e.Graphics, rect);
            }
        }

        private void SavePoints(string windowFilename, string sectionsFilename)
        {
            var pStr = JsonConvert.SerializeObject(window.Points).Replace("},", "},\n").Replace("],", "],\n\n");
            var writer = File.CreateText(windowFilename);
            writer.WriteLine(pStr);
            writer.Close();

            pStr = JsonConvert.SerializeObject(sections).Replace("},", "},\n").Replace("],", "],\n\n");
            writer = File.CreateText(sectionsFilename);
            writer.WriteLine(pStr);
            writer.Close();
        }

        private Window GetSavedWindow(string filename)
        {
            var pStr = File.ReadAllText(filename);
            return new Window(JsonConvert.DeserializeObject<List<Point3>>(pStr));
        }

        private List<Section> GetSavedSections(string filename)
        {
            var pStr = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<List<Section>>(pStr);
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

        private void highlightVisibleBtn_Click(object sender, EventArgs e)
        {
            isVisibleHighlighted = !isVisibleHighlighted;
            Canvas.Refresh();
        }

        private void HighlightVisible(Graphics g, Rectangle field)
        {
            var visible = sections.Select(s => window.GetVisiblePart(s, tolerance)).Where(s => s != null).ToList();
            foreach (Section s in visible)
            {
                g.DrawSection(new Pen(Brushes.Cyan, 2), s, Canvas.Size.Width, Canvas.Size.Height, isIsometric: false);
            }
        }

        private void windowInputFileCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetWindow();
            SetSections();
            DrawForm_ResizeEnd(sender, e);
        }

        private void sectionsInputFileCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetWindow();
            SetSections();
            DrawForm_ResizeEnd(sender, e);
        }
    }
}
