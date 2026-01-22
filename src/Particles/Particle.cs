using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShooterGame.Core;

namespace ShooterGame.Particles
{
    public class Particle
    {
        public Texture2D Texture{get;set;} = AssetLoader.GetPixel();
        public Vector2 Position{get;set;} = Vector2.Zero;
        public Vector2 Size{get;set;} = Vector2.One;
        public float Rotation{get;set;} = 0f;
        public Vector2 Velocity{get;set;} = Vector2.Zero;
        public Vector2 Acceleration{get;set;} = Vector2.Zero;
        public Color Color{get;set;} = Color.White;
        public float Alpha{get;set;} = 1f;
        public float LifeTime{get;set;} = 2f;
        public float Timer{get;set;} = 0f;
        public bool IsAlive{get;set;} = true;
    }
}