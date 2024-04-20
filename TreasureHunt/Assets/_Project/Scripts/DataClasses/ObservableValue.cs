using System;

namespace DataClasses
{
    public class ObservableValue<T>
    {
        public Action<T> onValueChagned;

        private T _value;

        public T value
        {
            get { return _value; }
            set { ChangeValue(value); }
        }

        public void ChangeValue(T value)
        {
            _value = value;
            onValueChagned?.Invoke(_value);
        }
    }
}