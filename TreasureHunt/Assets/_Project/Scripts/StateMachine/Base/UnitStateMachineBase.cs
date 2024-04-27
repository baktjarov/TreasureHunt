using System.Collections.Generic;
using Sensors;
using TagComponents;
using UnityEngine;

namespace StateMachine
{
    public abstract class UnitStateMachineBase : StateMachineBase
    {
        [Header("Components")]
        [SerializeField] protected VisionBase _visionSensor;

        [Header("Debug")]
        [SerializeField] protected List<TagComponentBase> _currentVisibleEnemies = new();
        public IReadOnlyList<TagComponentBase> currentVisiableEnemies => _currentVisibleEnemies;

        protected virtual void OnEnable()
        {
            _visionSensor.onEnter += OnSensorEnter;
            _visionSensor.onExit += OnSensorExit;
        }

        protected virtual void OnDisable()
        {
            _visionSensor.onEnter -= OnSensorEnter;
            _visionSensor.onExit -= OnSensorExit;
        }

        public abstract void OnSensorEnter(TagComponentBase tag);
        public abstract void OnSensorExit(TagComponentBase tag);
    }
}