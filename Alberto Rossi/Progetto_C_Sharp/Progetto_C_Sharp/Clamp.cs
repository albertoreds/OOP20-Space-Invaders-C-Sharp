namespace utility
{
	/// <summary>
	/// The Class Clamp.
	/// </summary>
	public class Clamp
	{

		/// <summary>
		/// Instantiates a new clamp.
		/// </summary>
		private Clamp()
		{
		}

		/// <summary>
		/// Clamp.
		/// </summary>
		/// <param name="var"> the var </param>
		/// <param name="min"> the min </param>
		/// <param name="max"> the max </param>
		/// <returns> the int </returns>
		public static int clamp( int var,  int min,  int max)
		{
			return var < min ? min : (var > max ? max : var);
		}

	}

}