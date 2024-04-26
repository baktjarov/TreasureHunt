using System.Linq;
using Interfaces;
using TagComponents;
using UnityEngine;

namespace StateMachine
{
    public class WarriorAttack_SMState : StateBase
    {
        [Header("Components")]
        [SerializeField] private Characters.CharacterController _character;
        [SerializeField] private Characters.CharacterInfo _characterInfo;

        [Header("Settings")]
        [SerializeField] private string _damageAnimKey = "isDamaging";
        [SerializeField] private float _damage = 25;

        [Header("States")]
        [SerializeField] private WarriorFindEnemy_SMState _findEnemyState;

        private TagComponentBase _currentEnemy = null;

        private void OnEnable()
        {
            _characterInfo.animationEvents.onAnimationEvent += OnAnimationEvent;
        }

        private void OnDisable()
        {
            _characterInfo.animationEvents.onAnimationEvent -= OnAnimationEvent;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Tick()
        {
            base.Tick();

            if (_character.currentVisiableEnemies.Count > 0) { _currentEnemy = _character.currentVisiableEnemies.ElementAt(0); }
            else { _currentEnemy = null; }

            if (_currentEnemy != null)
            {
                Vector3 enemyPosition = _character.currentVisiableEnemies.ElementAt(0).transform.position;
                Vector3 playerPosition = transform.position;

                bool flipped = playerPosition.x > enemyPosition.x;
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
                _characterInfo.animator.SetBool("Attack", false); _characterInfo.animator.SetBool("Attack", false);
                _characterInfo.animator.SetFloat("LastHorizontal", 0);
                _characterInfo.animator.SetFloat("LastVertical", 0);

                _nextState = _findEnemyState;
            }
        }

        private void OnAnimationEvent(string key)
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