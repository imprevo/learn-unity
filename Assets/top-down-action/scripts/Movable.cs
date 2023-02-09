namespace LearnUnity.TopDownAction
{
    using UnityEngine;

    [RequireComponent(typeof(CharacterController))]
    public class Movable : MonoBehaviour
    {
        [SerializeField]
        private float movementSpeed = 5f;

        [SerializeField]
        private float rotationSpeed = 500f;

        private CharacterController controller;

        public void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        public void Move(Vector3 direction)
        {
            var magnitude = Mathf.Clamp01(direction.magnitude);
            direction.Normalize();
            var velocity = direction * magnitude * movementSpeed;
            velocity.y = Physics.gravity.y * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

            if (direction != Vector3.zero)
            {
                Rotate(direction);
            }
        }

        private void Rotate(Vector3 direction)
        {
            var toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
