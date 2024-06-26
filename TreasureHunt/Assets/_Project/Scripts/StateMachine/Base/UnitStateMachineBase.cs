using System.Collections.Generic;
using Characters;
using Gameplay;
using Sensors;
using TagComponents;
using UnityEngine;

namespace StateMachine
{
    public abstract class UnitStateMachineBase : StateMachineBase
    {
        [Header("Components")]
        [SerializeField] protected VisionBase _visionSensor;
        [SerializeField] protected UnitHealth _health;
        [SerializeField] protected CharacterManager _characterManager;
        [SerializeField] protected CurrencySystem _currencySystem;

        [Header("Debug")]
        [SerializeField] protected List<TagComponentBase> _currentVisibleEnemies = new();
        public IReadOnlyList<TagComponentBase> currentVisiableEnemies => _currentVisibleEnemies;

        protected virtual void OnEnable()
        {
            _visionSensor.onEnter += OnSensorEnter;
            _visionSensor.onExit += OnSensorExit;
            _health.onDie += TurnDie;
        }

        protected virtual void OnDisable()
        {
            _visionSensor.onEnter -= OnSensorEnter;
            _visionSensor.onExit -= OnSensorExit;
            _health.onDie -= TurnDie;
        }

        public abstract void OnSensorEnter(TagComponentBase tag);
        public abstract void OnSensorExit(TagComponentBase tag);
        public abstract void TurnDie();
    }
}