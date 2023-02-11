namespace LearnUnity.TopDownAction
{
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Hurtbox))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private float bulletSpeed = 500f;

        private Rigidbody rb;

        public void Start()
        {
            rb = GetComponent<Rigidbody>();
            Fire();
        }

        public void OnTriggerEnter()
        {
            Destroy(gameObject);
        }

        private void Fire()
        {
            rb.AddRelativeForce(Vector3.forward * bulletSpeed);
            Destroy(gameObject, 5.0f);
        }

    }
}
