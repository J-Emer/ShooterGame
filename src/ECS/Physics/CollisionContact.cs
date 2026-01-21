using Microsoft.Xna.Framework;

namespace ShooterGame.ECS.Physics
{
    public struct CollisionContact
    {
        public Entity A;
        public Entity B;
        public Vector2 Normal;
        public float Penetration;
    }
}