using Attributes;
using Gameplay;
using UnityEngine;

namespace Characters
{
    public class UnitInfo : MonoBehaviour
    {
        [field: SerializeField] public Animator animator { get; private set; }
        [field: SerializeField] public AnimationEvents animationEvents { get; private set; }

        [ReadOnly] public OverlayTile standingTile;
        [ReadOnly] public bool moving;

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