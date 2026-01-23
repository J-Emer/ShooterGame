using System.Linq;
using GameConsole.GConsole;
using ShooterGame.Core;

namespace ShooterGame.Commands
{
    public class SceneCommand : ICommand
    {
        public string Name => "scene";

        public string Description => "Jumps to a given scene";

        public string Usage => "scene <scenename>";

        public void Load(CommandContext Context)
        {
        }
        public void Execute(CommandContext Context)
        {
            if(Context.Arguments.Length == 0)
            {
                Context.WriteLine($"Too few argument: {Usage}");
            }

            string _raw = Context.Arguments[0];
            string _name = char.ToUpper(_raw[0]) + _raw.Substring(1);

            SceneManager.Instance.LoadScene(_name);

            Context.WriteLine($"Loaded Scene: {_name}");
        }

    }
}