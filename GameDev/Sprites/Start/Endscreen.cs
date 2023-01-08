using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameDev
{
    class Endscreen : Sprite
    {
        public double counter = 0;
        public Endscreen(int x, int y, Texture2D texture) : base(x, y, texture)
        {

        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            counter += gameTime.ElapsedGameTime.TotalSeconds;
            base.Update(gameTime, sprites);
        }
    }
}


