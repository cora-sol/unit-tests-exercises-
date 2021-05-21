using System;
using UnityEngine;

namespace Worms
{
    public class WormyHealth
    {
        private readonly int maxHealth;
        private int health;

        public int Health => health;

        public WormyHealth(int maxHealth)
        {
            if (maxHealth <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxHealth), maxHealth, null);
            this.maxHealth = maxHealth;
            health = maxHealth;
        }

        public void ChangeHealth(int healthChange)
        {
            health = Mathf.Clamp(health + healthChange, 0, maxHealth);
        }
    }
}