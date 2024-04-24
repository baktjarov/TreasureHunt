using Attributes;
using Gameplay;
using Zenject;
using System;
using UnityEngine;

namespace Characters
{
    public class CharacterInfo : MonoBehaviour, IMouseSelectable
    {
        [Inject] private CharacterManager characterManager;

        public static Action<CharacterInfo> onSelected;
        
        [field: SerializeField] public Animator _animator {get; private set;}
        [field: SerializeField, ReadOnly] public OverlayTile standingTile { get; private set; }
        [field: SerializeField, ReadOnly] public bool selected { get; private set; }

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
    }
}