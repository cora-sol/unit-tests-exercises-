using UnityEngine;
using UnityEngine.UI;

namespace Worms
{
    public class WormyHealth : MonoBehaviour
    {
        public int health;
        public int maxHealth;
        public Text txtHealth;

        // Use this for initialization
        void Start()
        {
            health = maxHealth;
            txtHealth.text = health.ToString();
        }

        public void ChangeHealth(int change)
        {
            health += change;
            if (health > maxHealth)
            {
                health = maxHealth;
            }

            txtHealth.text = health.ToString();
        }
    }
}