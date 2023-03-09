namespace LearnUnity.TwinStickShooter
{
    using UnityEngine;

    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        private Hurtbox hurtbox;

        [SerializeField]
        private float destroyDelay = 3.0f;

        public void OnEnable()
        {
            Destroy(gameObject, destroyDelay);
            hurtbox.OnHit += OnHit;
        }

        public void OnDisable()
        {
            hurtbox.OnHit -= OnHit;
        }

        private void OnHit()
        {
            Destroy(gameObject);
        }
    }
}
