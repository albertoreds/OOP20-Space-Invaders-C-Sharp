using Microsoft.VisualStudio.TestTools.UnitTesting;
using model;
using System;
using utility;

namespace Test
{

    [TestClass]
    public class PlayerImplTest
    {
        [TestMethod]
        public void TestPlayer()
        {


            GameImpl gameTest = new GameImpl();
            PlayerImpl testPlayer = new PlayerImpl(ID.PLAYER, gameTest);

            Assert.IsNotNull(testPlayer);

            Pair<int, int> position = testPlayer.Position;
            testPlayer.setSpeed(5, 5);
            testPlayer.update();

            Assert.IsTrue(testPlayer.Position.Equals(position));
        }
    }
}
