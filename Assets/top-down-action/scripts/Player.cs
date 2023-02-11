namespace LearnUnity.TopDownAction
{
    using UnityEngine;

    [RequireComponent(typeof(Stats))]
    [RequireComponent(typeof(Movable))]
    public class Player : MonoBehaviour
    {
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
            var movementDirection = GetMoveDirection();
            movable.Move(movementDirection);
        }

        private void CheckDeath()
        {
            if (stats.IsDead)
            {
                Destroy(gameObject);
            }
        }

        private Vector3 GetMoveDirection()
        {
            return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        }
    }
}
