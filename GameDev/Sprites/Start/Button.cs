using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev
{
    public class Button : IGameComponent
    {
        private MouseState _currentMouse;

        private bool _isHovering;

        private MouseState _previousMouse;
        private Texture2D _texture;

        public event EventHandler Click;
        public bool Clicked { get; private set; }
        public Vector2 Position { get; set; }

        public Rectangle rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }
        public Button(Texture2D texture)
        {
            _texture = texture;
        }
        public void Update(GameTime gameTime)
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1,1);

            _isHovering = false;
            if(mouseRectangle.Intersects(rectangle))
            {
                _isHovering = true;

                if(_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, rectangle, Color.White);
        }

    }
}
