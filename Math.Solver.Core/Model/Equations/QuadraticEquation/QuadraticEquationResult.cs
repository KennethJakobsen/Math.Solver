using System.Collections.Generic;

namespace Math.Solver.Core.Model.Equations.QuadraticEquation
{
    public class QuadraticEquationResult
    {
        public QuadraticEquationResult()
        {
            HasResult = true;
            Results = new List<decimal>();
            Process = new List<string>();
        }
        public bool HasResult { get; set; }
        public List<decimal> Results { get; set; }
        public List<string> Process { get; set; }


    }
}
