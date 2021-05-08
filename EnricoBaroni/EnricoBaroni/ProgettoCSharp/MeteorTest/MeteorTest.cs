
using Enrico_Baroni;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using model;
using System;

namespace MeteorTest
{
    [TestClass]
    public class MeteorTest
    {
        /// <summary>
		/// The Constant LENGTH. </summary>
		private const int LENGTH = 50;

        /// <summary>
        /// The Constant XEXPECTED. </summary>
        private const int XEXPECTED = 0;

        /// <summary>
        /// The Constant YEXPECTED. </summary>
        private const int YEXPECTED = 3;
        [TestMethod]
        public void testMeteor()
        {
            MeteorImpl meteorimpl = new MeteorImpl(new Pair<int,int>(0, 0), 1, 1, LENGTH, ID.METEOR);
            meteorimpl.update();
            meteorimpl.setSpeed(1, 1);
            meteorimpl.update();
            meteorimpl.setSpeed(1, 1);
            meteorimpl.update();
            Assert.AreEqual(Convert.ToInt32(meteorimpl.Position.GetX()), XEXPECTED);
            Assert.AreEqual(Convert.ToInt32(meteorimpl.Position.GetY()), YEXPECTED);
        }
        [TestMethod]
        public virtual void testCollideMeteorWithBullet()
        {
            MeteorImpl meteorimpl = new MeteorImpl(new Pair<int,int>(0, 0), 1, 1, LENGTH, ID.METEOR);
            BulletImpl bulletplayer = new BulletImpl(0, 0, ID.PLAYER_BULLET);
            meteorimpl.collide(bulletplayer);
            Assert.IsFalse(meteorimpl.Dead);
            meteorimpl.collide(bulletplayer);
            meteorimpl.collide(bulletplayer);
            Assert.IsTrue(meteorimpl.Dead);
        }
    }
}
