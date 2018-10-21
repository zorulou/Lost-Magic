using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostMagic.Core
{
    public class GameObject
    {
        //Tout objet doit dériver de cette classe (maps, joueurs, monstres, sorts, etc)
        //Tout objet possède une texture, une position, une taille, une vitesse de déplacement, une orientation,
        //un temps de présence et un délai avant changement d'image ou disparition.
        public Vector2 Position;
        public Texture2D Texture;
        public float Vitesse;
        public Orientation orientation;


        public Rectangle Source;
        public float time;
        public float frameTime;
        public FramesIndex frameIndex;

        public int TotalFrames { get; }
        public int FrameWidth { get; }
        public int FrameHeight { get; }


        public enum FramesIndex
        {
            BOTTOM_0 = 0,
            TOP_0 = 1,
            LEFT_0 = 2,
            RIGHT_0 = 3,
            BOTTOM_1 = 4,
            BOTTOM_2 = 5,
            BOTTOM_3 = 6,
            BOTTOM_4 = 7,
            TOP_1 = 8,
            TOP_2 = 9,
            TOP_3 = 10,
            TOP_4 = 11,
            LEFT_1 = 12,
            LEFT_2 = 13,
            LEFT_3 = 14,
            LEFT_4 = 15,
            RIGHT_1 = 16,
            RIGHT_2 = 17,
            RIGHT_3 = 18,
            RIGHT_4 = 19,
        }

        public enum Orientation
        {
            BOTTOM = 0,
            TOP = 1,
            LEFT = 2,
            RIGHT = 3
        }

        public GameObject()
        {
        }

        public GameObject(int totalAnimationFrames, int frameWidth, int frameHeight)
        {
            TotalFrames = totalAnimationFrames;
            FrameWidth = frameWidth;
            FrameHeight = frameHeight;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

        public void DrawAnimation(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Source, Color.White);
        }

        public virtual void UpdateFrame(GameTime gameTime)
        {
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;

            switch (orientation)
            {
                case Orientation.TOP:
                    frameIndex = FramesIndex.TOP_0;
                    break;
                case Orientation.LEFT:
                    frameIndex = FramesIndex.LEFT_0;
                    break;
                case Orientation.BOTTOM:
                    frameIndex = FramesIndex.BOTTOM_0;
                    break;
                case Orientation.RIGHT:
                    frameIndex = FramesIndex.RIGHT_0;
                    break;
            }
            Source = new Rectangle((int)frameIndex * FrameWidth, 0, FrameWidth, FrameHeight);
        }
    }
}
