using Attributes;
using Gameplay;
using UnityEngine;

namespace Characters
{
    public class SpawnController : MonoBehaviour
    {
        [Header("Debug")]
        [SerializeField, ReadOnly] private TowerInfo _currentTower;

        private void OnEnable()
        {
            TowerInfo.onSelected += OnTowerClicked;
        }

        private void OnDisable()
        {
            TowerInfo.onSelected -= OnTowerClicked;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                IMouseSelectable selectable = GetMouseSelectableOfType<IMouseSelectable>();

                if (selectable is TowerInfo towerInfo)
                {
                    if (_currentTower == null) { towerInfo?.SetSelected(true); }
                    else
                    {
                        towerInfo?.SetSelected(false);
                        _currentTower = null;
                    }
                }
            }
        }

        private T GetMouseSelectableOfType<T>()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos, Vector2.zero);

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

        private void OnTowerClicked(TowerInfo tower)
        {
            if (_currentTower != null) { return; }

            _currentTower = tower;
        }
    }
}