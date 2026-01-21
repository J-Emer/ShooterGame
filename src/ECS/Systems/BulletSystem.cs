using System;
using ShooterGame.Core;
using ShooterGame.ECS.Components;

namespace ShooterGame.ECS.Systems
{
    public class BulletSystem : UpdateSystem
    {
        public override void Update()
        {
            foreach (var entity in EntityWorld.Instance.GetEntitiesWithComponent<Bullet>())
            {
                Bullet _bullet = entity.GetComponent<Bullet>();
                _bullet.LifeTimer -= Time.DeltaTime;

                if(_bullet.LifeTimer <= 0f)
                {
                    Console.WriteLine("---bullet died");
                    EntityWorld.Instance.DestroyEntity(_bullet.Entity);
                }
            }
        }
    }
}