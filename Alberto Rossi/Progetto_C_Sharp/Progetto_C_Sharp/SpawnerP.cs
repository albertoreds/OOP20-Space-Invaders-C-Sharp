using model;
using System;
using System.Collections.Generic;
using utility;

namespace Alberto_Rossi
{
	

	/// <summary>
	/// The Class to spawner PowerUp.
	/// </summary>
	public class SpawnerP
	{

		/// <summary>
		/// The Constant PROBABILITY_POWER_UP. </summary>
		private const int PROBABILITY_POWER_UP = 5;

		/// <summary>
		/// The Constant LEVEL_LIMIT_FOR_LOW. </summary>
		private const int LEVEL_LIMIT_FOR_LOW = 10;

		/// <summary>
		/// The Constant LEVEL_LIMIT_FOR_BASIC. </summary>
		private const int LEVEL_LIMIT_FOR_BASIC = 20;

		/// <summary>
		/// The spawn frezee. </summary>
		private readonly int spawnFrezee;


		/// <summary>
		/// Instantiates a new spawner P.
		/// </summary>
		public SpawnerP()
		{
			Random random = new Random();
			this.spawnFrezee = random.Next(PROBABILITY_POWER_UP);

		}

		/// <summary>
		/// Spawn power up player.
		/// </summary>
		/// <param name="level"> the level </param>
		/// <returns> the list of powerUp </returns>
		public virtual IList<PPowerUp> SpawnPowerUpPlayer( int level)
		{
			IList<PPowerUp> list = new List<PPowerUp>();
			Random random = new Random();
			Strategy strategy;
			//Strategy strategy = level < LEVEL_LIMIT_FOR_LOW ? new LowStrategy() : level < LEVEL_LIMIT_FOR_BASIC ? new BasicStrategy(): new HighStrategy();
			if(level < LEVEL_LIMIT_FOR_LOW)
            {
				 strategy = new LowStrategy();
            }else if (level < LEVEL_LIMIT_FOR_BASIC)
            {
				 strategy = new BasicStrategy();
            }
            else
            {
				 strategy = new HighStrategy();
			}
			int Number;
			PowerUpT type;
			int numberofSpawn = random.Next(3) + 1;
			while (numberofSpawn > 0)
			{
				Number = random.Next(3);
				switch (Number)
				{
				case 0 :
					type = PowerUpT.HEALTH;
				break;
				case 1 :
					type = PowerUpT.SHIELD;
				break;
				default :
					type = PowerUpT.FIRE_BOOST;
				break;
				}
				list.Add(new PPowerUp(this.generatePosition(),this.generateVelocity(),this.generateVelocity(),ID.POWER_UP, type, strategy));
				numberofSpawn--;
			}
			return list;
		}

		/// <summary>
		/// Generate position.
		/// </summary>
		/// <returns> the pair </returns>
		private Pair<int, int> generatePosition()
		{
			Random random = new Random();
			int xP = Clamp.clamp(random.Next(GameImpl.ARENA_WIDTH), 0 + PowerUpImpl.WIDTH / 2, GameImpl.ARENA_WIDTH - PowerUpImpl.WIDTH / 2);
			const int yP = 0;
			return new Pair<int, int>(xP, yP);
		}

		/// <summary>
		/// Generate velocity.
		/// </summary>
		/// <returns> the int </returns>
		private int generateVelocity()
		{

			Random random = new Random();
			return random.Next(PowerUpT.values().Length) + 1;
		}

		 /// <summary>
		 /// Spawn global power up.
		 /// </summary>
		 /// <returns> the optional </returns>
		 public virtual GPowerUp spawnGlobalPowerUp()
		 {
				Random random = new Random();
				int Number;
				PowerUpT type;
				Number = random.Next(PROBABILITY_POWER_UP);
				 if (Number == this.spawnFrezee)
				 {
					type = PowerUpT.FREEZE;
				 }
				else
				{
					return null;
				}
				return (new GPowerUp(this.generatePosition(), this.generateVelocity(), this.generateVelocity(),ID.POWER_UP, type));
		 }

	}

}