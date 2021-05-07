using Space;
using System;

namespace model
{




    /// <summary>
    /// The Class to create boss enemy <seealso cref="BossEnemy"/> extends the abstract class <seealso cref="AbstarctEnemy"/>.
    /// </summary>
    public class BossEnemy : AbstractEnemy
    {

        /// <summary>
        /// The Constant HIT. </summary>
        private static readonly int HIT = GameImpl.ARENA_HEIGHT / 3;

        /// <summary>
        /// The Constant MYID. </summary>
        private const ID MYID = ID.BOSS_ENEMY;

        /// <summary>
        /// The Constant SPD. </summary>
        private const int SPD = 1;

        /// <summary>
        /// The Constant TIMESHOT. </summary>
        private const int TIMESHOT = 20;

        /// <summary>
        /// The Constant CMOVIM. </summary>
        private const int CMOVIM = 10;

        /// <summary>
        /// The game. </summary>
        private readonly GameImpl game;

        /// <summary>
        /// The ran. </summary>
        private readonly Random ran;

        /// <summary>
        /// The shotgun. </summary>
        private int shotgun;

        /// <summary>
        /// The life. </summary>
        private int life;

        /// <summary>
        /// The count. </summary>
        private int count;

        /// <summary>
        /// The dir. </summary>
        private DirEnemy dir;

        /// <summary>
        /// Classic constructor for <seealso cref="BossEnemy"/>.
        /// </summary>
        /// <param name="game"> <seealso cref="model.GameImpl"/> </param>
        public BossEnemy(in GameImpl game) : base(new Pair<int, int>(0, 0), SPD, SPD, MYID, HIT)
        {
            this.game = game;
            ran = new Random();
        }

        /// <summary>
        /// Method of <seealso cref="EnemyBehaviour"/>.
        /// </summary>
        /// <returns> <seealso cref="AbstractEnemy"/>. </returns>
        public override AbstractEnemy createThisEnemy()
        {
            if (this.Dead)
            {
                this.setAlive();
            }
            this.life = 10;
            createEnemy();
            deleteList();
            setHitbox();
            dir = casualMovs();
            return this;

        }

        /// <summary>
        /// Method of <seealso cref="EntityImpl"/>
        /// </summary>
        public override void update()
        {
            shotgun++;
            if (count == CMOVIM)
            {
                dir = casualMovs();
                move(dir);
                count = 0;
            }
            else
            {
                count++;
                move(dir);
                dir = checkPosition(dir);
            }
            if (checkShotgun(shotgun, TIMESHOT))
            {
                enemyShot(dir, game, MYID);
                shotgun = 0;
            }
        }

        /// <summary>
        /// Method of <seealso cref="model.EntityImpl"/>
        /// </summary>
        /// <param name="entity"> <seealso cref="model.Entity"/> </param>
        public override void collide(Entity entity)
        {
            switch (entity.GetID())
            {
                case ID.BASIC_ENEMY:
                case ID.ENEMY_BULLET:
                    break;
                default:
                    life--;
                    break;
            }
            if (life == 0)
            {
                this.setDead();
            }

        }

        /// <summary>
        /// Casual movs.
        /// </summary>
        /// <returns> the dir enemy </returns>
        public override DirEnemy casualMovs()
        {
            if (ran.Next(2) == 1)
            {
                if (ran.Next(2) == 1)
                {
                    dir = DirEnemy.RIGHT;
                }
                else
                {
                    dir = DirEnemy.LEFT;
                }

            }
            else
            {
                dir = DirEnemy.DOWN;
            }
            return dir;
        }

    }



}