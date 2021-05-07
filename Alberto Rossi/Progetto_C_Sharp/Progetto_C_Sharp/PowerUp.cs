namespace Alberto_Rossi
{
	/// <summary>
	/// The Interface PowerUp.
	/// </summary>
	public interface PowerUp
	{

		/// <summary>
		/// Insert strategy.
		/// </summary>
		void InsertStrategy();

		/// <summary>
		/// Reset.
		/// </summary>
		void reset();

        /// <summary>
        /// Checks if is activated.
        /// </summary>
        /// <returns> true, if is activated </returns>
        bool GetActivated();
    }

}