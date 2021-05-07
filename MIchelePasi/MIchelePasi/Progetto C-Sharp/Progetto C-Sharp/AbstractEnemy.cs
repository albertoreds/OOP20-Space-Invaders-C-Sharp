using Space;
using System;
using System.Drawing;


namespace model
{
    /// <summary>
    /// The Abstract class implements <seealso cref="Enemy"/> to create entity for both type of enemies. <seealso cref="BasicEnemy"/>, <seealso cref="BossEnemy"/>.
    /// </summary>
    public abstract class AbstractEnemy : EntityImpl, EnemyBehaviour
    {
        public abstract DirEnemy casualMovs();
        public abstract AbstractEnemy createThisEnemy();

        /// <summary>
        /// The Constant WIDTH_X. </summary>
        private const int WIDTH_X = GameImpl.ARENA_WIDTH;

        /// <summary>
        /// The Constant HEIGHT_Y. </summary>
        private const int HEIGHT_Y = GameImpl.ARENA_HEIGHT;

        /// <summary>
        /// The Constant ENEMY_SPAWN_HEIGHT. </summary>
        private const int ENEMY_SPAWN_HEIGHT = 115;

        Random random = new Random();

        /// <summary>
        /// The model. </summary>
        private readonly Enemy model;

        /// <summary>
        /// The hit. </summary>
        private readonly int hit;

        /// <summary>
        /// The done. </summary>
        private bool done;

        /// <summary>
        /// Constructor for <seealso cref="AbstarctEnemy"/>.
        /// </summary>
        /// <param name="position"> : Position of the Enemy. </param>
        /// <param name="speedX"> : Speed's coordinate X. </param>
        /// <param name="speedY"> : Speed's coordinate Y. </param>
        /// <param name="id"> : ID of the enemy. </param>
        /// <param name="hit"> : size of the Hitbox. </param>
        public AbstractEnemy(in Pair<int, int> position, in int speedX, in int speedY, in ID id, in int hit) : base(position, speedX, speedY, id)
        {
            this.hit = hit;
            done = false;
            model = new EnemyImpl(hit);
        }

        /// <summary>
        /// Method to create the enemy's coordinate X and Y
        /// </summary>
        /// <returns> the abstract enemy </returns>
        protected internal virtual AbstractEnemy createEnemy()
        {
            double number;
            do
            {
                number = random.NextDouble() * (WIDTH_X);
            } while ((number > WIDTH_X / 3 && number < (WIDTH_X * 2) / 3) || model.tiedupX((int)number));
            model.addNumber(true, (int)number);
            this.Position.SetX((int)number);
            do
            {
                number = random.NextDouble() * (HEIGHT_Y);
            } while ((number > HEIGHT_Y / 4 && number < (HEIGHT_Y * 3) / 4) || model.tiedupY((int)number));
            this.Position.SetY(ENEMY_SPAWN_HEIGHT);
            done = false;
            return this;
        }

        /// <summary>
        /// Delete list in <seealso cref="EnemyImpl"/>.
        /// </summary>
        protected internal virtual void deleteList()
        {
            if (!done)
            {
                model.deleteList();
                done = true;
            }
        }

        /// <summary>
        /// Sets the hitbox.
        /// </summary>
        protected internal virtual void setHitbox()
        {
            Hitbox = new Rectangle(this.Position.GetX() - (hit / 2), this.Position.GetY() - (hit / 2), hit, hit);

        }

        /// <summary>
        /// Method to create Enemy's Shot with <seealso cref="ShotEnemyImpl "/>.
        /// </summary>
        /// <param name="dir"> <seealso cref="DirEnemy"/> </param>
        /// <param name="game"> <seealso cref="model.GameImpl"/>. </param>
        /// <param name="id"> <seealso cref="model.GameImpl"/>. </param>
        protected internal virtual void enemyShot(in DirEnemy dir, in GameImpl game, in ID id)
        {
            if (id == ID.BOSS_ENEMY)
            {
                game.Shot.Add(new ShotEnemyImpl(this.Position.GetX(), this.Position.GetY(), DirEnemy.D_R));
                game.Shot.Add(new ShotEnemyImpl(this.Position.GetX(), this.Position.GetY(), DirEnemy.D_L));
                game.Shot.Add(new ShotEnemyImpl(this.Position.GetX(), this.Position.GetY(), DirEnemy.DOWN));
            }
            else
            {
                game.Shot.Add(new ShotEnemyImpl(this.Position.GetX(), this.Position.GetY(), DirEnemy.DOWN));
            }
        }

        /// <summary>
        /// Check shotgun.
        /// </summary>
        /// <param name="shotgun"> variable to shot </param>
        /// <param name="timeShot"> time to shot </param>
        /// <returns> boolean: true if the shot <seealso cref="Shot"/> can be create, false otherwise. </returns>
        protected internal virtual bool checkShotgun(in int shotgun, in int timeShot)
        {
            return shotgun == timeShot ? true : false;
        }

        /// <summary>
        /// Method to check direction  of the enemy and move it.
        /// </summary>
        /// <param name="dir"> <seealso cref="DirEnemy"/>. </param>
        protected internal virtual void move(in DirEnemy dir)
        {
            switch (dir)
            {
                case DirEnemy.DOWN:
                    this.Position.SetY(this.Position.GetY() + this.Speed.GetY());
                    break;
                case DirEnemy.LEFT:
                    this.Position.SetX(this.Position.GetX() - this.Speed.GetX());
                    break;
                case DirEnemy.RIGHT:
                    this.Position.SetX(this.Position.GetX() + this.Speed.GetX());
                    break;
                default:
                    break;
            }
            setHitbox();
        }

        /// <summary>
        /// Check position of the enemy.
        /// </summary>
        /// <param name="dir"> <seealso cref="DirEnemy"/>. </param>
        /// <returns> DirEnemy <seealso cref="DirEnemy"/>. </returns>
        protected internal virtual DirEnemy checkPosition(in DirEnemy dir)
        {
            if (this.Position.GetX() - hit <= 0)
            {
                return DirEnemy.RIGHT;
            }
            else if (this.Position.GetX() + hit >= GameImpl.ARENA_WIDTH)
            {
                return DirEnemy.LEFT;
            }

            setHitbox();
            return dir;

        }

        /// <summary>
        /// Game over.
        /// </summary>
        /// <param name="enemy"> the enemy </param>
        /// <returns> the boolean </returns>
        public virtual bool? gameOver(AbstractEnemy enemy)
        {
            if (this.Position.GetY() >= 900)
            {
                return true;
            }
            return false;
        }
    }


}