
using Microsoft.Xna.Framework;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev
{
    interface ICollide
    {
        public bool IsTouchingLeft(Sprite sprite);
        public bool IsTouchingRight(Sprite sprite );
        public bool IsTouchingTop(Sprite sprite);
        public bool IsTouchingBottom(Sprite sprite);


    }
}
