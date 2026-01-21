using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using ShooterGame.ECS.Systems;

namespace ShooterGame.UI
{
    public class UISystem 
    {

        public static UISystem Instance{get; private set;}
        private List<Control> _controls = new List<Control>();


        public UISystem()
        {
            Instance = this;
        }
        public void Add(Control _control) => _controls.Add(_control);
        public void Remove(Control _control) => _controls.Remove(_control);
        public Control Fint(string _name) => _controls.First(x => x.Name == _name);
        public void Update()
        {
            for (int i = 0; i < _controls.Count; i++)
            {
                _controls[i].Update();
            }            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < _controls.Count; i++)
            {
                _controls[i].Draw(spriteBatch);
            }             
        }
    }
}