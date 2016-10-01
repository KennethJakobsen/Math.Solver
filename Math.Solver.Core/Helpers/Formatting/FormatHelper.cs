namespace Math.Solver.Core.Helpers.Formatting
{
    public class FormatHelper
    {
        public string ToPrefixedString(decimal input, bool parenthesis = false, bool prefixpositive = true)
        {
            if(!parenthesis && prefixpositive)
                return input > 0 ? $"+ {input}" : $"{input}";
            if (!parenthesis && !prefixpositive)
                return input > 0 ? $"{input}" : $"{input}";
            if (parenthesis && !prefixpositive)
                return input > 0 ? $"{input}" : $"({input})";
            return input > 0 ? $"+ {input}" : $"({input})";
        }
    }
}
