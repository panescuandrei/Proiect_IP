using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTycoon.Engine.Upgrades
{
    /// <summary>
    /// Îmbunătățirea "Espressor de Cafea".
    /// Un upgrade esențial pentru starea de bine a echipei, care adaugă beneficii pe termen lung în startup.
    /// </summary>
    public class EspressoMachine : BaseUpgrade
    {
        /// <summary>
        /// Inițializează aparatul de cafea setându-i numele și costul premium de 1000 de Linii de Cod.
        /// </summary>
        public EspressoMachine()
        {
            Name = "Espresso Machine";
            Cost = 1000;
        }

        /// <summary>
        /// Acest upgrade reprezintă un nivel avansat și necesită o companie bine structurată pentru a fi deblocat.
        /// </summary>
        /// <param name="manager">Instanța curentă a GameManager.</param>
        /// <returns>True dacă sistemul "CI/CD Pipeline" a fost deja cumpărat.</returns>
        protected override bool UnlockCondition(GameManager manager)
            => manager.HasPipeline;

        /// <summary>
        /// Aplică efectul final instalând espressorul în sediul companiei.
        /// </summary>
        /// <param name="manager">Instanța curentă a GameManager.</param>
        protected override void ApplyEffect(GameManager manager)
        {
            manager.HasEspressoMachine = true;
        }
    }
}