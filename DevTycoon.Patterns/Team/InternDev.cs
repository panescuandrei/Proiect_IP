using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTycoon.Patterns
{
    public class InternDev : IEmployee
    {
        public string Name => "Intern Developer";
        public double BaseCost => 25.0;
        public double CodePerSecond => 0.25;
        public double UnlockAt => 0;
    }
}
