using model;
using utility;

namespace Alberto_Rossi
{

	/// <summary>
	/// The Class PPowerUp for the player.
	/// </summary>
	public class PPowerUp : PowerUpImpl
	{

		/// <summary>
		/// The Constant STANDARD_HEALTH. </summary>
		private const int STANDARD_HEALTH = 20;

		/// <summary>
		/// The Constant STANDARD_FIRE_RATE_BOOST. </summary>
		private const int STANDARD_FIRE_RATE_BOOST = 2;

		/// <summary>
		/// The Constant SHIELD_S. </summary>
		private const int SHIELD_S = 100;

		/// <summary>
		/// The strategy. </summary>
		private readonly Strategy strategy;

		/// <summary>
		/// Instantiates a new p power up.
		/// </summary>
		/// <param name="position"> the position of powerUp </param>
		/// <param name="veloX"> the velo X of powerUp </param>
		/// <param name="veloY"> the velo Y of powerUp </param>
		/// <param name="id"> the id of powerUp </param>
		/// <param name="type"> the type of powerUp </param>
		/// <param name="strategy"> the strategy of powerUp </param>
		public PPowerUp(Pair<int, int> position, int veloX,  int veloY, ID id, PowerUpT type, Strategy strategy) : base(position, veloX, veloY, id, type)
		{
			this.strategy = strategy;
		}


		/// <summary>
		/// Reset.
		/// </summary>
		public override void reset()
		{

			 Player player = this.EntityStrategy;
				if (this.Type.Equals(PowerUpT.FIRE_BOOST))
				{
					player.CoolDown = player.CoolDown + this.strategy.multiplyEffect(STANDARD_FIRE_RATE_BOOST);
				}
				 else if (this.Type.Equals(PowerUpT.SHIELD))
				 {
					player.SHield = 0;
				 }
		}


		/// <summary>
		/// Insert effect.
		/// </summary>
		protected internal override void InsertEffect()
		{

			PlayerImpl player = this.EntityStrategy;
			if (this.Type.Equals(PowerUpT.HEALTH))
			{
				player.Health = Clamp.clamp(player.Health + this.strategy.multiplyEffect(STANDARD_HEALTH), 0, 100);
			}
			else if (this.Type.Equals(PowerUpT.FIRE_BOOST))
			{
				player.CoolDown = player.CoolDown - this.strategy.multiplyEffect(STANDARD_FIRE_RATE_BOOST);
			}
			else
			{
				if (this.GetActivated() == false)
				{
					player.SHield = this.strategy.multiplyEffect(SHIELD_S);
				}
				else if (player.Shield == 0)
				{
					this.setDead();
				}
			}

		}

		/// <summary>
		/// Sets the S.
		/// </summary>
		protected internal override void setS()
		{
			this.Position = (this.EntityStrategy.Position);
			this.Hitbox = (this.EntityStrategy.Hitbox);
		}


	}

}