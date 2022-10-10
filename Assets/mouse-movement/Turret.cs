namespace MouseMovement
{
    using UnityEngine;

    public class Turret : MonoBehaviour
    {
        [SerializeField]
        private Transform target;

        public void LateUpdate()
        {
            if (target)
            {
                LookAtTarget();
            }
        }

        private void LookAtTarget()
        {
            var direction = (target.position - transform.position).normalized;
            var lookRotation = Quaternion.LookRotation(direction);

            transform.rotation = lookRotation;
        }
    }
}
