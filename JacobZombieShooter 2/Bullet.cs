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
      
        Vector2 speed;
        float length = 1.5f;
        float rotation;
        public Bullet(Vector2 position, Color color, float rotation, float magnitude, float speedScale, float length)
             : base(Texture, position, color,1.5f,1.5f)
        {
            Origin = new Vector2(Texture.Width / 2f, Texture.Height / 2f);
            speed = speedScale * ZombieShooterHelper.CalculateNewSpeed(magnitude, rotation);
            this.rotation = rotation;
            this.length = length;
        }
         public void update (KeyboardState ks)
        {
            Position += speed;
        }
    }
}
