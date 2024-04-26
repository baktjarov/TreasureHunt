using Interfaces;
using System;
using UnityEngine;

namespace Characters
{
    public class CharacterHealth : MonoBehaviour, IHealth
    {
        public Action onDie { get; set; }
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
        }
    }
}