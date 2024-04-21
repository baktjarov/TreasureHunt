using System;
using UnityEngine;

namespace Gameplay
{
    public class OverlayTile : MonoBehaviour, IMouseSelectable
    {
        public static Action<OverlayTile> onSelected;

        public int G;
        public int H;
        public int F { get { return G + H; } }


        public OverlayTile Previous;
        public Vector3Int gridLocation;

        public void SetSelected(bool isSelected)
        {
            if (isSelected) { onSelected?.Invoke(this); }
        }
    }
}
