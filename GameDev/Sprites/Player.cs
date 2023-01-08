
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GameDev
{
    class Player : Sprite
    {
        private Animation idleAnimation;
        private Animation walkAnimation;
        private Animation deathAnimation;

        private IInputReader input;

        private Texture2D texture;

        private Vector2 acceleration;
        private double secondCounter;
        private float airTime;
        private bool Landed;
        private float runTime = 0;
        public bool dead;
        int framecounter = 0;


        public override Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X +24, (int)Position.Y+14, 13, 19);
            }
        }
        
        
        public Player(int x, int y, Texture2D texture, IInputReader input) : base( x,  y,  texture)
        {
            this.input = input;
            this._texture = texture;
            this.ctrlRect = Rectangle;
            Position.X= x; Position.Y = y;
            value= 0;
            
            Velocity= new Vector2(1,1);
            acceleration = new Vector2(0.3f, 0.1f);

            walkAnimation = new Animation();
            walkAnimation.GetFramesFromTextureProperties(_texture.Width, 8, 1, 32, 64);

            idleAnimation = new Animation();
            idleAnimation.GetFramesFromTextureProperties(_texture.Width, 8, 1, 0, 32);

            deathAnimation= new Animation();
            deathAnimation.GetFramesFromTextureProperties(_texture.Width - 192 ,5,1, 192, 224);
           


        }
        public bool Jump(Vector2 direction, bool landed  ) 
        { 
            return direction.Y < 0 && Landed;
        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            
            Landed = false;
            var direction = input.ReadInput();
            
            
            
            Velocity.X = 2*direction.X+direction.X*acceleration.X  ;
            Velocity.Y += acceleration.Y * airTime;

            if (this.dead)
            {
                Velocity.X = 0;
                
            }


            ctrlRect.X += (int)Velocity.X;
            ctrlRect.Y += (int)Velocity.Y;
             
            foreach (var sprite in sprites)
            {
                

                if (sprite == this)
                {
                    continue;
                }
                if (sprite is Enemy)
                {
                    if(sprite is Spikes)
                    {
                        if(this.IsTouchingBottom(sprite) || this.IsTouchingLeft(sprite) || this.IsTouchingRight(sprite) || this.IsTouchingTop(sprite))
                        {
                            this.dead= true;
                        }
                    }
                    if ((this.IsTouchingBottom(sprite) || this.IsTouchingLeft(sprite) || this.IsTouchingRight(sprite)) && !this.IsTouchingTop(sprite) && !sprite.dead)
                        this.dead = true;
                }
                else
                {
                    if (this.IsTouchingTop(sprite))
                    {
                        Landed = true;
                    }
                    if (this.Velocity.X > 0 && this.IsTouchingLeft(sprite))
                    {
                        Velocity.X = 0;
                    }
                    if (this.Velocity.X < 0 && this.IsTouchingRight(sprite))
                    {
                        Velocity.X = 0;
                    }

                    if (this.Velocity.Y > 0 && this.IsTouchingTop(sprite))
                    {

                        this.Velocity.Y = 0;
                    }
                    if (this.Velocity.Y < 0 && this.IsTouchingBottom(sprite))
                    {
                        this.Velocity.Y = 0;

                    }
                }
                
            }
            if(Jump(direction, Landed) && !dead)
            {
                Velocity.Y = -4f;
            }

            Position += Velocity;
            this.ctrlRect = this.Rectangle;

            if (Landed)
            {
                airTime = 0;
                acceleration.Y = 0;
            }
            else
            {
                airTime += 0.25f;
                acceleration.Y = 0.1f;
            }

            walkAnimation.Update(gameTime);
            idleAnimation.Update(gameTime);
            
            if (this.dead && framecounter <= 12)
            {
                
                deathAnimation.Update(gameTime);
                framecounter++;
            }

            
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            
            if (this.dead)
            {
                spriteBatch.Draw(_texture, Position, deathAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Origin, 1f, SpriteEffects.FlipHorizontally, 1f );
                
            }
            else if (input.ReadInput().X == 0f)
            {
                spriteBatch.Draw(_texture, Position, idleAnimation.CurrentFrame.SourceRectangle, Color.White);
            }
            else if (input.ReadInput().X == -1)
            {
                spriteBatch.Draw(_texture, Position, walkAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Origin, 1f, SpriteEffects.FlipHorizontally, 1f);
            }
            else spriteBatch.Draw(_texture, Position, walkAnimation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
