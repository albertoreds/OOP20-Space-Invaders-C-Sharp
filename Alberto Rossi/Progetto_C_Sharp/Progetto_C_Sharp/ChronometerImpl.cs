namespace Alberto_Rossi
{
	/// <summary>
	/// The Class ChronometerImpl.
	/// </summary>
	public class ChronometerImpl : Chronometer
	{

		/// <summary>
		/// The chronometer. </summary>
		private int chronometer;

		/// <summary>
		/// Instantiates a new chronometer impl.
		/// </summary>
		/// <param name="chronometer"> the chronometer </param>
		public ChronometerImpl( int chronometer)
		{
			this.chronometer = chronometer;
		}

		/// <summary>
		/// Tick.
		/// </summary>
		public virtual void tick()
		{
			this.chronometer--;

		}

        /// <summary>
        /// Checks if is ended.
        /// </summary>
        /// <returns> true, if is ended </returns>
        public virtual bool GetEnded()
        {
            return this.chronometer <= 0;
        }

        /// <summary>
        /// Gets the time left.
        /// </summary>
        /// <returns> the time left </returns>
        public virtual int GetTimeLeft()
        {
            return this.chronometer;
        }

    }

}