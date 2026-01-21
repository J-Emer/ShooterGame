using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShooterGame.Core;
using System;
using System.Text;

namespace ShooterGame.UI
{
    public class Textbox : Control
    {
        public SpriteFont Font { get; set; } = AssetLoader.DefaultFont;
        public Color TextColor { get; set; } = Color.Black;
        public Vector2 Padding { get; set; } = new Vector2(6, 4);
        public int MaxLength { get; set; } = 256;

        public bool IsFocused { get; private set; }

        public string Text
        {
            get
            {
                return _text.ToString();
            }
            set
            {
                _text.Clear();
                _text.Append(value);
                _caretIndex = _text.Length;
                NotifyTextChanged(); //---should this be here? 
            }
        }
        public StringBuilder _text { get; private set; } = new StringBuilder();
        private int _caretIndex;

        private float _caretTimer;
        private bool _showCaret = true;
        private Vector2 textPos;

        public event Action<string> OnTextChanged;


        public Textbox()
        {
            BackgroundColor = Color.White;
            Size = new Vector2(150, 30);
        }
        protected override void AfterDirty()
        {
            textPos = new Vector2(
                SourceRectangle.X + Padding.X,
                SourceRectangle.Y + Padding.Y
            );
        }
        protected override void MouseClick()
        {
            IsFocused = true;
        }

        public override void Update()
        {
            base.Update();

            if (!IsActive || !IsFocused)
                return;

            HandleKeyboard();
            UpdateCaret();
        }

        private void HandleKeyboard()
        {
            foreach (char c in Input.InputString)
            {
                if (_text.Length >= MaxLength)
                    break;

                _text.Insert(_caretIndex, c);
                _caretIndex++;

                NotifyTextChanged();
            }

            if (Input.GetKeyDown(Keys.Back))
            {
                if (_caretIndex > 0)
                {
                    _text.Remove(_caretIndex - 1, 1);
                    _caretIndex--;
                    NotifyTextChanged();                    
                }
            }

            if (Input.GetKeyDown(Keys.Delete))
            {
                if (_caretIndex < _text.Length)
                {
                    _text.Remove(_caretIndex, 1);
                    NotifyTextChanged();                    
                }
            }

            if(Input.GetKeyDown(Keys.Enter))
            {
                IsFocused = false;
            }

            if(Input.GetKeyDown(Keys.Left))
            {
                _caretIndex = Math.Max(0, _caretIndex - 1);
            }
            if(Input.GetKeyDown(Keys.Right))
            {
                _caretIndex = Math.Min(_text.Length, _caretIndex + 1);
            }            
        }

        private void UpdateCaret()
        {
            _caretTimer += Time.DeltaTime;
            if (_caretTimer >= 0.5f)
            {
                _caretTimer = 0f;
                _showCaret = !_showCaret;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);


            // spriteBatch.Draw(BackgroundTexture, SourceRectangle, BackgroundColor);


            spriteBatch.DrawString(Font, _text, textPos, TextColor);
            DrawCaret(spriteBatch, textPos);
        }

        private void DrawCaret(SpriteBatch spriteBatch, Vector2 textPos)
        {
            if (!IsFocused || !_showCaret)
                return;

            string beforeCaret = _text.ToString().Substring(0, _caretIndex);
            Vector2 size = Font.MeasureString(beforeCaret);

            Rectangle caretRect = new Rectangle(
                (int)(textPos.X + size.X),
                (int)textPos.Y,
                1,
                Font.LineSpacing
            );

            spriteBatch.Draw(BackgroundTexture, caretRect, TextColor);
        }
        private void NotifyTextChanged()
        {
            OnTextChanged?.Invoke(_text.ToString());
        }


    }
}
