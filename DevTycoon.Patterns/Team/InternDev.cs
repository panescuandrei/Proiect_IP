/**************************************************************************
 *                                                                        *
 *  File:        InternDev.cs                                             *
 *  Copyright:   (c) 2026 - Ciurilă Maria-Adriana, Frandeș Eugen-Codrin,  *
 *  Pănescu Andrei, Scutariu Darius-Ioan                                  *
 *  E-mail:      maria-adriana.ciurila@student.tuiasi.ro,                 *
 *               eugen-codrin.frandes@student.tuiasi.ro,                  *
 *               andrei.panescu@student.tuiasi.ro,                        *
 *               darius-ioan.scutariu@student.tuiasi.ro                   *
 *  Description: Definește datele de cost și producție pentru angajatul   *
 *  de tip stagiar (Intern Developer).                                    *
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
    /// Clasa pentru angajatul de tip Intern (Stagiar). 
    /// Este cel mai ieftin angajat, disponibil de la începutul jocului, dar cu aport minim de cod.
    /// </summary>
    public class InternDev : IEmployee
    {
        public string Name => "Intern Developer";
        public double BaseCost => 25.0;
        public double CodePerSecond => 0.25;
        public double UnlockAt => 0;
    }
}
