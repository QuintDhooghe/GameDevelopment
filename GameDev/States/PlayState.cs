using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Direct3D9;


namespace GameDev
{

    internal class PlayState : State
    {
        protected ContentManager _content;
        protected GraphicsDevice _graphicsDevice;
        protected Game1 _game;

        private List<Sprite> _sprites = new List<Sprite>();
        private List<Texture2D> textures;
        private Texture2D _backgroundTexture;
        private Texture2D _gameOver;
        private Endscreen end;
        private Texture2D _Victory;
        private SpriteFont font;
        bool dead = false;

        private int currentvalue = 0;


        private int currentLevel;
        private List<int[,]> _gameBoards;
        private int[,] _currentGameboard;
        public int[,] gameBoard1 = new int[,]
            {
                { 2 , 8 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,0 , 0 , 2},
                { 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 ,1 , 0 , 1},
                { 2 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,0 , 0 , 2},
                { 2 , 0 , 0 , 0 , 1 , 0 , 5 , 0 , 1 , 0 , 0 , 0 , 0 ,0 , 0 , 2},
                { 2 , 0 , 1 , 6 , 1 , 1 , 1 , 1 , 2 , 1 , 9 , 5 , 0 ,1 , 0 , 2},
                { 2 , 0 , 2 , 1 , 2 , 0 , 0 , 0 , 0 , 2 , 1 , 1 , 1 ,1 , 6 , 2},                                                                                                                         
                { 2 , 0 , 0 , 0 , 2 , 0 , 0 , 0 , 7 , 0 , 0 , 0 , 0 ,1 , 1 , 2},
                { 2 , 0 , 0 , 0 , 2 , 0 , 0 , 0 , 0 , 0 , 1 , 9 , 0 ,0 , 0 , 2},
                { 2 , 9 , 1 , 0 , 5 , 0 , 1 , 1 , 1 , 1 , 2 , 1 , 1 ,1 , 0 , 2},
                { 2 , 1 , 2 , 1 , 1 , 1 , 2 , 0 , 0 , 0 , 0 , 0 , 0 ,0 , 0 , 2},
                { 2 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 5 ,0 , 0 , 2},
                { 2 , 0 , 1 , 0 , 5 , 0 , 1 , 1 , 1 , 1 , 1 , 2 , 1 ,1 , 1 , 2},
                { 2 , 0 , 2 , 1 , 1 , 1 , 2 , 0 , 0 , 0 , 0 , 0 , 0 ,0 , 0 , 2},
                { 2 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,0 , 4 , 2},
                { 2 , 1 , 5 , 0 , 0 , 0 , 1 , 6 , 1 , 6 , 1 , 7 , 1 ,0 , 3 , 2},
                { 2 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 ,1 , 1 , 1 , 1}
            };
        public int[,] gameBoard2 = new int[,]
        {
             { 2 , 8 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,0 , 0 , 2},
             { 1 , 1 , 1 , 1 , 1 , 1 , 1 , 0 , 0 , 1 , 1 , 1 ,1 , 1 , 1 , 1},
             { 2 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,0 , 0 , 2},
             { 2 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 1 , 0 , 5 , 0 , 1 ,9 , 0 , 2},
             { 2 , 0 , 1 , 6 , 1 , 6 , 1 , 2 , 2 , 1 , 1 , 1 , 1 ,1 , 0 , 2},
             { 2 , 0 , 2 , 1 , 2 , 1 , 2 , 0 , 0 , 2 , 2 , 2 , 0 ,0 , 0 , 2},
             { 2 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,0 , 0 , 2},
             { 2 , 9 , 0 , 5 , 0 , 1 , 0 , 0 , 0 , 0 , 0 , 1 , 7 ,0 , 1 , 2},
             { 2 , 1 , 1 , 1 , 1 , 2 , 1 , 0 , 0 , 1 , 1 , 2 , 1 ,1 , 2 , 2},
             { 2 , 0 , 0 , 0 , 0 , 0 , 2 , 0 , 0 , 0 , 0 , 7 , 0 ,0 , 0 , 2},
             { 2 , 0 , 4 , 0 , 0 , 0 , 2 , 1 , 9 , 1 , 0 , 0 , 0 ,0 , 0 , 2},
             { 2 , 0 , 3 , 1 , 0 , 0 , 0 , 2 , 2 , 2 , 0 , 0 , 0 ,0 , 0 , 2},
             { 2 , 1 , 1 , 1 , 1 , 0 , 0 , 2 , 2 , 2 , 1 , 1 , 0 ,1 , 9 , 2},
             { 2 , 2 , 2 , 2 , 2 , 1 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,2 , 2 , 2},
             { 2 , 2 , 2 , 2 , 2 , 2 , 1 , 0 , 1 , 0 , 0 , 5 , 1 ,2 , 2 , 2},
             { 2 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 ,1 , 1 , 2}
        };


    public PlayState(ContentManager content, GraphicsDevice graphicsDevice, Game1 game) : base (content, graphicsDevice, game)
        {
            _gameBoards = new List<int[,]>
            {
                gameBoard1,
                gameBoard2,
            };
            _content = content;
            _graphicsDevice = graphicsDevice;
            _game = game;
            _backgroundTexture = content.Load<Texture2D>("Background");
            _gameOver = content.Load<Texture2D>("Game Over");
            _Victory = content.Load<Texture2D>("Victory");
            font = game.font;
            textures = game._textures;
            _currentGameboard = gameBoard1;
            currentLevel= 0;
            end = new Endscreen(0, 0, _gameOver);
            CreateSprites(_currentGameboard);
            
            
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

            Rectangle screen = new Rectangle(0, 0, 512, 512);
            // TODO: Add your drawing code here

            spriteBatch.Begin(SpriteSortMode.FrontToBack);

            foreach (var sprite in _sprites)
            {
                if (sprite is Player) { spriteBatch.DrawString(font, "" + sprite.value, Vector2.Zero, Color.Black, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f); }
                sprite.Draw(spriteBatch);
            }
            spriteBatch.Draw(_backgroundTexture, screen, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0f);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            bool levelSuccess = false;
            bool gameSuccess = false;

            

            // TODO: Add your update logic here
            foreach (var sprite in _sprites)
            {
                sprite.Update(gameTime, _sprites);
                if(sprite is Player)
                {
                    Player temp2 = (Player)sprite;
                    if(temp2.value >= 2400)
                    {
                        gameSuccess= true;
                    }
                    if(temp2.dead)
                    dead = true;
                }
                if(sprite is Idol)
                {
                    var temp = (Collectable)sprite;
                    if (temp.pickedUp)
                    {
                        
                        currentLevel++;
                        if (currentLevel < _gameBoards.Count)
                        {
                            levelSuccess = true;
                            _currentGameboard = _gameBoards[currentLevel];
                        }
                        else gameSuccess= true;
                        



                    }
                }
            }
            
            if(dead)
            {
                
                _sprites.Clear();
                
                _sprites.Add(end);
            }
            if (levelSuccess)
            {
                foreach(var sprite in _sprites)
                {
                    if(sprite is Player)
                    {
                        currentvalue += sprite.value;
                    }
                }
                _sprites.Clear();
                _currentGameboard = _gameBoards[currentLevel];
                CreateSprites(_currentGameboard);
                foreach (var sprite in _sprites)
                {
                    if (sprite is Player)
                    {
                        sprite.value = currentvalue;
                    }
                }
            }
            if (gameSuccess)
            {
                _sprites.Clear();
                end._texture = _Victory;
                _sprites.Add(end);
            }
            if(end.counter > 5)
            {
                _game.ChangeState(new MenuState(_content, _graphicsDevice, _game));
            }
        }
        private void CreateSprites(int[,] gameBoard)
        {
            for (int l = 0; l < gameBoard.GetLength(0); l++)
            {
                for (int k = 0; k < gameBoard.GetLength(1); k++)
                {

                    int type = gameBoard[l, k];
                    if (type != 0)
                    {
                        _sprites.Add(SpriteFactory.CreateSprite(type, k * 32, l * 32, textures));
                    }
                }
            }
        }
    }
}
