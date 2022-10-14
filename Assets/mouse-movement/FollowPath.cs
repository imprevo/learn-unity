namespace LearnUnity.MouseMovement
{
    using UnityEngine;

    public class FollowPath : MonoBehaviour
    {
        [SerializeField]
        private Transform[] waypoints;
        private int waypointIndex = 0;

        [SerializeField]
        private float movementSpeed = 1f;
        [SerializeField]
        private float rotateSpeed = 200f;

        private Transform Target => waypoints[waypointIndex];

        public void Update()
        {
            if (IsArrivedAtTarget())
            {
                SetNextTarget();
            }

            Move();
            Rotate();
        }

        private bool IsArrivedAtTarget()
        {
            return Vector3.Distance(transform.position, Target.position) < 0.1f;
        }

        private void SetNextTarget()
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Length;
        }

        private void Move()
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                Target.position,
                movementSpeed * Time.deltaTime
            );
        }

        private void Rotate()
        {
            var toRotation = Quaternion.LookRotation(
                Target.position - transform.position,
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
