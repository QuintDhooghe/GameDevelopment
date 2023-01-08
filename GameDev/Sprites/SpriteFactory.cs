using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev
{
    class SpriteFactory
    {
        public KeyboardReader keyboard
        {
            get { return keyboard; }
            set { keyboard = new KeyboardReader(); }
        }
        public static Sprite CreateSprite(int type, int x, int y, List<Texture2D> textures, IInputReader input = null)
        {
            input = new KeyboardReader();

            Sprite newSprite = null;
            if (type == 1)
            {
                newSprite = new Floor(x, y, textures[0]);
            }
            if (type == 2)
            {
                newSprite = new Wall(x, y, textures[1]);
            }
            if (type == 3)
            {
                newSprite = new Pedestal(x, y, textures[2]);

            }
            if (type == 4)
            {
                newSprite = new Idol(x, y, textures[3]);
            }
            if (type == 5)
            {
                newSprite = new Snake(x, y - 1, textures[4]);
            }
            if (type == 6)
            {
                newSprite = new Spikes(x, y - 1, textures[5]);
            }
            if (type == 7)
            {
                newSprite = new Spider(x, y - 1, textures[6]);
            }
            if (type == 8)
            {
                newSprite = new Player(x, y - 1, textures[7], input);
            }
            if (type == 9)
            {
                newSprite = new Coins(x, y, textures[8]);
            }
            return newSprite;
        }
    }
}
