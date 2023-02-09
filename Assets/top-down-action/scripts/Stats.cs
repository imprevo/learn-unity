namespace LearnUnity.TopDownAction
{
    using UnityEngine;

    public class Stats : MonoBehaviour
    {
        [SerializeField]
        private int maxHealth = 100;

        private int health;

        public void Start()
        {
            health = maxHealth;
        }

        public void Hit(int amount)
        {
            health = ClampHealth(health - amount);
        }

        public void Heal(int amount)
        {
            health = ClampHealth(health + amount);
        }

        private int ClampHealth(int value)
        {
            return Mathf.Clamp(value, 0, maxHealth);
        }
    }
}
