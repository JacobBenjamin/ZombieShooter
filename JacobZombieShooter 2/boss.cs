using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JacobZombieShooter
{
    class boss : Zombie
    {
        Vector2 oranginalPosition;
        public int bossLives = 20;
        public boss(Vector2 postions, Texture2D image, Color color, Vector2 speed) : base(postions, image, color, speed)
        {
            oranginalPosition = postions;
        }
        public void respawn()
        {
            bossLives = 20;
            Position = oranginalPosition;
        }
    }
   }
