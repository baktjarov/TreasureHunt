using System.Collections;
using Attributes;
using Gameplay;
using SO;
using UnityEngine;

namespace Characters
{
    public class EnemyInfo : MonoBehaviour
    {
        [field: SerializeField] public Animator animator { get; private set; }
        [field: SerializeField] public AnimationEvents animationEvents { get; private set; }

        [field: SerializeField, ReadOnly] public OverlayTile standingTile { get; private set; }
        [field: SerializeField, ReadOnly] public bool moving { get; private set; }

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
            yield return null;
            _pooling.Put(this);
        }

        public void SetStandingTile(OverlayTile tile)
        {
            if (tile == null) { return; }

            standingTile = tile;
        }

        public void SetMoving(bool isMoving)
        {
            if (moving == isMoving) { return; }
            moving = isMoving;
        }
    }
}