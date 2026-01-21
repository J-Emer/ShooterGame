using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShooterGame.Core;

namespace ShooterGame.UI
{
    public class Button : Control
    {
        public SpriteFont Font{get;set;} = AssetLoader.DefaultFont;
        public string Text{get;set;} = "Button";
        public Color TextColor{get;set;} = Color.Black;
        private Vector2 _textPos = Vector2.Zero;
        public Color HighlightColor{get;set;} = Color.White;
        public Color NormalColor{get;set;} = Color.LightGray;
        public Vector2 ExpandAmount = new Vector2(10, 10);
        public Action OnClick;


        public Button() : base()
        {
            Size = new Vector2(150, 30);
        }
        protected override void AfterDirty()
        {
            base.AfterDirty();

                Vector2 textSize = Font.MeasureString(Text);

                _textPos = new Vector2(
                    SourceRectangle.X + (SourceRectangle.Width  - textSize.X) * 0.5f,
                    SourceRectangle.Y + (SourceRectangle.Height - textSize.Y) * 0.5f
                );
        }
        protected override void MouseClick()
        {
            OnClick?.Invoke();
        }
        protected override void MouseEnter()
        {
            BackgroundColor = HighlightColor;
            Position -= ExpandAmount * 0.5f;
            Size += ExpandAmount;
        }
        protected override void MouseExit()
        {
            BackgroundColor = NormalColor;
            Position += ExpandAmount * 0.5f;
            Size -= ExpandAmount;            
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.DrawString(Font, Text, _textPos, TextColor);
        }
    }
}