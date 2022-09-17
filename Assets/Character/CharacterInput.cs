namespace ControllerV1
{
    using UnityEngine;

    public class CharacterInput : MonoBehaviour
    {
        public Vector3 Movement { get; private set; }
        public Vector3 Rotation { get; private set; }
        public bool IsJump { get; private set; }
        public bool IsAttack { get; private set; }

        public void OnMove()
        {
            Movement = GetMoveDirection();
            Rotation = GetRotateDirection();
            IsJump = GetJump();
            IsAttack = GetAttack();
        }

        private Vector3 GetMoveDirection()
        {
            return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        }

        private Vector3 GetRotateDirection()
        {
            var mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);
            var angle = AngleBetweenPoints(transform.position, mouseWorldPosition);

            return new Vector3(0f, -angle - 90, 0f);
        }

        private float AngleBetweenPoints(Vector2 a, Vector2 b)
        {
            return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
        }

        private bool GetJump()
        {
            return Input.GetButton("Jump");
        }
        private bool GetAttack()
        {
            return Input.GetButton("Fire1");
        }
    }
}
