

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShooterGame.Core;

namespace ShooterGame.UI
{
    public class Slot : Control
    {
        public SpriteFont Font{get;set;} = AssetLoader.DefaultFont;
        public string Text{get;set;} = "0";
        private Vector2 _textPos = Vector2.Zero;
        public Color TextColor{get;set;} = Color.Black;
        public Action<Slot, int> OnClick;
        public Texture2D SlotTexture{get;set;} = null;
        private Rectangle _slotTextureRect;
        public int Padding{get;set;} = 5;

        public Slot() : base()
        {
            Size = new Vector2(50, 50);
            ShowBorder = false;
        }
        protected override void MouseClick()
        {
            OnClick?.Invoke(this, int.Parse(Text));
        }
        protected override void MouseEnter()
        {
            ShowBorder = true;
        }
        protected override void MouseExit()
        {
            ShowBorder = false;
        }
        protected override void AfterDirty()
        {
            base.AfterDirty();

            float x = SourceRectangle.Left + 5;
            float y = SourceRectangle.Bottom - 25;

            _textPos = new Vector2(x,y);

            int xPos = SourceRectangle.X + Padding;
            int yPos = SourceRectangle.Y + Padding;
            int width = SourceRectangle.Width - (Padding * 2);
            int height = SourceRectangle.Height - (Padding * 2);

            _slotTextureRect = new Rectangle(xPos,yPos,width,height);

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            if(SlotTexture == null)
            {
                return;
            }

            spriteBatch.Draw(SlotTexture, _slotTextureRect, Color.White);

            spriteBatch.DrawString(Font, Text, _textPos, TextColor);
        }
    }
}