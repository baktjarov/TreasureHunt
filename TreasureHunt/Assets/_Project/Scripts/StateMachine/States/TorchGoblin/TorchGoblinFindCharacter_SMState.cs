using System.Collections.Generic;
using Characters;
using Gameplay;
using Mechanics;
using SO;
using UnityEngine;

namespace StateMachine
{
    public class TorchGoblinFindCharacter_SMState : UnitFindCharacter_SMState
    {
        [Header("Components")]
        [SerializeField] private ListOfAllTowers _listOfAllTowers;

        [Header("Settings")]
        [SerializeField] private float _speed;

        private OverlayTile _currentTile;
        private List<OverlayTile> _path;
        private MoveMechanic _moveMechanic;
        private PathFinder _pathFinder;

        private void Awake()
        {
            _pathFinder = new PathFinder();
            _moveMechanic = new MoveMechanic();
            _path = new List<OverlayTile>();
        }

        public override void Tick()
        {
            base.Tick();

            if (_path.Count > 0)
            {
                _moveMechanic.MoveAlongPath(_path, _characterInfo, _speed, _characterInfo.unitBase);
            }
            else
            {
                OnTowerDetacted();
            }
        }

        private void OnTowerDetacted()
        {
            int towerIndex = Random.Range(0, _listOfAllTowers._towersCount);

            TowerInfo tower = _listOfAllTowers.GetTower(towerIndex);
            _currentTile = tower.standingTile;

            _path = _pathFinder.FindPath(_characterInfo.standingTile, _currentTile);
        }
    }
}