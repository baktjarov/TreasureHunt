using Characters;
using UnityEngine;

namespace StateMachine
{
    public class WarriorFindEnemy_SMState : StateBase
    {
        [Header("Components")]
        [SerializeField] private CharacterStateController _character;

        [Header("States")]
        [SerializeField] private WarriorAttack_SMState _attackState;

        public override void Enter()
        {
            base.Enter();
        }

        public override void Tick()
        {
            base.Tick();

            if (_character.currentVisiableEnemies.Count > 0)
            {
                _nextState = _attackState;
            }
        }
    }
}