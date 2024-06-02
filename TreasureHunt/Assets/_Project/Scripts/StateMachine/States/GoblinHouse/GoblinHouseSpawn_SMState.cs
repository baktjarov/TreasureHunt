using UnityEngine;

namespace StateMachine
{
    public class GoblinHouseSpawn_SMState : StateBase
    {
        [Header("States")]
        [SerializeField] private GoblinHouseIdle_SMState _idleState;

        [Header("Components")]
        [SerializeField] private TowerStateMachineBase _tower;
        [SerializeField] private Transform _spawnPosition;
    }
}