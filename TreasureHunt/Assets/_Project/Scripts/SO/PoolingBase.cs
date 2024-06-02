using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    public class PoolingBase<T> : ScriptableObject where T : Component
    {
        [SerializeField] protected T _targetObject;

        [Header("Settings")]
        [SerializeField] protected int _spawnIfPoolIsEmpty;
        [SerializeField] protected string _parentName = typeof(T).Name;

        protected Queue<T> _targetsPool = new Queue<T>();

        protected Transform _parent;

        protected void Spawn(int spawnAmount)
        {
            if (_parent == null)
            {
                _parent = new GameObject(_parentName).transform;
                //DontDestroyOnLoad(_parent);
            }

            for (int i = 0; i < spawnAmount; i++)
            {
                T newObject = Instantiate(_targetObject, Vector3.zero, Quaternion.identity);
                Put(newObject);
            }
        }

        public T Get(Vector2 position)
        {
            _targetsPool.TryDequeue(out T result);

            if (result == null)
            {
                Spawn(_spawnIfPoolIsEmpty);
                result = _targetsPool.Dequeue();
            }

            result.transform.position = position;
            result.gameObject.SetActive(true);
            result.transform.SetParent(null, false);

            return result;
        }

        public void Put(T toPut)
        {
            toPut.transform.position = Vector3.zero;
            toPut.gameObject.SetActive(false);

            toPut.transform.SetParent(_parent, false);

            _targetsPool.Enqueue(toPut);
        }
    }
}