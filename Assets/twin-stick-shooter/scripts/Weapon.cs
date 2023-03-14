namespace LearnUnity.TwinStickShooter
{
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private List<Transform> firepoints;

        [SerializeField]
        private List<GameObject> projectilePrefabs;

        private int projectileIndex = 0;

        public void Attack()
        {
            if (projectilePrefabs.Count == 0 || firepoints.Count == 0)
            {
                return;
            }

            var projectilePrefab = GetNextProjectile();
            foreach (var point in firepoints)
            {
                InstantiateProjectile(point, projectilePrefab);
            }
        }

        private void InstantiateProjectile(Transform point, GameObject projectilePrefab)
        {
            Instantiate(projectilePrefab, point.position, point.rotation);
        }

        private GameObject GetNextProjectile()
        {
            projectileIndex = (projectileIndex + 1) % projectilePrefabs.Count;
            return projectilePrefabs.ElementAt(projectileIndex);
        }
    }
}
