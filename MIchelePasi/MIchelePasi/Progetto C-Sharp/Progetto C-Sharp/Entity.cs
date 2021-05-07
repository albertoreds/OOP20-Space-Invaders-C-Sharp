namespace model
{
    using Space;
    using System.Drawing;

    /// <summary>
    /// The Interface Entity for every object present in game
    /// </summary>
    public interface Entity
    {

        /// <summary>
        /// The method that updates the status of the object.
        /// </summary>
        void update();

        /// <summary>
        /// Notifies this entity that it's colliding with another entity. </summary>
        /// <param name="entity"> the entity this entity is colliding with </param>
        void collide(Entity entity);
        /// <returns> the hitbox of the object </returns>

        Rectangle Hitbox { get; set; }
        /// <returns> whether this object is dead </returns>

        bool Dead { get; }
        /// <returns> the current speed </returns>
        Pair<int, int> Speed { get; }

        /// <returns> the current position of this object </returns>
        Pair<int, int> Position { get; set; }

        /// <returns> the current position of this object </returns>
        ID GetID();

        /// <summary>
        /// Sets the dead.
        /// </summary>
        void setDead();


    }


}