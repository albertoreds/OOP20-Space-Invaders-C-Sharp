namespace model
{
    using System.Drawing;
    using Clamp = utility.Clamp;
    using System;
    using utility;

    /// <summary>
    /// The Class PlayerImpl that manages the creation of the player.
    /// </summary>
    public sealed class PlayerImpl : EntityImpl, Player
    {
        /// <summary>
        /// The Constant DAMAGE_MULTIPLIER. </summary>
        private const int DAMAGE_MULTIPLIER = 2; //10

        /// <summary>
        /// The Constant WIDTH. </summary>
        private static readonly int WIDTH = GameImpl.ARENA_WIDTH / 20;

        /// <summary>
        /// The Constant HEIGHT. </summary>
        private static readonly int HEIGHT = WIDTH + WIDTH / 100;

        /// <summary>
        /// The Constant DEFINITLY_NOT_SHOT_COOLDOWN. </summary>
        private const int DEFINITLY_NOT_SHOT_COOLDOWN = 20;

        /// <summary>
        /// The health. </summary>
        private int health = 100;

        /// <summary>
        /// The shoot CD. </summary>
        private int shootCD = DEFINITLY_NOT_SHOT_COOLDOWN;

        /// <summary>
        /// The shot ready. </summary>
        private int shotReady;

        /// <summary>
        /// The shield. </summary>
        private int shield;

        /// <summary>
        /// The y inizial. </summary>
        private static int Y_INIZIAL = 900;

        /// <summary>
        /// The game impl. </summary>
        private readonly GameImpl gameImpl;


        /// <summary>
        /// Instantiates a new player impl.
        /// </summary>
        /// <param name="id"> the id </param>
        /// <param name="gameImpl"> the game impl </param>
        public PlayerImpl(ID id, GameImpl gameImpl) : base(new Pair<int, int>(GameImpl.ARENA_WIDTH / 2, Y_INIZIAL), 0, 0, id)
        {
            this.gameImpl = gameImpl;
            Hitbox = new Rectangle(this.Position.GetX(), this.Position.GetY(), WIDTH, HEIGHT);
        }

        /// <summary>
        /// Gets the health.
        /// </summary>
        /// <returns> the health </returns>
        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                this.health = value;
            }
        }


        /// <summary>
        /// Gets the cool down.
        /// </summary>
        /// <returns> the cool down </returns>
        public int CoolDown
        {
            get
            {
                return this.shootCD;
            }
            set
            {
                this.shootCD = value;
            }
        }


        /// <summary>
        /// Gets the shield.
        /// </summary>
        /// <returns> the shield </returns>
        public int Shield
        {
            get
            {
                return this.shield;
            }
        }

        /// <summary>
        /// Sets the s hield.
        /// </summary>
        /// <param name="shieldLife"> the new s hield </param>
        public int SHield
        {
            set
            {
                this.shield = value;
            }
        }

        /// <summary>
        /// Gets the shot ready.
        /// </summary>
        /// <returns> the shot ready </returns>
        public int ShotReady
        {
            get
            {
                return this.shotReady;
            }
            set
            {
                this.shotReady = value;
            }
        }


        /// <summary>
        /// Reset position.
        /// </summary>
        public void resetPosition()
        {
            this.Position = new Pair<int, int>(GameImpl.ARENA_WIDTH / 2, Y_INIZIAL);
        }

        /// <summary>
        /// Update.
        /// </summary>
        public override void update()
        {
            this.Position.SetX(this.Position.GetX() + this.Speed.GetX());
            this.Position.SetY(this.Position.GetY() + this.Speed.GetY());

            this.Position.SetX(Clamp.clamp(this.Position.GetX(), WIDTH / 2, GameImpl.ARENA_WIDTH - WIDTH / 2));
            this.Position.SetY(Clamp.clamp(this.Position.GetY(), HEIGHT / 2, GameImpl.ARENA_HEIGHT - HEIGHT / 2));

            this.Hitbox = new Rectangle(this.Position.GetX() - WIDTH / 2, this.Position.GetY() - HEIGHT / 2, WIDTH, HEIGHT);
        }

        /// <summary>
        /// Collide.
        /// </summary>
        /// <param name="entity"> the entity </param>
        public override void collide(Entity entity)
        {
            if (this.shield == 0)
            {
                this.health -= DAMAGE_MULTIPLIER * gameImpl.Level;
            }
            else if (this.shield > 0 && this.shield < DAMAGE_MULTIPLIER)
            {

                int tempDamageOverShieldValue = DAMAGE_MULTIPLIER - this.shield;
                this.health -= tempDamageOverShieldValue;
                this.shield = 0;
            }
            else
            {
                this.shield -= DAMAGE_MULTIPLIER;
            }

            if (this.health <= 0)
            {
                this.setDead();
            }
        }

    }

}