namespace LearnUnity.TwinStickShooter
{
    using System.Collections.Generic;
    using UnityEngine;

    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private List<Transform> firepoints;

        [SerializeField]
        private GameObject projectilePrefab;

        public void Attack()
        {
            foreach (var point in firepoints)
            {
                InstantiateProjectile(point);
            }
        }

        private void InstantiateProjectile(Transform point)
        {
            Instantiate(projectilePrefab, point.position, point.rotation);
        }
    }
}
