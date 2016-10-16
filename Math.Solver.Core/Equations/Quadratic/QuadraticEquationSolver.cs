using System;
using Math.Solver.Core.Helpers.Formatting;
using Math.Solver.Core.Helpers.Tex;
using Math.Solver.Core.Model.Equations.QuadraticEquation;
using Math = System.Math;

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
            result.Process.Add(parameters.A + "x" + Tex.Squared + Format.ToPrefixedString(parameters.B) + "x " + Format.ToPrefixedString(parameters.C) + @" = 0");
            result.Process.Add(GetDProcess(parameters, d));
            result.Process.Add(GetXProcess(parameters, d, result));
            result.DProcess.Add(GetDProcess(parameters, d));
            result.XProcess.Add(GetXProcess(parameters, d, result));
        }

        private static string GetDProcess(QuadraticParameters parameters, decimal d)
        {
            return $@"d = {parameters.B + Tex.Squared} - 4{Tex.CDot}{Format.ToPrefixedString(parameters.A, true, false)}{Tex.CDot}{Format.ToPrefixedString(parameters.C, true)} = {parameters.B * parameters.B} {Format.ToPrefixedString(-4 * parameters.A * parameters.C)} = {d}";

        }

        private static string GetXProcess(QuadraticParameters parameters, decimal d, QuadraticEquationResult result)
        {
            if (d == 0)
            {
                return @"x = " + Tex.Fraction(Format.ToPrefixedString(-1 * parameters.B), " 2 " + Tex.Squared + Format.ToPrefixedString(parameters.A, true, false)) + " = " + result.X[0];

            }
            else if (d > 0)
            {
                var first = Tex.Fraction($"{Format.ToPrefixedString(-1 * parameters.B) }  {Tex.Pm} {Tex.SquareRoot(d.ToString())}", "2" + Tex.CDot + Format.ToPrefixedString(parameters.A, true, false));
                var second = Tex.Fraction($"{Format.ToPrefixedString(-1 * parameters.B)} {Tex.Pm} {System.Math.Sqrt((double)d)}", Format.ToPrefixedString(parameters.A * 2, true, false));
                var over1 = Tex.Fraction(Format.ToPrefixedString(-1 * parameters.B) + " + " + System.Math.Sqrt((double)d), Format.ToPrefixedString(parameters.A * 2, true, false));
                var under1 = Tex.Fraction(Format.ToPrefixedString(-1 * parameters.B) + " - " + System.Math.Sqrt((double)d), Format.ToPrefixedString(parameters.A * 2, true, false));
                var over2 = Tex.Fraction((-1 * (double)parameters.B + System.Math.Sqrt((double)d)).ToString(), Format.ToPrefixedString(parameters.A * 2, true, false));
                var under2 = Tex.Fraction((-1 * (double)parameters.B - System.Math.Sqrt((double)d)).ToString(), Format.ToPrefixedString(parameters.A * 2, true, false));
                return "x = " + first + " = " + second + " = " + Tex.Cases($"{over1} = {over2} = {result.X[0]}", $"{under1} = {under2} = {result.X[1]}");
            }
            else
            {
                return "x = Ø";
            }
        }
        private static void SetResult(QuadraticParameters parameters, QuadraticEquationResult result, decimal d)
        {

            if (d == 0)
            {
                result.X.Add((-1 * parameters.B) / (2 * parameters.A));
            }
            else if (d > 0)
            {
                var plus = (-1 * parameters.B) + Convert.ToDecimal(System.Math.Sqrt((double)d));
                var minus = (-1 * parameters.B) - Convert.ToDecimal(System.Math.Sqrt((double)d));
                var sub = 2 * parameters.A;
                result.X.Add(plus / sub);
                result.X.Add(minus / sub);

            }
            else
            {
                result.HasResult = false;
            }
        }
        
    }
}
