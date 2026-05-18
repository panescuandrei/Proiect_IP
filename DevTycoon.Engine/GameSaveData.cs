/**************************************************************************
 *                                                                        *
 *  File:        GameSaveData.cs                                          *
 *  Copyright:   (c) 2026 - Ciurilă Maria-Adriana, Frandeș Eugen-Codrin,  *
 *  Pănescu Andrei, Scutariu Darius-Ioan                                  *
 *  E-mail:      maria-adriana.ciurila@student.tuiasi.ro,                 *
 *               eugen-codrin.frandes@student.tuiasi.ro,                  *
 *               andrei.panescu@student.tuiasi.ro,                        *
 *               darius-ioan.scutariu@student.tuiasi.ro                   *
 *  Description: Contract de date utilizat pentru serializarea stării     *
 *  jocului în vederea salvării și încărcării progresului jucătorului.    *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/
using System.Runtime.Serialization;

namespace DevTycoon.Engine
{
    /// <summary>
    /// Contract de date care stochează toate informațiile necesare pentru a salva și a încărca progresul jucătorului.
    /// </summary>
    [DataContract]
    public class GameSaveData
    {
        /// <summary>Moneda curentă salvată.</summary>
        [DataMember]
        public double LinesOfCode { get; set; }

        /// <summary>Totalul istoric salvat.</summary>
        [DataMember]
        public double TotalLinesOfCode { get; set; }

        [DataMember]
        public bool HasMechanicalKeyboard { get; set; }

        [DataMember]
        public bool HasDualMonitor { get; set; }

        [DataMember]
        public bool HasPipeline { get; set; }

        [DataMember]
        public bool HasEspressoMachine { get; set; }

        [DataMember]
        public bool IsBugActive { get; set; }

        [DataMember]
        public int BugClicksRemaining { get; set; }

        [DataMember]
        public int CurrentVersion { get; set; }

        /// <summary>Numărul de Interni salvați.</summary>
        [DataMember]
        public int InternCount { get; set; }

        /// <summary>Numărul de Juniori salvați.</summary>
        [DataMember]
        public int JuniorCount { get; set; }

        /// <summary>Numărul de Seniori salvați.</summary>
        [DataMember]
        public int SeniorCount { get; set; }

        /// <summary>Numărul de Arhitecți de Sistem salvați.</summary>
        [DataMember]
        public int SysArchiCount { get; set; }
    }
}