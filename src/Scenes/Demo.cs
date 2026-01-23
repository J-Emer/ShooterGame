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
            // EntityFactory.Enemy(new Vector2(800, 600));


            // Panel _panel = new Panel
            // {
            //     Position = new Vector2(100, 100),
            //     Size = new Vector2(400, 400),
            //     Layout = new GridLayout(3, 3),
            //     Padding = 5,
            //     BackgroundColor = Color.Gray
            // };

            // UISystem.Instance.Add(_panel);

            // for (int i = 0; i < 9; i++)
            // {
            //     Slot _slot = new Slot
            //     {
            //         Text = i.ToString(),
            //         Name = $"Slot: {i}",
            //         BackgroundColor = Color.DimGray,
            //         BorderThickness = 2,
            //         BorderColor = Color.Black,
            //         SlotTexture = AssetLoader.GetTexture("Color")
            //     };
            //     _slot.OnClick += SlotClicked;
                
            //     _panel.Children.Add(_slot);
            // }


        }

        private void SlotClicked(Slot slot, int amount)
        {
            Console.WriteLine($"{slot.Name} | {amount}");
        }
    }
}