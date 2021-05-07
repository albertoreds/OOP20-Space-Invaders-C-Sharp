using controller;
using System.Collections.Generic;
using System.Linq;

namespace model
{

    /// <summary>
    /// The Class GameImpl that manages the creation of the game.
    /// </summary>
    public class GameImpl : Game
    {

        /// <summary>
        /// The Constant ARENA_WIDTH. </summary>
        public const int ARENA_WIDTH = 1600;

        /// <summary>
        /// The Constant ARENA_HEIGHT. </summary>
        public const int ARENA_HEIGHT = 900;

        /// <summary>
        /// The Constant ENEMY_DEAD. </summary>
        private const int ENEMY_DEAD = 10;

        /// <summary>
        /// The Constant LEVEL_CLEARED. </summary>
        private const int LEVEL_CLEARED = 1;

        /// <summary>
        /// The game status. </summary>
        private GameStatus gameStatus;

        /// <summary>
        /// The player. </summary>
        private readonly PlayerImpl player;

        /// <summary>
        /// The level. </summary>
        private readonly Level level;

        /// <summary>
        /// The score. </summary>
        private int score;

        /// <summary>
        /// The freeze. </summary>
        private bool freeze;

        /// <summary>
        /// The check. </summary>
        private bool check;

        /// <summary>
        /// Instantiates a new game impl.
        /// </summary>
        public GameImpl()
        {
            this.gameStatus = GameStatus.RUNNING;
            this.player = new PlayerImpl(ID.PLAYER, this);
            this.level = new LevelImpl(this);
            this.score = 0;
            this.freeze = false;
            this.check = false;
        }


        /// <summary>
        /// Update.
        /// </summary>
        public virtual void update()
        {
            this.player.update();
            if (!this.freeze)
            {
            }

        }

        /// <summary>
        /// Next level.
        /// </summary>
        public virtual void nextLevel()
        {
            this.score += (LEVEL_CLEARED * this.level.Level * this.player.Health);
            this.level.nextLevel();
        }

        /// <summary>
        /// Clear entities left.
        /// </summary>
        private void clearEntitiesLeft()
        {
            this.removeDeadEntities();
        }

        /// <summary>
        /// Gets the entities.
        /// </summary>
        /// <returns> the entities </returns>
        public virtual IList<Entity> Entities
        {
            get
            {
                IList<Entity> temp = new List<Entity>();
                temp.Add(player);
                return temp;
            }
        }

        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <returns> the status </returns>
        public virtual GameStatus Status
        {
            get
            {
                return this.gameStatus;
            }
        }

        /// <summary>
        /// Check collision.
        /// </summary>
        public virtual void checkCollision()
        {
            if (this.player.Dead)
            {
                this.gameStatus = GameStatus.LOST;
            }
            else
            {
                this.nextLevel();
            }
            this.removeDeadEntities();
        }

        /// <summary>
        /// Check for collisions.
        /// </summary>
        /// <param name="entities1"> the entities 1 </param>
        /// <param name="entities2"> the entities 2 </param>
        private void checkForCollisions(IList<EntityImpl> entities1, IList<EntityImpl> entities2)
        {
        }

        /// <summary>
        /// Removes the dead entities.
        /// </summary>
        private void removeDeadEntities()
        {
        }

        /// <summary>
        /// Gets the level.
        /// </summary>
        /// <returns> the level </returns>
        public virtual int Level
        {
            get
            {
                return level.Level;

            }
        }

        /// <summary>
        /// Gets the score.
        /// </summary>
        /// <returns> the score </returns>
        public virtual int Score
        {
            get
            {
                return this.score;
            }
        }

        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <returns> the player </returns>
        public virtual PlayerImpl Player
        {
            get
            {
                return this.player;
            }
        }

        /// <summary>
        /// Sets the freeze.
        /// </summary>
        public virtual void setFreeze()
        {
            this.freeze = !this.freeze;
        }

    }

}