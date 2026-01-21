using System.Collections.Generic;
using Microsoft.Xna.Framework;
using ShooterGame.Core;
using ShooterGame.ECS;
using ShooterGame.ECS.Components;

namespace ShooterGame.StaticHelpers
{
    public static class EntityFactory
    {
        public static void Player(Vector2 pos)
        {
            EntityWorld.Instance.CreateEntity("Player", "Player", new List<Component>
            {
                new Transform
                {
                    Position = pos,
                },
                new Sprite
                {
                    Texture = AssetLoader.GetTexture("Color"),
                    SourceRect = new Rectangle(50,0,50,50)
                },
                new PlayerMover(),
                new BoxCollider
                {
                    Size = new Vector2(50, 50),
                    IsStatic = false
                },
                new CollisionHandler
                {
                    OnCollision = CollisionLogic.PlayerCollision
                },
                new Health()
            });            
        }
        public static void Block(Vector2 pos)
        {
            EntityWorld.Instance.CreateEntity("Block", "Block", new List<Component>
            {
                new Transform
                {
                    Position = pos,
                },
                new Sprite
                {
                    Texture = AssetLoader.GetTexture("Color"),
                    SourceRect = new Rectangle(50,50,50,50)
                },
                new BoxCollider
                {
                    Size = new Vector2(50, 50),
                    IsStatic = false
                },
            });
        }
        public static void Bullet(Vector2 pos, Vector2 velocity)
        {
            EntityWorld.Instance.CreateEntity("Bullet", "Bullet", new List<Component>
            {
                new Transform
                {
                    Position = pos,  
                },
                new Sprite
                {
                    Texture = AssetLoader.GetTexture("Color"),
                    SourceRect = new Rectangle(0,0,15,15)
                },
                new BoxCollider
                {
                    Size = new Vector2(15,15),
                    IsStatic = false
                },
                new CollisionHandler
                {
                    OnCollision = CollisionLogic.BulletCollision
                },
                new Velocity
                {
                    Value = velocity
                },
                new Bullet()
            });            
        }
        public static void Wall(Vector2 pos)
        {
            EntityWorld.Instance.CreateEntity("Wall", "Wall", new List<Component>
            {
                new Transform
                {
                    Position = pos
                },
                new Sprite
                {
                    Texture = AssetLoader.GetTexture("Color"),
                    SourceRect = new Rectangle(0,0,100,100)
                },
                new BoxCollider
                {
                    Size = new Vector2(100, 100),
                    IsStatic = true,
                }
            });            
        }
        public static void Enemy(Vector2 pos)
        {
            EntityWorld.Instance.CreateEntity("Enemy", "Enemy", new List<Component>
            {
                new Transform
                {
                    Position = pos,
                },
                new Sprite
                {
                    Texture = AssetLoader.GetTexture("Color"),
                    SourceRect = new Rectangle(0,0,50,50)
                },
                new BoxCollider
                {
                    Size = new Vector2(50, 50),
                    IsStatic = false
                },
                new CollisionHandler
                {
                    OnCollision = CollisionLogic.PlayerCollision
                },
                new Health
                {
                    Value = 20f
                },
                new Velocity(),
                new EnemyComponent()
            });               
        }
    
    
    }
}