/**************************************************************************
 *                                                                        *
 *  File:        IUpgradeObserver.cs                                      *
 *  Copyright:   (c) 2026 - Ciurilă Maria-Adriana, Frandeș Eugen-Codrin,  *
 *  Pănescu Andrei, Scutariu Darius-Ioan                                  *
 *  E-mail:      maria-adriana.ciurila@student.tuiasi.ro,                 *
 *               eugen-codrin.frandes@student.tuiasi.ro,                  *
 *               andrei.panescu@student.tuiasi.ro,                        *
 *               darius-ioan.scutariu@student.tuiasi.ro                   *
 *  Description: Definește interfața pentru șablonul Observer, folosită   *
 *  pentru a asculta modificările de stare din motorul de joc.            *
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