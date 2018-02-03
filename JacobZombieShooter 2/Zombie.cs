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
        public Vector2 Speed;
        Player Enemy;
       public List<evil> BadBullets;
        public override Rectangle hitbox
        {
            get
            {
                return new Rectangle((int)(Position.X - Origin.X), (int)(Position.Y - Origin.Y), Image.Width, Image.Height);
            }
        }
        public Zombie(Vector2 postions, Texture2D image, Color color, Vector2 speed) : base(image, postions, color, 1f, 1f)
        {
            Speed = speed;
            BadBullets = new List<evil> ();
            Origin = new Vector2(Image.Width / 2f, Image.Height / 2f);
        }

        public void update(Player player)
        {
            Origin = new Vector2(Image.Width / 2f, Image.Height / 2f);
            float deltaX;
            float deltaY;
            deltaX = Position.X - player.Position.X;
            deltaY = Position.Y - player.Position.Y;
            Rotation = (float)Math.Atan2(-deltaX, deltaY);

            if (Position.X > player.Position.X)
            {
                Position.X -= Speed.X;
            }
            else if (Position.X < player.Position.X)
            {
                Position.X += Speed.X;
            }
            if (Position.Y > player.Position.Y)
            {
                Position.Y -= Speed.Y;
            }
            else if (Position.Y < player.Position.Y)
            {
                Position.Y += Speed.Y;
            }
           // BadBullets.Add(new evil(Position, Color, 0, 0, 0, 0));
        }
    }
}
