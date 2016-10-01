using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math.Solver.Core.Helpers.Formatting
{
    public interface IHelpFormatNumbers
    {
        string ToPrefixedString(decimal input, bool parenthesis = false, bool prefixpositive = false);
    }
}
