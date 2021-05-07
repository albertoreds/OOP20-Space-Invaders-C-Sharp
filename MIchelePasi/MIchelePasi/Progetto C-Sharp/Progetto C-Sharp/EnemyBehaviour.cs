namespace model
{
    /// <summary>
    /// The Interface EnemyBehaviour.
    /// </summary>
    public interface EnemyBehaviour
    {

        /// <summary>
        /// Method for create the enemies.
        /// </summary>
        /// <returns> <seealso cref="AbstarctEnemy"/>. </returns>
        AbstractEnemy createThisEnemy();

        /// <summary>
        /// Method for the enemies's movement.
        /// </summary>
        /// <returns> <seealso cref="DirEnemy"/>. </returns>
        DirEnemy casualMovs();


    }

}