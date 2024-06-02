using UnityEngine;

namespace StateMachine
{
    public class GoblinHouseIdle_SMState : StateBase
    {
        [Header("States")]
        [SerializeField] private GoblinHouseSpawn_SMState _spawnState;

        [Header("Components")]
        [SerializeField] private TowerStateMachineBase _tower;
    }
}