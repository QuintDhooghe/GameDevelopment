using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev
{
    class Wall : Sprite
    {
        public Wall(int x, int y, Texture2D texture) : base(x, y, texture)
        {
            this._texture = texture;
            Position.X = x; Position.Y = y;
        }
    }
}
