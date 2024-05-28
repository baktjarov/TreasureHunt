using System;
using Attributes;
using Gameplay;
using SO;
using StateMachine;
using UnityEngine;
using Zenject;
namespace Characters
{
    public class UnitInfo : MonoBehaviour, IMouseSelectable
    {
        [Inject] public ListOfAllUnits listOfAllUnits;

        [field: SerializeField] public Animator animator { get; private set; }
        [field: SerializeField] public AnimationEvents animationEvents { get; private set; }
        [field: SerializeField] public UnitStateMachineBase unitBase { get; private set; }

        [ReadOnly] public OverlayTile standingTile;
        [ReadOnly] public bool moving;

        [field: SerializeField, ReadOnly] public bool selected;
        public static Action<CharacterInfo> onSelected;

        private void Update()
        {
            SetTileUnderCharacter();
        }

        public virtual void SetSelected(bool isSelected) { }

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

        public void SetTileUnderCharacter()
        {
            OverlayTile tile = GetTileUnderCharacter<OverlayTile>();
            SetStandingTile(tile);
        }

        public T GetTileUnderCharacter<T>()
        {
            Vector2 characterPosition = transform.position;
            Vector2 rayDirection = Vector2.down;

            RaycastHit2D[] hits = Physics2D.RaycastAll(characterPosition, rayDirection);

            T result = default(T);

            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider == null) { continue; }

                if (hit.collider.TryGetComponent<T>(out var component))
                {
                    result = component;
                    break;
                }
            }

            return result;
        }
    }
}