using System.Collections.Generic;
using System.Drawing;
using System.Linq;
namespace GameFrameWork
{

    public partial class Game
    {
        private List<GameObject> objects = new List<GameObject>();

        public List<GameObject> Objects => objects;

        public void AddObject(GameObject obj)
        {
            objects.Add(obj);
        }

        public void Update(GameTime gameTime)
        {
            foreach (var obj in objects.Where(o => o.IsActive))
                obj.Update(gameTime);
        }

        public void Draw(Graphics g)
        {
            foreach (var obj in objects.Where(o => o.IsActive))
                obj.Draw(g);
        }

        public void Cleanup()
        {
            objects.RemoveAll(o => !o.IsActive);
        }
    }
}