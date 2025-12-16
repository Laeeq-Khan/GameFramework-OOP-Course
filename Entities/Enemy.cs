using System.Drawing;
namespace GameFrameWork
{

    public class Enemy : GameObject
    {
        public IMovement? Movement { get; set; }

        public Enemy()
        {
            Velocity = new PointF(-2, 0);
        }

        public override void Update(GameTime gameTime)
        {
            Movement?.Move(this, gameTime); // movement must be called
            base.Update(gameTime);
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Red, Bounds);
        }

        public override void OnCollision(GameObject other)
        {
            if (other is Bullet)
                IsActive = false;
        }
    }
}