using System.Drawing;
namespace GameFrameWork
{

    public class Bullet : GameObject
    {
        public Bullet()
        {
            Velocity = new PointF(8, 0);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Position.X > 1000)
                IsActive = false;
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Yellow, Bounds);
        }

        public override void OnCollision(GameObject other)
        {
            if (other is Enemy)
                IsActive = false;
        }
    }
}