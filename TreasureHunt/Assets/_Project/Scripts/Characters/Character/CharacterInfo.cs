using Attributes;
using Gameplay;
using Zenject;
using System;
using UnityEngine;
using SO;
using System.Collections;

namespace Characters
{
    public class CharacterInfo : MonoBehaviour, IMouseSelectable
    {
        [Inject] private CharacterManager characterManager;

        public static Action<CharacterInfo> onSelected;

        [field: SerializeField] public Animator animator { get; private set; }
        [field: SerializeField] public AnimationEvents animationEvents { get; private set; }

        [field: SerializeField, ReadOnly] public OverlayTile standingTile { get; private set; }
        [field: SerializeField, ReadOnly] public bool selected { get; private set; }
        [field: SerializeField, ReadOnly] public bool moving { get; private set; }

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
            yield return null;
            _pooling.Put(this);
        }

        public void SetStandingTile(OverlayTile tile)
        {
            if (tile == null) { return; }

            standingTile = tile;
        }

        public void SetSelected(bool isSelected)
        {
            if (selected == isSelected) { return; }

            selected = isSelected;

            if (selected == true)
            {
                foreach (CharacterInfo obj in characterManager.listOfAllWarriors.moveableObjects)
                {
                    if (obj != this) { obj.SetSelected(false); }
                }

                onSelected?.Invoke(this);
            }
        }

        public void SetMoving(bool isMoving)
        {
            if (moving == isMoving) { return; }
            moving = isMoving;
        }
    }
}