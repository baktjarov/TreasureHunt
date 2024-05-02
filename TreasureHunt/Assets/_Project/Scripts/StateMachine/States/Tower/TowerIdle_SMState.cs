using UnityEngine;

namespace StateMachine
{
    public class TowerIdle_SMState : StateBase
    {
        [Header("States")]
        [SerializeField] private TowerSpawn_SMState _spawnState;

        [Header("Components")]
        [SerializeField] private TowerStateMachineBase _tower;

        public override void Tick()
        {
            base.Tick();

            if(_tower._towerInfo.selected == true)
            {
                _nextState = _spawnState;
            }
        }
    }
}