namespace model
{
    using Space;
    using System.Drawing;


    /// <summary>
    /// Class to create the enemies's shots, implements the interface <seealso cref="ShotEnemy"/>.
    /// 
    /// </summary>
    public class ShotEnemyImpl : EntityImpl, ShotEnemy
    {

        /// <summary>
        /// The Constant MYID. </summary>
        private const ID MYID = ID.ENEMY_BULLET;

        /// <summary>
        /// The Constant STDSPD. </summary>
        private const int STDSPD = 3;

        /// <summary>
        /// The Constant HIT. </summary>
        private static readonly int HIT = GameImpl.ARENA_HEIGHT / 25;

        /// <summary>
        /// The spd. </summary>
        private readonly Pair<int, int> spd;

        /// <summary>
        /// The dir. </summary>
        private DirEnemy dir;

        /// <summary>
        /// Constructor for shot enemy class <seealso cref="ShotEnemyImpl"/>. </summary>
        /// <param name="enemyX"> Integer: Coordinate X of the enemy that called this class. </param>
        /// <param name="enemyY"> Integer: Coordinate Y of the enemy that called this class. </param>
        /// <param name="dir"> DirEnemy: Direction of the enemy that called this class. </param>
        public ShotEnemyImpl(int enemyX, int enemyY, DirEnemy dir) : base(new Pair<int, int>(enemyX, enemyY), 0, 0, MYID)
        {
            this.dir = dir;
            this.spd = new Pair<int, int>(0, 0);
            whichSpeed();
            setSpeed(spd.GetX(), spd.GetY());
            Hitbox = new Rectangle(this.Position.GetX() - (HIT / 2), this.Position.GetY() - (HIT / 2), HIT, HIT);
        }

        /// <summary>
        /// Method to check the direction of the shot and to set the speed.
        /// </summary>
        private void whichSpeed()
        {
            switch (dir)
            {
                case DirEnemy.DOWN:
                    spd.SetX(0);
                    spd.SetY(+STDSPD);
                    break;
                case DirEnemy.D_R:
                    spd.SetX(STDSPD);
                    spd.SetY(+STDSPD);
                    break;
                case DirEnemy.D_L:
                    spd.SetX(-STDSPD);
                    spd.SetY(+STDSPD);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Method of <seealso cref="model.EntityImpl"/>.
        /// </summary>
        public override void update()
        {
            whichSpeed();
            setSpeed(spd.GetX(), spd.GetY());
            this.Position = new Pair<int, int>(this.Position.GetX() + spd.GetX(), this.Position.GetY() + spd.GetY());
            Hitbox = new Rectangle(this.Position.GetX() - (HIT / 2), this.Position.GetY() - (HIT / 2), HIT, HIT);
            if (this.Position.GetY() >= GameImpl.ARENA_HEIGHT || this.Position.GetY() < 0 || this.Position.GetX() >= GameImpl.ARENA_WIDTH || this.Position.GetX() < 0)
            {
                this.setDead();
            }

        }

        /// <summary>
        /// Method of <seealso cref="model.EntityImpl"/>.
        /// </summary>
        /// <param name="entity"> <seealso cref="Entity"/> </param>
        public override void collide(Entity entity)
        {
            this.setDead();
        }

        /// <summary>
        /// Method of <seealso cref="ShotEnemy"/>
        /// </summary>
        /// <param name="dir"> <seealso cref="DirEnemy"/> </param>
        public virtual DirEnemy SetDir(DirEnemy value)
        {
            return this.dir = value;

        }

    }

}