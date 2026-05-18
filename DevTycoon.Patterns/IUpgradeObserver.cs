using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTycoon.Patterns
{
    /// <summary>
    /// Interfața ce definește rolul de Observer (Observator) în cadrul jocului.
    /// Permite obiectelor interesate (cum sunt Upgrade-urile) să asculte modificările de stare ale motorului de joc.
    /// </summary>
    public interface IUpgradeObserver
    {
        /// <summary>
        /// Metodă apelată automat de către subiect (GameManager) pentru a trimite notificări când starea jocului s-a schimbat.
        /// </summary>
        /// <param name="gameState">Obiectul care reprezintă starea curentă a jocului (de regulă, o instanță de GameManager).</param>
        void OnGameStateChanged(object gameState);
    }
}