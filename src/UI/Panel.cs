using Microsoft.Xna.Framework.Graphics;

namespace ShooterGame.UI
{
    public class Panel : Control
    {
        public ControlCollection Children{get; private set;} = new ControlCollection();
        public int Padding{get;set;} = 5;
        public Layout Layout{get;set;} = new HorizontalLayout();


        public Panel() : base()
        {
            Children.OnControlsChanged += AfterDirty;
        }
        protected override void AfterDirty()
        {
            base.AfterDirty();

            Layout.DoLayout(SourceRectangle, Children.Controls, Padding);
        }

        public override void Update()
        {
            base.Update();

            for (int i = 0; i < Children.Controls.Count; i++)
            {
                Children.Controls[i].Update();
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            for (int i = 0; i < Children.Controls.Count; i++)
            {
                Children.Controls[i].Draw(spriteBatch);
            }            
        }
    }

}