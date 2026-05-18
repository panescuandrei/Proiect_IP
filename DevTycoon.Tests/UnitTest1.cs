using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DevTycoon.Engine;

namespace DevTycoon.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Setup()
        {
            GameManager.Instance.Reset();
        }
        [TestMethod]
        public void WriteCode_ShouldIncreaseLinesOfCodeByOne()
        {
            GameManager manager = GameManager.Instance;

            manager.WriteCode();

            Assert.AreEqual(1.0, manager.LinesOfCode, "LinesOfCode ar trebui sa fie 1 dupa un click.");
        }

        [TestMethod]
        public void ManagerSingleInstance()
        {
            GameManager manager = GameManager.Instance;
            GameManager manager2 = GameManager.Instance;

            Assert.AreEqual(manager, manager2);
        }


        [TestMethod]
        public void BuyEmployee_WithEnoughCode_ShouldDeductCostAndAddToTeam()
        {
            GameManager manager = GameManager.Instance;


            for (int i = 0; i < 100; i++) { manager.WriteCode(); }

            manager.BuyEmployee("junior");

            Assert.AreEqual(50.0, manager.LinesOfCode);
            Assert.AreEqual(1, manager.Team.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(NotEnoughCodeException))]
        public void BuyEmployee_WithoutEnoughCode_ShouldThrowException()
        {
            GameManager manager = GameManager.Instance;
            manager.BuyEmployee("junior");
        }


        [TestMethod]
        public void BuyEmployee_CostShouldIncreaseAfterPurchase()
        {
            GameManager manager = GameManager.Instance;
            manager.SetAdminLinesOfCode(10000); 

            double initialCost = manager.GetNextCost("junior");
            manager.BuyEmployee("junior");
            double newCost = manager.GetNextCost("junior");

            Assert.IsTrue(newCost > initialCost, "Costul trebuie sa creasca dupa prima achizitie.");
        }

        [TestMethod]
        public void GeneratePassiveCode_EmptyTeam_ShouldNotIncreaseLOC()
        {
            GameManager manager = GameManager.Instance;
            double initialLoc = manager.LinesOfCode;

            manager.GeneratePassiveCode();

            Assert.AreEqual(initialLoc, manager.LinesOfCode, "Fara echipa, nu ar trebui sa se genereze cod pasiv.");
        }


        [TestMethod]
        public void GetTotalCPS_WithEmptyTeam_ShouldBeZero()
        {
            GameManager manager = GameManager.Instance;
            Assert.AreEqual(0, manager.GetTotalCPS());
        }


        [TestMethod]
        public void GetTotalCPS_WithEmployees_ShouldBeGreaterThanZero()
        {
            GameManager manager = GameManager.Instance;
            manager.SetAdminLinesOfCode(1000);
            manager.BuyEmployee("intern");

            Assert.IsTrue(manager.GetTotalCPS() > 0, "CPS trebuie sa fie mai mare de 0 cand avem angajati.");
        }

        [TestMethod]
        public void PurchaseUpgrade_WithEnoughCode_ShouldSetIsPurchasedToTrue()
        {
            GameManager manager = GameManager.Instance;
            manager.SetAdminLinesOfCode(5000); 
            var upgrade = manager.Upgrades.Find(u => u.Name == "Mechanical Keyboard");

          
            upgrade.Purchase(manager);

            Assert.IsTrue(upgrade.IsPurchased, "Upgrade-ul ar trebui marcat ca achizitionat.");
        }

        [TestMethod]
        [ExpectedException(typeof(NotEnoughCodeException))]
        public void PurchaseUpgrade_WithoutEnoughCode_ShouldThrowException()
        {
            GameManager manager = GameManager.Instance;
            
            var upgrade = manager.Upgrades.Find(u => u.Name == "Mechanical Keyboard");

            upgrade.Purchase(manager);
        }

        [TestMethod]
        public void ReleaseVersion_WithEnoughCode_ShouldDeductCost()
        {
            GameManager manager = GameManager.Instance;
            double cost = manager.NextVersionCost;
            manager.SetAdminLinesOfCode(cost + 50);

            manager.ReleaseVersion();

            Assert.AreEqual(50, manager.LinesOfCode, "Costul versiunii trebuie scazut din total.");
        }


        [TestMethod]
        [ExpectedException(typeof(NotEnoughCodeException))]
        public void ReleaseVersion_WithoutEnoughCode_ShouldThrowException()
        {
            GameManager manager = GameManager.Instance;
            manager.ReleaseVersion(); // incearca sa lanseze pe saracie
        }

        [TestMethod]
        public void ReleaseVersion_WithEnoughCode_ShouldIncreaseVersionNumber()
        {
            GameManager manager = GameManager.Instance;
            manager.SetAdminLinesOfCode(manager.NextVersionCost + 100);
            int initialVersion = manager.CurrentVersion;

            manager.ReleaseVersion();

            Assert.AreEqual(initialVersion + 1, manager.CurrentVersion, "Versiunea ar trebui sa creasca cu 1.");
        }

        [TestMethod]
        public void SquashBug_ShouldDecreaseClicksRemaining()
        {
            GameManager manager = GameManager.Instance;

            
            typeof(GameManager).GetProperty("IsBugActive").SetValue(manager, true);
            typeof(GameManager).GetProperty("BugClicksRemaining").SetValue(manager, 5);

            manager.SquashBug();

            Assert.AreEqual(4, manager.BugClicksRemaining, "Clickurile necesare pentru bug ar trebui sa scada.");
        }

        [TestMethod]
        public void SquashBug_ShouldDeactivateBug_WhenClicksReachZero()
        {
            GameManager manager = GameManager.Instance;

            
            typeof(GameManager).GetProperty("IsBugActive").SetValue(manager, true);
            typeof(GameManager).GetProperty("BugClicksRemaining").SetValue(manager, 1);

            manager.SquashBug();

            Assert.IsFalse(manager.IsBugActive, "Bug-ul ar trebui sa se dezactiveze cand ajunge la 0 clickuri.");
            Assert.AreEqual(0, manager.BugClicksRemaining);
        }

        [TestMethod]
        public void SetAdminLinesOfCode_ShouldExactMatch()
        {
            GameManager manager = GameManager.Instance;
            manager.SetAdminLinesOfCode(1337);

            Assert.AreEqual(1337, manager.LinesOfCode);
        }

        [TestMethod]
        public void SetAdminLinesOfCode_ShouldIncreaseTotalLinesOfCode()
        {
            GameManager manager = GameManager.Instance;
            manager.SetAdminLinesOfCode(5000);

            Assert.IsTrue(manager.TotalLinesOfCode >= 5000, "TotalLinesOfCode trebuie sa tina pasul cu admin mode pentru a nu strica unlock-urile.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))] 
        public void BuyEmployee_WithInvalidEmployeeId_ShouldThrowException()
        {
            GameManager manager = GameManager.Instance;
            manager.SetAdminLinesOfCode(999999);

            
            manager.BuyEmployee("hacker_suprem");
        }

        [TestMethod]
        public void SetAdminLinesOfCode_ToLowerValue_ShouldNotDecreaseTotalLOC()
        {
            GameManager manager = GameManager.Instance;
            manager.SetAdminLinesOfCode(1000); 
            manager.SetAdminLinesOfCode(500);

            Assert.AreEqual(500, manager.LinesOfCode, "Balanța curentă trebuie să fie forțată la 500.");
            Assert.AreEqual(1000, manager.TotalLinesOfCode, "TotalLinesOfCode a rămas la recordul maxim istoric (1000).");
        }

        [TestMethod]
        public void BuyEmployee_ShouldDecreaseLOC_ButKeepTotalLOC()
        {
            GameManager manager = GameManager.Instance;
            manager.SetAdminLinesOfCode(500); //seteaza LOC si Total LOC la 500
            double initialTotal = manager.TotalLinesOfCode;

            manager.BuyEmployee("intern");

            Assert.IsTrue(manager.LinesOfCode < 500, "Codul disponibil (balanța) ar trebui să scadă după achiziție.");
            Assert.AreEqual(initialTotal, manager.TotalLinesOfCode, "TotalLinesOfCode nu trebuie să scadă niciodată la achiziții.");
        }

        [TestMethod]
        public void BuyMultipleEmployees_ShouldMultiplyTotalCPS()
        {
            GameManager manager = GameManager.Instance;
            manager.SetAdminLinesOfCode(10000);

            manager.BuyEmployee("intern");
            double cpsOneIntern = manager.GetTotalCPS();

            manager.BuyEmployee("intern");
            double cpsTwoInterns = manager.GetTotalCPS();

            Assert.IsTrue(cpsTwoInterns > cpsOneIntern, "CPS-ul total trebuie să fie mai mare când avem 2 interni.");
            Assert.AreEqual(cpsOneIntern * 2, cpsTwoInterns, 0.01, "2 interni ar trebui să producă exact dublu față de 1 intern.");
        }

    }
}
