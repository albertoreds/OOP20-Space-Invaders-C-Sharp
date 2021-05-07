using System.Drawing;

namespace Alberto_Rossi
{


	/// <summary>
	/// The Class GPowerUp for all the entity.
	/// </summary>
	public class GPowerUp : PowerUpImpl
	{

		/// <summary>
		/// The game. </summary>
		//private GameImpl game;



		/// <summary>
		/// Instantiates a new g power up.
		/// </summary>
		/// <param name="position"> the position of powerUp </param>
		/// <param name="veloX"> the velo X of powerUp </param>
		/// <param name="veloY"> the velo Y of powerUp </param>
		/// <param name="id"> the id of powerUp </param>
		/// <param name="type"> the type of powerUp </param>
		public GPowerUp(Pair<int, int> position, int veloX, int veloY, ID id, PowerUpT type) : base(position, veloX, veloY, id, type)
		{

		}

		/// <summary>
		/// Insert effect.
		/// </summary>
		protected internal override void InsertEffect()
		{
			/// this.game.setFreeze();

		}

		/// <summary>
		/// Reset.
		/// </summary>
		public override void reset()
		{
			if (this.Type.Equals(PowerUpT.FREEZE))
			{
				//this.game.setFreeze();
			}

		}

		/// <summary>
		/// Sets the S.
		/// </summary>
		protected internal override void setS()
		{
			if (this.GetTimeLeft() == this.Type.getLifetime())
			{
				this.Position=(new Pair<int,int>(0, 0));
				this.setSpeed(0, 0);
				//this.SetHitbox(new Rectangle(0, 0, GameImpl.ARENA_WIDTH, GameImpl.ARENA_HEIGHT));
			}

		}

		/// <summary>
		/// Sets the game.
		/// </summary>
		/// <param name="game"> the new game </param>
		//public virtual GameImpl Game
		//{
		//	set
		//	{
		//		this.game = value;
		//	}
		//}

	}

}