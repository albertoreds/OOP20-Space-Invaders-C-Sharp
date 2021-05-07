namespace model
{
	/// <summary>
	/// The Interface Player.
	/// </summary>
	public interface Player
	{

		/// <summary>
		/// Gets the health.
		/// </summary>
		/// <returns> the health </returns>
		int Health {get;set;}


		/// <summary>
		/// Gets the cool down.
		/// </summary>
		/// <returns> the cool down </returns>
		int CoolDown {get;set;}


		/// <summary>
		/// Gets the shield.
		/// </summary>
		/// <returns> the shield </returns>
		int Shield {get;}

		/// <summary>
		/// Sets the s hield.
		/// </summary>
		/// <param name="shieldLife"> the new s hield </param>
		int SHield {set;}

		/// <summary>
		/// Gets the shot ready.
		/// </summary>
		/// <returns> the shot ready </returns>
		int ShotReady {get;set;}


		/// <summary>
		/// Reset position.
		/// </summary>
		void resetPosition();

	}

}