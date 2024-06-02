using Attributes;
using Gameplay;
using UnityEngine;

namespace Characters
{
    public class TowerInfo : MonoBehaviour
    {
        [ReadOnly] public OverlayTile standingTile;

        private void Update()
        {
            if (standingTile == null)
            {
                SetTileUnderCharacter();
            }
        }

        public void SetStandingTile(OverlayTile tile)
        {
            if (tile == null) { return; }

            standingTile = tile;
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