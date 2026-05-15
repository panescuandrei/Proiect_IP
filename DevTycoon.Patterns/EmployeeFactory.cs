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
                case "intern":
                    return new InternDev();

                case "junior":
                    return new JuniorDev();

                case "senior": 
                    return new SeniorDev();

                case "sysarchitect":
                    return new SysArchiDev();
                default:
                    throw new ArgumentException("Unknown employee type.");
            }

        }
        public static double GetUnlockAt(string type)
        {
            return CreateEmployee(type).UnlockAt;
        }
        public static string GetDisplayName(string type)
        {
            return CreateEmployee(type).Name;
        }
    }
}
