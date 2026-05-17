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