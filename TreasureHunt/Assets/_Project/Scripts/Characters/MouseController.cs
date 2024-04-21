using Attributes;
using Gameplay;
using SO;
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

        [Header("Debug")]
        [SerializeField, ReadOnly] private CharacterInfo _currentCharacter;
        [SerializeField, ReadOnly] private bool _canSetPathForCharacter = false;

        private List<OverlayTile> _path;
        private PathFinder _pathFinder;
        private OverlayTile _currentTile;

        private void Awake()
        {
            _pathFinder = new PathFinder();
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
                GetMouseSelectable()?.SetSelected(true);
            }

            if (_path.Count > 0)
            {
                MoveAlongPath();
            }

            ManageCursorVisibility();
        }

        private void MoveAlongPath()
        {
            if (_path.Count < 1) { return; }
            if (_currentCharacter == null) { return; }

            var step = _speed * Time.deltaTime;

            float zIndex = _path[0].transform.position.z;
            Vector3 newPosition = Vector2.MoveTowards(_currentCharacter.transform.position, _path[0].transform.position, step);
            newPosition.z = zIndex;

            _currentCharacter.transform.position = newPosition;

            if (Vector2.Distance(_currentCharacter.transform.position, _path[0].transform.position) < 0.00001f)
            {
                _currentCharacter.SetStandingTile(_path[0]);
                _path.RemoveAt(0);

                if (_path.Count == 0)
                {
                    _currentCharacter.SetSelected(false);
                    _currentCharacter = null;
                }
            }
        }

        private IMouseSelectable GetMouseSelectable()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            return hit.collider?.GetComponent<IMouseSelectable>();
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
                }
            }

            return result;
        }

        private void OnCharacterClicked(CharacterInfo character)
        {
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