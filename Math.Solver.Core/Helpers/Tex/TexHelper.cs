using System.Dynamic;

namespace Math.Solver.Core.Helpers.Tex
{
    public static class Tex
    {
        public static string Fraction(string over, string under)
        {
            return @"\frac{" + over + "} { " + under + "}";
        }

        public static string Cases(string over, string under)
        {
            return @"\begin{cases} " + over + @" \\ \\ " + under + @" \end{cases}";
        }

        public static string CDot => @" \cdot ";

        public static string Squared => "^2";


        public static string Pm => @" \pm ";
        

        public static string SquareRoot(string str)
        {
            return @"\sqrt{" + str + @"}";
        }
    }
}
