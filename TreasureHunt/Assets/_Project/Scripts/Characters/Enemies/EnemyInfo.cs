using Attributes;
using Gameplay;
using UnityEngine;

namespace Characters
{
    public class EnemyInfo : MonoBehaviour
    {
        [field: SerializeField] public Animator animator { get; private set; }
        [field: SerializeField] public AnimationEvents animationEvents { get; private set; }

        [field: SerializeField, ReadOnly] public OverlayTile standingTile { get; private set; }
        [field: SerializeField, ReadOnly] public bool moving { get; private set; }

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