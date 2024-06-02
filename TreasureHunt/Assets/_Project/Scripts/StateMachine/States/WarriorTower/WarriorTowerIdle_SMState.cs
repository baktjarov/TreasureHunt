using UnityEngine;

namespace StateMachine
{
    public class WarriorTowerIdle_SMState : StateBase
    {
        [Header("States")]
        [SerializeField] private WarriorTowerSpawn_SMState _spawnState;

        [Header("Components")]
        [SerializeField] private TowerStateMachineBase _tower;

        public override void Tick()
        {
            base.Tick();
        }
    }
}