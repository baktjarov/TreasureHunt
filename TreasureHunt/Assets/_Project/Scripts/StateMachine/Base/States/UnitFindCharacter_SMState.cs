using UnityEngine;

namespace StateMachine
{
    public abstract class UnitFindCharacter_SMState : StateBase
    {
        [Header("States")]
        [SerializeField] protected UnitCombat_SMState _combatState;

        [Header("Components")]
        [SerializeField] protected UnitStateMachineBase _character;

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