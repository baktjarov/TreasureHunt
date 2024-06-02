using System.Collections;
using Characters;
using UnityEngine;
using Zenject;

namespace StateMachine
{
    public class GoblinHouseSpawn_SMState : StateBase
    {
        [Inject] private CharacterManager _characterManager;

        [Header("Components")]
        [SerializeField] private TowerStateMachineBase _tower;
        [SerializeField] private Transform _spawnPosition;

        [Header("Settings")]
        [SerializeField] private float _spawnInterval;

        private void Start()
        {
            StartCoroutine(SpawnDelay());
        }

        private IEnumerator SpawnDelay()
        {
            SpawnEnemy();
            yield return new WaitForSeconds(_spawnInterval);
            StartCoroutine(SpawnDelay());
        }

        private void SpawnEnemy()
        {
            _characterManager.torchGoblinPooling.Get(_spawnPosition.position);
        }
    }
}