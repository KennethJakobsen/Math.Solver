using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Math.Solver.Core.CoordinateSystem;
using Math.Solver.Core.Equations.Quadratic;
using Math.Solver.Core.Equations.QuadraticEquation;
using Math.Solver.Core.Model.Equations.QuadraticEquation;
using Point = Math.Solver.Core.Model.Navigation.Point;

namespace Math.Solver.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var solver = new QuadraticEquationSolver();
            var param = new QuadraticParameters()
            {
                A = 2,
                B = 2,
                C = -2
            };
            var res = solver.Solve(param);
            foreach (var proc in res.Process)
            {
                System.Console.WriteLine(proc);
            }

            foreach (var proc in res.Process)
            {
                System.Console.WriteLine(proc);
            }
            var points = new List<Point>();
            var slv = new QuadraticPolynomiumSolver();
            for (int i = -20; i <= 20; i++)
            {
                points.Add(new Point(i, slv.Solve(param, i)));
            }
            var coord = new TwoDimensionalCoordinateSystem(1000);
            coord.DrawBezier(points, String.Empty, Color.Red);
            coord.Save(Environment.CurrentDirectory);

        }
    }
}
