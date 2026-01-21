namespace ShooterGame.Scenes
{
    public abstract class Scene
    {
        public string Name{get; private set;}

        public Scene(string _name)
        {
            Name = _name;
        }

        public abstract void Load();
        public virtual void UnLoad(){}
    }
}