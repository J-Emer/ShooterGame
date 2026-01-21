using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShooterGame.Core;

namespace ShooterGame.UI
{
    public class ToggleButton : Control
    {
        public int Padding{get;set;} = 5;
        private Rectangle _thumbRect = new Rectangle();
        public Color ActiveColor{get;set;} = Color.Blue;
        public Color InActiveColor{get;set;} = Color.DarkGray;
        private Color _thumRectColor;
        public bool Value{get; private set;} = true;
        public Action<bool> OnValueChanged;


        public ToggleButton() : base()
        {
            Size = new Vector2(150, 50);
        }
        protected override void AfterDirty()
        {
            _thumRectColor = ActiveColor;

            float width = (Size.X / 2) - Padding;
            float height = Size.Y - (Padding * 2);
            float y = Position.Y + Padding;
            float x = Position.X + Padding;

            if(!Value)
            {
                x = Position.X + Padding + width;            
                _thumRectColor = InActiveColor;
            }

            _thumbRect = new Rectangle(
                (int)x,
                (int)y,
                (int)width,
                (int)height
            );
        }

        public override void Update()
        {
            base.Update();

            if(_thumbRect.Contains(Input.MousePos) && Input.GetMouseButtonDown(Input.MouseButton.Left))
            {
                Value = !Value;
                AfterDirty(); //this is a bad way to set the _thumRect.x position
                OnValueChanged?.Invoke(Value);
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.Draw(BackgroundTexture, _thumbRect, _thumRectColor);
        }
    }
}