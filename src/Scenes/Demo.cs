using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using ShooterGame.Core;
using ShooterGame.ECS;
using ShooterGame.ECS.Components;
using ShooterGame.Particles;
using ShooterGame.StaticHelpers;
using ShooterGame.UI;

namespace ShooterGame.Scenes
{
    public class Demo : Scene
    {
        public Demo(string _name) : base(_name)
        {
        }

        public override void Load()
        {
            Console.WriteLine($"{Name}: Load()");

            EntityFactory.Player(new Vector2(50, 50));
            // EntityFactory.Block(new Vector2(200, 200));
            // EntityFactory.Wall(new Vector2(500, 500));
            EntityFactory.Enemy(new Vector2(800, 600));


            HealthBar _playerHealthBar = new HealthBar
            {
                Name = "playerhealthbar",
                Position = new Vector2(10, 10),
                Size = new Vector2(300, 30),
                MaxValue = 10,
                Value = 10,
                BorderColor = Color.White
            };
            UISystem.Instance.Add(_playerHealthBar);

        }

    }
}