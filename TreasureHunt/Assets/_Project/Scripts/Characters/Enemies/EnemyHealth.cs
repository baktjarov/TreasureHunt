using System;
using Interfaces;
using UnityEngine;

namespace Characters.Enemy
{
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        public Action onDie { get; set; }
        public Action<float> onHealthChanged { get; set; }

        public bool isAlive { get; private set; }
        public float currentHealth { get; private set; } = 100;

        private void Update()
        {
            if (currentHealth <= 0)
            {
                onDie?.Invoke();

                Destroy(gameObject);
                return;
            }
        }

        public void TakeDamage(float damage)
        {
            currentHealth = currentHealth - damage;

            onHealthChanged?.Invoke(currentHealth);
        }
    }
}