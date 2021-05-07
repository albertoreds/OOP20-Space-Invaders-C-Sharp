using Space;
using System;

namespace model
{



    /// <summary>
    /// The Class to create a Basic enemy <seealso cref="BasicEnemy"/> extend the abstract class <seealso cref="AbstactEnemy"/>.
    /// </summary>
    public class BasicEnemy : AbstractEnemy
    {

        /// <summary>
        /// The Constant HIT. </summary>
        private static readonly int HIT = GameImpl.ARENA_HEIGHT / 12;

        /// <summary>
        /// The Constant MYID. </summary>
        private const ID MYID = ID.BASIC_ENEMY;

        /// <summary>
        /// The Constant SPD. </summary>
        private const int SPD = 1;

        /// <summary>
        /// The Constant TIMESHOT. </summary>
        private const int TIMESHOT = 150;

        /// <summary>
        /// The Constant CMOVIM. </summary>
        private const int CMOVIM = 50;

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
        private int life = 3;

        /// <summary>
        /// The count. </summary>
        private int count;

        /// <summary>
        /// The done. </summary>
        private bool done;

        /// <summary>
        /// The dir. </summary>
        private DirEnemy dir;

        /// <summary>
        /// Constructor for <seealso cref="BasicEnemy"/>.
        /// </summary>
        /// <param name="game"> the game </param>
        public BasicEnemy(in GameImpl game) : base(new Pair<int, int>(0, 0), SPD, SPD, MYID, HIT)
        {
            this.game = game;
            this.done = false;
            ran = new Random();
        }

        /// <summary>
        /// Method of <seealso cref="Enemy"/>.
        /// </summary>
        /// <returns> <seealso cref="AbstarctEnemy"/>. </returns>
        public override AbstractEnemy createThisEnemy()
        {
            createEnemy();
            setHitbox();
            dir = casualMovs();
            return this;

        }

        /// <summary>
        /// Method of <seealso cref="EnemyBehaviour"/>.
        /// </summary>
        /// <returns> <seealso cref="DirEnemy"/>.
        ///  </returns>
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

        /// <summary>
        /// Method of <seealso cref="EnemyBehaviour"/>.
        /// </summary>
        public override void update()
        {
            shotgun++;
            if (!done)
            {
                deleteList();
                done = true;
            }
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
        /// 	Method of <seealso cref="model.EntityImpl"/>. </summary>
        /// <param name="entity"> <seealso cref="mode.Entity"/>. </param>
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


    }






}