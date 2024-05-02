using Gameplay;
using UnityEngine;

namespace Characters
{
    public class EnemyInfo : UnitInfo
    {
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