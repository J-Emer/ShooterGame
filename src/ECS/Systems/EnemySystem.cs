using System;
using Microsoft.Xna.Framework;
using ShooterGame.Core;
using ShooterGame.ECS.Components;

namespace ShooterGame.ECS.Systems
{
    public class EnemySystem : UpdateSystem
    {
        public override void Update()
        {
            Entity _player = EntityWorld.Instance.GetEntitiesByTag("Player")[0];
            Transform _playerTrans = _player.GetComponent<Transform>();
            Health _playerHealth = _player.GetComponent<Health>();

            if(_player == null){return;}

            foreach (var enemy in EntityWorld.Instance.GetEntitiesWithComponent<EnemyComponent, Velocity>())
            {
                //---enemy movemet--//
                Transform _enemyTrans = enemy.GetComponent<Transform>();
                Velocity _enemyVel = enemy.GetComponent<Velocity>();
                EnemyComponent _enemyComp = enemy.GetComponent<EnemyComponent>();

                Vector2 direction = _playerTrans.Position - _enemyTrans.Position;

                if (direction != Vector2.Zero)
                {
                    direction.Normalize();
                    _enemyVel.Value = direction * _enemyComp.MoveSpeed;
                }
                else
                {
                    _enemyVel.Value = Vector2.Zero;
                }    

                //---enemy attack--//
                _enemyComp._timer += Time.DeltaTime;

                if(_enemyComp._timer >= _enemyComp.AttackCoolDownTimer)
                {
                    _enemyComp._timer = 0;

                    float dist = Vector2.Distance(_playerTrans.Position, _enemyTrans.Position);

                    if(dist <= _enemyComp.AttackRange)
                    {
                        Console.WriteLine("---enemy attack");
                        _playerHealth.Value -= _enemyComp.Damage;
                    }                    
                }

            }
        }
    }
}