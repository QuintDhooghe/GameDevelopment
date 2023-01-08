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

    public  class MenuState : State
    {
        private Texture2D background;
        private Sprite _background;
        private Button startButton;
        public MenuState(ContentManager content, GraphicsDevice graphicsDevice, Game1 game) : base(content, graphicsDevice, game)
        {
            var buttonTexture = content.Load<Texture2D>("Button");
            var background = content.Load<Texture2D>("Background");
            _background = new Sprite(0,0 , background);
            startButton = new Button(buttonTexture)
            {
                Position = new Vector2(192, 224)
            };
            startButton.Click += StartButton_Click;
            
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new PlayState(_content, _graphicsDevice, _game));
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin();
            _background.Draw(spriteBatch);
            startButton.Draw(spriteBatch);

            spriteBatch.End();

        }
        public override void Update(GameTime gameTime)
        {
            startButton.Update(gameTime);
        }

    }
}
