using Gameplay;
using SO;
using UnityEngine;
using Zenject;

namespace StateMachine
{
    public class WarriorTowerSpawn_SMState : StateBase
    {
        [Inject] public CurrencySystem _currencySystem;
        [Inject] public WarriorPooling _warriorPooling;

        [Header("States")]
        [SerializeField] private WarriorTowerIdle_SMState _idleState;

        [Header("Components")]
        [SerializeField] private TowerStateMachineBase _tower;
        [SerializeField] private Transform _spawnPosition;

        private void OnEnable()
        {
            _currencySystem.isSpawn += SpawnWarrior;
        }

        private void OnDisable()
        {
            _currencySystem.isSpawn -= SpawnWarrior;
        }

        private void SpawnWarrior()
        {
            _warriorPooling.Get(_spawnPosition.position);
        }
    }
}