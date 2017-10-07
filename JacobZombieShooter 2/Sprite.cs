using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JacobZombieShooter
{
    public class Sprite
    {
        //add scale to this class
        protected Texture2D Image;
        public Vector2 Position;
        public Color Color;
        public virtual Rectangle hitbox
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Image.Width, Image.Height);
            }
        }

     public Sprite(Texture2D image,Vector2 position,Color color)
        {
            Color = color;
            Image = image;
            Position = position;

        }
        public virtual void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Image,Position,Color);
            
        }
        
    }
}
