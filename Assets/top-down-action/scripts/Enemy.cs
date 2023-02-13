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

        [SerializeField]
        private MeleeWeapon weapon;

        private Stats stats;

        private Movable movable;

        private ItemDroppable itemDroppable;

        public void Awake()
        {
            stats = GetComponent<Stats>();
            movable = GetComponent<Movable>();
            itemDroppable = GetComponent<ItemDroppable>();
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
            FollowTarget();
        }

        public void SetTarget(Transform target2)
        {
            target = target2;
        }

        private void CheckDeath()
        {
            if (stats.IsDead)
            {
                itemDroppable.DropItem();
                Destroy(gameObject);
            }
        }

        private void FollowTarget()
        {
            var direction = Vector3.zero;
            var shouldAttack = false;
            if (target)
            {
                var distance = GetDistanceToTarget();
                if (distance <= weapon.AttackDistance)
                {
                    shouldAttack = true;
                }
                if (distance > stopDistance)
                {
                    direction = GetMoveDirection();
                }
            }

            movable.Move(direction);
            if (shouldAttack)
            {
                weapon.Attack();
            }
        }

        private float GetDistanceToTarget()
        {
            return Vector3.Distance(transform.position, target.position);
        }

        private Vector3 GetMoveDirection()
        {
            return target.position - transform.position;
        }
    }
}
