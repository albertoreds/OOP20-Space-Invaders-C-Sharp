using System.Collections.Generic;

namespace model
{

    /// <summary>
    /// The Class EnemyImpl to check enemies's coordinate, implements <seealso cref="Enemy"/>.
    /// </summary>
    public class EnemyImpl : Enemy
    {

        /// <summary>
        /// The list enemy X. </summary>
        private readonly IList<int> listEnemyX;

        /// <summary>
        /// The list enemy Y. </summary>
        private readonly IList<int> listEnemyY;

        /// <summary>
        /// The hit. </summary>
        private readonly int hit;

        /// <summary>
        /// Constructor of <seealso cref="EnemyImpl"/>
        /// </summary>
        /// <param name="hit"> hitbox </param>
        public EnemyImpl(int hit)
        {
            this.hit = hit;
            listEnemyX = new List<int>();
            listEnemyY = new List<int>();
        }

        /// <summary>
        /// Method of <seealso cref="Enemy"/>.
        /// </summary>
        /// <param name="n"> to check. </param>
        /// <returns> true, if successful. </returns>
        public virtual bool tiedupX(int n)
        {
            foreach (int x in listEnemyX)
            {
                if (x == n || (x >= n - hit && x <= n + hit))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Method of <seealso cref="Enemy"/>.
        /// </summary>
        /// <param name="n"> to check. </param>
        /// <returns> true, if successful. </returns>
        public virtual bool tiedupY(int n)
        {
            foreach (int x in listEnemyY)
            {
                if (x == n || (x >= -hit && x <= n + hit))
                {
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete list.
        /// </summary>
        public virtual void deleteList()
        {
            listEnemyX.Clear();
            listEnemyY.Clear();

            // TODO Auto-generated method stub

        }

        /// <summary>
        /// Method of <seealso cref="Enemy"/>
        /// </summary>
        /// <param name="list"> list to add the number n to </param>
        /// <param name="n"> number to check </param>
        public virtual void addNumber(bool list, int n)
        {
            if (list)
            {
                listEnemyX.Add(n);
            }
            else
            {
                listEnemyY.Add(n);
            }


            // TODO Auto-generated method stub

        }


    }





}