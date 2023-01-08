using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev
{
    class Coins : Collectable
    {

        public Coins(int x, int y, Texture2D texture) : base(x, y, texture)
        {
            this._texture = texture;
            Position.X = x; Position.Y = y;
            pickedUp = false;
            value = 200;
        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Collect(sprites);

            base.Update(gameTime, sprites);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!pickedUp)
                spriteBatch.Draw(_texture, Rectangle, Color.White);
        }
    }
}
