using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostMagic.Core
{
    public class Player : Entity
    {
        //Le joueur dérive de la classe Entity
        //Le joueur possède un contrôle manuel des déplacements
        //Le joueur possède une statistique de mana
        //Le joueur possède un livre de sorts

        int Mana { get; set; }

        int Hauteur { get { return Texture.Height; } }
        int Largeur { get { return Texture.Width; } }

        public Player(int totalAnimationFrames, int frameWidth, int frameHeight) : base(totalAnimationFrames, frameWidth, frameHeight)
        {
            orientation = Orientation.BOTTOM;
            frameIndex = FramesIndex.BOTTOM_0;
            Vitesse = 30f;
            frameTime = 0.3f;
        }

        public void Initialize(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
        }

        public void Move(KeyboardState state, GameTime gameTime)
        {
            bool enMouvement = false;
            if (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.Z))
            {
                orientation = Orientation.TOP;
                Position.Y -= Vitesse * (float)gameTime.ElapsedGameTime.TotalSeconds;
                enMouvement = true;
            }

            else if (state.IsKeyDown(Keys.Down) || state.IsKeyDown(Keys.S))
            {
                orientation = Orientation.BOTTOM;
                Position.Y += Vitesse * (float)gameTime.ElapsedGameTime.TotalSeconds;
                enMouvement = true;
            }

            if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.Q))
            {
                orientation = Orientation.LEFT;
                Position.X -= Vitesse * (float)gameTime.ElapsedGameTime.TotalSeconds;
                enMouvement = true;
            }

            else if (state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D))
            {
                orientation = Orientation.RIGHT;
                Position.X += Vitesse * (float)gameTime.ElapsedGameTime.TotalSeconds;
                enMouvement = true;
            }
            UpdateFrame(gameTime, enMouvement);
            enMouvement = false;
        }

        public void UpdateFrame(GameTime gameTime, bool enMouvement)
        {
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            switch (orientation)
            {
                case Orientation.BOTTOM:
                    if (enMouvement)
                    {
                        if ((int)frameIndex < 4 || (int)frameIndex > 6)
                        {
                            frameIndex = FramesIndex.BOTTOM_1;
                        }
                        else
                        {
                            if (time < frameTime)
                            {
                                return;
                            }
                            frameIndex += 1;
                        }
                        time = 0;
                    }
                    else
                    {
                        frameIndex = FramesIndex.BOTTOM_0;
                    }
                    break;
                case Orientation.TOP:
                    if (enMouvement)
                    {
                        if ((int)frameIndex < 8 || (int)frameIndex > 10)
                        {
                            frameIndex = FramesIndex.TOP_1;
                        }
                        else
                        {
                            if (time < frameTime)
                            {
                                return;
                            }
                            frameIndex += 1;
                        }
                        time = 0;
                    }
                    else
                    {
                        frameIndex = FramesIndex.TOP_0;
                    }
                    break;
                case Orientation.LEFT:
                    if (enMouvement)
                    {
                        if ((int)frameIndex < 12 || (int)frameIndex > 14)
                        {
                            frameIndex = FramesIndex.LEFT_1;
                        }
                        else
                        {
                            if (time < frameTime)
                            {
                                return;
                            }
                            frameIndex += 1;
                        }
                        time = 0;
                    }
                    else
                    {
                        frameIndex = FramesIndex.LEFT_0;
                    }
                    break;
                case Orientation.RIGHT:
                    if (enMouvement)
                    {
                        if ((int)frameIndex < 16 || (int)frameIndex > 18)
                        {
                            frameIndex = FramesIndex.RIGHT_1;
                        }
                        else
                        {
                            if (time < frameTime)
                            {
                                return;
                            }
                            frameIndex += 1;
                        }
                        time = 0;
                    }
                    else
                    {
                        frameIndex = FramesIndex.RIGHT_0;
                    }
                    break;
            }
            Source = new Rectangle(((int)frameIndex % 4) * FrameWidth, ((int)frameIndex / 4) * FrameHeight, FrameWidth, FrameHeight);
        }
    }
}
