using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostMagic.Core
{
    public static class Collision
    {
        public static bool TestCollision(Rectangle box1, Rectangle box2)
        {
            if ((box2.Left >= box1.Right) // trop à droite
                || (box2.Right <= box1.Left) // trop à gauche
                || (box2.Top >= box1.Bottom) // trop en bas
                || (box2.Bottom <= box1.Top)) // trop en haut
                return false;
            else
                return true;
        }
    }
}
