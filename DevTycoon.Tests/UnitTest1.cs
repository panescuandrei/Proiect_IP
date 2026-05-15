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
    }
}
