namespace LearnUnity.TopDownAction
{
    using UnityEngine;

    [RequireComponent(typeof(Movable))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private Transform target;

        [SerializeField]
        private float stopDistance = 0.5f;

        private Movable movable;

        public void Start()
        {
            movable = GetComponent<Movable>();
        }

        public void Update()
        {
            MoveToTarget();
        }

        public void SetTarget(Transform target2)
        {
            target = target2;
        }

        private void MoveToTarget()
        {
            var direction = GetMoveDirection();
            movable.Move(direction);
        }

        private Vector3 GetMoveDirection()
        {
            if (target)
            {
                var distance = Vector3.Distance(transform.position, target.position);
                if (distance > stopDistance)
                {
                    return target.position - transform.position;
                }
            }
            return Vector3.zero;
        }
    }
}
