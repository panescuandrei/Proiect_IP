using DevTycoon.Engine.Upgrades;
using DevTycoon.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTycoon.Engine
{
    public class GameManager
    {
        // Singleton
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameManager();
                return _instance;
            }
        }
        public double LinesOfCode { get; private set; }
        public double TotalLinesOfCode { get; private set; }

        public List<IEmployee> Team { get; private set; }

        public bool HasMechanicalKeyboard { get; internal set; } // pt a putea fi setat separat
        public bool HasDualMonitor { get; internal set; }
        public bool HasPipeline { get; internal set; }
        public bool HasEspressoMachine { get; internal set; }
        public bool IsBugActive { get; private set; }
        public int BugClicksRemaining { get; private set; } // pt a putea fi setat in pipeline
        public int CurrentVersion { get; private set; } = 0;
        public double NextVersionCost => 10000.0 * Math.Pow(2, CurrentVersion); // 10k, dupa 20k, 30k etc.

        // Observer Design patter, pt upgrades
        public List<IUpgrade> Upgrades { get; private set; }
        public int BonusCodePerClick { get; set; } = 0;  // pentru DualMonitor etc.

        public void ReduceBugClicks(int amount)
        {
            BugClicksRemaining = Math.Max(1, BugClicksRemaining - amount);
        }

        // a devenit singleton
        private GameManager()
        {            
            LinesOfCode = 0;
            TotalLinesOfCode = 0;
            Team = new List<IEmployee>();

            HasMechanicalKeyboard = false;
            HasDualMonitor = false;
            HasPipeline = false;
            HasEspressoMachine = false;

            Upgrades = new List<IUpgrade> // perma upgrades
                {
                    new MechanicalKeyboardUpgrade(),
                    new DualMonitorUpgrade(),
                    new Pipeline(),
                    new EspressoMachine()
                };

        }
        public void Reset()
        {
            LinesOfCode = 0;
            TotalLinesOfCode = 0;
            Team = new List<IEmployee>();
            HasMechanicalKeyboard = false;
            HasDualMonitor = false;
            HasPipeline = false;
            HasEspressoMachine = false;
            BonusCodePerClick = 0;
            IsBugActive = false;
            BugClicksRemaining = 0;
            CurrentVersion = 0;
            Upgrades = new List<IUpgrade>
                    {
                        new MechanicalKeyboardUpgrade(),
                        new DualMonitorUpgrade(),
                        new Pipeline()
                    };
        }
        private void NotifyUpgrades()
        {
            foreach (var upgrade in Upgrades)
                upgrade.OnGameStateChanged(this);
        }

        public void SpendCode(double amount)
        {
            LinesOfCode -= amount;
        }

        public void WriteCode()
        {
            double amount = HasMechanicalKeyboard ? 2.0 : 1.0;
            amount += BonusCodePerClick;  // bonus de la DualMonitor etc.
            LinesOfCode += amount;
            TotalLinesOfCode += amount;
            NotifyUpgrades();
        }

        public void GeneratePassiveCode()
        {
            if (IsBugActive) return;
            NotifyUpgrades();

            foreach (IEmployee employee in Team)
            {
                LinesOfCode += employee.CodePerSecond;
                TotalLinesOfCode += employee.CodePerSecond;
            }

            foreach (var upgrade in Upgrades)
                upgrade.OnGameStateChanged(this);
        }

        public void TriggerBug()
        {
            if (!IsBugActive)
            {
                IsBugActive = true;
                BugClicksRemaining = 5;

                // notifica upgrade-urile sa isi aplice reducerile
                foreach (var upgrade in Upgrades)
                {
                    if (upgrade.IsPurchased)
                        upgrade.OnBugTriggered(this);
                }
            }
        }

        public void SquashBug()
        {
            if (IsBugActive)
            {
                BugClicksRemaining--;
                if (BugClicksRemaining <= 0)
                {
                    IsBugActive = false;
                }
            }
        }

        public void ReleaseVersion()
        {
            if (LinesOfCode < NextVersionCost)
            {
                throw new NotEnoughCodeException($"You need {NextVersionCost} LOC to release the next version!");
            }

            LinesOfCode -= NextVersionCost;
            CurrentVersion++;
        }

        public double GetNextCost(string employeeType)
        {
            IEmployee prototype = EmployeeFactory.CreateEmployee(employeeType);

            
            int ownedCount = 0;
            foreach (var emp in Team)
            {
                if (emp.Name == prototype.Name) ownedCount++;
            }
            return prototype.BaseCost * Math.Pow(1.15, ownedCount);
        }

        public double GetTotalCPS()
        {
            double totalCps = 0;
            foreach (IEmployee employee in Team)
            {
                totalCps += employee.CodePerSecond;
            }
            return totalCps;
        }

        public void BuyEmployee(string employeeType)
        {
            double actualCost = GetNextCost(employeeType);

            if (LinesOfCode < actualCost)
            {
                throw new NotEnoughCodeException($"You need {Math.Ceiling(actualCost)} lines of code to hire this.");
            }

            LinesOfCode -= actualCost;
            Team.Add(EmployeeFactory.CreateEmployee(employeeType));
        }

        public GameSaveData CreateSaveData()
        {
            return new GameSaveData
            {
                LinesOfCode = LinesOfCode,
                HasMechanicalKeyboard = HasMechanicalKeyboard,
                HasDualMonitor = HasDualMonitor,
                HasEspressoMachine = HasEspressoMachine,
                HasPipeline = HasPipeline,
                TotalLinesOfCode = TotalLinesOfCode,
                IsBugActive = IsBugActive,
                BugClicksRemaining = BugClicksRemaining,
                CurrentVersion = CurrentVersion,
                InternCount = Team.Count(e => e.Name == "Intern Developer"),
                JuniorCount = Team.Count(e => e.Name == "Junior Developer"),
                SeniorCount = Team.Count(e => e.Name == "Senior Developer"),
                SysArchiCount = Team.Count(e => e.Name == "System Architect")
            };
        }

        public void LoadSaveData(GameSaveData data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            LinesOfCode = Math.Max(0, data.LinesOfCode);
            TotalLinesOfCode = Math.Max(0, data.TotalLinesOfCode);
            HasMechanicalKeyboard = data.HasMechanicalKeyboard;
            HasDualMonitor = data.HasDualMonitor;
            HasPipeline = data.HasPipeline;
            HasEspressoMachine = data.HasEspressoMachine;
            CurrentVersion = Math.Max(0, data.CurrentVersion);
            IsBugActive = data.IsBugActive;
            BugClicksRemaining = data.IsBugActive ? Math.Max(1, data.BugClicksRemaining) : 0;

            Team.Clear();

            for (int i = 0; i < Math.Max(0, data.InternCount); i++)
            {
                Team.Add(EmployeeFactory.CreateEmployee("intern"));
            }

            for (int i = 0; i < Math.Max(0, data.JuniorCount); i++)
            {
                Team.Add(EmployeeFactory.CreateEmployee("junior"));
            }

            for (int i = 0; i < Math.Max(0, data.SeniorCount); i++)
            {
                Team.Add(EmployeeFactory.CreateEmployee("senior"));
            }

            for (int i = 0; i < Math.Max(0, data.SysArchiCount); i++)
            {
                Team.Add(EmployeeFactory.CreateEmployee("sysarchitect"));
            }
        }

    }
}
