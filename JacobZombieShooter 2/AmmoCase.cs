using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JacobZombieShooter
{
    class AmmoCase : Sprite
    {
        public AmmoCase(Texture2D image, Vector2 position, Color color) : base(image, position, color, .5f, .5f)
        {
        }
            public override void Draw(SpriteBatch spritebatch)
        {
            base.Draw(spritebatch);
        }
    
    }
    
}
