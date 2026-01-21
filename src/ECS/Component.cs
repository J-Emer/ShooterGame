namespace ShooterGame.ECS
{
    public abstract class Component
    {
        public int EntityID{get;set;}
        private Entity _entity = null;
        public Entity Entity
        {
            get
            {
                if(_entity == null)
                {
                    _entity = EntityWorld.Instance.GetEntityByID(EntityID);
                }

                return _entity;
            }
        }
    }
}