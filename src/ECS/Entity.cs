using System.Collections.Generic;
using System.Linq;

namespace ShooterGame.ECS
{
    public class Entity
    {
        public int ID{get; set;} = -1;
        public string Name{get;set;} = "Entity";
        public string Tag{get;set;} = "Default";
        public List<Component> Components = new List<Component>();
    
    

        public bool HasComponent<T>() where T : Component
        {
            for (int i = 0; i < Components.Count; i++)
            {
                if (Components[i] is T)
                    return true;
            }

            return false;
        }

        public T GetComponent<T>() where T : Component
        {
            for (int i = 0; i < Components.Count; i++)
            {
                if (Components[i] is T component)
                    return component;
            }

            return null;
        }
        public void Destroy()
        {
            EntityWorld.Instance.DestroyEntity(this);
        }
        public override string ToString()
        {
            return $"Entity: Name: {Name} | Tag: {Tag} | ID: {ID} | Component Count: {Components.Count}";
        }

    }
}