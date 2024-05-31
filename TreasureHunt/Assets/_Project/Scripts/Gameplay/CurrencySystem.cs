using System;
using UnityEngine;

namespace Gameplay
{
    public class CurrencySystem : MonoBehaviour
    {
        [SerializeField] private int _defaultCurrency;
        [SerializeField] private int _defaultEnemyCount;

        public int _currency { get; private set; } = 0;
        public int _enemyCount { get; private set; } = 0;
        public Action _isUIUpdate;

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

        public bool Use(int val)
        {
            if (EnoughCurrency(val))
            {
                _currency -= val;
                UpdateUI();
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool EnoughCurrency(int val)
        {
            return val <= _currency;
        }

        private void UpdateUI()
        {
            _isUIUpdate?.Invoke();
        }

        public void USE_TEST()
        {
            Debug.Log(Use(2));
        }
    }
}
