using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTycoon.Patterns
{
    public static class EmployeeFactory
    {
        public static IEmployee CreateEmployee(string type)
        {
            switch (type.ToLower())
            {
                case "junior":
                    return new JuniorDev();

                case "senior": 
                    return new SeniorDev();
                //alte upgrade mai incolo
                default:
                    throw new ArgumentException("Unknown employee type.");
            }
        }
    }
}
