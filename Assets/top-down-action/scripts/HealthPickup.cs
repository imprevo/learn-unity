namespace LearnUnity.TopDownAction
{
    using UnityEngine;

    [RequireComponent(typeof(Collider))]
    public class HealthPickup : MonoBehaviour
    {
        [SerializeField]
        private int health = 50;

        public void Use(Stats stats)
        {
            stats.Heal(health);
            Destroy(gameObject);
        }
    }
}
