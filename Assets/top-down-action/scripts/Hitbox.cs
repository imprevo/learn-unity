namespace LearnUnity.TopDownAction
{
    using UnityEngine;

    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Hitbox : MonoBehaviour
    {
        [SerializeField]
        private Stats stats;

        public void TakeDamage(int damage)
        {
            stats.Hit(damage);
        }
    }
}
