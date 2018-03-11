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
        bool shooting = false;
        float originalSpeedMagnitude;
        Player Enemy;
      
        TimeSpan elapsedShootTime;
        TimeSpan timeToShoot;
        public List<Bullet> BadBullets;
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
            BadBullets = new List<Bullet> ();
            Origin = new Vector2(Image.Width / 2f, Image.Height / 2f);
            originalSpeedMagnitude = speed.Length();
            //bulletImage = Content.Load<Texture2D>("noodle");
            timeToShoot = TimeSpan.FromMilliseconds(2000);
        }

        public void update(Player player, GameTime gameTime)
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
            
                elapsedShootTime += gameTime.ElapsedGameTime;
                if (elapsedShootTime > timeToShoot)
                {
                    elapsedShootTime = TimeSpan.Zero;
                   BadBullets.Add(new Bullet(Position, Color, Rotation - MathHelper.PiOver2, originalSpeedMagnitude, 2, 2, true, 2 ));
                }

            
         
        }
    }
}
