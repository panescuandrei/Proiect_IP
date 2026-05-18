using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTycoon.Patterns
{
    /// <summary>
    /// Clasa pentru angajatul de tip Junior. 
    /// Un programator la început de drum, deblocat destul de repede în joc.
    /// </summary>
    public class JuniorDev : IEmployee
    {
        public string Name => "Junior Developer";
        public double BaseCost => 50.0;
        public double CodePerSecond => 1.15;
        public double UnlockAt => 50;
    }
}
