namespace Math.Solver.Core.Helpers.Formatting
{
    public static class Format
    {
        public static string ToPrefixedString(decimal input, bool parenthesis = false, bool prefixpositive = true)
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
