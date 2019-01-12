using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JacobZombieShooter
{
    class Angery : Zombie
    {
        public override Vector2 Speed
        {
            get => base.Speed;
            set => base.Speed = value;
        }

        public Angery(Vector2 postions, Texture2D image, Color color, Vector2 speed, int shoots) : base(postions, image, color, speed, shoots)
        {

        }
    }
}
