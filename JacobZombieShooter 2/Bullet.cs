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
        Vector2 origin;
        Vector2 speed;
        float rotation;
        public Bullet(Texture2D image, Vector2 position, Color color, float rotation, float magnitude)
             : base(image, position, color)
        {
            origin = new Vector2(image.Width / 2f, image.Height / 2f);
            speed = ZombieShooterHelper.CalculateNewSpeed(magnitude, rotation);
            this.rotation = rotation;
        }
         public void update (KeyboardState ks)
        {
            Position += speed;
        }
    }
}
