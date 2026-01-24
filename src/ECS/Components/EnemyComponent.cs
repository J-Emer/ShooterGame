namespace ShooterGame.ECS.Components
{
    public class EnemyComponent : Component
    {
        public float MoveSpeed{get;set;} = 2f;
        public float Damage{get;set;} = 5f;
        public float AttackRange{get;set;} = 60f;
        public float AttackCoolDownTimer{get;set;} = 5f;
        public float _timer = 0f;
    }
}