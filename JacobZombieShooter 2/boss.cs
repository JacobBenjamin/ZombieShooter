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
        public boss(Vector2 postions, Texture2D image, Color color, Vector2 speed, int shoots) : base(postions, image, color, speed, shoots)
        {
            oranginalPosition = postions;
            Speed += new Vector2(1, 1);
          
        }
        public override void update(Player player, GameTime gameTime)
        {
            for (int i = 0; i > BadBullets.Count; i++)
            {
                if (!BadBullets[i].CanSlowDown)
                {
                    BadBullets[i].CanSpeedUp = true;
                }
            }

            base.update(player, gameTime);
        }

        public void respawn()
        {
            bossLives = 50;
            Position = oranginalPosition;
        }
    }
   }
