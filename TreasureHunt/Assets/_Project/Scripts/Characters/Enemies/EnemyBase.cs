using System.Collections;
using SO;
using UnityEngine;

namespace Characters
{
    public class EnemyBase : MonoBehaviour
    {
        [SerializeField] private TorchGoblinPooling _pooling;

        public void Inititlize(TorchGoblinPooling pooling)
        {
            _pooling = pooling;
        }

        private void OnEnable()
        {
            StartCoroutine(Put_Coroutine());
        }

        private void OnDisable()
        {
            StopCoroutine(Put_Coroutine());
        }

        private IEnumerator Put_Coroutine()
        {
            _pooling.Put(this);

            yield return null;
        }
    }
}