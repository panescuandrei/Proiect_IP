using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevTycoon.Patterns;

namespace DevTycoon.Engine
{
    public class GameManager
    {

        public double LinesOfCode { get; private set; }

        public List<IEmployee> Team { get; private set; }

        public bool HasMechanicalKeyboard { get; private set; }
        public bool IsBugActive { get; private set; }
        public int BugClicksRemaining { get; private set; }
        public int CurrentVersion { get; private set; } = 0;
        public double NextVersionCost => 10000.0 * Math.Pow(2, CurrentVersion); // 10k, dupa 20k, 30k etc.

        public GameManager()
        {            
            LinesOfCode = 0;
            Team = new List<IEmployee>();
            HasMechanicalKeyboard = false;
        }

        public void WriteCode()
        {
            if (HasMechanicalKeyboard)
            {
                LinesOfCode += 2.0;
            }
            else
            {
                LinesOfCode += 1.0;
            }
        }

        public void GeneratePassiveCode()
        {
            if (IsBugActive) return;

            foreach (IEmployee employee in Team)
            {
                LinesOfCode += employee.CodePerSecond;
            }
        }

        public void TriggerBug()
        {
            if (!IsBugActive)
            {
                IsBugActive = true;
                BugClicksRemaining = 5; 
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

        public void BuyMechanicalKeyboard()
        {
            if (HasMechanicalKeyboard) return;

            if (LinesOfCode < 250)
            {
                throw new NotEnoughCodeException("You need 250 lines of code to buy the Mechanical Keyboard.");
            }

            LinesOfCode -= 250;
            HasMechanicalKeyboard = true;
        }


    }
}
