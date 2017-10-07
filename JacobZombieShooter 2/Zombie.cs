using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JacobZombieShooter
{
    class Zombie : Sprite
    {
        Vector2 Speed;
        Player Enemy;
        public Zombie(Vector2 postions, Texture2D image, Color color, Vector2 speed): base(image,postions, color,1f,1f)
        {
            Speed = speed;
            
        }
        public override void Draw(SpriteBatch spritebatch)
        {
            base.Draw(spritebatch);
        }
        public void update(Player player)
        {
            if(Position.X > player.Position.X)
            {
                Position.X -= .3f;
            }
            else if (Position.X < player.Position.X)
            {
                Position.X += .3f;
            }
            if (Position.Y > player.Position.Y)
            {
                Position.Y -= .3f;
            }
            else if (Position.Y < player.Position.Y)
            {
                Position.Y += .3f;
            }
        }
    }
}
