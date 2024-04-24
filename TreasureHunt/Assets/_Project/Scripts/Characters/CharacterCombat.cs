using System.Collections.Generic;
using Sensors;
using TagComponents;
using UnityEngine;

namespace Characters
{
    public class CharacterCombat : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private VisionBase _visionSensor;

        [Header("Debug")]
        [SerializeField] private List<TagComponentBase> _currentVisibleEnemies = new();

        private void OnEnable()
        {
            _visionSensor.onEnter += OnSensorEnter;
            _visionSensor.onExit += OnSensorExit;
        }

        private void OnDisable()
        {
            _visionSensor.onEnter -= OnSensorEnter;
            _visionSensor.onExit -= OnSensorExit;
        }

        private void OnSensorEnter(TagComponentBase tag)
        {
            if (tag is IShootableEnemy_Tag && _currentVisibleEnemies.Contains(tag) == false) { _currentVisibleEnemies.Add(tag); }
        }

        private void OnSensorExit(TagComponentBase tag)
        {
            if (tag is IShootableEnemy_Tag) { _currentVisibleEnemies.Remove(tag); }
        }
    }
}