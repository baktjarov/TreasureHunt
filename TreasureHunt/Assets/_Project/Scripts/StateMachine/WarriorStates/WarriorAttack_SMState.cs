using System.Linq;
using TagComponents;
using UnityEngine;

namespace StateMachine
{
    public class WarriorAttack_SMState : StateBase
    {
        [Header("Components")]
        [SerializeField] private Characters.CharacterController _character;
        [SerializeField] private Characters.CharacterInfo _characterInfo;

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

            if (_currentEnemy != null && _characterInfo.moving == false) { _characterInfo.animator.SetBool("Attack", true); }
            else
            {
                _characterInfo.animator.SetBool("Attack", false);
                _nextState = _findEnemyState;
            }
        }
    }
}