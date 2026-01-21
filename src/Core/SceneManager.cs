using System.Collections.Generic;
using System.Linq;
using ShooterGame.ECS;
using ShooterGame.Scenes;

namespace ShooterGame.Core
{
    public class SceneManager
    {
        public static SceneManager Instance{get; private set;}

        private List<Scene> _scenes = new List<Scene>();
        private Scene _activeScene = null;

        public SceneManager()
        {
            Instance = this;
        }
        public void RegisterScene(Scene _scene)
        {
            _scenes.Add(_scene);
        }

        public void LoadScene(string _name)
        {
            Game1.IsPaused = true;

            if(_activeScene != null)
            {
                _activeScene.UnLoad();
            }

            EntityWorld.Instance.Clear();//clear all entities here
            //todo: clear out all of the UI elements here

            _activeScene = _scenes.FirstOrDefault(x => x.Name == _name);

            _activeScene.Load();
        
            Game1.IsPaused = false;
        }

        public void LoadNextScene()
        {
            int index = _scenes.IndexOf(_activeScene);
            index += 1;

            if(index >= _scenes.Count)
            {
                throw new System.Exception($"{this}: LoadNextScene(): This is the last scene!!!");
            }

            LoadScene(_scenes[index].Name);
        }

        public string ActiveSceneName() => _activeScene.Name;
    }
}