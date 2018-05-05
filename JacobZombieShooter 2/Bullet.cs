
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
    public class Bullet:Sprite
    {
        public static Texture2D Texture;
        public static Texture2D EvilTexture;
      
        Vector2 speed;
        float length = 1.5f;
        
        int fast;
        public override Rectangle hitbox


        {
            get
            {
                return new Rectangle((int)(Position.X - Origin.X), (int)(Position.Y - Origin.Y), Image.Width, Image.Height);
            }
        }
        public Bullet(Vector2 position, Color color, float rotation, float magnitude, float speedScale, float length, bool evil, int fast)
             : base((evil ? EvilTexture : Texture), position, color,1.5f,1.5f)
        {
            Origin = new Vector2(Texture.Width / 2f, Texture.Height / 2f);
            speed = speedScale * ZombieShooterHelper.CalculateNewSpeed(magnitude, rotation);
            //this.turn = turn;
            Rotation = rotation;
            this.fast = fast;
            this.length = length;
        }
         public virtual void update ()
        {
            Origin = new Vector2(Image.Width / 2f, Image.Height/2f);
            Position  += speed * fast;
        }
    }
}
