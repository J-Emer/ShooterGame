using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShooterGame.Core;
using ShooterGame.ECS.Components;

namespace ShooterGame.ECS.Systems
{
    public class ColliderDebugSystem : DrawSystem
    {
        private int borderThickness = 2;
        private Color borderColor = Color.White;


        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!Game1.ShowDebug)
            {
                return;
            }

            foreach (var entity in EntityWorld.Instance.GetEntitiesWithComponent<BoxCollider>())
            {
                var collider = entity.GetComponent<BoxCollider>();

                DrawRectangleOutline(spriteBatch, collider.Bounds, borderColor, borderThickness);
            }
        }

        private void DrawRectangleOutline(SpriteBatch spriteBatch, Rectangle rect, Color color, int thickness)
        {
            // Top
            spriteBatch.Draw(AssetLoader.GetPixel(), new Rectangle(rect.Left, rect.Top, rect.Width, thickness), color);
            // Bottom
            spriteBatch.Draw(AssetLoader.GetPixel(), new Rectangle(rect.Left, rect.Bottom - thickness, rect.Width, thickness), color);
            // Left
            spriteBatch.Draw(AssetLoader.GetPixel(), new Rectangle(rect.Left, rect.Top, thickness, rect.Height), color);
            // Right
            spriteBatch.Draw(AssetLoader.GetPixel(), new Rectangle(rect.Right - thickness, rect.Top, thickness, rect.Height), color);
        }
    }
}
