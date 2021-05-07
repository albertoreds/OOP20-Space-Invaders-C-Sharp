namespace Alberto_Rossi
{
	/// <summary>
	/// A class used to count time synchronously with the gameLoop.
	/// </summary>

	public interface Chronometer
	{

		/// <summary>
		/// Tick.
		/// </summary>
		void tick();

        /// <summary>
        /// Checks if is ended.
        /// </summary>
        /// <returns> true, if is ended </returns>
        bool GetEnded();

        /// <summary>
        /// Gets the time left.
        /// </summary>
        /// <returns> the time left </returns>
        int GetTimeLeft();
    }

}