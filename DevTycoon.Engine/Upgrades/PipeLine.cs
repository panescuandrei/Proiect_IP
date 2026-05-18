/**************************************************************************
 *                                                                        *
 *  File:        Pipeline.cs                                              *
 *  Copyright:   (c) 2026 - Ciurilă Maria-Adriana, Frandeș Eugen-Codrin,  *
 *  Pănescu Andrei, Scutariu Darius-Ioan                                  *
 *  E-mail:      maria-adriana.ciurila@student.tuiasi.ro,                 *
 *               eugen-codrin.frandes@student.tuiasi.ro,                  *
 *               andrei.panescu@student.tuiasi.ro,                        *
 *               darius-ioan.scutariu@student.tuiasi.ro                   *
 *  Description: Implementează infrastructura "CI/CD Pipeline" care       *
 *  reduce efortul manual necesar pentru repararea bug-urilor.            *
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
    /// Îmbunătățirea de infrastructură "CI/CD Pipeline".
    /// Reduce semnificativ efortul manual necesar pentru a repara bug-urile care apar în timpul jocului.
    /// </summary>
    public class Pipeline : BaseUpgrade
    {
        /// <summary>
        /// Inițializează upgrade-ul setându-i numele și costul standard de 700 de Linii de Cod.
        /// </summary>
        public Pipeline()
        {
            Name = "CI/CD Pipeline";
            Cost = 700;
        }

        /// <summary>
        /// Condiția de deblocare pentru acest upgrade necesită deținerea unei îmbunătățiri anterioare.
        /// </summary>
        /// <param name="manager">Instanța curentă a GameManager.</param>
        /// <returns>True dacă jucătorul a achiziționat deja "Dual Monitor".</returns>
        protected override bool UnlockCondition(GameManager manager)
            => manager.HasDualMonitor == true;

        /// <summary>
        /// Aplică efectul achiziției marcând activarea sistemului automatizat în GameManager.
        /// </summary>
        /// <param name="manager">Instanța curentă a GameManager.</param>
        protected override void ApplyEffect(GameManager manager)
            => manager.HasPipeline = true;

        /// <summary>
        /// Funcție declanșată automat atunci când apare un bug critic în joc. 
        /// Reduce numărul total de click-uri necesare pentru remedierea acestuia cu 3.
        /// </summary>
        /// <param name="manager">Instanța curentă a GameManager.</param>
        public override void OnBugTriggered(GameManager manager)
            => manager.ReduceBugClicks(3);
    }
}