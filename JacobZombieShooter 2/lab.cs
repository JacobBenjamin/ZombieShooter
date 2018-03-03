using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JacobZombieShooter
{
    class Lab:Sprite
    {
        public int lives = 0;
        public Lab(Texture2D image, Vector2 position, Color color) : base(image, position, color,1,1)
        {

        }

    }
}
