namespace LearnUnity.TopDownAction
{
    using System;
    using UnityEngine;

    public class Stats : MonoBehaviour
    {
        [SerializeField]
        public int MaxHealth { get; private set; } = 100;

        public int Health { get; private set; }

        public event Action OnChange;

        public bool IsDead => Health <= 0;

        public void Awake()
        {
            Health = MaxHealth;
        }

        public void Hit(int amount)
        {
            Health = ClampHealth(Health - amount);
            OnChange?.Invoke();
        }

        public void Heal(int amount)
        {
            Health = ClampHealth(Health + amount);
            OnChange?.Invoke();
        }

        public void SetMaxHealth(int amount)
        {
            MaxHealth = Mathf.Max(0, amount);
            Health = MaxHealth;
            OnChange?.Invoke();
        }

        private int ClampHealth(int value)
        {
            return Mathf.Clamp(value, 0, MaxHealth);
        }
    }
}
