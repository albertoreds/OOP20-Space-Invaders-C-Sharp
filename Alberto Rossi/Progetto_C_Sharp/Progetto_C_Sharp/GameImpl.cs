
using Alberto_Rossi;
using controller;
using System.Collections.Generic;
using System.Linq;

namespace model
{

	//using LevelImpl = controller.LevelImpl;
	//using SpecialEffectT = model.SpecialEffect.SpecialEffectT;
	//using GPowerUp = model.powerup.GPowerUp;
	//using PPowerUp = model.powerup.PPowerUp;

	/// <summary>
	/// The Class GameImpl that manages the creation of the game.
	/// </summary>
	public class GameImpl : Game
	{

	   /// <summary>
	   /// The Constant ARENA_WIDTH. </summary>
	   public const int ARENA_WIDTH = 1600;

	   /// <summary>
	   /// The Constant ARENA_HEIGHT. </summary>
	   public const int ARENA_HEIGHT = 900;

	   /// <summary>
	   /// The Constant ENEMY_DEAD. </summary>
	   private const int ENEMY_DEAD = 10;

	   /// <summary>
	   /// The Constant LEVEL_CLEARED. </summary>
	   private const int LEVEL_CLEARED = 1;

		/// <summary>
		/// The game status. </summary>
		private GameStatus gameStatus;

		/// <summary>
		/// The player. </summary>
		private readonly PlayerImpl player;

		/// <summary>
		/// The enemies. </summary>
		//private readonly Optional<IList<AbstractEnemy>> enemies;

		/// <summary>
		/// The meteors. </summary>
		//private readonly Optional<IList<AbstractMeteor>> meteors;

		/// <summary>
		///// The bullets. </summary>
		//private readonly IList<BulletImpl> bullets;

		///// <summary>
		///// The effects. </summary>
		//private readonly IList<SpecialEffect> effects;

		/// <summary>
		/// The shots. </summary>
		//private readonly Optional<IList<ShotEnemyImpl>> shots;

		/// <summary>
		/// The player power ups. </summary>
		//private readonly IList<PPowerUp> playerPowerUps;

		/// <summary>
		/// The global power up. </summary>
		//private Optional<GPowerUp> globalPowerUp;

		/// <summary>
		/// The level. </summary>
		private readonly Level level;

		/// <summary>
		/// The score. </summary>
		private int score;

		/// <summary>
		/// The freeze. </summary>
		private bool freeze;

		/// <summary>
		/// The check. </summary>
		private bool check;

		/// <summary>
		/// Instantiates a new game impl.
		/// </summary>
		public GameImpl()
		{
			this.gameStatus = GameStatus.RUNNING;
			this.player = new PlayerImpl(ID.PLAYER, this);
			//this.enemies = new List<IList<AbstractEnemy>>();
			//this.meteors = new List<IList<AbstractMeteor>>();
			//this.bullets = new List<BulletImpl>();
			//this.effects = new List<SpecialEffect>();
			//this.shots = new List<IList<ShotEnemyImpl>>();
			//this.playerPowerUps = new List<PPowerUp>();
			//this.globalPowerUp = null;
			this.level = new LevelImpl(this);
			this.score = 0;
			this.freeze = false;
			this.check = false;
		}


		/// <summary>
		/// Update.
		/// </summary>
		public virtual void update()
		{
			//foreach (var ppu in playerPowerUps)
   //         {
			//	ppu.update();
			//}
			this.player.update();
			if (!this.freeze)
			{
				//this.enemies.get().forEach(e => e.update());
				//this.meteors.get().forEach(m => m.update());
				//this.shots.get().forEach(s => s.update());
			}

			//foreach (var b in bullets)
			//{
			//	b.update();
			//}

			//foreach (var eff in effects)
			//{
			//	eff.update();
			//}

			/*if (this.globalPowerUp.isPresent())
			{
				this.globalPowerUp.get().update();
			}*/
		}

		/// <summary>
		/// Next level.
		/// </summary>
		public virtual void nextLevel()
		{
			//if (this.effects.Count == 0 && this.enemies.isPresent() && this.enemies.get().isEmpty())
			//{
			//this.score += (LEVEL_CLEARED * this.level.Level * this.player.Health);
			//	this.clearEntitiesLeft();
			//this.level.nextLevel();
			//}
		}

		/// <summary>
		/// Clear entities left.
		/// </summary>
		private void clearEntitiesLeft()
		{
			//this.meteors.get().forEach(a => a.setDead());
			//foreach (var b in bullets)
			//{
			//	b.setDead();
			//}
			////this.shots.get().forEach(s => s.setDead());
			////this.enemies.get().forEach(e => e.setDead());
			//foreach (var eff in effects)
			//{
			//	eff.setDead();
			//}
			//this.playerPowerUps.Where(ppu => ppu.isActivated());
			//foreach(var ppu in PlayerPowerUps)
   //         {
			//	ppu.reset();
   //         }
			//foreach (var ppu in playerPowerUps)
			//{
			//	ppu.setDead();
			//}
			/*if (this.globalPowerUp.isPresent() && this.globalPowerUp.get().isActivated())
			{
				this.globalPowerUp.get().reset();
				this.globalPowerUp.get().setDead();
			}*/
			this.removeDeadEntities();
		}

		/// <summary>
		/// Gets the entities.
		/// </summary>
		/// <returns> the entities </returns>
		public virtual IList<Entity> Entities
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final java.util.List<Entity> temp = new java.util.LinkedList<>();
				IList<Entity> temp = new List<Entity>();
				temp.Add(player);
    
		//		((List<Entity>)temp).AddRange(this.bullets);
    
		//		((List<Entity>)temp).AddRange(this.playerPowerUps);
		////        
		//		((List<Entity>)temp).AddRange(this.effects);
		//		
				/*if (this.enemies.isPresent())
				{
					((List<Entity>)temp).AddRange(this.enemies.get());
				}
    
				if (this.meteors.isPresent())
				{
					((List<Entity>)temp).AddRange(this.meteors.get());
				}
    
				if (this.shots.isPresent())
				{
					((List<Entity>)temp).AddRange(this.shots.get());
				}
    
				if (this.globalPowerUp.isPresent())
				{
					temp.Add(globalPowerUp.get());
				}*/
    
				return temp;
			}
		}

		/// <summary>
		/// Gets the status.
		/// </summary>
		/// <returns> the status </returns>
		public virtual GameStatus Status
		{
			get
			{
				return this.gameStatus;
			}
		}

		/// <summary>
		/// Check collision.
		/// </summary>
		public virtual void checkCollision()
		{
			/*this.checkForCollisions(new List<EntityImpl> {this.player}, this.meteors.get().ToList());

			this.checkForCollisions(new List<EntityImpl> {this.player}, this.enemies.get().ToList());
			//this.checkForCollisions(this.enemies.get().Where(e => !e.isDead()).ToList(), this.bullets.Where(b => !b.isDead()).ToList());
			//this.checkForCollisions(this.meteors.get().Where(e => !e.isDead()).ToList(), this.bullets.Where(b => !b.isDead()).ToList());
			this.checkForCollisions(new List<EntityImpl> {this.player}, this.shots.get().ToList());
			if (this.globalPowerUp.isPresent() && !this.globalPowerUp.get().isActivated() && this.globalPowerUp.get().getHitbox().intersects(this.player.Hitbox))
			{
				this.globalPowerUp.get().setGame(this);
				this.globalPowerUp.get().collide(this.player);
			}*/
			//this.checkForCollisions(new List<EntityImpl> {this.player}, this.playerPowerUps.Where(pu => !pu.isActivated()).ToList());
			if (this.player.Dead)
			{
			this.gameStatus = GameStatus.LOST;
			}
			else
			{
			this.nextLevel();
			}
			this.removeDeadEntities();
			//prova fine gioco

			//this.enemies.get().forEach(e =>
			//{
			//check = e.gameOver(e);
			//if (check == true)
			//{
			//	this.player.setDead();
			//}
			//});
	//        if(check == true) {
	//        	this.player.setDead();
	//        }
		}

		/// <summary>
		/// Check for collisions.
		/// </summary>
		/// <param name="entities1"> the entities 1 </param>
		/// <param name="entities2"> the entities 2 </param>
		private void checkForCollisions(IList<EntityImpl> entities1, IList<EntityImpl> entities2)
		{
			/*entities1.ForEach(e1 => entities2.Where(e2 => !e2.isDead()).Where(e2 => e2.getHitbox().intersects(e1.getHitbox())).ForEach(e2 =>
			{
			if (!e2.getID().Equals(ID.POWER_UP))
			{
				e1.collide(e2);
			}
			e2.collide(e1);
			}));*/
		}

		/// <summary>
		/// Removes the dead entities.
		/// </summary>
		private void removeDeadEntities()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.List<AbstractEnemy> deadEnemies = this.enemies.get().stream().filter(e -> e.isDead()).peek(e -> this.score += (ENEMY_DEAD * this.level.getLevel())).peek(e -> this.effects.add(new SpecialEffect(ID.EFFECT, e.getPosition(), e.getHitbox(), model.SpecialEffect.SpecialEffectT.EXPLOSION))).collect(java.util.stream.Collectors.toList());
			/*IList<AbstractEnemy> deadEnemies = this.enemies.get().Where(e => e.isDead()).peek(e => this.score += (ENEMY_DEAD * this.level.getLevel())).peek(e => this.effects.Add(new SpecialEffect(ID.EFFECT, e.getPosition(), e.getHitbox(), SpecialEffectT.EXPLOSION))).ToList();
			foreach (var e in deadEnemies)
			{
				this.enemies.get().remove(e);
			}
			//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
			//ORIGINAL LINE: final java.util.List<AbstractMeteor> deadObstacles = this.meteors.get().stream().filter(a -> a.isDead()).collect(java.util.stream.Collectors.toList());
			IList<AbstractMeteor> deadObstacles = this.meteors.get().Where(a => a.isDead()).ToList();
			foreach (var o in deadObstacles)
			{
				this.meteors.get().remove(o);
			}
			this.shots.get().removeIf(s => s.isDead());
			if (this.globalPowerUp.isPresent() && this.globalPowerUp.get().isDead())
			{
				this.globalPowerUp = null;
			}*/
		//this.bullets.RemoveIf(b => b.isDead());
		//this.playerPowerUps.RemoveIf(pu => pu.isDead());
		//this.effects.RemoveIf(e => e.isDead());
		}

		/// <summary>
		/// Gets the enemies.
		/// </summary>
		/// <returns> the enemies </returns>
		/*public virtual Optional<IList<AbstractEnemy>> Enemies
		{
			get
			{
				return this.enemies;
			}
		}*/

		/// <summary>
		/// Gets the shot.
		/// </summary>
		/// <returns> the shot </returns>
		/*public virtual IList<ShotEnemyImpl> Shot
		{
			get
			{
				return this.shots.get();
			}
		}*/

	  /// <summary>
	  /// Gets the player power ups.
	  /// </summary>
	  /// <returns> the player power ups </returns>
	  //public virtual IList<PPowerUp> PlayerPowerUps
	  //{
		 // get
		 // {
			//  return this.playerPowerUps;
		 // }
	  //}

	  /// <summary>
	  /// Sets the global power up.
	  /// </summary>
	  /// <param name="globalPowerUp"> the new global power up </param>
	  /*public virtual GPowerUp GlobalPowerUp
	  {
		  set
		  {
			  this.globalPowerUp = Optional.ofNullable(value);
		  }
	  }*/

		/// <summary>
		/// Gets the level.
		/// </summary>
		/// <returns> the level </returns>
		public virtual int Level
		{
			get
			{
				return level.Level;

			}
		}

		/// <summary>
		/// Gets the score.
		/// </summary>
		/// <returns> the score </returns>
		public virtual int Score
		{
			get
			{
				return this.score;
			}
		}

		/// <summary>
		/// Gets the player.
		/// </summary>
		/// <returns> the player </returns>
		public virtual PlayerImpl Player
		{
			get
			{
				return this.player;
			}
		}

		/// <summary>
		/// Gets the bullets.
		/// </summary>
		/// <returns> the bullets </returns>
		//public virtual IList<BulletImpl> Bullets
		//{
		//	get
		//	{
		//		return this.bullets;
		//	}
		//}

		/// <summary>
		/// Gets the meteor.
		/// </summary>
		/// <returns> the meteor </returns>
		/*public virtual IList<AbstractMeteor> Meteor
		{
			get
			{
				return this.meteors.get();
			}
		}*/

		/// <summary>
		/// Sets the freeze.
		/// </summary>
		public virtual void setFreeze()
		{
			this.freeze = !this.freeze;
		}

	}

}