namespace model
{
    using Enrico_Baroni;

	/// <summary>
	/// The Class MeteorImpl manages the behaviors of each meteor
	/// </summary>
	public class MeteorImpl : AbstractMeteor
	{

		/// <summary>
		/// The meteor life. </summary>
		private int meteor_life = 3;


		/// <summary>
		/// Instantiates a new meteor impl.
		/// </summary>
		/// <param name="position"> the position </param>
		/// <param name="velocityX"> the velocity X </param>
		/// <param name="velocityY"> the velocity Y </param>
		/// <param name="Length"> the length </param>
		/// <param name="id"> the id </param>
		public MeteorImpl(Pair<int, int> position, int velocityX, int velocityY, int Length, ID id) : base(position, velocityX, velocityY, Length, id)
		{
			// TODO Auto-generated constructor stub
		}

		/// <summary>
		/// Update entity.
		/// </summary>
		protected internal override void updateEntity()
		{
			// TODO Auto-generated method stub
			//if (((MeteorHitBox)(this.Hitbox)).OutBorder)
			//{
			//	this.setDead();
			//}

		}

		/// <summary>
		/// Collide.
		/// </summary>
		/// <param name="entity"> the entity </param>
		public override void collide(Entity entity)
		{
			// TODO Auto-generated method stub
			this.meteor_life--;
			if (this.meteor_life <= 0)
			{
				this.setDead();
			}
		}



	}

}