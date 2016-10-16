using System.Drawing;

namespace Math.Solver.Core.Model.CoordinateSystem
{
    public enum Axis
    {
        X, Y, Z
    }

    public class AxisDefinition
    {
        public Axis AxisType { get; set; }
        public Color Color { get; set; }
        public int Length { get; set; }
        public int LineWidth { get; set; }
        public int NumericIndicatorEvery { get; set; }
        public int LineIndicatorEvery { get; set; }
        public bool ShowLineIndicator { get; set; }
        public int LineIndicatorLength { get; set; }
        public int Start { get; set; }

    }
}