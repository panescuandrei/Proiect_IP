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
        public void ReleaseVersion_WithEnoughCode_ShouldIncreaseVersionNumber()
        {
            GameManager manager = GameManager.Instance;
            manager.SetAdminLinesOfCode(manager.NextVersionCost + 100);
            int initialVersion = manager.CurrentVersion;

            manager.ReleaseVersion();

            Assert.AreEqual(initialVersion + 1, manager.CurrentVersion, "Versiunea ar trebui sa creasca cu 1.");
        }
    }
}
