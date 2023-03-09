namespace LearnUnity.TwinStickShooter
{
    using UnityEngine;

    [RequireComponent(typeof(CharacterController))]
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private float movementSpeed = 5f;

        [SerializeField]
        private Weapon weapon;

        private CharacterController controller;

        private float lastRotation = 0f;

        private Plane mouseCheckPlane = new(Vector3.up, Vector3.zero);

        public void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        public void Update()
        {
            var movementDirection = GetMoveDirection();
            var rotateAngle = GetRotateDirection();

            Move(movementDirection);
            Rotate(rotateAngle);

            if (GetFire())
            {
                weapon.Attack();
            }
        }

        private Vector3 GetMoveDirection()
        {
            return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        }

        private float GetRotateDirection()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (mouseCheckPlane.Raycast(ray, out var distance))
            {
                var target = ray.GetPoint(distance);
                var direction = target - transform.position;
                lastRotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            }
            return lastRotation;
        }

        private bool GetFire()
        {
            return Input.GetButtonDown("Fire1");
        }

        private void Move(Vector3 direction)
        {
            var magnitude = Mathf.Clamp01(direction.magnitude);
            direction.Normalize();
            var velocity = direction * magnitude * movementSpeed;
            velocity.y = Physics.gravity.y * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }

        private void Rotate(float angle)
        {
            // TODO: interpolate
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }
}
