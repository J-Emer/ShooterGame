using System;
using ShooterGame.ECS;
using ShooterGame.ECS.Components;

namespace ShooterGame.StaticHelpers
{
    public static class CollisionLogic
    {
        public static void PlayerCollision(Entity self, Entity other)
        {
            // Console.WriteLine($"PlayerCollision: {self} | {other}");
        }
        public static void BulletCollision(Entity self, Entity other)
        {
            if(other.Tag == "Wall" || other.Tag == "Block")
            {
                EntityWorld.Instance.DestroyEntity(self);
            }

            if(other.Tag == "Enemy")
            {
                other.GetComponent<Health>().Value -= self.GetComponent<Bullet>().Damage;
                EntityWorld.Instance.DestroyEntity(self);
            }
        }
    }
}