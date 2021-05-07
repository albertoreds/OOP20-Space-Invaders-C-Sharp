namespace Alberto_Rossi
{
	/// <summary>
	/// The Interface Strategy to determinate the power of powerUp.
	/// </summary>
	public interface Strategy
	{

		/// <summary>
		/// Multiply effect.
		/// </summary>
		/// <param name="effect"> the effect </param>
		/// <returns> the int </returns>
		int multiplyEffect(int effect);
	}

}