/**************************************************************************
 *                                                                        *
 *  File:        BaseUpgrade.cs                                           *
 *  Copyright:   (c) 2026 - Ciurilă Maria-Adriana, Frandeș Eugen-Codrin,  *
 *  Pănescu Andrei, Scutariu Darius-Ioan                                  *
 *  E-mail:      maria-adriana.ciurila@student.tuiasi.ro,                 *
 *               eugen-codrin.frandes@student.tuiasi.ro,                  *
 *               andrei.panescu@student.tuiasi.ro,                        *
 *               darius-ioan.scutariu@student.tuiasi.ro                   *
 *  Description: Clasă de bază abstractă care oferă funcționalitatea      *
 *  comună (deblocare, cumpărare, aplicare efect) pentru toate            *
 *  îmbunătățirile din joc.                                               *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTycoon.Engine
{
    /// <summary>
    /// Clasa de bază abstractă pentru toate îmbunătățirile (upgrades) din joc.
    /// Oferă funcționalitatea standard pentru deblocare și cumpărare.
    /// </summary>
    public abstract class BaseUpgrade : IUpgrade
    {
        /// <summary>Numele îmbunătățirii.</summary>
        public string Name { get; protected set; }

        /// <summary>Costul îmbunătățirii în Linii de Cod.</summary>
        public double Cost { get; protected set; }

        /// <summary>Indică dacă îmbunătățirea a devenit vizibilă/disponibilă pentru jucător.</summary>
        public bool IsUnlocked { get; private set; }

        /// <summary>Indică dacă îmbunătățirea a fost deja cumpărată.</summary>
        public bool IsPurchased { get; set; }

        /// <summary>Textul afișat pe butonul din interfață, care se schimbă în funcție de starea achiziției.</summary>
        public virtual string ButtonText => IsPurchased ? $"{Name} (Owned)": $"Buy {Name} (Cost: {Cost})";


        /// <summary>
        /// Metodă apelată atunci când apare un bug în joc, permițând upgrade-ului să reacționeze (ex: Pipeline scade click-urile necesare).
        /// </summary>
        /// <param name="manager">Instanța curentă a GameManager.</param>
        public virtual void OnBugTriggered(GameManager manager) { }


        // Fiecare upgrade defineste propria conditie de unlock
        /// <summary>Definește condiția specifică pentru ca acest upgrade să devină disponibil.</summary>
        /// <param name="manager">Instanța curentă a GameManager.</param>
        /// <returns>True dacă se îndeplinește condiția de deblocare, altfel False.</returns>
        protected abstract bool UnlockCondition(GameManager manager);


        // Fiecare upgrade defineste propriu efect
        /// <summary>Aplică efectul permanent al acestui upgrade asupra jocului.</summary>
        /// <param name="manager">Instanța curentă a GameManager.</param>
        protected abstract void ApplyEffect(GameManager manager);

        // Observer - se apeleaza la fiecare tick
        /// <summary>
        /// Metodă din pattern-ul Observer, apelată la fiecare actualizare a jocului pentru a verifica dacă upgrade-ul trebuie deblocat.
        /// </summary>
        /// <param name="gameState">Starea curentă a jocului (GameManager).</param>
        public void OnGameStateChanged(object gameState)
        {
            GameManager manager = (GameManager)gameState;
            if (!IsUnlocked && UnlockCondition(manager))
                IsUnlocked = true;
        }

        /// <summary>
        /// Procesează cumpărarea îmbunătățirii: verifică disponibilitatea, scade fondurile și aplică efectul.
        /// </summary>
        /// <param name="manager">Instanța curentă a GameManager.</param>
        /// <exception cref="NotEnoughCodeException">Aruncată dacă jucătorul nu are suficiente Linii de Cod sau upgrade-ul nu e disponibil.</exception>
        public void Purchase(GameManager manager)
        {
            if (!IsUnlocked || IsPurchased)
                throw new NotEnoughCodeException("Upgrade not available!");

            if (manager.LinesOfCode < Cost)
                throw new NotEnoughCodeException($"You need {Cost} lines of code for {Name}.");

            manager.SpendCode(Cost);
            ApplyEffect(manager);
            IsPurchased = true;
        }
    }
}
