using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTycoon.Patterns
{
    public class SeniorDev : IEmployee
    {
        public string Name => "Senior Developer";
        public double BaseCost => 500.0; 
        public double CodePerSecond => 15.0; 
    }
}
