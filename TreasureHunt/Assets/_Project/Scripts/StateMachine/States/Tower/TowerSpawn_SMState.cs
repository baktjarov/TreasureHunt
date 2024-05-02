using UnityEngine;

namespace StateMachine
{
    public class TowerSpawn_SMState : StateBase
    {
        [Header("States")]
        [SerializeField] private TowerIdle_SMState _idleState;

        [Header("Components")]
        [SerializeField] private TowerStateMachineBase _tower;

        public override void Tick()
        {
            base.Tick();

            if(_tower._towerInfo.selected == false)
            {
                _nextState = _idleState;
            }
        }
    }
}