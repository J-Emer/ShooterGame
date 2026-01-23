using System;
using GameConsole.GConsole;
using Microsoft.Xna.Framework;
using ShooterGame.StaticHelpers;

namespace ShooterGame.Commands
{
    public class Spawn : ICommand
    {
        public string Name => "spawn";

        public string Description => "Spawns in an entity from the Entity.Factory";

        public string Usage => "spawn <entity> <x> <y>";

        public void Load(CommandContext Context)
        {

        }
        public void Execute(CommandContext Context)
        {
            if(Context.Arguments.Length < 2)
            {
                Context.WriteLine($"Spawn: too few arguments. Usage: {Usage}");
                return;
            }

            string _entity = Context.Arguments[0];
            string _x = Context.Arguments[1];
            string _y = Context.Arguments[2];

            Context.WriteLine($"Spawning {_entity} | X: {_x}, Y: {_y}");


            switch (_entity)
            {
                case "enemy":
                    EntityFactory.Enemy(new Vector2(int.Parse(_x), int.Parse(_y)));
                    break;
                case "wall":
                    EntityFactory.Wall(new Vector2(int.Parse(_x), int.Parse(_y)));
                    break;
                case "block":
                    EntityFactory.Block(new Vector2(int.Parse(_x), int.Parse(_y)));
                    break;                    
                default:
                    Context.WriteLine($"unable to spaawn entity: {_entity}");
                    break;
            }

        }

    }
}