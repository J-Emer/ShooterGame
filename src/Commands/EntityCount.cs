using GameConsole.GConsole;
using ShooterGame.ECS;

namespace ShooterGame.Commands
{
    public class EntityCount : ICommand
    {
        public string Name => "EntityCount";

        public string Description => "Displays total number of Entities in the active scene";

        public string Usage => "entitycount";

        public void Load(CommandContext Context)
        {
            
        }

        public void Execute(CommandContext Context)
        {
            Context.WriteLine($"Entity Count: {EntityWorld.Instance.EntityCount}");
        }

    }
}