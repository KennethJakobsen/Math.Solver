using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using Math.Solver.Core.Model.CoordinateSystem;
using Math = System.Math;
using Point = Math.Solver.Core.Model.Navigation.Point;

namespace Math.Solver.Core.CoordinateSystem
{
    public class TwoDimensionalCoordinateSystem : ICoordinateSystem
    {
        private Bitmap system;
        public TwoDimensionalCoordinateSystem(int imgLength)
        {
            AxisDefinition = new AxisDefinition()
            {
                Color = Color.Black,
                Length = 40,
                LineWidth = 1,
                NumericIndicatorEvery = 5,
                LineIndicatorEvery = 5,
                LineIndicatorLength = 1,
                ShowLineIndicator = true
            };
            Margin = 1;
            GridCellSpacing = Convert.ToInt32(System.Math.Floor((double)imgLength / (AxisDefinition.Length + Margin * 2)));
            GridLineColor = Color.LightBlue;
            GridLineWidth = 0;
            Id = Guid.NewGuid();
            Height = imgLength;
            Width = imgLength;
            DrawGrid = true;



        }

        private Bitmap GenerateCoordinateSystem()
        {
            //Creates a new transparent image
            CoordinateSystem = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
            if (DrawGrid)
            {
                DrawGridLines(Width, Axis.X);
                DrawGridLines(Height, Axis.Y);
            }
            DrawAxis(Axis.X);
            DrawAxis(Axis.Y);

            if (AxisDefinition.ShowLineIndicator)
            {
                DrawIndicators(Axis.X);
                DrawIndicators(Axis.Y);
            }

            DrawNumericIndicators(Axis.X);
            DrawNumericIndicators(Axis.Y);
            return CoordinateSystem;

        }

        private int CalculateFontSize()
        {
            return (int)System.Math.Floor((double)GridCellSpacing / 1.2);
        }
        private void DrawNumericIndicators(Axis axis)
        {
            using (var gfx = Graphics.FromImage(CoordinateSystem))
            using (var pen = new Pen(AxisDefinition.Color, AxisDefinition.LineWidth))
            {
                var number = AxisDefinition.Length / 2;
                number *= -1;

                for (int i = GetStepsInPixels(Margin); i <= GetStepsInPixels(AxisDefinition.Length) + GetStepsInPixels(Margin); i += GetStepsInPixels(AxisDefinition.NumericIndicatorEvery))
                {
                    if (number != 0)
                    {
                        var fontFamily = new FontFamily("Times New Roman");
                        var font = new Font(
                           fontFamily,
                           CalculateFontSize(),
                           FontStyle.Regular,
                           GraphicsUnit.Pixel);
                        gfx.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                        if (axis == Axis.X)
                        {
                            var y =
                                Convert.ToInt32(System.Math.Round((double)GetStepsInPixels(AxisDefinition.Length / 2))) +
                                GetStepsInPixels(Margin) * 1.5;
                            gfx.DrawString(number.ToString(), font,
                                new SolidBrush(AxisDefinition.Color), new PointF(i - GetStepsInPixels(1) / 2, (float)y));
                        }
                        if (axis == Axis.Y)
                        {

                            var x =
                                Convert.ToInt32(System.Math.Round((double)GetStepsInPixels(AxisDefinition.Length / 2))) +
                                GetStepsInPixels(Margin) * 1.5;
                            gfx.DrawString(number.ToString(), font, new SolidBrush(AxisDefinition.Color),
                                new PointF((float)x, i - GetStepsInPixels(1) / 2));
                        }
                    }
                    number += AxisDefinition.NumericIndicatorEvery;
                }


            }
        }
        private void DrawIndicators(Axis axis)
        {
            using (var gfx = Graphics.FromImage(CoordinateSystem))
            using (var pen = new Pen(AxisDefinition.Color, AxisDefinition.LineWidth))
            {
                for (int i = GetStepsInPixels(Margin); i <= GetStepsInPixels(AxisDefinition.Length) + GetStepsInPixels(Margin); i += GetStepsInPixels(AxisDefinition.LineIndicatorEvery))
                {
                    if (axis == Axis.X)
                    {
                        var y = Convert.ToInt32(System.Math.Round((double)GetStepsInPixels(AxisDefinition.Length / 2))) + GetStepsInPixels(Margin);
                        gfx.DrawLine(pen,
                        new System.Drawing.Point(i, y - Convert.ToInt32((double)GetStepsInPixels(AxisDefinition.LineIndicatorLength) / 2)),
                        new System.Drawing.Point(i, y + Convert.ToInt32((double)GetStepsInPixels(AxisDefinition.LineIndicatorLength) / 2)));
                    }
                    if (axis == Axis.Y)
                    {
                        var x = Convert.ToInt32(System.Math.Round((double)GetStepsInPixels(AxisDefinition.Length / 2))) + GetStepsInPixels(Margin);
                        gfx.DrawLine(pen,
                            new System.Drawing.Point(x - Convert.ToInt32((double)GetStepsInPixels(AxisDefinition.LineIndicatorLength) / 2), i),
                            new System.Drawing.Point(x + Convert.ToInt32((double)GetStepsInPixels(AxisDefinition.LineIndicatorLength) / 2), i));
                    }
                }
            }
        }
        private void DrawAxis(Axis axis)
        {
            using (var gfx = Graphics.FromImage(CoordinateSystem))
            using (var pen = new Pen(AxisDefinition.Color, AxisDefinition.LineWidth))
            {
                if (axis == Axis.X)
                {
                    var y = GetStepsInPixels(Margin) + Convert.ToInt32(System.Math.Round((double)GetStepsInPixels(AxisDefinition.Length / 2)));
                    gfx.DrawLine(pen, new System.Drawing.Point(GetStepsInPixels(Margin), y), new System.Drawing.Point(GetStepsInPixels(AxisDefinition.Length) + GetStepsInPixels(Margin), y));
                }
                if (axis == Axis.Y)
                {
                    var x = GetStepsInPixels(Margin) + Convert.ToInt32(System.Math.Round((double)GetStepsInPixels(AxisDefinition.Length / 2)));
                    gfx.DrawLine(pen, new System.Drawing.Point(x, GetStepsInPixels(Margin)), new System.Drawing.Point(x, GetStepsInPixels(AxisDefinition.Length) + GetStepsInPixels(Margin)));
                }
            }
        }
        private void DrawGridLines(int max, Axis axis)
        {
            using (var gfx = Graphics.FromImage(CoordinateSystem))
            using (var pen = new Pen(GridLineColor, GridLineWidth))
            {
                for (var i = 0; i <= max; i += GridCellSpacing)
                {
                    if (axis == Axis.X)
                    {
                        gfx.DrawLine(pen, new System.Drawing.Point(i, 0), new System.Drawing.Point(i, Height));
                    }
                    if (axis == Axis.Y)
                        gfx.DrawLine(pen, new System.Drawing.Point(0, i), new System.Drawing.Point(Width, i));
                }

            }
        }

        private int GetStepsInPixels(decimal steps)
        {
            return (int)(steps * GridCellSpacing + GridLineWidth);
        }

        private int GetStepsInPixels(int steps)
        {
            return GetStepsInPixels((decimal)steps);
        }
        public int Margin { get; set; }

        public Bitmap CoordinateSystem
        {
            get { return system ?? (system = GenerateCoordinateSystem()); }
            set { system = value; }
        }

        public void Draw(IEnumerable<Point> points, string id, Color color)
        {
            using (var gfx = Graphics.FromImage(CoordinateSystem))
            using (var pen = new Pen(color, GridLineWidth))
            {
                gfx.DrawLines(pen, points.Select(p => new System.Drawing.Point(GetStepsInPixels(p.X + Margin), GetStepsInPixels(p.Y + Margin))).ToArray());
            }
        }

        public void DrawBezier(IEnumerable<Point> points, string id, Color color)
        {
            var bmp = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);

            using (var gfx = Graphics.FromImage(bmp))
            using (var pen = new Pen(color, 1))
            {
                gfx.SmoothingMode = SmoothingMode.AntiAlias;
                var arr =
                    //points.Select(p => new System.Drawing.Point(GetStepsInPixels(p.X + Margin), GetStepsInPixels(p.Y + Margin))).ToArray();
                    points.Select(TranslateToBitmapPosition)
                    .Where(p => p != System.Drawing.Point.Empty)
                        .ToArray();
                gfx.DrawCurve(pen, arr);
            }
            ApplyMargin(bmp);
            using (var gfx = Graphics.FromImage(CoordinateSystem))
            {
                gfx.DrawImage(bmp, new System.Drawing.Point(0, 0));
            }
        }


        private void ApplyMargin(Bitmap bmp)
        {
            using (var gfx = Graphics.FromImage(bmp))
            {
                gfx.SetClip(new Rectangle(0, 0, Width, GetStepsInPixels(Margin)), CombineMode.Replace);
                gfx.Clear(Color.Transparent);
                gfx.SetClip(new Rectangle(GetStepsInPixels(AxisDefinition.Length + Margin), 0, Width - GetStepsInPixels(AxisDefinition.Length + Margin), Height), CombineMode.Replace);
                gfx.Clear(Color.Transparent);
                gfx.SetClip(new Rectangle(0, GetStepsInPixels(AxisDefinition.Length + Margin), Width, Height - GetStepsInPixels(AxisDefinition.Length + Margin)), CombineMode.Replace);
                gfx.Clear(Color.Transparent);
                gfx.SetClip(new Rectangle(0, 0, GetStepsInPixels(Margin), Height), CombineMode.Replace);
                gfx.Clear(Color.Transparent);

            }
        }

        private System.Drawing.Point TranslateToBitmapPosition(Point point)
        {
            var origo = new Point(GetStepsInPixels(Margin + AxisDefinition.Length / 2), GetStepsInPixels(Margin + AxisDefinition.Length / 2));
            int x = 0, y = 0;
            if (point.X < 0)
                x = (int)origo.X - GetStepsInPixels(point.X * -1);
            if (point.X == 0)
                x = (int)origo.X;
            if (point.X > 0)
                x = (int)origo.X + GetStepsInPixels(point.X);

            if (point.Y < 0)
                y = (int)origo.Y + GetStepsInPixels(point.Y * -1);
            if (point.Y == 0)
                y = (int)origo.Y;
            if (point.Y > 0)
                y = (int)origo.Y - GetStepsInPixels(point.Y);

            return new System.Drawing.Point(x, y);
        }
        public int GridCellSpacing { get; set; }

        public int GridLineWidth { get; set; }
        public Color GridLineColor { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Save(string destFolder)
        {
            var file = $"{Id.ToString()}.png";
            var path = Path.Combine(destFolder, file);
            CoordinateSystem.Save(path);
            return file;
        }

        public Guid Id { get; }
        public bool DrawGrid { get; set; }
        public AxisDefinition AxisDefinition { get; set; }
        public void DrawPoint(Point point, string label, Color color)
        {
            using (var gfx = Graphics.FromImage(CoordinateSystem))
            using (var brush = new SolidBrush(color))
            {
                var fontFamily = new FontFamily("Times New Roman");
                var font = new Font(
                   fontFamily,
                   CalculateFontSize(),
                   FontStyle.Regular,
                   GraphicsUnit.Pixel);

                gfx.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                gfx.SmoothingMode = SmoothingMode.AntiAlias;
                var newPoint = TranslateToBitmapPosition(point);
                newPoint.X -= 3;
                newPoint.Y -= 3;
                gfx.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                gfx.FillEllipse(brush, new Rectangle(newPoint, new Size(5, 5)));
                gfx.DrawString(label, font, brush, newPoint);
            }
        }
    }
}
