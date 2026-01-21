using System;
using System.Collections.Generic;
using System.Linq;

namespace ShooterGame.ECS
{
    public class EntityWorld
    {
        public static EntityWorld Instance{get; private set;}
        private List<Entity> _entities = new List<Entity>();
        private int _nextID = 0;


        public EntityWorld()
        {
            Instance = this;
        }

        private int GetNextID()
        {
            _nextID += 1;
            return _nextID;
        }

        public void CreateEntity(string _name, List<Component> _components)
        {
            this.CreateEntity(_name, "Default", _components);
        }
        public void CreateEntity(string _name, string _tag, List<Component> _components)
        {
            Entity _ent = new Entity();
            _ent.ID = GetNextID();
            _ent.Name = _name;
            _ent.Tag = _tag;

            foreach (var item in _components)
            {
                item.EntityID = _ent.ID;
            }

            _ent.Components = _components;

            _entities.Add(_ent);
        }
        public Entity GetEntityByID(int id)
        {
            return _entities.FirstOrDefault(x => x.ID == id);
        }
        public List<Entity> GetEntitiesByTag(string _tag)
        {
            return _entities.Where(x => x.Tag == _tag).ToList();
        }
        public List<Entity> GetEntitiesWithComponent<T>() where T : Component
        {
            return _entities.Where(e => e.HasComponent<T>()).ToList();
        }
        public List<Entity> GetEntitiesWithComponent<T, T2>()where T : Component where T2 : Component
        {
            return _entities.Where(e => e.HasComponent<T>() && e.HasComponent<T2>()).ToList();
        }
        public List<Entity> GetEntitiesWithComponent<T, T2, T3>()where T : Component where T2 : Component where T3 : Component
        {
            return _entities.Where(e => e.HasComponent<T>() && e.HasComponent<T2>() && e.HasComponent<T3>()).ToList();
        }
        public void DestroyEntity(Entity _ent)
        {
            _entities.Remove(_ent);
        }
        public void Clear()
        {
            _entities.Clear();
            _nextID = 0;
        }
    }
}