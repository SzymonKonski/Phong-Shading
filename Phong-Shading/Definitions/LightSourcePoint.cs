using System;
using System.Numerics;

namespace Filler.Definitions
{
    public class LightSourcePoint
    {
        public const int LightSourceRadius = 4;

        public float MaxRadius { get; set; }
        public Vector3 Center { get; set;  }
        public float X => (float)(Center.X + r * Math.Cos(angle));
        public float Y => (float)(Center.Y + r * Math.Sin(angle));
        public float Z { get; set; }

        // angle
        private float angle;
        private readonly float angleStep;

        // r
        private float r;
        private float rStep;
        private float rMin = 0;

        public LightSourcePoint(float radius, Vector3 center)
        {
            Center = center;

            angle = 0;
            angleStep = 0.5f;

            r = rMin;
            rStep = 5;
            MaxRadius = radius;

            Z = radius + center.Z;
        }

        public void UpdateLightSource()
        {
            angle += angleStep;
            if (angle >= 2 * Math.PI)
                angle = 0;

            r += rStep;
            if (r <= rMin || r >= MaxRadius)
                rStep = -rStep;
        }
    }
}
