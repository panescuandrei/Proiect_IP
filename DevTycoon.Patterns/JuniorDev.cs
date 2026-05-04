using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTycoon.Patterns
{
    public class JuniorDev : IEmployee
    {
        public string Name => "Junior Developer";
        public double BaseCost => 50.0;
        public double CodePerSecond => 1.15;
    }
}
