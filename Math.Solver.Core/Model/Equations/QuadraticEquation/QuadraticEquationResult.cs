using System.Collections.Generic;
using System.Drawing;

namespace Math.Solver.Core.Model.Equations.QuadraticEquation
{
    public class QuadraticEquationResult
    {
        public QuadraticEquationResult()
        {
            HasResult = true;
            
            X = new List<decimal>();
            Process = new List<string>();
            XProcess = new List<string>();
            TProcess = new List<string>();
            DProcess = new List<string>();
        }
        public bool HasResult { get; set; }
        public List<decimal> X { get; set; }
        public List<string> Process { get; set; }
        public Point T { get; set; }
        public decimal D { get; set; }
        public List<string> TProcess { get; set; }
        public List<string> DProcess { get; set; }
        public List<string> XProcess { get; set; }


    }
}
