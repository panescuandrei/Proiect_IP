using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTycoon.Engine.Upgrades
{
    /// <summary>
    /// Îmbunătățirea "Al Doilea Monitor". 
    /// Adaugă un bonus fix la Liniile de Cod generate prin apăsarea manuală a butonului.
    /// </summary>
    public class DualMonitorUpgrade : BaseUpgrade
    {
        /// <summary>
        /// Inițializează upgrade-ul setându-i numele și costul standard de 500 de Linii de Cod.
        /// </summary>
        public DualMonitorUpgrade()
        {
            Name = "Dual Monitor";
            Cost = 500;
        }

        /// <summary>
        /// Verifică dacă jucătorul a adunat suficient progres pentru a debloca acest element.
        /// </summary>
        /// <param name="manager">Instanța curentă a GameManager.</param>
        /// <returns>True dacă jucătorul a produs istoric peste 100 de Linii de Cod.</returns>
        protected override bool UnlockCondition(GameManager manager)
            => manager.TotalLinesOfCode >= 100;

        /// <summary>
        /// Aplică efectul achiziției: adaugă +1 bonus de cod la fiecare click și activează flag-ul specific.
        /// </summary>
        /// <param name="manager">Instanța curentă a GameManager.</param>
        protected override void ApplyEffect(GameManager manager)
        {
            manager.BonusCodePerClick += 1;
            manager.HasDualMonitor = true;
        }
    }
}