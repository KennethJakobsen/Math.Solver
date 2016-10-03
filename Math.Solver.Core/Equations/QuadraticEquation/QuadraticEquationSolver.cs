using System;
using Math.Solver.Core.Helpers.Formatting;
using Math.Solver.Core.Helpers.Tex;
using Math.Solver.Core.Model.Equations.QuadraticEquation;
using Math = System.Math;

namespace Math.Solver.Core.Equations.QuadraticEquation
{
    public class QuadraticEquationSolver
    {


        public QuadraticEquationResult Solve(QuadraticEquationParameters parameters)
        {
            var result = new QuadraticEquationResult();

            var d = (parameters.B * parameters.B) - (4 * parameters.A * parameters.C);
            SetResult(parameters, result, d);
            SetProcessInTexFormat(parameters, result, d);
            


            return result;
        }

        private static void SetProcessInTexFormat(QuadraticEquationParameters parameters, QuadraticEquationResult result, decimal d)
        {
            result.Process.Add(parameters.A + "x" + Tex.Squared + Format.ToPrefixedString(parameters.B) + "x " + Format.ToPrefixedString(parameters.C) + @" = 0");
            result.Process.Add($@"d = {parameters.B + Tex.Squared} - 4{Tex.CDot}{Format.ToPrefixedString(parameters.A, true, false)}{Tex.CDot}{Format.ToPrefixedString(parameters.C, true)} = {parameters.B * parameters.B} {Format.ToPrefixedString(-4 * parameters.A * parameters.C)} = {d}");
           if (d == 0)
            {
                result.Process.Add(@"x = " +Tex.Fraction(Format.ToPrefixedString(-1 * parameters.B) , " 2 " + Tex.Squared + Format.ToPrefixedString(parameters.A, true, false)) + " = " + result.Results[0]);
                
            }
            else if (d > 0)
            {
               var first = Tex.Fraction($"{Format.ToPrefixedString(-1 * parameters.B) }  {Tex.Pm} {Tex.SquareRoot(d.ToString())}" , "2" + Tex.CDot + Format.ToPrefixedString(parameters.A, true, false) );
                var second = Tex.Fraction($"{Format.ToPrefixedString(-1 * parameters.B)} {Tex.Pm} {System.Math.Sqrt((double)d)}", Format.ToPrefixedString(parameters.A *2, true, false));
                var over1 = Tex.Fraction(Format.ToPrefixedString(-1*parameters.B) + " + " + System.Math.Sqrt((double) d), Format.ToPrefixedString(parameters.A * 2, true, false));
                var under1 =Tex.Fraction(Format.ToPrefixedString(-1 * parameters.B) + " - " + System.Math.Sqrt((double)d), Format.ToPrefixedString(parameters.A * 2, true, false));
                var over2 = Tex.Fraction((-1*(double) parameters.B + System.Math.Sqrt((double) d)).ToString(),Format.ToPrefixedString(parameters.A*2, true, false));
                var under2 = Tex.Fraction((-1 * (double)parameters.B - System.Math.Sqrt((double)d)).ToString(), Format.ToPrefixedString(parameters.A * 2, true, false));
                result.Process.Add("x = "+ first+ " = " + second + " = " + Tex.Cases($"{over1} = {over2} = {result.Results[0]}", $"{under1} = {under2} = {result.Results[1]}"));
            }
            else
            {
                result.HasResult = false;
                result.Process.Add("x = Ø");
            }
        }
        private static void SetResult(QuadraticEquationParameters parameters, QuadraticEquationResult result, decimal d)
        {

            if (d == 0)
            {
                result.Results.Add((-1 * parameters.B) / (2 * parameters.A));
            }
            else if (d > 0)
            {
                var plus = (-1 * parameters.B) + Convert.ToDecimal(System.Math.Sqrt((double)d));
                var minus = (-1 * parameters.B) - Convert.ToDecimal(System.Math.Sqrt((double)d));
                var sub = 2 * parameters.A;
                result.Results.Add(plus / sub);
                result.Results.Add(minus / sub);

            }
            else
            {
                result.HasResult = false;
            }
        }
        
    }
}
