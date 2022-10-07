namespace ControllerV2
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
        private float speed;
        private float ySpeed;
        private Vector3 prevMovementDirection = Vector3.zero;

        public void Start()
        {
            speed = moveSpeed;
        }

        public void Update()
        {
            Vector3 movementDirection;
            var currentMovementDirection = GetMovementDirection();

            // on ground
            if (controller.isGrounded)
            {
                movementDirection = currentMovementDirection;
                prevMovementDirection = movementDirection;

                ySpeed = Physics.gravity.y;
                speed = moveSpeed;

                SetBodyColor(Color.blue);
                SetEyesColor(Color.white);


                if (IsJump())
                {
                    ySpeed = jumpHeight;
                    SetEyesColor(Color.yellow);
                }

                if (IsRun())
                {
                    speed = runSpeed;
                    SetEyesColor(Color.red);
                }

                if (IsChroaching())
                {
                    speed = chroachingSpeed;
                    SetEyesColor(Color.cyan);
                }

            }
            // in air
            else
            {
                ySpeed += Physics.gravity.y * Time.deltaTime;

                movementDirection = prevMovementDirection + currentMovementDirection * 0.25f;

                SetBodyColor(Color.green);

                var flags = controller.collisionFlags;

                // touch ceiling
                if (flags == CollisionFlags.Above)
                {
                    ySpeed = 0;
                    SetEyesColor(Color.grey);
                }

                // wall jump
                if (IsJump() && flags == CollisionFlags.Sides)
                {
                    var direction = prevMovementDirection == Vector3.zero
                            ? currentMovementDirection.normalized
                            : prevMovementDirection.normalized;
                    movementDirection = Quaternion.AngleAxis(180, Vector3.up) * direction;
                    prevMovementDirection = movementDirection;

                    ySpeed = jumpHeight;
                    SetEyesColor(Color.magenta);
                }
            }

            var magnitude = Mathf.Clamp01(movementDirection.magnitude);
            movementDirection.Normalize();
            var velocity = movementDirection * magnitude * speed;
            velocity.y = ySpeed;

            controller.Move(velocity * Time.deltaTime);

            if (movementDirection != Vector3.zero)
            {
                Rotate(movementDirection);
            }

        }

        private Vector3 GetMovementDirection()
        {

            var horizontalInput = Input.GetAxis("Horizontal");
            var verticalInput = Input.GetAxis("Vertical");

            return new Vector3(horizontalInput, 0, verticalInput);
        }

        private bool IsJump()
        {
            return Input.GetButtonDown("Jump");
        }

        private bool IsChroaching()
        {
            return Input.GetButton("Fire1");
        }

        private bool IsRun()
        {
            return Input.GetButton("Fire3");
        }

        private void Rotate(Vector3 movementDirection)
        {
            var toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
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
