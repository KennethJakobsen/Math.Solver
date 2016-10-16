using System;
using System.Collections.Generic;
using System.Drawing;
using Math.Solver.Core.Model.CoordinateSystem;

namespace Math.Solver.Core.CoordinateSystem
{
    public interface ICoordinateSystem
    {
        int Margin { get; set; }
        Bitmap CoordinateSystem { get; }
        void Draw(IEnumerable<Model.Navigation.Point> points, string id, Color color);
        void DrawBezier(IEnumerable<Model.Navigation.Point> points, string id, Color color);
        int GridCellSpacing { get; set; }
        int GridLineWidth { get; set; }
        Color GridLineColor { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        string Save(string destFolder);
        Guid Id { get; }
        bool DrawGrid { get; set; }
        AxisDefinition AxisDefinition { get; set; }

    }
}
