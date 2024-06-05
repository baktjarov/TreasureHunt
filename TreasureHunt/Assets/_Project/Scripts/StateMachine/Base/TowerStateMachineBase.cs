using System;
using Characters;
using UnityEngine;

namespace StateMachine
{
    public abstract class TowerStateMachineBase : StateMachineBase
    {
        [Header("Components")]
        [SerializeField] private TowerInfo _towerInfo;
        [SerializeField] private UnitHealth _health;

        public Action isLouse;

        private void OnEnable()
        {
            _health.onDie += TurnDie;
        }

        private void OnDisable()
        {
            _health.onDie -= TurnDie;
        }

        private void TurnDie()
        {
            isLouse?.Invoke();
        }
    }
}