/*using System.Collections;
using SO;
using UnityEngine;

namespace Characters
{
    public class CharacterBase : MonoBehaviour
    {
        [SerializeField] private WarriorPooling _pooling;

        public void Inititlize(WarriorPooling pooling)
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
}*/