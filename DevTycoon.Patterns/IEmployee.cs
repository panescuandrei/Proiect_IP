using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTycoon.Patterns
{
    public interface IEmployee
    {
        string Name { get; }
        double BaseCost { get; }
        double CodePerSecond { get; }
    }
}
