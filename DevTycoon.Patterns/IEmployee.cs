using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTycoon.Patterns
{
    /// <summary>
    /// Interfața de bază pentru toți angajații (programatorii) din joc.
    /// Definește proprietățile esențiale pentru cost, producție și deblocare.
    /// </summary>
    public interface IEmployee
    {
        /// <summary>Numele de afișare al tipului de angajat (ex: "Junior Developer").</summary>
        string Name { get; }

        /// <summary>Costul de bază inițial pentru angajarea primului programator de acest tip.</summary>
        double BaseCost { get; }

        /// <summary>Numărul de Linii de Cod generate automat de acest angajat în fiecare secundă (CPS).</summary>
        double CodePerSecond { get; }

        /// <summary>Pragul de Linii de Cod totale necesar pentru a debloca acest tip de angajat în magazin.</summary>
        double UnlockAt { get; }
    }
}