using Microsoft.Xna.Framework;

namespace ShooterGame.ECS.Components
{
    public class Velocity : Component
    {
        public Vector2 Value{get;set;} = Vector2.Zero;
    }
}