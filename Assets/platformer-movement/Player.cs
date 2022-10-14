namespace LearnUnity.PlatformerMovement
{
    using UnityEngine;

    public class Player : MonoBehaviour
    {
        [SerializeField]
        private CharacterController controller;

        [SerializeField]
        private Renderer bodyRenderer;
        [SerializeField]
        private Renderer eyesRenderer;

        [SerializeField]
        private float moveSpeed = 5f;
        [SerializeField]
        private float runSpeed = 10f;
        [SerializeField]
        private float chroachingSpeed = 2f;
        [SerializeField]
        private float rotationSpeed = 500f;

        private float jumpHeight = 5f;
        private float xSpeed;
        private float ySpeed;

        public void Update()
        {
            var movementDirection = GetMovementDirection();

            if (controller.isGrounded)
            {
                ySpeed = Physics.gravity.y;
                xSpeed = moveSpeed;

                SetBodyColor(Color.blue);
                SetEyesColor(Color.white);


                if (IsJump())
                {
                    ySpeed = jumpHeight;
                    SetEyesColor(Color.yellow);
                }

                if (IsRun())
                {
                    xSpeed = runSpeed;
                    SetEyesColor(Color.red);
                }

                if (IsChroaching())
                {
                    // TODOL change collider size
                    xSpeed = chroachingSpeed;
                    SetEyesColor(Color.cyan);
                }
            }
            else
            {
                ySpeed += Physics.gravity.y * Time.deltaTime;
                SetBodyColor(Color.green);

                var flags = controller.collisionFlags;

                if (flags == CollisionFlags.Above)
                {
                    ySpeed = 0;
                    SetEyesColor(Color.grey);
                }
            }


            var magnitude = Mathf.Clamp01(movementDirection.magnitude);
            movementDirection.Normalize();
            var velocity = movementDirection * magnitude * xSpeed;
            velocity.y = ySpeed;

            controller.Move(velocity * Time.deltaTime);

            if (movementDirection != Vector3.zero)
            {
                Rotate(movementDirection);
            }
        }

        private bool IsJump()
        {
            return Input.GetButtonDown("Jump") || Input.GetAxis("Vertical") > 0.2f;
        }

        private bool IsRun()
        {
            return Input.GetButton("Fire3");
        }

        private bool IsChroaching()
        {
            return Input.GetButton("Fire1") || Input.GetAxis("Vertical") < -0.2f;
        }

        private Vector3 GetMovementDirection()
        {

            var horizontalInput = Input.GetAxis("Horizontal");

            return new Vector3(horizontalInput, 0, 0);
        }

        private void Rotate(Vector3 movementDirection)
        {
            var toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                toRotation,
                rotationSpeed * Time.deltaTime
            );
        }

        private void SetBodyColor(Color color)
        {
            bodyRenderer.material.color = color;
        }

        private void SetEyesColor(Color color)
        {
            eyesRenderer.material.color = color;
        }
    }
}
