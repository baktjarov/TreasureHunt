using Attributes;
using Gameplay;
using Mechanics;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    public class MoveController : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _speed;

        [Header("Debug")]
        [SerializeField, ReadOnly] private CharacterInfo _currentCharacter;
        [SerializeField, ReadOnly] private bool _canSetPathForCharacter = false;

        private List<OverlayTile> _path;
        private OverlayTile _currentTile;

        private PathFinder _pathFinder;
        private MoveMechanic _moveMechanic;

        private void Awake()
        {
            _pathFinder = new PathFinder();
            _moveMechanic = new MoveMechanic();
            _path = new List<OverlayTile>();
        }

        private void OnEnable()
        {
            CharacterInfo.onSelected += OnCharacterClicked;
            OverlayTile.onSelected += OnTileClicked;
        }

        private void OnDisable()
        {
            CharacterInfo.onSelected -= OnCharacterClicked;
            OverlayTile.onSelected -= OnTileClicked;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                IMouseSelectable selectable = GetMouseSelectableOfType<IMouseSelectable>();

                if (selectable is CharacterInfo characterInfo)
                {
                    if (_currentCharacter == null) { characterInfo?.SetSelected(true); }
                }
                else if (selectable is OverlayTile overlayTile)
                {
                    overlayTile?.SetSelected(true);
                }
            }

            if (_path.Count > 0)
            {
                _moveMechanic.MoveAlongPath(_path, _currentCharacter, _speed, _currentCharacter.unitBase);
                ResetCharacter();
            }
        }

        private void ResetCharacter()
        {
            if (_path.Count == 0)
            {
                _currentCharacter = null;
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

        private void OnCharacterClicked(CharacterInfo character)
        {
            if (_currentCharacter != null) { return; }

            _currentCharacter = character;
            _canSetPathForCharacter = _currentCharacter.standingTile != null;
        }

        private void OnTileClicked(OverlayTile overlayTile)
        {
            _currentTile = overlayTile;

            if (_canSetPathForCharacter == true && _currentCharacter != null)
            {
                _path = _pathFinder.FindPath(_currentCharacter.standingTile, _currentTile);
                _canSetPathForCharacter = false;
            }
        }
    }
}