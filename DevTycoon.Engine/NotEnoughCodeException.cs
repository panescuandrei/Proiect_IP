using System;
using System.Collections.Generic;
using System.Linq;
/**************************************************************************
 *                                                                        *
 *  File:        NotEnoughCodeExceptions.cs                               *
 *  Copyright:   (c) 2026 - Ciurilă Maria-Adriana, Frandeș Eugen-Codrin,  *
 *  Pănescu Andrei, Scutariu Darius-Ioan                                  *
 *  E-mail:      maria-adriana.ciurila@student.tuiasi.ro,                 *
 *               eugen-codrin.frandes@student.tuiasi.ro,                  *
 *               andrei.panescu@student.tuiasi.ro,                        *
 *               darius-ioan.scutariu@student.tuiasi.ro                   *
 *  Description: Definește o excepție personalizată aruncată atunci când  *
 *  jucătorul nu are suficiente resurse (Linii de Cod) pentru o achiziție *
 *  sau lansare.                                                          *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/
using System.Text;
using System.Threading.Tasks;

namespace DevTycoon.Engine
{
    /// <summary>
    /// Excepție personalizată aruncată atunci când jucătorul încearcă să cumpere un element 
    /// fără a avea cantitatea necesară de Linii de Cod.
    /// </summary>
    public class NotEnoughCodeException : Exception
    {
        /// <summary>
        /// Creează o nouă instanță a excepției cu un mesaj detaliat.
        /// </summary>
        /// <param name="message">Mesajul care explică de ce operațiunea a eșuat.</param>
        public NotEnoughCodeException(string message) : base(message) { }
    }
}
