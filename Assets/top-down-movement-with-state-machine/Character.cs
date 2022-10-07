namespace TopDownMovementWithStateMachine
{
    using UnityEngine;

    public class Character : MonoBehaviour
    {
        [SerializeField]
        private float playerSpeed = 5.0f;
        [SerializeField]
        private GameObject bulletPrefab;
        [SerializeField]
        private Transform bulletPosition;

        [SerializeField]
        private CharacterController controller;
        [SerializeField]
        private Material material;

        public bool IsGrounded => controller.isGrounded;
        public Vector3 Velocity => controller.velocity;
        public Vector3 velocity = Vector3.zero;

        public Vector3 MoveDirection { get; set; }
        public Vector3 MoveRotation { get; set; }

        public void Update()
        {
            Rotate();
        }

        public void FixedUpdate()
        {
            Move();
        }

        private float gravity = -10f;

        private void Move()
        {
            // TODO: double gravity applied
            var move = MoveDirection;
            move.y += gravity * Time.deltaTime;

            controller.Move(move * Time.deltaTime * playerSpeed);
        }

        private void Rotate()
        {
            transform.rotation = Quaternion.Euler(MoveRotation);
        }

        public void Fire()
        {
            Instantiate(bulletPrefab, bulletPosition.position, bulletPosition.rotation);
        }

        public void SetColor(Color color)
        {
            material.SetColor("_Color", color);
        }
    }
}
