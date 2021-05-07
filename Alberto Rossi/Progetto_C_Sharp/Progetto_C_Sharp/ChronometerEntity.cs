using model;

namespace Alberto_Rossi
{
   

    /// <summary>
    /// An entity with a time-limited life..
    /// </summary>
    public abstract class ChronometerEntity : EntityImpl,Chronometer
	{


		/// <summary>
		/// The chronometer. </summary>
		private readonly Chronometer chronometer;
        

		/// <summary>
		/// Instantiates a new chronometer entity.
		/// </summary>
		/// <param name="position"> the position of this entity </param>
		/// <param name="veloX"> the velo X of  entity </param>
		/// <param name="veloY"> the velo Y of entity </param>
		/// <param name="id"> the id of entity </param>
		/// <param name="chronometer"> the chronometer of entity </param>
		public ChronometerEntity( Pair<int, int> position, int veloX,  int veloY,  ID id,  int chronometer) : base(position,veloX,veloY,id)
		{
			this.chronometer = new ChronometerImpl(chronometer);
		}

		/// <summary>
		/// Update.
		/// </summary>
		public override abstract void update();

		/// <summary>
		/// Collide.
		/// </summary>
		/// <param name="entity"> the entity </param>
		public override abstract void collide(Entity entity);

		/// <summary>
		/// Tick.
		/// </summary>
		public virtual void tick()
		{
			this.chronometer.tick();
		}



        /// <summary>
        /// Gets the time left.
        /// </summary>
        /// <returns> the time left </returns>
        public virtual int GetTimeLeft()
        {
            return chronometer.GetTimeLeft();
        }


        /// <summary>
        /// Checks if is ended.
        /// </summary>
        /// <returns> true, if is ended </returns>
        public virtual bool GetEnded()
        {
            return chronometer.GetEnded();
        }




    }

}