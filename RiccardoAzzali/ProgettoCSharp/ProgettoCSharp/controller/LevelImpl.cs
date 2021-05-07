namespace controller
{
	using ID = model.ID;
	using GameImpl = model.GameImpl;

	/// <summary>
	/// The Class LevelImpl manages the creation of the level.
	/// </summary>
	public class LevelImpl : Level
	{

		/// <summary>
		/// The game impl. </summary>
		private readonly GameImpl gameImpl;

		/// <summary>
		/// The Constant LEVEL_BOSS. </summary>
		private const int LEVEL_BOSS = 5;

		/// <summary>
		/// The my level. </summary>
		private int myLevel = 1;

		/// <summary>
		/// The current level. </summary>
		private int currentLevel = 1;

		/// <summary>
		/// The n enemy. </summary>
		private int nEnemy = 2;

		/// <summary>
		/// The n meteor. </summary>
		private int nMeteor = 1;

		/// <summary>
		/// Instantiates a new level impl.
		/// </summary>
		/// <param name="gameImpl"> the game impl </param>
		public LevelImpl(in GameImpl gameImpl)
		{
			this.gameImpl = gameImpl;
			createSomething();
		}

		/// <summary>
		/// Creates the.
		/// </summary>
		/// <param name="number"> the number </param>
		/// <param name="id"> the id </param>
		private void create(in int number, in ID id)
		{
			switch (id)
			{
			default:
				break;
			}
		}

		/// <summary>
		/// Creates the something.
		/// </summary>
		private void createSomething()
		{
			switch (myLevel)
			{
			default:
				break;
			}
		}

		/// <summary>
		/// Gets the level.
		/// </summary>
		/// <returns> the level </returns>
		public virtual int Level
		{
			get
			{
				return this.currentLevel;
			}
		}

		/// <summary>
		/// Next level.
		/// </summary>
		public virtual void nextLevel()
		{
			gameImpl.Player.resetPosition();
			currentLevel++;
			myLevel++;
			nEnemy++;
			if (myLevel <= LEVEL_BOSS)
			{
				createSomething();
			}
			else
			{
				myLevel = 1;
				nEnemy++;
				nMeteor++;
				createSomething();
			}
		}

	}

}