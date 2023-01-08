using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev
{
    class Collectable : Sprite
    {
        public bool pickedUp;
        public Collectable(int x, int y, Texture2D texture) : base(x, y, texture)
        {
            this._texture = texture;
            Position.X = x; Position.Y = y;
        }
        public void Collect(List<Sprite> sprites)
        {
            ctrlRect = this.Rectangle;
            ctrlRect.X -= 4;
            ctrlRect.Y -= 4;
            ctrlRect.Width += 8;
            ctrlRect.Height += 8;
            foreach (var sprite in sprites)
            {
                if (sprite is Player)
                {
                    if (sprite.IsTouchingTop(this) || sprite.IsTouchingBottom(this) || sprite.IsTouchingRight(this) || sprite.IsTouchingLeft(this))
                    {
                        pickedUp = true;
                        sprite.value += value;
                    }
                }
            }
            if (pickedUp)
            {
                Position.X = 0;
                Position.Y = 0;
            }
        }
    }
}
