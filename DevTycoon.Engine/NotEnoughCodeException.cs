using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTycoon.Engine
{
    public class NotEnoughCodeException : Exception
    {
        public NotEnoughCodeException(string message) : base(message) { }
    }
}
