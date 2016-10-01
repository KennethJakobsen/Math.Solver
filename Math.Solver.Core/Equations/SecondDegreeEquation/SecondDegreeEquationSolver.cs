using System;
using System.Collections.Generic;
using Math.Solver.Core.Helpers.Formatting;
using Math.Solver.Core.Model.Equations.SecondDegreeEquation;

namespace Math.Solver.Core.Equations.SecondDegreeEquation
{
    public class SecondDegreeEquationSolver
    {
       

        public SecondDegreeEquationResult Solve(SecondDegreeEquationParameters parameters)
        {
            var numbers = new FormatHelper();
            var  result = new SecondDegreeEquationResult();
            result.Process.Add($"{parameters.A}x² {numbers.ToPrefixedString(parameters.B)} {numbers.ToPrefixedString(parameters.C)} = 0");
            result.ProcessJaxFormatted.Add(@"$"+parameters.A+"x^2 "+ numbers.ToPrefixedString(parameters.B) + "x "+ numbers.ToPrefixedString(parameters.C) + @" = 0$");
            var d = (parameters.B*parameters.B) - (4*parameters.A*parameters.C);
            result.Process.Add($"d = {parameters.B}² - 4 · {numbers.ToPrefixedString(parameters.A, true, false)} · {numbers.ToPrefixedString(parameters.C, true)} = {parameters.B * parameters.B} {numbers.ToPrefixedString(-4*parameters.A*parameters.C)} = {d}");
            result.ProcessJaxFormatted.Add($@"$d = {parameters.B}^2 - 4 \cdot {numbers.ToPrefixedString(parameters.A, true, false)} \cdot {numbers.ToPrefixedString(parameters.C, true)}$");
            result.ProcessJaxFormatted.Add($@"$d = {parameters.B * parameters.B} {numbers.ToPrefixedString(-4 * parameters.A * parameters.C)} = {d}$");
            result.ProcessJaxFormatted.Add($@"$d = {d}$");
            if (d == 0)
            {
                result.Process.Add($"{numbers.ToPrefixedString(-1 * parameters.B)} / 2 · {numbers.ToPrefixedString(parameters.A, true, false)}");
                result.ProcessJaxFormatted.Add(@"${"+ numbers.ToPrefixedString(-1 * parameters.B) + @"  \over 2 \cdot " + numbers.ToPrefixedString(parameters.A, true, false) + @"}$");
                result.Results.Add((-1 * parameters.B) / (2*parameters.A));
                result.Process.Add("L = {" + result.Results[0] + "}");
                result.ProcessJaxFormatted.Add("L = {" + result.Results[0] + "}");
            }
            else if (d > 0)
            {
                var plus = (-1*parameters.B) + Convert.ToDecimal(System.Math.Sqrt((double) d));
                var minus = (-1*parameters.B) - Convert.ToDecimal(System.Math.Sqrt((double) d));
                var sub = 2*parameters.A;
                result.Process.Add($"{numbers.ToPrefixedString(-1 * parameters.B)} ± √{numbers.ToPrefixedString(d, true, false)} / 2 · {numbers.ToPrefixedString(parameters.A, true, false)} = {numbers.ToPrefixedString(-1 * parameters.B)} ± {System.Math.Sqrt((double) d)} / {2*parameters.A}");
                result.Results.Add(plus / sub);
                result.Results.Add(minus / sub);
                result.ProcessJaxFormatted.Add(@"${" + numbers.ToPrefixedString(-1 * parameters.B) + @" \pm \sqrt{" + d + @"} \over 2 \cdot " + numbers.ToPrefixedString(parameters.A, true, false) + @"}$");

                result.Process.Add("L = {"+ result.Results[0] + ", "+ result.Results[1] + "}");
                result.ProcessJaxFormatted.Add("$L = {" + result.Results[0] + ", " + result.Results[1] + "}$");
            }
            else
            {
                result.Process.Add("No solution");
                result.HasResult = false;
            }
            
           
            
            return result;
        }
    }
}
