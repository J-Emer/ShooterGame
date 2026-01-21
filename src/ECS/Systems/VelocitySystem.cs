using ShooterGame.ECS.Components;

namespace ShooterGame.ECS.Systems
{
    public class VelocitySystem : UpdateSystem
    {
        public override void Update()
        {
            foreach (var entity in EntityWorld.Instance.GetEntitiesWithComponent<Transform, Velocity>())
            {
                Velocity _vel = entity.GetComponent<Velocity>();
                entity.GetComponent<Transform>().Position += _vel.Value;
            }
        }
    }
}