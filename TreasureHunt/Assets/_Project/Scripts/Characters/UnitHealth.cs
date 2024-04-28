using Interfaces;
using System;
using UnityEngine;

namespace Characters
{
    public class UnitHealth : MonoBehaviour, IHealth
    {
        public Action onDie { get; set; }
        public bool isAlive { get; private set; }

        public float currentHealth { get; private set; }
        public float maxHealth { get; private set; } = 100;

        private void Start()
        {
            if (currentHealth < maxHealth) { currentHealth = maxHealth; }
        }

        public void TakeDamage(float damage)
        {
            currentHealth = currentHealth - damage;

            if (currentHealth <= 0)
            {
                onDie?.Invoke();
                
                return;
            }
        }
    }
}