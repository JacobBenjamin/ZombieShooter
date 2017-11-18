using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JacobZombieShooter
{
    class Tank : Pickup
    {
        public Tank(Texture2D image, Vector2 position, Color color) : base(image, position, color)
        {

        }
    }
}
