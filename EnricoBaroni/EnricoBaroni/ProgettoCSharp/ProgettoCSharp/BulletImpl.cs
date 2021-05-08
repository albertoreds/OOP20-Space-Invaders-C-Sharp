using Enrico_Baroni;
using System.Drawing;

namespace model
{


	/// <summary>
	/// The Class BulletImpl that manages the creation of the player bullet.
	/// </summary>
	public class BulletImpl : EntityImpl, Bullet
	{

		/// <summary>
		/// The owner. </summary>
		private readonly ID owner;

		/// <summary>
		/// The Constant BULLETSIZE. </summary>
		private const int BULLETSIZE = 20;

		/// <summary>
		/// The Constant WIDTH. </summary>
		private static readonly int WIDTH = 1600 / 40;

		/// <summary>
		/// The Constant HEIGHT. </summary>
		private static readonly int HEIGHT = 900 / 22;

		/// <summary>
		/// The Constant SPEED. </summary>
		private static readonly int SPEED = 900 / 50;

		/// <summary>
		/// Instantiates a new bullet impl.
		/// </summary>
		/// <param name="x"> the x </param>
		/// <param name="y"> the y </param>
		/// <param name="owner"> the owner </param>
		public BulletImpl(int x,int y, ID owner) : base(new Pair<int, int>(x, y), 0, SPEED, ID.PLAYER_BULLET)
		{
			if (owner == ID.PLAYER)
			{
				setSpeed(Speed.GetX(), Speed.GetY() * -1);
			}
			this.owner = owner;
			Hitbox = new Rectangle(this.Position.GetX() - BULLETSIZE, this.Position.GetY() - BULLETSIZE, WIDTH, HEIGHT);
		}

		/// <summary>
		/// Gets the owner.
		/// </summary>
		/// <returns> the owner </returns>
		public virtual ID Owner
		{
			get
			{
				// TODO Auto-generated method stub
				return this.owner;
			}
		}

		/// <summary>
		/// Update.
		/// </summary>
		public override void update()
		{
			Position.SetX(Position.GetX() + Speed.GetX());
			Position.SetY(Position.GetY() + Speed.GetY());
			Hitbox = new Rectangle(this.Position.GetX() - 10, this.Position.GetY() - 10, BULLETSIZE, BULLETSIZE);
			if (this.Position.GetY() == 900 || this.Position.GetY() < 0)
			{
				this.setDead();
			}
		}

		/// <summary>
		/// Collide.
		/// </summary>
		/// <param name="entity"> the entity </param>
		public override void collide(Entity entity)
		{
			this.setDead();

		}
	}

}