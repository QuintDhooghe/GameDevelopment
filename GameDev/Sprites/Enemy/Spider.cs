using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev
{
    class Spider : Enemy
    {
        private bool dead = false;
        public Rectangle textureSpawn;
        public override Rectangle Rectangle
        {
            get { return new Rectangle((int)Position.X + 3, (int)Position.Y + 1, _texture.Width - 6, _texture.Height / 3 - 4); }
        }
        public Spider(int x, int y, Texture2D texture) : base(x, y, texture)
        {
            this._texture = texture;
            this.Velocity = new Vector2(0, 0.5f);
            Position.X = x; Position.Y = y;
        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            foreach (var sprite in sprites)
            {
                if (sprite == this) continue;
                if (sprite.GetType() == typeof(Player))
                {

                    if (this.IsTouchingBottom(sprite) && (!this.IsTouchingTop(sprite) || !this.IsTouchingLeft(sprite)))
                        this.dead = true;
                }
                else
                {
                    if (Velocity.Y < 0 && this.IsTouchingBottom(sprite)) Velocity.Y = 0.5f;
                    if (Velocity.Y > 0 && this.IsTouchingTop(sprite)) Velocity.Y = -0.5f;
                }
            }
            this.textureSpawn.X = this.Rectangle.X - 3;
            this.textureSpawn.Y = this.Rectangle.Y - 65;

            this.textureSpawn.Width = _texture.Width;
            this.textureSpawn.Height = _texture.Height;
            if (this.dead)
            {
                Position.X = 0;
                Position.Y = 0;
            }
            else
            {
                Position.X += Velocity.X;
                Position.Y += Velocity.Y;
            }
            this.ctrlRect = this.Rectangle;

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!this.dead)
                spriteBatch.Draw(_texture, textureSpawn, null, Color.White, 0f, Origin, SpriteEffects.None, 0.4f);
        }
    }
}
