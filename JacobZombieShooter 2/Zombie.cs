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
        public bool badShooting = false;
        public bool slow;
          float deltaX;
            float deltaY;
        Vector2 normal;
        float originalSpeedMagnitude;
        int Shoots;
        Player Enemy;
        Random randy;
        Vector2 goal;
        //float speed  1;
        int direction;
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
        public Zombie(Vector2 postions, Texture2D image, Color color, Vector2 speed, int shoots) : base(image, postions, color, 1, 1)
        {
            Speed = speed;
            Shoots = shoots;
            normal = speed;
            BadBullets = new List<Bullet>();
            randy = new Random();
            direction = randy.Next(1, 5);
            Origin = new Vector2(Image.Width / 2f, Image.Height / 2f);
            originalSpeedMagnitude = speed.Length();
            
            //bulletImage = Content.Load<Texture2D>("noodle");
            timeToShoot = TimeSpan.FromMilliseconds(shoots);
        }
        public virtual void update(Player player, GameTime gameTime)
        {

            Origin = new Vector2(Image.Width / 2f, Image.Height / 2f);
            deltaY = Position.Y - player.Position.Y;
            deltaX = Position.X - player.Position.X;
            Rotation = (float)Math.Atan2(-deltaX, deltaY);
        }
        public virtual void shoot(Player player, GameTime gameTime)
        {

           
            if (!badShooting)
            {
                
                //Shoots *= 2;
                //for (int i = 0; i < BadBullets.Count; i++)
                //{
                //    BadBullets[i].speed *= 10000;
                //}
            }
            else
            {
                

            }
            //else
            //{
            //    Shoots /= 2;
            //    for (int i = 0; i < BadBullets.Count; i++)
            //    {
            //        BadBullets[i].speed /= 2;
            //    }
            //}
            for (int i = 0; i < BadBullets.Count; i++)
            {
                BadBullets[i].update();
            }
           
        

            //when the player is shooting make timeToShoot smaller
            elapsedShootTime += gameTime.ElapsedGameTime;
            if (elapsedShootTime > timeToShoot)
            {
                elapsedShootTime = TimeSpan.Zero;
                BadBullets.Add(new Bullet(Position, Color, Rotation - MathHelper.PiOver2, originalSpeedMagnitude, 2, 2, true));                
                //BadBullets[BadBullets.Count - 1].fast = 0.1f;
            }



        }
        public void Muve()
        {
            Vector2 currentPosition;
            currentPosition = Position;
            if (slow == false)
            {
                if (direction == 1)
                {

                    if (Position.X < goal.X)
                    {
                        Position.X++;
                    }
                    else
                    {
                        ChangeGoal();
                    }
                }
                if (direction == 2)
                {

                    if (Position.X > goal.X)
                    {
                        Position.X--;
                    }
                    else
                    {
                        ChangeGoal();
                    }
                }
                if (direction == 3)
                {

                    if (Position.Y < goal.Y)
                    {
                        Position.Y++;
                    }
                    else
                    {
                        ChangeGoal();
                    }
                }
                if (direction == 4)
                {

                    if (Position.Y > goal.Y)
                    {
                        Position.Y--;
                    }
                    else
                    {
                        ChangeGoal();
                    }
                }
            }
            else
            {
                if (direction == 1)
                {

                    if (Position.X < goal.X)
                    {
                        Position.X+= .5f;
                    }
                    else
                    {
                        ChangeGoal();
                    }
                }
                if (direction == 2)
                {

                    if (Position.X > goal.X)
                    {
                        Position.X -= .5f;
                    }
                    else
                    {
                        ChangeGoal();
                    }
                }
                if (direction == 3)
                {

                    if (Position.Y < goal.Y)
                    {
                        Position.Y += .5f;
                    }
                    else
                    {
                        ChangeGoal();
                    }
                }
                if (direction == 4)
                {

                    if (Position.Y > goal.Y)
                    {
                        Position.Y -= .5f;
                    }
                    else
                    {
                        ChangeGoal();
                    }
                }
            }
        }

        void ChangeGoal()
        {
            direction = randy.Next(1, 5);

            if (direction == 1)
            {
                goal = new Vector2((float)Position.X + 50, Position.X);
            }
            if (direction == 2)
            {
                goal = new Vector2((float)Position.X - 50, Position.X);
            }
            if (direction == 3)
            {
                goal = new Vector2(Position.Y, (float)Position.Y + 50);
            }
            if (direction == 4)
            {
                goal = new Vector2(Position.Y, (float)Position.Y - 50);
            }
        }
        public void otherMuve(Player player)
        {

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
        }
    }
}
