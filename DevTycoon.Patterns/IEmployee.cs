/**************************************************************************
 *                                                                        *
 *  File:        IEmployee.cs                                             *
 *  Copyright:   (c) 2026 - Ciurilă Maria-Adriana, Frandeș Eugen-Codrin,  *
 *  Pănescu Andrei, Scutariu Darius-Ioan                                  *
 *  E-mail:      maria-adriana.ciurila@student.tuiasi.ro,                 *
 *               eugen-codrin.frandes@student.tuiasi.ro,                  *
 *               andrei.panescu@student.tuiasi.ro,                        *
 *               darius-ioan.scutariu@student.tuiasi.ro                   *
 *  Description: Definește interfața de bază pe care o implementează      *
 *  toate tipurile de programatori din joc.                               *
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
    /// Interfața de bază pentru toți angajații (programatorii) din joc.
    /// Definește proprietățile esențiale pentru cost, producție și deblocare.
    /// </summary>
    public interface IEmployee
    {
        /// <summary>Numele de afișare al tipului de angajat (ex: "Junior Developer").</summary>
        string Name { get; }

        /// <summary>Costul de bază inițial pentru angajarea primului programator de acest tip.</summary>
        double BaseCost { get; }

        /// <summary>Numărul de Linii de Cod generate automat de acest angajat în fiecare secundă (CPS).</summary>
        double CodePerSecond { get; }

        /// <summary>Pragul de Linii de Cod totale necesar pentru a debloca acest tip de angajat în magazin.</summary>
        double UnlockAt { get; }
    }
}