using System.Globalization;

namespace Math.Solver.Core.Helpers.Formatting
{
    public static class Format
    {
        public static string ToPrefixedString(decimal input, bool parenthesis = false, bool prefixpositive = true)
        {

            if (!parenthesis && prefixpositive)
                return input >= 0 ? $"+ {input}" : $"{input}";
            if (!parenthesis && !prefixpositive)
                return input > 0 ? $"{input}" : $"{input}";
            if (parenthesis && !prefixpositive)
                return input > 0 ? $"{input}" : $"({input})";
            return input > 0 ? $"+ {input}" : $"({input})";
        }

        public static string PrintMultiplier(decimal m, bool prefixPositive)
        {
            if (prefixPositive && m == 1)
                return "+";
            if (!prefixPositive && m == 1)
                return string.Empty;
            return m == -1 ? "-" : m.ToString();
        }

        public static string GetCoordinateDelimiter()
        {
            return CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == "," ? ";" : ",";
        }
    }
}
