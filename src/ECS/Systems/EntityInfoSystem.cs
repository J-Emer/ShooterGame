using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShooterGame.Core;
using ShooterGame.ECS.Components;

namespace ShooterGame.ECS.Systems
{
    public class EntityInfoSystem : DrawSystem
    {
        public override void Draw(SpriteBatch _spritebatch)
        {
            if(!Game1.ShowDebug){return;}

            foreach (var entity in EntityWorld.Instance.GetEntitiesWithComponent<Transform>())
            {
                Transform _tran = entity.GetComponent<Transform>();

                _spritebatch.DrawString(AssetLoader.DefaultFont, $"ID: {entity.ID}", _tran.Position - new Vector2(0, 100), Color.White);
                _spritebatch.DrawString(AssetLoader.DefaultFont, $"Name: {entity.Name}", _tran.Position - new Vector2(0, 80), Color.White);
                _spritebatch.DrawString(AssetLoader.DefaultFont, $"Tag: {entity.Tag}", _tran.Position - new Vector2(0, 60), Color.White);
                _spritebatch.DrawString(AssetLoader.DefaultFont, $"Position: {_tran.Position}", _tran.Position - new Vector2(0, 40), Color.White);
                _spritebatch.DrawString(AssetLoader.DefaultFont, $"Components: {entity.Components.Count}", _tran.Position - new Vector2(0, 20), Color.White);

            }
        }
    }
}