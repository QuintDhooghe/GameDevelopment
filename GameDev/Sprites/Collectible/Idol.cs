using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev
{
    class Idol : Collectable
    {
        public Idol(int x, int y, Texture2D texture) : base(x, y, texture)
        {
            this._texture = texture;
            Position.X = x; Position.Y = y;
            value = 1000;
        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Collect(sprites);

            base.Update(gameTime, sprites);
        }

    }
}
