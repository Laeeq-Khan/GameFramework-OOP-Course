using GameFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWork
{
    public class PatrolMovement : IMovement
    {
        private float leftBound;
        private float rightBound;
        private float speed = 2f;

        public PatrolMovement(float left, float right)
        {
            leftBound = left;
            rightBound = right;
        }

        public void Move(GameObject obj, GameTime gameTime)
        {
            obj.Position = new PointF(obj.Position.X + speed, obj.Position.Y);

            if (obj.Position.X < leftBound)
            {
                obj.Position = new PointF(leftBound, obj.Position.Y);
                speed = Math.Abs(speed); // Move right
            }
            else if (obj.Position.X > rightBound)
            {
                obj.Position = new PointF(rightBound, obj.Position.Y);
                speed = -Math.Abs(speed); // Move left
            }
        }
    }

}
