using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EngineGDI;

namespace UnitTestProject1
{
    [TestClass]
    public class TestGame
    {
        // Consigna 8: Escribir funciones de Test utilizando el tipo de proyecto "Unit Test"
        [TestMethod]
        public void TestGameManagerScore()
        {
            GameManager.Instance.StartNewGame();
            GameManager.Instance.AddScore(20);
            Assert.AreEqual(20, GameManager.Instance.Score);
        }

        [TestMethod]
        public void TestGameManagerLoseLife()
        {
            GameManager.Instance.StartNewGame();
            int initialLives = GameManager.Instance.Lives;
            GameManager.Instance.LoseLife();
            Assert.AreEqual(initialLives - 1, GameManager.Instance.Lives);
        }

        [TestMethod]
        public void TestItemFactory()
        {
            var good = ItemFactory.CreateItem("good", 0, 0, 10);
            Assert.IsTrue(good is GoodItem);
            
            var bad = ItemFactory.CreateItem("bad", 0, 0, 10);
            Assert.IsTrue(bad is BadItem);
        }
    }
}
