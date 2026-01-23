using System;
using GameConsole.GConsole;
using Microsoft.Xna.Framework;
using ShooterGame.StaticHelpers;

namespace ShooterGame.Commands
{
    public class Debug : ICommand
    {
        public string Name => "debug";

        public string Description => "toggles the Game1.ShowDebug";

        public string Usage => "debug";

        public void Load(CommandContext Context)
        {

        }
        public void Execute(CommandContext Context)
        {
            Game1.ShowDebug = !Game1.ShowDebug;

            Context.WriteLine($"Show Debug: {Game1.ShowDebug}");
        }

    }
}