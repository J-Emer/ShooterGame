using Microsoft.Xna.Framework;

namespace ShooterGame.ECS.Components
{
    public class BoxCollider : Component
    {
        public Vector2 Size;
        public Vector2 Offset;
        public bool IsStatic;
        public Rectangle Bounds
        {
            get
            {
                var transform = Entity.GetComponent<Transform>();
                Vector2 pos = transform.Position + Offset;

                return new Rectangle(
                    (int)pos.X,
                    (int)pos.Y,
                    (int)Size.X,
                    (int)Size.Y
                );
            }
        }
    
    
    }
}