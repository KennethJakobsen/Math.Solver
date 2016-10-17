using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using Math.Solver.Core.Helpers.Formatting;
using Math.Solver.Core.Helpers.Tex;
using Math.Solver.Core.Model.Equations.QuadraticEquation;
using math = System.Math;

namespace Math.Solver.Core.Equations.QuadraticEquation
{
    public class QuadraticEquationSolver
    {


        public QuadraticEquationResult Solve(QuadraticParameters parameters)
        {
            var result = new QuadraticEquationResult();

            var d = (parameters.B * parameters.B) - (4 * parameters.A * parameters.C);
            SetResult(parameters, result, d);
            SetProcessInTexFormat(parameters, result, d);



            return result;
        }

        private static void SetProcessInTexFormat(QuadraticParameters parameters, QuadraticEquationResult result, decimal d)
        {
            var bx = (parameters.B == 0) ? string.Empty : Format.PrintMultiplier(parameters.B, true) + "x ";
            var c = (parameters.C == 0) ?string.Empty : Format.ToPrefixedString(parameters.C);
            result.Process.Add(Format.PrintMultiplier(parameters.A, false) + "x" + Tex.Squared + bx + c + @" = 0");
            result.Process.Add(GetDProcess(parameters, d));
            result.Process.Add(GetXProcess(parameters, d, result));
            result.Process.AddRange(GetTProcess(parameters, d, result));
            result.DProcess.Add(GetDProcess(parameters, d));
            result.XProcess.Add(GetXProcess(parameters, d, result));
            result.TProcess.AddRange(GetTProcess(parameters, d, result));
        }

        private static string GetDProcess(QuadraticParameters parameters, decimal d)
        {
            return $@"d = {parameters.B + Tex.Squared} - 4{Tex.CDot}{Format.ToPrefixedString(parameters.A, true, false)}{Tex.CDot}{Format.ToPrefixedString(parameters.C, true, false)} = {parameters.B * parameters.B} {Format.ToPrefixedString(-4 * parameters.A * parameters.C)} = {d}";

        }

        private static string GetXProcess(QuadraticParameters parameters, decimal d, QuadraticEquationResult result)
        {
            if (d == 0)
            {
                return @"x = " + Tex.Fraction(Format.ToPrefixedString(-1 * parameters.B), " 2 " + Tex.Squared + Format.ToPrefixedString(parameters.A, true, false)) + " = " + result.X[0];

            }
            else if (d > 0)
            {
                var sqrtd = System.Math.Round(System.Math.Sqrt((double)d), 2);
                var first = Tex.Fraction($"{Format.ToPrefixedString(-1 * parameters.B) }  {Tex.Pm} {Tex.SquareRoot(d.ToString())}", "2" + Tex.CDot + Format.ToPrefixedString(parameters.A, true, false));
                var second = Tex.Fraction($"{Format.ToPrefixedString(-1 * parameters.B)} {Tex.Pm} {sqrtd}", Format.ToPrefixedString(parameters.A * 2, false, false));
                var over1 = Tex.Fraction(Format.ToPrefixedString(-1 * parameters.B) + " + " + sqrtd, Format.ToPrefixedString(parameters.A * 2, false, false));
                var under1 = Tex.Fraction(Format.ToPrefixedString(-1 * parameters.B) + " - " + sqrtd, Format.ToPrefixedString(parameters.A * 2, false, false));
                var over2 = Tex.Fraction((-1 * (double)parameters.B + sqrtd).ToString(), Format.ToPrefixedString(parameters.A * 2, false, false));
                var under2 = Tex.Fraction((-1 * (double)parameters.B - sqrtd).ToString(), Format.ToPrefixedString(parameters.A * 2, false, false));
                return "x = " + first + " = " + second + " = " + Tex.Cases($"{over1} = {over2} = {result.X[0]}", $"{under1} = {under2} = {result.X[1]}");
            }
            else
            {
                return "x = Ø";
            }
        }

        private static IEnumerable<string> GetTProcess(QuadraticParameters p, decimal d, QuadraticEquationResult result)
        {
            var lst = new List<string>();
            lst.Add($"T_x = {Tex.Fraction($"-{Format.ToPrefixedString(p.B, true, false)}", $"2 {Tex.CDot} {Format.ToPrefixedString(p.A, true, false)}")}"
                + $" =  {Tex.Fraction(Format.ToPrefixedString(-p.B, false, false), Format.ToPrefixedString(2 * p.A, false, false))}"
            + $" =  {result.T.X}");

            lst.Add($"T_y = {Tex.Fraction($"-{Format.ToPrefixedString(d, true, false)}", $"4 {Tex.CDot} {Format.ToPrefixedString(p.A, true, false)}")}"
                + $" =  {Tex.Fraction(Format.ToPrefixedString(-d, false, false), Format.ToPrefixedString(4 * p.A, false, false))}"
            + $" =  {result.T.Y}");
            lst.Add($"(T_x{Format.GetCoordinateDelimiter()} T_y) = ({result.T.X}{Format.GetCoordinateDelimiter()} {result.T.Y})");
            return lst;
        }
        private static void SetResult(QuadraticParameters parameters, QuadraticEquationResult result, decimal d)
        {

            if (d == 0)
            {
                result.X.Add(System.Math.Round((-1 * parameters.B) / (2 * parameters.A), 2));
            }
            else if (d > 0)
            {
                var sqrtd = System.Math.Round(System.Math.Sqrt((double)d), 2);
                var plus = (-1 * parameters.B) + Convert.ToDecimal(sqrtd);
                var minus = (-1 * parameters.B) - Convert.ToDecimal(sqrtd);
                var sub = 2 * parameters.A;
                result.X.Add(System.Math.Round(plus / sub, 2));
                result.X.Add(System.Math.Round(minus / sub, 2));

            }
            else
            {
                result.HasResult = false;
            }
            var tx = -parameters.B/(2*parameters.A);
            var ty = -d/(4*parameters.A);
            result.T = new Math.Solver.Core.Model.Navigation.Point(tx, ty);
        }

    }
}
