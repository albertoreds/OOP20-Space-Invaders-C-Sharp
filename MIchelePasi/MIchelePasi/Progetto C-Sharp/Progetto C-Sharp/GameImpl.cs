using System.Collections.Generic;

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
        //private readonly PlayerImpl player;

        /// <summary>
        /// The enemies. </summary>
        private readonly IList<AbstractEnemy> enemies;





        /// <summary>
        /// The shots. </summary>
        private readonly IList<ShotEnemyImpl> shots;



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

            this.enemies = new List<AbstractEnemy>();

            this.shots = new List<ShotEnemyImpl>();

        }


        /// <summary>
        /// Update.
        /// </summary>
        public virtual void update()
        {

            {

                foreach (var e in enemies)
                {
                    e.update();
                }

                foreach (var e in shots)
                {
                    e.update();
                }
            }

        }

        /// <summary>
        /// Next level.
        /// </summary>
        public virtual void nextLevel()
        {

        }

        /// <summary>
        /// Clear entities left.
        /// </summary>
        private void clearEntitiesLeft()
        {

            foreach (var e in enemies)
            {
                e.setDead();
            }
            foreach (var e in shots)
            {
                e.setDead();
            }

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
                ((List<Entity>)temp).AddRange(this.enemies);
                ((List<Entity>)temp).AddRange(this.shots);




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
        /// Gets the shot.
        /// </summary>
        /// <returns> the shot </returns>
        public virtual IList<ShotEnemyImpl> Shot
        {
            get
            {
                return this.shots;
            }
        }

        /// <summary>
        /// Gets the player power ups.
        /// </summary>
        /// <returns> the player power ups </returns>


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


    }

}