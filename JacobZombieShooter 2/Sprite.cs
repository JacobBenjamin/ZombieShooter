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
        public Texture2D Image;
        public Vector2 Position;
        public Color Color;
        public Vector2 Scale;
        public Vector2 Origin;
        public float Rotation;

        public virtual Rectangle hitbox
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, (int)(Image.Width * Scale.X), (int)(Image.Height*Scale.Y));
            }
        }

     public Sprite(Texture2D image,Vector2 position,Color color,float XScale,float YScale)
        {
            Color = color;
            Image = image;
            Position = position;
            Scale = new Vector2(XScale, YScale);
            Rotation = 0;
            Origin = new Vector2(0, 0);
        }
        public virtual void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Image, Position, null, Color, Rotation, Origin, Scale, SpriteEffects.None, 0);
        }

        public virtual void DrawHitBox(SpriteBatch spritebatch, GraphicsDevice graphicsDevice)
        {
            Texture2D pixel = new Texture2D(graphicsDevice, 1, 1);
            pixel.SetData(new Color[] { Color.White });

            spritebatch.Draw(pixel, hitbox, Color.Red);
        }
        
        
    }
}
