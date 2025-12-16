using System.Drawing;
namespace GameFrameWork
{

    public interface ICollidable
    {
        RectangleF Bounds { get; }
        void OnCollision(GameObject other);
    }
}