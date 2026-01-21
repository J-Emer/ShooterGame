using System;
using ShooterGame.Core;
using ShooterGame.ECS.Components;

namespace ShooterGame.ECS.Systems
{
    public class HealthSystem : UpdateSystem
    {
        public override void Update()
        {
            foreach (var entity in EntityWorld.Instance.GetEntitiesWithComponent<Health>())
            {
                if(entity.GetComponent<Health>().Value <= 0)
                {
                    if(entity.Tag == "Player")
                    {
                        Console.WriteLine("---PLAYER DIED: DEATH SCENE---");
                        Console.WriteLine("---Load Game Over Scene---");
                        //todo: load the "Player Death Scene"
                    }
                    else
                    {
                        EntityWorld.Instance.DestroyEntity(entity);                    
                    }
                }
            }
        }
    }
}