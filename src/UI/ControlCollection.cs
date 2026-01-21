using System;
using System.Collections.Generic;
using System.Linq;

namespace ShooterGame.UI
{
    public class ControlCollection
    {
        private List<Control> _controls = new List<Control>();
        public Action OnControlsChanged;
        
        public void Add(Control _control)
        {
            _controls.Add(_control);
            OnControlsChanged?.Invoke();
        }
        public void Remove(Control _control)
        {
            _controls.Remove(_control);
            OnControlsChanged?.Invoke();
        }

        public Control Find(string _name)
        {
            return _controls.Find(x => x.Name == _name);
        }
        public T Find<T>(string _name) where T : Control
        {
            return (T)_controls.Find(x => x.Name == _name);
        }
        public IReadOnlyList<Control> Controls => _controls.AsReadOnly();
    }
}