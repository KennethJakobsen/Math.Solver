using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Math.Solver.Core.Model.Equations.QuadraticEquation;

namespace Math.Solver.Core.Equations.Quadratic
{
    public class QuadraticPolynomiumSolver
    {
        public int Solve(QuadraticParameters parameters, int x)
        {
            var ax = parameters.A * (x*x);
            var bx = parameters.B*x;
            var test = 1 + parameters.C;
            return Convert.ToInt32((ax) + (bx) + parameters.C);
        }
    }
}
