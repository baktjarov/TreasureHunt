using System;

namespace DataClasses
{
    public class Signal
    {
        public Action signal;

        public void AddListener(Action listener)
        {
            signal -= listener;
            signal += listener;
        }

        public void RemoveListener(Action listener)
        {
            signal -= listener;
        }

        public void Invoke()
        {
            signal?.Invoke();
        }
    }

    public class Signal<T>
    {
        public Action<T> signal;

        public void AddListener(Action<T> listener)
        {
            signal -= listener;
            signal += listener;
        }

        public void RemoveListener(Action<T> listener)
        {
            signal -= listener;
        }

        public void Invoke(T obj)
        {
            signal?.Invoke(obj);
        }
    }
}