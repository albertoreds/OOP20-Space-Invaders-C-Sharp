namespace Alberto_Rossi
{
	/// <summary>
	/// The Class BasicStrategy.
	/// </summary>
	public sealed class BasicStrategy : Strategy
	{

		/// <summary>
		/// Multiply effect.
		/// </summary>
		/// <param name="effect"> the effect </param>
		/// <returns> the int </returns>
		public int multiplyEffect( int effect)
		{

			return effect * 2;
		}

	}

}