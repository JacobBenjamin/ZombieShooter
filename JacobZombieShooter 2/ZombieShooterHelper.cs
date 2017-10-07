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
     public static class ZombieShooterHelper
    {
        public static Vector2 CalculateNewSpeed(float magnitude, float rotation)
        {
            float xComponent = magnitude * (float)Math.Cos(rotation);
            float yComponent = magnitude * (float)Math.Sin(rotation);
            return new Vector2(xComponent, yComponent);
        }
    }
}
