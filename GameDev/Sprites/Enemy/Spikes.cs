using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev
{
    class Spikes : Enemy
    {
        bool activated;

        public Rectangle sourceRectangle;
        public Vector2 positie;
        public override Rectangle Rectangle

        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y + 16, 32, 16);
            }
        }

        public Spikes(int x, int y, Texture2D texture) : base(x, y, texture)
        {
            dead = false;
            this._texture = texture;
            sourceRectangle = new Rectangle(0, 0, _texture.Width / 2, _texture.Height);
            Position.X = x; Position.Y = y;


        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            this.ctrlRect = this.Rectangle;
            ctrlRect.X = Rectangle.X - 16;
            ctrlRect.Y = Rectangle.Y - 32;
            ctrlRect.Width = Rectangle.Width + 32;
            ctrlRect.Height = Rectangle.Height + 48;
            foreach (var sprite in sprites)
            {
                if (sprite.GetType() == typeof(Player))
                {
                    if (this.IsTouchingBottom(sprite) || this.IsTouchingLeft(sprite) || this.IsTouchingRight(sprite) || this.IsTouchingTop(sprite))
                    {
                        activated = true;
                    }
                    else activated = false;

                }


            }
            if (activated)
            {
                sourceRectangle.X = 32;
            }
            else sourceRectangle.X = 0;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Rectangle, sourceRectangle, Color.White);
        }
    }
}
