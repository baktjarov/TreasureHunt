using Characters;
using UnityEngine;
using Zenject;

namespace StateMachine
{
    public class GoblinHouseSpawn_SMState : StateBase
    {
        [Inject] private CharacterManager _characterManager;

        [Header("States")]
        [SerializeField] private GoblinHouseIdle_SMState _idleState;

        [Header("Components")]
        [SerializeField] private TowerStateMachineBase _tower;
        [SerializeField] private Transform _spawnPosition;
    }
}