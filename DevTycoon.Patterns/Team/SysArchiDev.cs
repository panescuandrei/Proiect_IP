using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTycoon.Patterns
{
    /// <summary>
    /// Clasa pentru angajatul de tip Arhitect de Sistem. 
    /// Cel mai avansat și costisitor expert, capabil să genereze cantități uriașe de cod pasiv.
    /// </summary>
    public class SysArchiDev : IEmployee
    {
        public string Name => "System Architect";
        public double BaseCost => 1000.0;
        public double CodePerSecond => 20.0;
        public double UnlockAt => 500.0;
    }
}
