using Microsoft.Xna.Framework.Graphics;

namespace ShooterGame.ECS.Systems
{
    public abstract class System
    {
        
    }

    public abstract class UpdateSystem : System
    {
        public abstract void Update();
    }
    public abstract class DrawSystem : System
    {
        public abstract void Draw(SpriteBatch _spritebatch);
    }
}