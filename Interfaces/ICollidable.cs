using System.Drawing;

namespace GameFrameWork
{
    public interface ICollidable
    {
        // Bounds of the object for collision detection
        RectangleF Bounds { get; }

        // Method to handle collision with another object

        // Reaction hook invoked when a collision occurs; objects decide their own responses.
        void OnCollision(GameObject other);
    }
}