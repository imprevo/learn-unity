namespace PlatformerMovement
{
    using UnityEngine;

    public class Platform : MonoBehaviour
    {
        [SerializeField]
        private Transform[] waypoints;
        private int waypointIndex = 0;

        [SerializeField]
        private float speed = 1f;

        private Transform Target => waypoints[waypointIndex];

        public void Update()
        {
            if (IsArrivedAtTarget())
            {
                SetNextTarget();
            }

            transform.position = Vector3.MoveTowards(
                transform.position,
                Target.position,
                speed * Time.deltaTime
            );
        }

        private bool IsArrivedAtTarget()
        {
            return Vector3.Distance(transform.position, Target.position) < 0.1f;
        }

        private void SetNextTarget()
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Length;
        }
    }
}
