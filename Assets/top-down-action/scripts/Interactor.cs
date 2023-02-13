namespace LearnUnity.TopDownAction
{
    using UnityEngine;

    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Interactor : MonoBehaviour
    {
        [SerializeField]
        private Stats stats;

        public void OnTriggerEnter(Collider other)
        {
            var health = other.gameObject.GetComponent<HealthPickup>();

            if (health)
            {
                health.Use(stats);
            }
        }
    }
}
