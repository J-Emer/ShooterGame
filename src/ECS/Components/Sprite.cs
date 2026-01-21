using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ShooterGame.ECS.Components
{
    public class Sprite : Component
    {
        public Texture2D Texture{get;set;}
        public Color DrawColor{get;set;} = Color.White;
        public SpriteEffects Effects{get;set;} = SpriteEffects.None;
        public int DrawLayer{get;set;} = 0;
        public Rectangle SourceRect{get;set;} 
    }
}