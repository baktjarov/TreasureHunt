using UnityEngine;

namespace StateMachine
{
    public class UnitFindCharacter_SMState : StateBase
    {
        [Header("Components")]
        [SerializeField] private UnitStateMachineBase _character;

        [Header("States")]
        [SerializeField] private UnitCombat_SMState _combatState;

        public override void Enter()
        {
            base.Enter();
        }

        public override void Tick()
        {
            base.Tick();

            if (_character.currentVisiableEnemies.Count > 0)
            {
                _nextState = _combatState;
            }
        }
    }
}