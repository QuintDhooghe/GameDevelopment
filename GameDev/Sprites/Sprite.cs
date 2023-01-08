using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev
{
    class Sprite : ICollide 
    {
        public Texture2D _texture;
        public Vector2 Position;
        public Vector2 Velocity;
        public Vector2 Origin;
        public Rectangle ctrlRect;
        public bool dead;
        public int value;
        virtual public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }
        
        public Sprite(int x, int y, Texture2D texture)
        {
            _texture = texture;
            ctrlRect = Rectangle;
        }
        public bool IsTouchingLeft(Sprite sprite)
        {
            return this.ctrlRect.Right + this.Velocity.X  > sprite.Rectangle.Left
                && this.ctrlRect.Left < sprite.Rectangle.Left
                && this.ctrlRect.Bottom > sprite.Rectangle.Top 
                && this.ctrlRect.Top < sprite.Rectangle.Bottom ;
        }
        public bool IsTouchingRight(Sprite sprite)
        {
            return this.ctrlRect.Left + this.Velocity.X < sprite.Rectangle.Right
                && this.ctrlRect.Right > sprite.Rectangle.Right
                && this.ctrlRect.Bottom > sprite.Rectangle.Top 
                && this.ctrlRect.Top < sprite.Rectangle.Bottom ;
        }
        public bool IsTouchingTop(Sprite sprite)
        {
            return this.ctrlRect.Bottom + this.Velocity.Y > sprite.Rectangle.Top
                && this.ctrlRect.Top < sprite.Rectangle.Top
                && this.ctrlRect.Right > sprite.Rectangle.Left
                && this.ctrlRect.Left < sprite.Rectangle.Right;
        }
        public bool IsTouchingBottom(Sprite sprite)
        {
            return this.ctrlRect.Top + this.Velocity.Y < sprite.Rectangle.Bottom
                && this.ctrlRect.Bottom > sprite.Rectangle.Top
                && this.ctrlRect.Right > sprite.Rectangle.Left
                && this.ctrlRect.Left < sprite.Rectangle.Right;
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {
            ctrlRect = Rectangle;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture,Rectangle,null,Color.White, 0f, Origin, SpriteEffects.None, 0.5f);
        }
    }
}
