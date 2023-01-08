using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameDev
{
    class AnimationFrame
    {
        public Rectangle SourceRectangle { get; set; }
        public AnimationFrame(Rectangle sourceRectangle)
        {
            SourceRectangle = sourceRectangle;
        }
    }   
    class Animation
    {
        public AnimationFrame CurrentFrame { get; set; }
        private List<AnimationFrame> frames;
        private int counter;
        private double secondCounter = 0d;

        public Animation()
        {
            frames = new List<AnimationFrame>();
        }
        public void GetFramesFromTextureProperties(int width, int numberOfWidthSprites, int numberOfHeightSprites, int maxHeight, int minHeight)
        {
            int widthOfFrame = width/numberOfWidthSprites;
            int heightOfFrame = (minHeight-maxHeight)/numberOfHeightSprites;
            for(int y = maxHeight; y <= minHeight - heightOfFrame; y += heightOfFrame)
            {
                for (int x = 0; x <= width - widthOfFrame; x+= widthOfFrame)
                {
                    AddFrame(new AnimationFrame(new Rectangle(x, y, widthOfFrame, heightOfFrame)));
                }
            }
        }
        public void AddFrame(AnimationFrame frame)
        {
            frames.Add(frame);
            CurrentFrame = frames[0];
        }
        public void Update(GameTime gameTime)
        {
            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;
            CurrentFrame= frames[counter];
            int fps = 12;
            if (secondCounter >= 1d / fps)
            {
                counter++;
                secondCounter= 0;
            }
            if(counter >= frames.Count)
            {
                counter= 0;
            }
        }
    }
}
