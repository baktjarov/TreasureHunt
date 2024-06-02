using System;
using UnityEngine;

namespace Gameplay
{
    public class CurrencySystem : MonoBehaviour
    {
        [SerializeField] private int _defaultCurrency;
        [SerializeField] private int _defaultEnemyCount;

        public int _currency { get; private set; }
        public int _enemyCount { get; private set; }

        public Action isUseCurrency;
        public Action isSpawn;

        public void Init()
        {
            _currency = _defaultCurrency;
            _enemyCount = _defaultEnemyCount;

            UpdateUI();
        }

        public void Gain(int val)
        {
            _currency += val;
            UpdateUI();
        }

        public void UseCurrency(int val)
        {
            Use(val);
        }

        public bool Use(int val)
        {
            if (EnoughCurrency(val))
            {
                _currency -= val;
                SpawnCharacter();
                UpdateUI();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EnoughCurrency(int val)
        {
            return val <= _currency;
        }

        private void UpdateUI()
        {
            isUseCurrency?.Invoke();
        }

        private void SpawnCharacter()
        {
            isSpawn?.Invoke();
        }
    }
}
