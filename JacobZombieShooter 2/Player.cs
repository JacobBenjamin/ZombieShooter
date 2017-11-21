using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JacobZombieShooter
{
    class Player : Sprite
    {
        Vector2 origin;
       public float rotation;
       public Vector2 speed;
        public bool gameOver = false;

        public float originalSpeedMagnitude;
        public override Rectangle hitbox
        {
            get
            {
                return new Rectangle((int)(Position.X - origin.X), (int)(Position.Y - origin.Y), Image.Width, Image.Height);
            }
        }


        public Player(Texture2D image, Vector2 position, Color color, Vector2 Speed)
            : base(image, position, color,0,0)
        {
            rotation = 0;
            speed = Speed;
            origin = new Vector2(image.Width / 2f, image.Height / 2f);
            originalSpeedMagnitude = speed.Length();
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Image, Position, null, Color, rotation, origin, 1f, SpriteEffects.None, 0);
          
        }

        public void Update(KeyboardState ks, GamePadState gs)
        {
            if (gameOver == false)
            {
                if (ks.IsKeyDown(Keys.W))
                {
                    Position += speed;
                }
                if (ks.IsKeyDown(Keys.S))
                {
                    Position -= speed;
                }
                Position.Y -= gs.ThumbSticks.Left.Y * 3;
                Position.X += gs.ThumbSticks.Left.X * 3;
                if(Math.Abs(gs.ThumbSticks.Left.X) >= 0.1 || Math.Abs(gs.ThumbSticks.Left.Y) >= 0.1)
                {
                    rotation = (float)Math.Atan2(gs.ThumbSticks.Left.X, gs.ThumbSticks.Left.Y);
                }
                if (ks.IsKeyDown(Keys.D))
                {
                    rotation += .05f;
                    speed = ZombieShooterHelper.CalculateNewSpeed(originalSpeedMagnitude, (float)(rotation - Math.PI / 2));
                }
                if (ks.IsKeyDown(Keys.A))
                {
                    rotation -= .05f;
                    //hero.Position.X -= 5;
                    speed = ZombieShooterHelper.CalculateNewSpeed(originalSpeedMagnitude, (float)(rotation - Math.PI / 2));
                }
                
            }
            Console.WriteLine("speed: {0}", speed.ToString());
            Console.WriteLine("Position: {0}", Position.ToString());
        }

      

    }
}
