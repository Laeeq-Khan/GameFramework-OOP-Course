using GameFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWork
{
    public interface IMovement
    {
        void Move(GameObject obj, GameTime gameTime);
    }
}
