using DevTycoon.Engine.Upgrades;
using DevTycoon.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTycoon.Engine
{
    /// <summary>
    /// Clasa principală a jocului care gestionează starea, resursele, echipa și evenimentele.
    /// Este implementată folosind pattern-ul Singleton.
    /// </summary>
    public class GameManager
    {
        // Singleton
        private static GameManager _instance;

        /// <summary>Instanța unică a jocului (Singleton).</summary>
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameManager();
                return _instance;
            }
        }
        // bug triggering
        private Random _random = new Random();

        /// <summary>Șansa (în procente) ca un bug să apară.</summary>
        public int BugChance { get; private set; } = 5; // % sansa

        /// <summary>Cantitatea curentă de Linii de Cod (moneda jocului).</summary>
        public double LinesOfCode { get; private set; }

        /// <summary>Totalul istoric de Linii de Cod produse de la începutul jocului.</summary>
        public double TotalLinesOfCode { get; private set; }

        /// <summary>*****************************************************************************************************************</summary>
        public bool IsEspressoBuffActive { get; set; } = false; // pentru cafea

        /// <summary>Lista angajaților actuali din companie.</summary>
        public List<IEmployee> Team { get; private set; }

        //starile upgrade-urilor
        public bool HasMechanicalKeyboard { get; internal set; } // pt a putea fi setat separat
        public bool HasDualMonitor { get; internal set; }
        public bool HasPipeline { get; internal set; }
        public bool HasEspressoMachine { get; internal set; }

        /// <summary>Indică dacă în acest moment există o eroare critică nerezolvată pe ecran.</summary>
        public bool IsBugActive { get; private set; }

        /// <summary>Numărul de click-uri necesare pentru a rezolva bug-ul curent.</summary>
        public int BugClicksRemaining { get; private set; } // pt a putea fi setat in pipeline

        /// <summary>Versiunea actuală a software-ului lansat.</summary>
        public int CurrentVersion { get; private set; } = 0;

        /// <summary>Costul necesar pentru a lansa următoarea versiune a aplicației.</summary>
        public double NextVersionCost => 10000.0 * Math.Pow(2, CurrentVersion); // 10k, dupa 20k, 30k etc.

        // Observer Design patter, pt upgrades

        /// <summary>Lista cu toate îmbunătățirile disponibile în joc.</summary>
        public List<IUpgrade> Upgrades { get; private set; }

        /// <summary>Bonusul de Linii de Cod adăugat la fiecare click manual.</summary>
        public int BonusCodePerClick { get; set; } = 0;  // pentru DualMonitor etc.


        /// <summary>
        /// Reduce numărul de click-uri necesare pentru a strivi un bug (folosit de obicei de Pipeline).
        /// </summary>
        /// <param name="amount">Numărul de click-uri cu care se reduce efortul.</param>
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

        /// <summary>Resetează complet starea jocului (folosit în special pentru Unit Testing).</summary>
        public void Reset() // reset function used in unit testing bcs dau share la aceasi instanta la fiecare test si crapa
        {
            LinesOfCode = 0;
            TotalLinesOfCode = 0;
            Team = new List<IEmployee>();
            HasMechanicalKeyboard = false;
            HasDualMonitor = false;
            HasPipeline = false;
            HasEspressoMachine = false;
            IsEspressoBuffActive = false;
            BonusCodePerClick = 0;
            IsBugActive = false;
            BugClicksRemaining = 0;
            CurrentVersion = 0;
            Upgrades = new List<IUpgrade>
                    {
                        new MechanicalKeyboardUpgrade(),
                        new DualMonitorUpgrade(),
                        new Pipeline(),
                        new EspressoMachine()
                    };
        }
        private void NotifyUpgrades()
        {
            foreach (var upgrade in Upgrades)
                upgrade.OnGameStateChanged(this);
        }

        /// <summary>Scade o anumită sumă din totalul curent de Linii de Cod.</summary>
        /// <param name="amount">Suma de cheltuit.</param>
        public void SpendCode(double amount)
        {
            LinesOfCode -= amount;
        }

        /// <summary>Generează Linii de Cod la apăsarea manuală a butonului (Click).</summary>
        public void WriteCode()
        {
            double amount = HasMechanicalKeyboard ? 2.0 : 1.0;
            amount += BonusCodePerClick;  // bonus de la DualMonitor etc.

            if (IsEspressoBuffActive)
            {
                amount *= 3.0;
            }

            LinesOfCode += amount;
            TotalLinesOfCode += amount;
            NotifyUpgrades();
        }

        /// <summary>Generează Liniile de Cod produse automat de echipă. Se oprește dacă un bug este activ.</summary>
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

        /// <summary>Apare o eroare în sistem și oprește producția până este rezolvată.</summary>
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

        /// <summary>Încearcă să genereze un bug bazat pe probabilitatea curentă.</summary>
        public void TryTriggerBug()
        {
            if (!IsBugActive && _random.Next(0, 100) < BugChance)
                TriggerBug();
            // daca se doreste sa scadeti, urcati logica de buggs, puteti face asta usor intr un upgrade, cu
            // manager.BugChance -= 2 or smth;
        }

        /// <summary>Scade cu 1 numărul de click-uri necesare pentru a repara bug-ul curent.</summary>
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

        /// <summary>Lansează o nouă versiune a aplicației dacă există suficiente fonduri.</summary>
        /// <exception cref="NotEnoughCodeException">Aruncată dacă nu sunt suficiente Linii de Cod.</exception>
        public void ReleaseVersion()
        {
            if (LinesOfCode < NextVersionCost)
            {
                throw new NotEnoughCodeException($"You need {NextVersionCost} LOC to release the next version!");
            }

            LinesOfCode -= NextVersionCost;
            CurrentVersion++;
        }

        /// <summary>Calculează costul următorului angajat de un anumit tip, bazat pe câți angajați de acel tip deții deja.</summary>
        /// <param name="employeeType">Tipul angajatului (ex: "intern").</param>
        /// <returns>Costul calculat cu formula exponențială.</returns>
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

        /// <summary>Calculează totalul de Linii de Cod pe Secundă (CPS) generat de echipă.</summary>
        /// <returns>Suma CPS-ului tuturor angajaților.</returns>
        public double GetTotalCPS()
        {
            double totalCps = 0;
            foreach (IEmployee employee in Team)
            {
                totalCps += employee.CodePerSecond;
            }
            return totalCps;
        }

        /// <summary>Cumpără și adaugă în echipă un nou angajat.</summary>
        /// <param name="employeeType">Tipul angajatului (ex: "intern").</param>
        /// <exception cref="NotEnoughCodeException">Aruncată dacă fondurile sunt insuficiente.</exception>
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

        /// <summary>Creează un obiect de salvare conținând starea actuală a jocului.</summary>
        /// <returns>Un obiect de tip GameSaveData gata de serializare.</returns>
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

        /// <summary>Încarcă starea jocului dintr-un obiect de salvare existent.</summary>
        /// <param name="data">Datele jocului salvate anterior.</param>
        /// <exception cref="ArgumentNullException">Aruncată dacă datele furnizate sunt nule.</exception>
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

            foreach (var upgrade in Upgrades)
            {
                if (upgrade.Name == "Mechanical Keyboard" && HasMechanicalKeyboard)
                    upgrade.IsPurchased = true;

                else if (upgrade.Name == "Dual Monitor" && HasDualMonitor)
                    upgrade.IsPurchased = true;

                else if (upgrade.Name == "CI/CD Pipeline" && HasPipeline)
                    upgrade.IsPurchased = true;

                else if (upgrade.Name == "Espresso Machine" && HasEspressoMachine)
                    upgrade.IsPurchased = true;
            }

            NotifyUpgrades();

            BonusCodePerClick = 0;
            if (HasDualMonitor)
            {
                // Pune aici valoarea pe care o dădea Dual Monitor în metoda lui Purchase()
                BonusCodePerClick += 2;
            }
        }

        /// <summary>
        /// Admin method to explicitly set the Lines of Code.
        /// </summary>
        public void SetAdminLinesOfCode(double amount)
        {
            LinesOfCode = amount;
            // Keep TotalLinesOfCode equal or higher so we don't re-lock items
            TotalLinesOfCode = Math.Max(TotalLinesOfCode, amount);
            NotifyUpgrades();
        }

    }
}
