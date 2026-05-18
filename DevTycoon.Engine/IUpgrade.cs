/**************************************************************************
 *                                                                        *
 *  File:        IUpgrade.cs                                              *
 *  Copyright:   (c) 2026 - Ciurilă Maria-Adriana, Frandeș Eugen-Codrin,  *
 *  Pănescu Andrei, Scutariu Darius-Ioan                                  *
 *  E-mail:      maria-adriana.ciurila@student.tuiasi.ro,                 *
 *               eugen-codrin.frandes@student.tuiasi.ro,                  *
 *               andrei.panescu@student.tuiasi.ro,                        *
 *               darius-ioan.scutariu@student.tuiasi.ro                   *
 *  Description: Definește interfața standard pe care trebuie să o        *
 *  implementeze orice îmbunătățire din joc.                              *
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
        bool IsPurchased { get; set; }

        /// <summary>Textul dinamic afișat pe buton.</summary>
        string ButtonText { get; }

        /// <summary>Logica de cumpărare a îmbunătățirii.</summary>
        void Purchase(GameManager manager);

        /// <summary>Metodă apelată de GameManager atunci când un bug apare în sistem.</summary>
        void OnBugTriggered(GameManager manager);
    }
}
