using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DevTycoon.Patterns;

namespace DevTycoon.Engine
{
    /// <summary>
    /// Interfața pe care trebuie să o implementeze orice îmbunătățire (Upgrade) din joc.
    /// Moștenește IUpgradeObserver pentru a reacționa la schimbările de stare.
    /// </summary>
    public interface IUpgrade : IUpgradeObserver
    {
        /// <summary>Numele îmbunătățirii.</summary>
        string Name { get; }

        /// <summary>Costul îmbunătățirii.</summary>
        double Cost { get; }

        /// <summary>Starea de deblocare.</summary>
        bool IsUnlocked { get; }

        /// <summary>Starea de achiziție.</summary>
        bool IsPurchased { get; }

        /// <summary>Textul dinamic afișat pe buton.</summary>
        string ButtonText { get; }

        /// <summary>Logica de cumpărare a îmbunătățirii.</summary>
        void Purchase(GameManager manager);

        /// <summary>Metodă apelată de GameManager atunci când un bug apare în sistem.</summary>
        void OnBugTriggered(GameManager manager);
    }
}
