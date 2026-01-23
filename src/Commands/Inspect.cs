using GameConsole.GConsole;
using ShooterGame.ECS;

namespace ShooterGame.Commands
{
    public class Inspect : ICommand
    {
        public string Name => "inspect";

        public string Description => "Displays an entities components";

        public string Usage => "inspect <entity.id>";

        public void Load(CommandContext Context)
        {
        }
        public void Execute(CommandContext Context)
        {
            if(Context.Arguments.Length < 1)
            {
                Context.WriteLine($"Too few arguments | Usage: {Usage}");
            }

            int _id = int.Parse(Context.Arguments[0]);

            Entity _ent = EntityWorld.Instance.GetEntityByID(_id);

            Context.WriteLine("Inspecting Entity");
            Context.WriteLine($"Name: {_ent.Name}");
            Context.WriteLine($"Tag: {_ent.Tag}");
            Context.WriteLine("Components: ");
            foreach (var item in _ent.Components)
            {
                Context.WriteLine($"        {item.GetType().Name}");
            }

        }
    }
}