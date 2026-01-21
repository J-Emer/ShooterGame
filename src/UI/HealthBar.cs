using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShooterGame.Core;

namespace ShooterGame.UI
{
    public class HealthBar : Control
    {
        public float Value { get; set; } = 100f;
        public float MaxValue { get; set; } = 100f;

        public Color FillColor { get; set; } = Color.Red;
        public Color BackgroundFillColor { get; set; } = new Color(50, 50, 50);

        public bool ShowText { get; set; } = true;
        public SpriteFont Font { get; set; } = AssetLoader.DefaultFont;
        public Color TextColor { get; set; } = Color.White;

        public HealthBar()
        {
            Size = new Vector2(200, 25);
            BackgroundColor = BackgroundFillColor;
            BorderColor = Color.Black;
            BorderThickness = 2;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            // Draw fill based on CurrentValue / MaxValue
            float percent = MathHelper.Clamp(Value / MaxValue, 0f, 1f);
            int fillWidth = (int)((SourceRectangle.Width - 2 * BorderThickness) * percent);

            if (fillWidth > 0)
            {
                Rectangle fillRect = new Rectangle(
                    SourceRectangle.X + BorderThickness,
                    SourceRectangle.Y + BorderThickness,
                    fillWidth,
                    SourceRectangle.Height - 2 * BorderThickness
                );

                spriteBatch.Draw(BackgroundTexture, fillRect, FillColor);
            }


            // Draw optional text
            if (ShowText && Font != null)
            {
                string text = $"{(int)Value}/{(int)MaxValue}";
                Vector2 textSize = Font.MeasureString(text);
                Vector2 textPos = new Vector2(
                    SourceRectangle.Center.X - textSize.X / 2,
                    SourceRectangle.Center.Y - textSize.Y / 2
                );

                spriteBatch.DrawString(Font, text, textPos, TextColor);
            }
        }
    }
}
