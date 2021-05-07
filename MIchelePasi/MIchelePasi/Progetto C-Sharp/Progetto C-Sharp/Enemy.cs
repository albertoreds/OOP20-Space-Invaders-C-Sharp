namespace model
{


    /// 
    /// <summary>
    /// A class with methods to check the position of the enemies, to delete the coordinates's enemies,
    /// to add a number to the coordinate's enemies <seealso cref="EnemyImpl"/>.
    /// 
    /// </summary>
    public interface Enemy
    {
        /// <summary>
        /// Method to check the number. </summary>
        /// <param name="n"> int number to check. </param>
        /// <returns> boolean: true if the number exists in the X coordinates's enemies, false otherwise. </returns>
        bool tiedupX(int n);
        /// <summary>
        /// Method to check the number. </summary>
        /// <param name="n"> int number to check. </param>
        /// <returns> boolean: true if the number exists in the Y coordinates's enemies, false otherwise. </returns>
        bool tiedupY(int n);

        /// <summary>
        /// Delete list.
        /// </summary>
        void deleteList();

        /// <summary>
        /// Method to add a number in a list. </summary>
        /// <param name="list"> boolean: true if the number is a X coordinate, false otherwise. </param>
        /// <param name="n"> int number to add. </param>
        void addNumber(bool list, int n);

    }

}