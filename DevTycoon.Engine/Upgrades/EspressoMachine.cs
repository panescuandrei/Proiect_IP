/**************************************************************************
 *                                                                        *
 *  File:        EspressoMachine.cs                                       *
 *  Copyright:   (c) 2026 - Ciurilă Maria-Adriana, Frandeș Eugen-Codrin,  *
 *  Pănescu Andrei, Scutariu Darius-Ioan                                  *
 *  E-mail:      maria-adriana.ciurila@student.tuiasi.ro,                 *
 *               eugen-codrin.frandes@student.tuiasi.ro,                  *
 *               andrei.panescu@student.tuiasi.ro,                        *
 *               darius-ioan.scutariu@student.tuiasi.ro                   *
 *  Description: Implementează îmbunătățirea "Espressor de Cafea" ce      *
 *  oferă un multiplicator temporar de productivitate.                    *
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