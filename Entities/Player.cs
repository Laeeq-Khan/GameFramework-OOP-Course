using System.Drawing;
namespace GameFrameWork
{
    public class Player : GameObject
    {
        // Movement strategy: demonstrates composition over inheritance.
        // Different movement behaviors can be injected (KeyboardMovement, PatrolMovement, etc.).
        public IMovement? Movement { get; set; }

        // Domain state
        public int Health { get; set; } = 100;
        public int Score { get; set; } = 0;

        /// Update the player: delegate movement to the Movement strategy (if provided) and then apply base update.
        /// Shows the Strategy pattern (movement behavior varies independently from Player class).
        public override void Update(GameTime gameTime)
        {
            Movement?.Move(this, gameTime);
            base.Update(gameTime);
        }

        /// Draw uses base implementation; override if player needs custom visuals.
   
        public override void Draw(Graphics g)
        {
            base.Draw(g);
        }

        /// Collision reaction for the player. Demonstrates single responsibility: domain reaction is handled here.
        public override void OnCollision(GameObject other)
        {
            if (other is Enemy)
                Health -= 10;

            if (other is PowerUp)
                Health += 20;
        }
    }

}