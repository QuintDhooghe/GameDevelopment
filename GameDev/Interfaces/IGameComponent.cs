using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.XAudio2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameDev
{
    interface IGameComponent
    {
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
        
    }
    
    
    
    
    
    

    
}
