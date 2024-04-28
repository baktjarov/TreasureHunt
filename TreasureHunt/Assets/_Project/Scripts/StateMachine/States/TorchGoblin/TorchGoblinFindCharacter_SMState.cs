using System.Collections.Generic;
using Attributes;
using Characters;
using Gameplay;
using UnityEngine;

namespace StateMachine
{
    public class TorchGoblinFindCharacter_SMState : UnitFindCharacter_SMState
    {
        [Header("Settings")]
        [SerializeField] private float _speed;

        [Header("Debug")]
        [SerializeField, ReadOnly] private Characters.CharacterInfo _currentCharacter;
        [SerializeField, ReadOnly] private bool _canSetPathForCharacter = false;

        private List<OverlayTile> _path;
        private PathFinder _pathFinder;
        private OverlayTile _currentTile;

        private void Awake()
        {
            _pathFinder = new PathFinder();
            _path = new List<OverlayTile>();
        }

        public override void Chase()
        {
            if (_characterInfo.standingTile != null)
            {
                OnTileSet();
            }
            else { SetTileUnderCharacter(); }

            if (_path.Count > 0)
            {
                MoveAlongPath();
            }
        }

        private void MoveAlongPath()
        {
            if (_path.Count < 1) { return; }
            if (_characterInfo == null) { return; }

            var step = _speed * Time.deltaTime;

            float zIndex = _path[0].transform.position.z;
            Vector3 newPosition = Vector2.MoveTowards(_characterInfo.transform.position, _path[0].transform.position, step);
            newPosition.z = zIndex;

            bool flipped = newPosition.x < _characterInfo.transform.position.x;
            _characterInfo.transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f));

            _characterInfo.transform.position = newPosition;
            _characterInfo.animator.SetFloat("Forward", newPosition.magnitude);
            _characterInfo.SetMoving(true);

            if (Vector2.Distance(_characterInfo.transform.position, _path[0].transform.position) < 0.00001f)
            {
                _characterInfo.SetStandingTile(_path[0]);
                _path.RemoveAt(0);

                if (_path.Count == 0)
                {
                    _characterInfo.SetMoving(false);
                    _characterInfo.animator.SetFloat("Forward", 0);
                    _characterInfo = null;
                }
            }
        }

        private void SetTileUnderCharacter()
        {
            if (_currentCharacter != null) { return; }
            _currentCharacter = FindAnyObjectByType<Characters.CharacterInfo>();

            OverlayTile tile = GetTileUnderCharacter<OverlayTile>();

            if (_characterInfo.standingTile == null)
            {
                _characterInfo.SetStandingTile(tile);
            }
            _canSetPathForCharacter = _characterInfo.standingTile != null;
        }

        private void OnTileSet()
        {
            _currentTile = _currentCharacter.standingTile;

            if (_canSetPathForCharacter == true && _characterInfo != null)
            {
                _path = _pathFinder.FindPath(_characterInfo.standingTile, _currentTile);
                _canSetPathForCharacter = false;
            }
        }

        private T GetTileUnderCharacter<T>()
        {
            Vector2 characterPosition = _characterInfo.transform.position;
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