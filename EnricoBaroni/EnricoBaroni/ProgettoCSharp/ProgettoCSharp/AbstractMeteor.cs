namespace model
{
    using Enrico_Baroni;
    using System;
    using System.Drawing;

    /// <summary>
    /// The Class AbstractMeteor defines the general behaviors of meteors
    /// </summary>
    public abstract class AbstractMeteor : EntityImpl, Meteor
	{

		/// <summary>
		/// Instantiates a new abstract meteor.
		/// </summary>
		/// <param name="position"> the position </param>
		/// <param name="velocityX"> the velocity X </param>
		/// <param name="velocityY"> the velocity Y </param>
		/// <param name="Length"> the length </param>
		/// <param name="id"> the id </param>
		public AbstractMeteor(Pair<int, int> position,  int velocityX,  int velocityY,  int Length,  ID id) : base(position,velocityX,velocityY,id)
		{
			this.Hitbox = new Rectangle(position.GetX(), position.GetY(), Length, Length);
				//new MeteorHitBox(position, Length);
		}

		/// <summary>
		/// Update.
		/// </summary>
		public override void update()
		{
			this.Position.SetY(this.Position.GetY() + this.Speed.GetY());
			this.Hitbox = new Rectangle(Position.GetX() - (50 / 2),(Position.GetY()) - 50 / 2,50,50);
			this.updateEntity();
		}

		/// <summary>
		/// Update entity.
		/// </summary>
		protected internal abstract void updateEntity();

	}

}