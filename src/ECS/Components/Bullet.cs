namespace ShooterGame.ECS.Components
{
    public class Bullet : Component
    {
        public float Damage{get;set;} = 10f;
        public float LifeTimer{get;set;} = 2f;
    }
}