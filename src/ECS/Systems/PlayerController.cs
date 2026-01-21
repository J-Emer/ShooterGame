using System;
using Microsoft.Xna.Framework;
using ShooterGame.Core;
using ShooterGame.ECS.Components;
using ShooterGame.StaticHelpers;

namespace ShooterGame.ECS.Systems
{
    public class PlayerController : UpdateSystem
    {
        public override void Update()
        {
            Entity _player = EntityWorld.Instance.GetEntitiesByTag("Player")[0]; //---only need the first element of list...theres only 1 entity with tag = player

            Transform _tran = _player.GetComponent<Transform>();
            PlayerMover _mover = _player.GetComponent<PlayerMover>();

            _tran.Position += new Vector2(Input.XAxis, Input.YAxis) * _mover.MoveSpeed;

            if(Input.GetMouseButtonDown(0))
            {
                Vector2 direction = GetDirection(_tran.Position);

                // Distance from player center to outside of collider
                float spawnDistance = Math.Max(50, 50) * 0.5f + 10f; //---magic numbers are magical

                Vector2 spawnPos = _tran.Position + direction * spawnDistance;

                Vector2 velocity = direction * 10f;

                EntityFactory.Bullet(spawnPos, velocity);
            }
        }

        //---gets direction from mousePos to playerPos...where we want the bullet to fly too
        private Vector2 GetDirection(Vector2 playerPos)
        {
            Vector2 mousePos = Camera.Instance.ScreenToWorld(Input.MousePos);

            Vector2 direction = mousePos - playerPos;

            if (direction == Vector2.Zero)
            {
                return Vector2.Zero;                
            }

            return Vector2.Normalize(direction);
        }

    }
}