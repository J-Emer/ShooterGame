using System.Collections.Generic;
using ShooterGame.ECS.Components;
using TestGame.ECS.Physics;

namespace ShooterGame.ECS.Systems
{
    public class PhysicsSystem : UpdateSystem
    {
        public override void Update()
        {
            var entities = EntityWorld.Instance.GetEntitiesWithComponent<Transform, BoxCollider>();
            var colliders = new List<BoxCollider>();

            foreach (var e in entities)
            {
                if (e.HasComponent<BoxCollider>() && e.HasComponent<Transform>())
                    colliders.Add(e.GetComponent<BoxCollider>());
            }

            for (int i = 0; i < colliders.Count; i++)
            {
                for (int j = i + 1; j < colliders.Count; j++)
                {
                    if (AABBCollision.Intersects(colliders[i], colliders[j], out var contact))
                    {
                        AABBCollision.Resolve(contact);
                    }
                }
            }
        }
    }
}
