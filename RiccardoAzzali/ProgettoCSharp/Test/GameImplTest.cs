using Microsoft.VisualStudio.TestTools.UnitTesting;
using model;

namespace Test
{
    [TestClass]
    public class GameImplTest
    {
        [TestMethod]
        public void TestGame()
        {
            GameImpl gameTest = new GameImpl();
            int oldScore = gameTest.Score;
            int oldLevel = gameTest.Level;

            Assert.IsNotNull(gameTest);
            Assert.IsNotNull(gameTest.Player);
            Assert.IsNotNull(gameTest.Entities);

            Assert.AreEqual(gameTest.Score, oldScore);

            Assert.AreEqual(gameTest.Status, GameStatus.RUNNING);

            Assert.AreEqual(gameTest.Level, oldLevel);

            gameTest.nextLevel();
            gameTest.nextLevel();
            gameTest.nextLevel();
            gameTest.nextLevel();
            Assert.AreNotEqual(gameTest.Level, oldLevel);


        }
    }
}
