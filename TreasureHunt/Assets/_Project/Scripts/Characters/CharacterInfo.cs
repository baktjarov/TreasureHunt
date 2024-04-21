using Attributes;
using Gameplay;
using System;
using UnityEngine;

namespace Characters
{
    public class CharacterInfo : MonoBehaviour, IMouseSelectable
    {
        private CharacterManager charactersManager;

        public static Action<CharacterInfo> onSelected;

        [field: SerializeField, ReadOnly] public OverlayTile standingTile { get; private set; }
        [field: SerializeField, ReadOnly] public bool selected { get; private set; }

        public void SetStandingTile(OverlayTile tile)
        {
            if (tile == null) { return; }

            standingTile = tile;
        }

        public void SetSelected(bool isSelected)
        {
            if(selected == isSelected) { return; }

            selected = isSelected;
            GetComponent<SpriteRenderer>().color = selected ? Color.green : Color.white;

            if (selected == true)
            {
                foreach (CharacterInfo obj in charactersManager.listOfAllWarriors.moveableObjects)
                {
                    if (obj != this) { obj.SetSelected(false); }
                }

                onSelected?.Invoke(this);
            }
        }
    }
}