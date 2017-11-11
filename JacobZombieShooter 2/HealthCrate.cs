using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JacobZombieShooter
{
    class HealthCrate : Pickup
    {
        public HealthCrate(Texture2D image, Vector2 position, Color color) : base(image, position, color)
        {
        }
    }
}
