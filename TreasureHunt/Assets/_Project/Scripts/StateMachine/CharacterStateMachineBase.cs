using System.Collections.Generic;
using Sensors;
using TagComponents;
using UnityEngine;

namespace StateMachine
{
    public class CharacterStateMachineBase : StateMachineBase
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

        protected virtual void OnSensorEnter(TagComponentBase tag)
        {
            if (tag is IShootableEnemy_Tag && _currentVisibleEnemies.Contains(tag) == false) { _currentVisibleEnemies.Add(tag); }
        }

        protected virtual void OnSensorExit(TagComponentBase tag)
        {
            if (tag is IShootableEnemy_Tag) { _currentVisibleEnemies.Remove(tag); }
        }
    }
}