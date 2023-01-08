
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Drawing.Design;

namespace GameDev
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager _graphics;
        private Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch;
        private int index;

        private State _currentState;
        private State _nextState;
        
        private Texture2D _floorTexture;
        private Texture2D _wallTexture;
        private Texture2D _pedestalTexture;
        private Texture2D _idolTexture;
        private Texture2D _snakeTexture;
        private Texture2D _spikesTexture;
        private Texture2D _spiderTexture;
        private Texture2D _heroTexture;
        private Texture2D _coinTexture;
        private Texture2D _backgroundTexture;
        private Texture2D _button;
        internal List<Sprite> _sprites;
        public List<Texture2D> _textures;

        public SpriteFont font;


        public void ChangeState(State state)
        {
            _nextState = state;
        }


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 512;
            _graphics.PreferredBackBufferHeight = 512;
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _sprites = new List<Sprite>();
            _textures= new List<Texture2D>();
            
            

            
            // TODO: Add your initialization logic here

            base.Initialize();
;
        }

        protected override void LoadContent()
        {
            spriteBatch = new Microsoft.Xna.Framework.Graphics.SpriteBatch(GraphicsDevice);


            // TODO: use this.Content to load your game content here
            font = Content.Load<SpriteFont>("File");
            _backgroundTexture = Content.Load<Texture2D>("Background");
            _textures.Add(_floorTexture = Content.Load<Texture2D>("Floor Texture"));
            _textures.Add(_wallTexture = Content.Load<Texture2D>("Wall Texture"));
            _textures.Add(_pedestalTexture = Content.Load<Texture2D>("Pedestal Texture"));
            _textures.Add(_idolTexture = Content.Load<Texture2D>("idol"));
            _textures.Add(_snakeTexture = Content.Load<Texture2D>("Cobra Sprite Sheet"));
            _textures.Add(_spikesTexture = Content.Load<Texture2D>("Spike Trap"));
            _textures.Add(_spiderTexture = Content.Load<Texture2D>("Spider Texture"));
            _textures.Add(_heroTexture = Content.Load<Texture2D>("Archaeologist Sprite Sheet"));
            _textures.Add(_coinTexture = Content.Load<Texture2D>("Coins Texture"));
            _button = Content.Load<Texture2D>("Button");
            //CreateSprites(gameBoard1);
            var StartButton = new Button(_button)
            {
                Position = new Vector2(200,200)
            };
            StartButton.Click += StartButton_Click;
            _currentState = new MenuState(Content, _graphics.GraphicsDevice, this);
        }

        private void StartButton_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        protected override void Update(GameTime gameTime)
        {
            if(_nextState != null)
            {
                _currentState = _nextState;
                _nextState = null;
            }
            _currentState.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);
            _currentState.Draw(spriteBatch,gameTime);
            base.Draw(gameTime);
        }
        
    }
}