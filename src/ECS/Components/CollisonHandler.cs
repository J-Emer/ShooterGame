using System;
using ShooterGame.ECS;

namespace ShooterGame.ECS.Components
{
    public class CollisionHandler : Component
    {
        public Action<Entity, Entity>OnCollision;

        public void Raise(Entity self, Entity other)
        {
            OnCollision?.Invoke(self, other);
        }
    }
}


