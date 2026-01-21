using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShooterGame.Core;

namespace ShooterGame.UI
{
    public class Control
    {
        public string Name{get;set;} = "Control";
        public bool IsActive{get;set;} = true;
        public Vector2 Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                HandleDirty();
            }
        }
        private Vector2 _position;
        public Vector2 Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
                HandleDirty();
            }
        }
        public Vector2 _size;
        public Rectangle SourceRectangle{get; private set;} = new Rectangle();
        public Texture2D BackgroundTexture{get;set;} = AssetLoader.GetPixel();
        private bool _pCursor;
        private bool _cCursor;
        public Color BackgroundColor{get;set;} = Color.White;
        public Color BorderColor { get; set; } = Color.Black;
        public int BorderThickness { get; set; } = 1;
        public bool ShowBorder{get;set;} = true;
        public object UserData{get;set;} = null;

        private void HandleDirty()
        {
            SourceRectangle = new Rectangle(
                (int)_position.X,
                (int)_position.Y,
                (int)_size.X,
                (int)_size.Y
            );

            AfterDirty();
        }

        protected virtual void AfterDirty(){}

        public virtual void Update()
        {
            if(!IsActive){return;}

            _pCursor = _cCursor;
            _cCursor = SourceRectangle.Contains(Input.MousePos);

            //enter
            if(!_pCursor && _cCursor)
            {
                MouseEnter();
            }
            //click
            if(_cCursor && Input.GetMouseButtonDown(Input.MouseButton.Left))
            {
                MouseClick();
            }
            //exit
            if(_pCursor && !_cCursor)
            {
                MouseExit();
            }            
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if(!IsActive){return;}
            
            spriteBatch.Draw(BackgroundTexture, SourceRectangle, BackgroundColor);


            if (BorderThickness <= 0 || !ShowBorder)
                return;

            // Top
            spriteBatch.Draw(BackgroundTexture, new Rectangle(
                SourceRectangle.X,
                SourceRectangle.Y,
                SourceRectangle.Width,
                BorderThickness
            ), BorderColor);

            // Bottom
            spriteBatch.Draw(BackgroundTexture, new Rectangle(
                SourceRectangle.X,
                SourceRectangle.Bottom - BorderThickness,
                SourceRectangle.Width,
                BorderThickness
            ), BorderColor);

            // Left
            spriteBatch.Draw(BackgroundTexture, new Rectangle(
                SourceRectangle.X,
                SourceRectangle.Y,
                BorderThickness,
                SourceRectangle.Height
            ), BorderColor);

            // Right
            spriteBatch.Draw(BackgroundTexture, new Rectangle(
                SourceRectangle.Right - BorderThickness,
                SourceRectangle.Y,
                BorderThickness,
                SourceRectangle.Height
            ), BorderColor);            
        }

        protected virtual void MouseEnter(){}
        protected virtual void MouseExit(){}
        protected virtual void MouseClick(){}

    }
}