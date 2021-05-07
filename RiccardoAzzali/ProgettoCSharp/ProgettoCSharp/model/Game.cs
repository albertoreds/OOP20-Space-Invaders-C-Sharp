using System.Collections.Generic;

namespace model
{

    /// <summary>
    /// The Interface Game.
    /// </summary>
    public interface Game
    {
        /// <summary>
        /// Update.
        /// </summary>
        void update();

        /// <summary>
        /// Gets the entities.
        /// </summary>
        /// <returns> the entities </returns>
        IList<Entity> Entities { get; }

        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <returns> the status </returns>
        GameStatus Status { get; }

        /// <summary>
        /// Check collision.
        /// </summary>
        void checkCollision();

        /// <summary>
        /// Gets the level.
        /// </summary>
        /// <returns> the level </returns>
        int Level { get; }

        /// <summary>
        /// Gets the score.
        /// </summary>
        /// <returns> the score </returns>
        int Score { get; }

        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <returns> the player </returns>
        PlayerImpl Player { get; }
    }

}