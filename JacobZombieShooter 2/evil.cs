﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JacobZombieShooter
{
    class evil:Bullet
    {
        Vector2 speed;
        public evil(Vector2 position, Color color, float rotation, float magnitude, float speedScale, float length)
            :base (position,color,rotation,magnitude,speedScale,length)
        {
            float xComponent = magnitude * (float)Math.Cos(rotation);
            float yComponent = magnitude * (float)Math.Sin(rotation);
            speed = speedScale * new Vector2(xComponent, yComponent);
           

        }
       
    }
}