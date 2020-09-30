using System;

namespace Game.Models
{
    
    /// <summary>
    /// Свойство, на изменение которого можно подписаться.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ContextProperty<T>
    {

        private T _value;
        
        public T Value
        {
            get { return _value; }
            set
            {
                var old = _value;
                _value = value;
                OnChanged?.Invoke(old, _value);
            }
        }

        public event Action<T, T> OnChanged;

        public static implicit operator T(ContextProperty<T> prop) => prop.Value;
        
        
        public ContextProperty(T initValue = default)
        {
            _value = initValue;
        }

    }
}
