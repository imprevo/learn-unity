namespace LearnUnity.TwinStickShooter
{
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody))]
    public class Directionmovement : MonoBehaviour
    {
        [SerializeField]
        private float speed = 500f;

        private Rigidbody rb;

        public void Start()
        {
            rb = GetComponent<Rigidbody>();
            ApplyForce();
        }

        private void ApplyForce()
        {
            rb.useGravity = false;
            rb.isKinematic = false;
            rb.AddRelativeForce(Vector3.forward * speed);
        }
    }
}
