using SO;
using UnityEngine;

namespace StateMachine
{
    public class TowerSpawn_SMState : StateBase
    {
        [Header("States")]
        [SerializeField] private TowerIdle_SMState _idleState;

        [Header("Components")]
        [SerializeField] private TowerStateMachineBase _tower;
        [SerializeField] private WarriorPooling _warriorPooling;
        [SerializeField] private Transform _spawnPosition;

        public override void Tick()
        {
            base.Tick();

            if(_tower._towerInfo.selected == false)
            {
                _nextState = _idleState;
            }

            if(Input.GetKeyDown(KeyCode.E))
            {
                _warriorPooling.Get(_spawnPosition.position);
            }
        }
    }
}