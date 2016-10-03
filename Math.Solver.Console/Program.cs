using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Math.Solver.Core.Equations.SecondDegreeEquation;
using Math.Solver.Core.Model.Equations.QuadraticEquation;

namespace Math.Solver.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var solver = new SecondDegreeEquationSolver();
            var param = new QuadraticEquationParameters()
            {
                A = 2,
                B = 20,
                C = -22
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
        }
    }
}
