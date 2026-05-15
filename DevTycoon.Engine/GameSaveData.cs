using System.Runtime.Serialization;

namespace DevTycoon.Engine
{
    [DataContract]
    public class GameSaveData
    {
        [DataMember]
        public double LinesOfCode { get; set; }

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

        [DataMember]
        public int InternCount { get; set; }

        [DataMember]
        public int JuniorCount { get; set; }

        [DataMember]
        public int SeniorCount { get; set; }

        [DataMember]
        public int SysArchiCount { get; set; }
    }
}