using System.Drawing;
namespace GameFrameWork
{

    public class PowerUp : GameObject
    {
        public override void Update(GameTime gameTime) { }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Green, Bounds);
        }

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