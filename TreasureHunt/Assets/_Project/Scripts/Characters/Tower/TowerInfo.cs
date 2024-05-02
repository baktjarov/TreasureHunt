using System;
using Attributes;
using Gameplay;
using SO;
using UnityEngine;
using Zenject;

namespace Characters
{
    public class TowerInfo : MonoBehaviour, IMouseSelectable
    {
        [Inject] public ListOfAllTowers listOfAllTowers;

        [field: SerializeField, ReadOnly] public bool selected;
        public static Action<TowerInfo> onSelected;

        public void SetSelected(bool isSelected)
        {
            if (selected == isSelected) { return; }

            selected = isSelected;

            if (selected == true)
            {
                foreach (TowerInfo obj in listOfAllTowers.towerObjects)
                {
                    if (obj != this) { obj.SetSelected(false); }
                }

                onSelected?.Invoke(this);
            }
        }
    }
}