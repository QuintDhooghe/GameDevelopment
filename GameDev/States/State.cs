using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev
{
    public abstract class State
    {
        protected ContentManager _content;
        protected GraphicsDevice _graphicsDevice;
        protected Game1 _game;

        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);

        public State(ContentManager content, GraphicsDevice graphicsDevice, Game1 game)
        {
            _content = content;
            _graphicsDevice = graphicsDevice;
            _game = game;
        }

        public abstract void Update(GameTime gameTime);
    }
}
