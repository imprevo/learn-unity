namespace MouseMovement
{
    using UnityEngine;

    public class Character : MonoBehaviour
    {
        [SerializeField]
        private CharacterController controller;

        [SerializeField]
        private float moveSpeed = 5f;
        [SerializeField]
        private float rotateSpeed = 200f;

        private Vector3[] targetPath = { };
        private int targetPathIndex = 0;

        private Vector3 Target => targetPath[targetPathIndex];
        private bool HasTarget => targetPath.Length > 0 && targetPathIndex < targetPath.Length;

        public void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SetTarget();
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                ReturnToBase();
            }

            var direction = GetMovementDirection();
            if (HasTarget && direction.magnitude < 0.1f)
            {
                targetPathIndex++;
            }
            Move(direction.normalized);
            Rotate(direction.normalized);
        }

        private void SetTarget()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Terrain")
                {
                    // TODO: use navigation
                    targetPath = new Vector3[] {
                        hit.point,
                    };
                    targetPathIndex = 0;
                }
            }
        }

        private void ReturnToBase()
        {
            // TODO: use navigation
            targetPath = new Vector3[] {
                Vector3.left,
                Vector3.forward,
                Vector3.right,
                Vector3.back,
                Vector3.zero,
            };
            targetPathIndex = 0;
        }

        private Vector3 GetMovementDirection()
        {
            return HasTarget
                ? Target - transform.position
                : Vector3.zero;
        }

        private void Move(Vector3 movementDirection)
        {
            controller.Move(movementDirection * Time.deltaTime * moveSpeed);
        }

        private void Rotate(Vector3 movementDirection)
        {
            if (movementDirection.magnitude == 0)
            {
                return;
            }
            var toRotation = Quaternion.LookRotation(
                new Vector3(movementDirection.x, 0, movementDirection.z),
                Vector3.up
            );
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                toRotation,
                rotateSpeed * Time.deltaTime
            );
        }
    }
}
