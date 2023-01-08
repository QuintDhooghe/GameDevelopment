using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev
{
    class Snake : Enemy
    {
        private Animation walkAnimation;
        private Animation attackAnimation;
        private Animation deathAnimation;

        private bool attacking;
        int frameCounter = 0;
        public override Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X + 2, (int)Position.Y + 16, 28, 16);
            }
        }

        public Snake(int x, int y, Texture2D texture) : base(x, y, texture)
        {

            this.ctrlRect = Rectangle;
            Origin = new Vector2(0, 0);
            this._texture = texture;
            Position.X = x; Position.Y = y;

            Velocity = new Vector2(0.5f, 0);

            walkAnimation = new Animation();
            walkAnimation.GetFramesFromTextureProperties(_texture.Width, 8, 1, 0, 32);

            attackAnimation = new Animation();
            attackAnimation.GetFramesFromTextureProperties(_texture.Width - 64, 6, 1, 64, 96);

            deathAnimation = new Animation();
            deathAnimation.GetFramesFromTextureProperties(_texture.Width - 64, 6, 1, 128, 160);
        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {

            foreach (var sprite in sprites)
            {
                if (sprite == this) continue;
                if (sprite.GetType() == typeof(Player))
                {
                    if (this.IsTouchingBottom(sprite))
                        this.dead = true;
                    else if ((this.IsTouchingRight(sprite) || this.IsTouchingLeft(sprite)))
                        this.attacking = true;

                }
                else
                {
                    if (Velocity.X < 0 && this.IsTouchingRight(sprite)) Velocity.X = 0.5f;
                    if (Velocity.X > 0 && this.IsTouchingLeft(sprite)) Velocity.X = -0.5f;
                }
            }
            this.ctrlRect = this.Rectangle;
            this.ctrlRect.Width += 2;
            this.ctrlRect.Height += 10;
            this.ctrlRect.X -= 1;
            this.ctrlRect.Y -= 10;
            Position += Velocity;
            if (this.dead && frameCounter <= 28 && !attacking)
            {
                frameCounter++;
                Velocity.X = 0;
                deathAnimation.Update(gameTime);


            }
            if (this.dead && frameCounter > 28)
            {
                Position.X = 0;
                Position.Y = 0;
            }

            if (attacking)
                attackAnimation.Update(gameTime);
            walkAnimation.Update(gameTime);


        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (frameCounter <= 28)
            {
                if (Velocity.X < 0)
                {
                    if (this.attacking)
                        spriteBatch.Draw(_texture, Position, attackAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Origin, 1f, SpriteEffects.FlipHorizontally, 0.9f);
                    else if (this.dead)
                        spriteBatch.Draw(_texture, Position, deathAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Origin, 1f, SpriteEffects.FlipHorizontally, 0.9f);
                    else
                        spriteBatch.Draw(_texture, Position, walkAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Origin, 1f, SpriteEffects.FlipHorizontally, 0.9f);
                }
                else
                {
                    if (this.attacking)
                        spriteBatch.Draw(_texture, Position, attackAnimation.CurrentFrame.SourceRectangle, Color.White);
                    else if (dead)
                        spriteBatch.Draw(_texture, Position, deathAnimation.CurrentFrame.SourceRectangle, Color.White);
                    else
                        spriteBatch.Draw(_texture, Position, walkAnimation.CurrentFrame.SourceRectangle, Color.White);
                }
            }
        }
    }
}
