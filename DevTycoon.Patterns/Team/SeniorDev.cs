using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTycoon.Patterns
{
    /// <summary>
    /// Clasa pentru angajatul de tip Senior. 
    /// Un veteran scump, dar care aduce un spor masiv de viteză startup-ului tău.
    /// </summary>
    public class SeniorDev : IEmployee
    {
        public string Name => "Senior Developer";
        public double BaseCost => 500.0; 
        public double CodePerSecond => 15.0;
        public double UnlockAt => 100.0;
    }
}
