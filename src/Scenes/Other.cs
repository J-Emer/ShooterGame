using System;
using Microsoft.Xna.Framework;
using ShooterGame.StaticHelpers;

namespace ShooterGame.Scenes
{
    public class Other : Scene
    {
        public Other(string _name) : base(_name)
        {
        }

        public override void Load()
        {
            Console.WriteLine($"{Name}: Load()");

            Camera.Instance.Position = Vector2.Zero;
            EntityFactory.Player(Vector2.Zero);
        }
    }
}