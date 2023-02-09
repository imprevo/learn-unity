namespace LearnUnity.TopDownAction
{
    using UnityEngine;

    [RequireComponent(typeof(Movable))]
    public class Player : MonoBehaviour
    {
        private Movable movable;

        public void Start()
        {
            movable = GetComponent<Movable>();
        }

        public void Update()
        {
            var movementDirection = GetMoveDirection();
            movable.Move(movementDirection);
        }

        private Vector3 GetMoveDirection()
        {
            return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        }
    }
}
