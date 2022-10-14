namespace LearnUnity.TopDownMovementWithStateMachine
{
    using UnityEngine;

    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private float bulletSpeed = 10f;
        private Rigidbody rb;

        public void Start()
        {
            rb = GetComponent<Rigidbody>();

            Fire();
        }

        public void OnCollisionEnter(Collision collision)
        {
            var enemy = collision.gameObject.GetComponent<Enemy>();

            if (enemy)
            {
                enemy.TakeDamage();
            }

            Destroy(gameObject);
        }

        private void Fire()
        {
            rb.AddRelativeForce(Vector3.forward * bulletSpeed);
            Destroy(gameObject, 5.0f);
        }
    }
}
