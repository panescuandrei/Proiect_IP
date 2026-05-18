using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTycoon.Engine.Upgrades
{
    /// <summary>
    /// Îmbunătățirea "Tastatură Mecanică". 
    /// Dublează numărul de Linii de Cod obținute la fiecare click manual.
    /// </summary>
    public class MechanicalKeyboardUpgrade : BaseUpgrade
    {
        /// <summary>
        /// Inițializează upgrade-ul setându-i numele și costul standard de 250 de Linii de Cod.
        /// </summary>
        public MechanicalKeyboardUpgrade()
        {
            Name = "Mechanical Keyboard";
            Cost = 250;
        }

        /// <summary>
        /// Verifică dacă jucătorul îndeplinește condiția pentru a vedea acest upgrade.
        /// </summary>
        /// <param name="manager">Instanța curentă a GameManager.</param>
        /// <returns>True dacă jucătorul a produs istoric peste 40 de Linii de Cod, altfel False.</returns>
        protected override bool UnlockCondition(GameManager manager)
            => manager.TotalLinesOfCode >= 40;

        /// <summary>
        /// Aplică efectul cumpărării: informează GameManager-ul că jucătorul deține acum o tastatură mecanică.
        /// </summary>
        /// <param name="manager">Instanța curentă a GameManager.</param>
        protected override void ApplyEffect(GameManager manager)
            => manager.HasMechanicalKeyboard = true;
    }
}