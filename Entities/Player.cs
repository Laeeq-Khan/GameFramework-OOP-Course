using System.Drawing;
namespace GameFrameWork
{
    public class Player : GameObject
    {
        public IMovement? Movement { get; set; }

        public int Health { get; set; } = 100;
        public int Score { get; set; } = 0;

        public override void Update(GameTime gameTime)
        {
            Movement?.Move(this, gameTime);
            base.Update(gameTime);
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);
        }

        public override void OnCollision(GameObject other)
        {
            if (other is Enemy)
                Health -= 10;

            if (other is PowerUp)
                Health += 20;
        }
    }

}