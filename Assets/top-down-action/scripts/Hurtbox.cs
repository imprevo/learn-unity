namespace LearnUnity.TopDownAction
{
    using UnityEngine;

    [RequireComponent(typeof(Collider))]
    public class Hurtbox : MonoBehaviour
    {
        [SerializeField]
        private int damage = 10;

        public void OnTriggerEnter(Collider other)
        {
            var hitbox = other.gameObject.GetComponent<Hitbox>();

            if (hitbox)
            {
                hitbox.TakeDamage(damage);
            }
        }
    }
}
