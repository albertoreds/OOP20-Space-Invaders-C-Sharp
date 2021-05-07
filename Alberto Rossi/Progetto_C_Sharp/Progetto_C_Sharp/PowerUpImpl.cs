using model;
using System.Drawing;

namespace Alberto_Rossi
{
    /// <summary>
    /// The Class PowerUpImpl implements powerUp.
    /// </summary>
    public abstract class PowerUpImpl : ChronometerEntity, PowerUp
	{

		/// <summary>
		/// The Constant WIDTH. </summary>
		public const int WIDTH = 60;

		/// <summary>
		/// The Constant HEIGHT. </summary>
		public const int HEIGHT = 60;

        /// <summary>
        /// The Constant LIFETIME_P. </summary>
        public static readonly int LIFETIME_P = 60; //GameLoop.FPS * 6;

		/// <summary>
		/// The type. </summary>
		private readonly PowerUpT type;

		/// <summary>
		/// The is activeted. </summary>
		private bool isActiveted;

		/// <summary>
		/// The player. </summary>
		private PlayerImpl player;



		/// <summary>
		/// Instantiates a new power up impl.
		/// </summary>
		/// <param name="position"> the position </param>
		/// <param name="veloX"> the velo X </param>
		/// <param name="veloY"> the velo Y </param>
		/// <param name="id"> the id </param>
		/// <param name="type"> the type </param>
		public PowerUpImpl( Pair<int, int> position,  int veloX,  int veloY,  ID id,  PowerUpT type) : base(position, veloX, veloY, id, type.getLifetime())
		{
			this.type = type;
			this.isActiveted = false;
            
            this.Hitbox = (new Rectangle(this.Position.GetX() - WIDTH / 2, this.Position.GetY() - HEIGHT / 2, WIDTH, HEIGHT));

		}

		/// <summary>
		/// Insert strategy.
		/// </summary>
		public virtual void InsertStrategy()
		{
			if (this.isActiveted == false || this.Type.GetRequiringUpdate())
			{
				this.InsertEffect();
				this.isActiveted = true;
			}

		}

		/// <summary>
		/// Insert effect.
		/// </summary>
		protected internal abstract void InsertEffect();


		/// <summary>
		/// Reset.
		/// </summary>
		public  abstract void reset();



        /// <summary>
        /// Checks if is activated.
        /// </summary>
        /// <returns> true, if is activated </returns>
        public virtual bool GetActivated()
        {
            return this.isActiveted;
        }



        /// <summary>
        /// Update.
        /// </summary>
        public override void update()
		{
			if (this.isActiveted == false)
			{
				this.Position.SetY(this.Position.GetY() + this.Speed.GetY());
                Rectangle r = new Rectangle();
                this.Hitbox=(new Rectangle(this.Position.GetX() - WIDTH / 2, this.Position.GetY() - HEIGHT / 2,WIDTH,HEIGHT));
			}
			else
			{
				this.setS();
				if (this.GetEnded() == false)
				{
					this.tick();
					this.InsertStrategy();
				}
				else
				{
					this.reset();
					this.setDead();
				}
			}

		}

		/// <summary>
		/// Sets the S.
		/// set the position and the hitbox of the powerUp
		/// </summary>
		protected internal abstract void setS();

		/// <summary>
		/// Gets the type.
		/// </summary>
		/// <returns> the type </returns>
		public PowerUpT Type
		{
			get
			{
				return this.type;
			}
		}


		/// <summary>
		/// Collide.
		/// </summary>
		/// <param name="entity"> the entity </param>
		public override void collide(Entity entity)
		{
			if (entity is PlayerImpl)
			{
				this.player = (PlayerImpl)entity;
				this.InsertStrategy();
				this.Position=(entity.Position);
				this.Hitbox = (entity.Hitbox);
			}


		}

		/// <summary>
		/// Gets the entity strategy.
		/// </summary>
		/// <returns> the entity strategy </returns>
		public PlayerImpl EntityStrategy
		{
			get
			{
				return this.player;
			}
		}


	}

}