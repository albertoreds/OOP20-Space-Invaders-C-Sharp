using Microsoft.VisualStudio.TestTools.UnitTesting;
using model;
using Space;

namespace TestEnemy
{
    [TestClass]
    public class TestEnemy
    {
        private const int EXPECTED = 6;
        [TestMethod]
        public void TestBasicEnemy()
        {
            GameImpl game = new GameImpl();

            AbstractEnemy basic = new BasicEnemy(game);

          
            basic.createThisEnemy();
            Assert.IsNotNull(basic);
         

            Pair<int, int> position = basic.Position;
           
            Assert.AreNotEqual(position, new Pair<int, int>(0, 0));
            basic.setDead();
            Assert.IsTrue(basic.Dead);
            basic.setAlive();
            Assert.IsFalse(basic.Dead);
        }
        public void TestBossEnemy()
        {
            GameImpl game = new GameImpl();

            AbstractEnemy boss = new BossEnemy(game);

            boss.createThisEnemy();
            Assert.IsNotNull(boss);

            Pair<int, int> position = boss.Position;

            Assert.AreNotEqual(position, new Pair<int, int>(0, 0));
            boss.update();



            boss.setDead();
            Assert.IsTrue(boss.Dead);
            boss.setAlive();
            Assert.IsFalse(boss.Dead);

        }
        public void TestShootEnemy()
        {
            ShotEnemyImpl shotenemy = new ShotEnemyImpl(6, 6, DirEnemy.DOWN);
            Assert.IsNotNull(shotenemy);
            Assert.AreEqual(new Pair<int, int>(0, 3), shotenemy.Speed);
            Assert.AreEqual(new Pair<int, int>(EXPECTED, EXPECTED), shotenemy.Position);
            shotenemy.update();
            shotenemy.update();

            Assert.AreEqual(new Pair<int, int>(EXPECTED, EXPECTED * 2), shotenemy.Position);
            shotenemy.SetDir(DirEnemy.D_R);
            shotenemy.SetDir(DirEnemy.D_R);
            shotenemy.update();
            shotenemy.update();
            Assert.AreEqual(new Pair<int, int>(EXPECTED * 2, EXPECTED * 3), shotenemy.Position);
            shotenemy.SetDir(DirEnemy.D_L);
            shotenemy.update();
            shotenemy.update();


            Assert.AreEqual(new Pair<int, int>(EXPECTED, EXPECTED * 4), shotenemy.Position);
            shotenemy.setDead();
            Assert.IsTrue(shotenemy.Dead);
            shotenemy.setAlive();
            Assert.IsFalse(shotenemy.Dead);
            shotenemy.update();
            shotenemy.update();
            shotenemy.update();
            shotenemy.update();

            Assert.IsTrue(shotenemy.Dead);
        }
    }
}
