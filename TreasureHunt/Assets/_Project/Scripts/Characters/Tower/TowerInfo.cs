using System;
using Attributes;
using Gameplay;
using SO;
using UnityEngine;
using Zenject;

namespace Characters
{
    public class TowerInfo : MonoBehaviour
    {
        [Inject] public ListOfAllTowers listOfAllTowers;

        [ReadOnly] public OverlayTile standingTile;

        private void Awake()
        {
            SetTileUnderCharacter();
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