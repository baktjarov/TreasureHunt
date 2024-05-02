using System;
using Attributes;
using Gameplay;
using SO;
using UnityEngine;
using Zenject;
namespace Characters
{
    public class UnitInfo : MonoBehaviour, IMouseSelectable
    {
        [Inject] public ListOfAllUnits listOfAllUnits;

        [field: SerializeField] public Animator animator { get; private set; }
        [field: SerializeField] public AnimationEvents animationEvents { get; private set; }

        [ReadOnly] public OverlayTile standingTile;
        [ReadOnly] public bool moving;

        [field: SerializeField, ReadOnly] public bool selected;
        public static Action<CharacterInfo> onSelected;

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
    }
}