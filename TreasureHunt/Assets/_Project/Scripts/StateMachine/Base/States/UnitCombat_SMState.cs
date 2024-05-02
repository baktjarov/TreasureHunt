using System.Linq;
using Characters;
using Interfaces;
using TagComponents;
using UnityEngine;

namespace StateMachine
{
    public abstract class UnitCombat_SMState : StateBase
    {
        [Header("States")]
        [SerializeField] protected UnitFindCharacter_SMState _findCharacterState;

        [Header("Components")]
        [SerializeField] protected UnitStateMachineBase _character;
        [SerializeField] protected UnitInfo _characterInfo;

        [Header("Settings")]
        [SerializeField] protected string _damageAnimKey = "isDamaging";
        [SerializeField] protected float _damage = 25;

        protected TagComponentBase _currentEnemy = null;

        protected virtual void OnEnable()
        {
            _characterInfo.animationEvents.onAnimationEvent += OnAnimationEvent;
        }

        protected virtual void OnDisable()
        {
            _characterInfo.animationEvents.onAnimationEvent -= OnAnimationEvent;
        }

        public override void Tick()
        {
            base.Tick();

            if (_character.currentVisiableEnemies.Count > 0) { _currentEnemy = _character.currentVisiableEnemies.ElementAt(0); }
            else { _currentEnemy = null; }

            if (_currentEnemy != null && _characterInfo.moving == false)
            {
                Vector3 playerPosition = _character.currentVisiableEnemies.ElementAt(0).transform.position;
                Vector3 enemyPosition = transform.position;

                bool flipped = playerPosition.x < enemyPosition.x;
                _character.transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f));

                float deltaX = enemyPosition.x - playerPosition.x;
                float deltaY = enemyPosition.y - playerPosition.y;

                if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
                {
                    _characterInfo.animator.SetBool("Attack", true);
                    _characterInfo.animator.SetFloat("LastHorizontal", deltaX);
                }
                else if (Mathf.Abs(deltaX) < Mathf.Abs(deltaY))
                {
                    _characterInfo.animator.SetBool("Attack", true);
                    _characterInfo.animator.SetFloat("LastVertical", deltaY);
                }
            }
            else
            {
                _characterInfo.animator.SetBool("Attack", false);
                _characterInfo.animator.SetFloat("LastHorizontal", 0);
                _characterInfo.animator.SetFloat("LastVertical", 0);

                _nextState = _findCharacterState;
            }
        }

        protected virtual void OnAnimationEvent(string key)
        {
            if (_damageAnimKey == key)
            {
                var damagable = _character.currentVisiableEnemies.ElementAt(0).GetComponent<IHealth>();

                if (damagable != null)
                {
                    damagable.TakeDamage(_damage);
                }
            }
        }
    }
}