using System;
using ShooterGame.Components;
using ShooterGame.Core;
using ShooterGame.ECS.Components;
using ShooterGame.UI;

namespace ShooterGame.ECS.Systems
{
    public class HealthSystem : UpdateSystem
    {
        public override void Update()
        {
            foreach (var entity in EntityWorld.Instance.GetEntitiesWithComponent<Health, Damage>())
            {
                Console.WriteLine($"took damage: {entity.Name}");
                
                Health _health = entity.GetComponent<Health>();
                Damage _damage = entity.GetComponent<Damage>();

                _health.Value -= _damage.Value;

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

                if(entity.Tag == "Player")
                {
                    HealthBar _healthBar =  (HealthBar)UISystem.Instance.Fint("playerhealthbar");
                    _healthBar.Value = _health.Value;
                }
            }
        }
    }
}