using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GameFrameWork
{
    public class GameObject : IDrawable, IUpdatable, IMovable, ICollidable, IPhysicsObject
    {
        // Position of the object in the game world
        public PointF Position { get; set; }

        // Size of the object (width and height)
        public SizeF Size { get; set; }

        // Velocity of the object (speed and direction)
        public PointF Velocity { get; set; } = PointF.Empty;

        // Whether this object is active (used for cleanup)
        public bool IsActive { get; set; } = true;

        // Physics-related properties (optional)
        public bool HasPhysics { get; set; } = false;

        // Custom gravity (null => use global gravity)
        public float? CustomGravity { get; set; } = null;

        // Mark this object as a rigid body. When a rigid body collides, it should stop
        // (velocity will be cleared and physics disabled to prevent gravity from moving it).
        public bool IsRigidBody { get; set; } = false;

        // Optional sprite for rendering
        public Image? Sprite { get; set; } = null;

        // Bounds of the object for collision detection
        public RectangleF Bounds => new RectangleF(Position, Size);

        // Update method to apply velocity to position
        public virtual void Update(GameTime gameTime)
        {
            Position = new PointF(Position.X + Velocity.X, Position.Y + Velocity.Y);
        }

        // Draw method to render the object (can be overridden)
        public virtual void Draw(Graphics graphics)
        {
            if (Sprite != null)
            {
                graphics.DrawImage(Sprite, Bounds);
            }
            else
            {
                using (Brush brush = new SolidBrush(Color.Gray)) // Default color
                {
                    graphics.FillRectangle(brush, Bounds);
                }
            }
        }

        // Collision handling logic (can be overridden)
        public virtual void OnCollision(GameObject other)
        {
            // Default behavior: Do nothing
        }
    }
}