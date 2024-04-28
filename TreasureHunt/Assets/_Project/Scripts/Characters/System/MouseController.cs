using Attributes;
using Gameplay;
using Mechanics;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    public class MouseController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private GameObject _cursor;

        [Header("Settings")]
        [SerializeField] private float _speed;
        [SerializeField] private LayerMask _selectableRaycastMask;

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

            _cursor.SetActive(false);
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
                _moveMechanic.MoveAlongPath(_path, _currentCharacter, _speed);
                ResetCharacter();
            }

            ManageCursorVisibility();
        }

        private void ResetCharacter()
        {
            if (_path.Count == 0)
            {
                _currentCharacter.SetSelected(false);
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

            if (_currentCharacter.standingTile == null)
            {
                _currentCharacter.SetStandingTile(GetMouseSelectableOfType<OverlayTile>());
            }

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

        private void ManageCursorVisibility()
        {
            if (_canSetPathForCharacter == true && _currentCharacter != null)
            {
                OverlayTile hoverOverlayTile = GetMouseSelectableOfType<OverlayTile>();
                if (hoverOverlayTile != null)
                {
                    _cursor.transform.position = hoverOverlayTile.transform.position;
                }
            }

            if (_cursor.gameObject.activeSelf != _canSetPathForCharacter) { _cursor.SetActive(_canSetPathForCharacter); }
        }
    }
}