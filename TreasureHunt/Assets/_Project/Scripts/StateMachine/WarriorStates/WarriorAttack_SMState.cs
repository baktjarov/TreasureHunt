using System.Linq;
using Characters;
using TagComponents;
using UnityEngine;

namespace StateMachine
{
    public class WarriorAttack_SMState : StateBase
    {
        [Header("Components")]
        [SerializeField] private CharacterStateController _character;

        [Header("States")]
        [SerializeField] private WarriorFindEnemy_SMState _findEnemyState;

        private TagComponentBase _currentEnemy = null;

        public override void Enter()
        {
            base.Enter();
        }

        public override void Tick()
        {
            base.Tick();

            if (_character.currentVisiableEnemies.Count > 0) { _currentEnemy = _character.currentVisiableEnemies.ElementAt(0); }
            else { _currentEnemy = null; }

            if (_currentEnemy != null) { }
            else { _nextState = _findEnemyState; }
        }
    }
}