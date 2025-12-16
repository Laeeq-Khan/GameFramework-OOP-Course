using System.Drawing;

namespace GameFrameWork
{
    public interface IMovable
    {
        // Velocity of the object
        PointF Velocity { get; set; }
    }
}