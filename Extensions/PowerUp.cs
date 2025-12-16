using System.Drawing;
namespace GameFrameWork
{

    public class PowerUp : GameObject
    {
        // PowerUps don't move, so Update is intentionally empty (single responsibility: provide pickup behavior)
        public override void Update(GameTime gameTime) { }

        /// PowerUp draws as a green ellipse — demonstrates polymorphic drawing.
        public override void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Green, Bounds);
        }

        /// When a player collides, apply the effect and deactivate. Encapsulates pickup logic here.
        public override void OnCollision(GameObject other)
        {
            if (other is Player player)
            {
                player.Health += 20;
                IsActive = false;
            }
        }
    }
}