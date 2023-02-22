namespace LearnUnity.InteractWithObjects
{
    using System;
    using UnityEngine;

    public class Health : MonoBehaviour
    {
        [SerializeField]
        private int health = 100;

        public int CurrentHealth => health;

        public event Action<int> OnChange;

        public void UpdateHealth(int amount)
        {
            health += amount;
            OnChange?.Invoke(amount);
        }
    }
}
