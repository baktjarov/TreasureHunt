using Gameplay;
using SO;
using UI.Menus;
using UnityEngine;
using Zenject;

namespace StateMachine
{
    public class WarriorTowerSpawn_SMState : StateBase
    {
        [Inject] public CurrencySystem _currencySystem;

        [Header("States")]
        [SerializeField] private WarriorTowerIdle_SMState _idleState;

        [Header("Components")]
        [SerializeField] private TowerStateMachineBase _tower;
        [SerializeField] private WarriorPooling _warriorPooling;
        [SerializeField] private Transform _spawnPosition;

        public override void Enter()
        {
            base.Enter();

            _currencySystem.isSpawn += SpawnWarrior;
        }

        public override void Exit()
        {
            base.Exit();

            _currencySystem.isSpawn -= SpawnWarrior;
        }

        public override void Tick()
        {
            base.Tick();

            /*if (_tower._towerInfo.selected == false)
            {
                _nextState = _idleState;
            }*/
        }

        private void SpawnWarrior()
        {
            _warriorPooling.Get(_spawnPosition.position);
        }
    }
}