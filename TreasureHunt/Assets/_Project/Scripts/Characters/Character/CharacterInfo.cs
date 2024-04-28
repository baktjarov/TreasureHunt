using System;
using Attributes;
using Gameplay;
using SO;
using UnityEngine;
using Zenject;

namespace Characters
{
    public class CharacterInfo : UnitInfo, IMouseSelectable
    {
        [Inject] public ListOfAllUnits listOfAllUnits;

        public static Action<CharacterInfo> onSelected;
        [field: SerializeField, ReadOnly] public bool selected { get; private set; }

        public void SetSelected(bool isSelected)
        {
            if (selected == isSelected) { return; }

            selected = isSelected;

            if (selected == true)
            {
                foreach (CharacterInfo obj in listOfAllUnits.moveableObjects)
                {
                    if (obj != this) { obj.SetSelected(false); }
                }

                onSelected?.Invoke(this);
            }
        }
    }
}