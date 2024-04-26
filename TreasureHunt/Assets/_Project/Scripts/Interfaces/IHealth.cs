using System;

namespace Interfaces
{
    public interface IHealth
    {
        public Action onDie { get; set; }

        public bool isAlive { get; }
        public float currentHealth { get; }

        public void TakeDamage(float damage);
    }
}