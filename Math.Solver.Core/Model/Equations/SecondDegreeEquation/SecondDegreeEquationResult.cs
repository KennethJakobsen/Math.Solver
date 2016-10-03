using System.Collections.Generic;
using System.Linq.Expressions;

namespace Math.Solver.Core.Model.Equations.SecondDegreeEquation
{
    public class SecondDegreeEquationResult
    {
        public SecondDegreeEquationResult()
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
