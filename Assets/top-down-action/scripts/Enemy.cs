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

        private Stats stats;

        private Movable movable;

        public void Awake()
        {
            stats = GetComponent<Stats>();
            movable = GetComponent<Movable>();
        }

        public void OnEnable()
        {
            stats.OnChange += CheckDeath;
        }

        public void OnDisable()
        {
            stats.OnChange -= CheckDeath;
        }

        public void Update()
        {
            MoveToTarget();
        }

        public void SetTarget(Transform target2)
        {
            target = target2;
        }

        private void CheckDeath()
        {
            if (stats.IsDead)
            {
                Destroy(gameObject);
            }
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
