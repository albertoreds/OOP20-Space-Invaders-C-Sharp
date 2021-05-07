namespace model
{
    using System;
    using System.Drawing;
    using utility;

    /// <summary>
    /// A class describing the basic behavior of every entity in the game.
    /// </summary>
    public abstract class EntityImpl : Entity
    {

        /// <summary>
        /// The id. </summary>
        private readonly ID id;
        private readonly Rectangle Empty;

        /// <summary>
        /// The hitbox. </summary>
        private Rectangle hitbox;

        /// <summary>
        /// The position. </summary>
        private Pair<int, int> position;

        /// <summary>
        /// The dead. </summary>
        private bool dead;

        /// <summary>
        /// The speed. </summary>
        private Pair<int, int> speed;


        /// <summary>
        /// Instantiates a new entity impl.
        /// </summary>
        /// <param name="position"> the position </param>
        /// <param name="speedX"> the speed X </param>
        /// <param name="speedY"> the speed Y </param>
        /// <param name="id"> the id </param>
        public EntityImpl(Pair<int, int> position, int speedX, int speedY, ID id)
        {
            this.position = position;
            this.id = id;
            this.hitbox = Empty;
            this.speed = new Pair<int, int>(speedX, speedY);
        }

        /// <summary>
        /// Instantiates a new entity impl.
        /// </summary>
        /// <param name="id"> the id </param>
        public EntityImpl(ID id) : this(null, 0, 0, id)
        {
        }

        /// <summary>
        /// Update.
        /// </summary>
        public abstract void update();

        /// <summary>
        /// Collide.
        /// </summary>
        /// <param name="entity"> the entity </param>
        public abstract void collide(Entity entity);



        /// <summary>
        /// Gets the hitbox.
        /// </summary>
        /// <returns> the hitbox </returns>
        public virtual Rectangle Hitbox
        {
            get
            {
                return this.hitbox;
            }
            set
            {
                this.hitbox = value;
            }
        }

        /// <summary>
        /// Checks if is dead.
        /// </summary>
        /// <returns> true, if is dead </returns>
        public virtual bool Dead
        {
            get
            {
                return this.dead;
            }
        }

        /// <summary>
        /// Gets the speed.
        /// </summary>
        /// <returns> the speed </returns>
        public virtual Pair<int, int> Speed
        {
            get
            {
                return this.speed;
            }
        }

        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <returns> the position </returns>
        public virtual Pair<int, int> Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        /// <returns> the id </returns>
        public ID ID
        {
            get
            {
                return this.id;
            }
        }


        /// <summary>
        /// Sets the dead.
        /// </summary>
        public virtual void setDead()
        {
            this.dead = true;
        }

        /// <summary>
        /// Sets the alive.
        /// </summary>
        public virtual void setAlive()
        {
            this.dead = false;
        }


        /// <summary>
        /// Sets the speed.
        /// </summary>
        /// <param name="speedX"> the speed X </param>
        /// <param name="speedY"> the speed Y </param>
        public virtual void setSpeed(int speedX, int speedY)
        {
            this.speed = new Pair<int, int>(speedX, speedY);
        }

    }

}