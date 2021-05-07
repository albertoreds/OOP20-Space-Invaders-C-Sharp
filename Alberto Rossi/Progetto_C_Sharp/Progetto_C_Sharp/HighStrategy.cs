namespace Alberto_Rossi
{
	/// <summary>
	/// The Class HighStrategy.
	/// </summary>
	public sealed class HighStrategy : Strategy
	{

		/// <summary>
		/// The Constant MULTI. </summary>
		private const double MULTI = 5;

		/// <summary>
		/// Multiply effect.
		/// </summary>
		/// <param name="effect"> the effect </param>
		/// <returns> the int </returns>
		public int multiplyEffect(int effect)
		{
			return (int)(effect * MULTI);
		}

	}

}