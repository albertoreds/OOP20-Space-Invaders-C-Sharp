using Alberto_Rossi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using model;
using System;
using System.Linq;

namespace Test
{
	[TestClass]
	public class testpowerUp
	{
		/// <summary>
		/// The Constant XEXPECTED. </summary>
		private const int XEXPECTED = 0;

		/// <summary>
		/// The Constant YEXPECTED. </summary>
		private const int YEXPECTED = 9;

		/// <summary>
		/// The Constant INITIAL_H. </summary>
		private const int INITIAL_H = 20;

		/// <summary>
		/// The Constant FINAL_H. </summary>
		private const int FINAL_H = 40;

		[TestMethod]
		public void TestPowerUpB()
		{
			PPowerUp ppu = new PPowerUp(new Pair<int, int>(0, 0), 1, 1, ID.POWER_UP, PowerUpT.HEALTH, new HighStrategy());
			ppu.update();
			ppu.setSpeed(1, 1);
			ppu.update();
			ppu.setSpeed(1, 1);
			ppu.update();
			Assert.AreEqual(Convert.ToInt32(ppu.Position.GetX()), 0);
			Assert.AreEqual(Convert.ToInt32(ppu.Position.GetY()), 3);
			ppu.setSpeed(1, 3);
			ppu.update();
			ppu.setSpeed(1, 3);
			ppu.update();
			Assert.AreEqual(Convert.ToInt32(ppu.Position.GetX()), XEXPECTED);
			Assert.AreEqual(Convert.ToInt32(ppu.Position.GetY()), YEXPECTED);
			ppu.collide(new PPowerUp(new Pair<int, int>(0, 0), 1, 1, ID.POWER_UP, PowerUpT.SHIELD, new HighStrategy()));
			Assert.IsFalse(ppu.GetActivated());
		}
		[TestMethod]
		public void TestHealthPowerUp()
		{
			PlayerImpl player = new PlayerImpl(ID.PLAYER, new GameImpl());
			PPowerUp ppu = new PPowerUp(new Pair<int, int>(0, 0), 1, 1, ID.POWER_UP, PowerUpT.HEALTH, new LowStrategy());
			player.Health = (INITIAL_H);
			Assert.AreEqual(player.Health, INITIAL_H);
			ppu.collide(player);
			Assert.AreEqual(player.Health, FINAL_H);
			ppu.update();
			Assert.IsTrue(ppu.Dead);
		}

		[TestMethod]
		public void TestShieldPowerUp()
		{

			PlayerImpl player = new PlayerImpl(ID.PLAYER, new GameImpl());
			PPowerUp ppu = new PPowerUp(new Pair<int, int>(0, 0), 1, 1, ID.POWER_UP, PowerUpT.SHIELD, new HighStrategy());
			ppu.collide(player);
			Assert.IsTrue(player.Shield > 0);
			Assert.IsTrue(ppu.GetActivated());
			Assert.IsNotNull(ppu.EntityStrategy);
			foreach(var i in Enumerable.Range(0, PowerUpT.SHIELD.getLifetime() + 1))
            {
				ppu.update();
            }
			Assert.IsTrue(ppu.Dead);
			Assert.AreEqual(player.Shield, 0);
		}

	}
}
