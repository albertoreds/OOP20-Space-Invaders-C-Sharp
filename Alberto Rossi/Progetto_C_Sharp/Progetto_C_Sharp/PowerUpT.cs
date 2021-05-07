using System.Collections.Generic;

namespace Alberto_Rossi
{
	/// <summary>
	/// The Enum PowerUpT.
	/// </summary>
	public sealed class PowerUpT
	{

		/// <summary>
		/// The health. </summary>
		public static readonly PowerUpT HEALTH = new PowerUpT("HEALTH", InnerEnum.HEALTH, false,0);

		/// <summary>
		/// The fire boost. </summary>
		public static readonly PowerUpT FIRE_BOOST = new PowerUpT("FIRE_BOOST", InnerEnum.FIRE_BOOST, false,(int)(PowerUpImpl.LIFETIME_P * 1.5));

		/// <summary>
		/// The shield. </summary>
		public static readonly PowerUpT SHIELD = new PowerUpT("SHIELD", InnerEnum.SHIELD, true, PowerUpImpl.LIFETIME_P);

		/// <summary>
		/// The freeze. </summary>
		public static readonly PowerUpT FREEZE = new PowerUpT("FREEZE", InnerEnum.FREEZE, false,PowerUpImpl.LIFETIME_P);

		private static readonly List<PowerUpT> valueList = new List<PowerUpT>();

		static PowerUpT()
		{
			valueList.Add(HEALTH);
			valueList.Add(FIRE_BOOST);
			valueList.Add(SHIELD);
			valueList.Add(FREEZE);
		}

		public enum InnerEnum
		{
			HEALTH,
			FIRE_BOOST,
			SHIELD,
			FREEZE
		}

		public readonly InnerEnum innerEnumValue;
		private readonly string nameValue;
		private readonly int ordinalValue;
		private static int nextOrdinal = 0;

		/// <summary>
		/// The requiring update. </summary>
		private readonly bool requiringUpdate;

		/// <summary>
		/// The lifetime. </summary>
		private readonly int lifetime;

		/// <summary>
		/// Instantiates a new power up T.
		/// </summary>
		/// <param name="requiringUpdate"> the requiring update </param>
		/// <param name="lifetime"> the lifetime </param>
		internal PowerUpT(string name, InnerEnum innerEnum,  bool requiringUpdate,  int lifetime)
		{
			this.requiringUpdate = requiringUpdate;
			this.lifetime = lifetime;

			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}

        /// <summary>
        /// Checks if is requiring update.
        /// </summary>
        /// <returns> true, if is requiring update </returns>
        public bool GetRequiringUpdate()
        {
            return this.requiringUpdate;
        }

        /// <summary>
        /// Gets the lifetime.
        /// </summary>
        /// <returns> the lifetime </returns>
        public int getLifetime()
        {

            return this.lifetime;
	
		}


		public static PowerUpT[] values()
		{
			return valueList.ToArray();
		}

		public int ordinal()
		{
			return ordinalValue;
		}

		public override string ToString()
		{
			return nameValue;
		}

		public static PowerUpT valueOf(string name)
		{
			foreach (PowerUpT enumInstance in PowerUpT.valueList)
			{
				if (enumInstance.nameValue == name)
				{
					return enumInstance;
				}
			}
			throw new System.ArgumentException(name);
		}
	}

}