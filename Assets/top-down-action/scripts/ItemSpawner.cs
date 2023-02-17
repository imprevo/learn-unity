namespace LearnUnity
{
    using UnityEngine;

    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject healthPrefab;

        [SerializeField]
        private GameObject upgradePrefab;

        public GameObject GetHealth()
        {
            return healthPrefab;
        }

        public GameObject GetUpgrade()
        {
            return upgradePrefab;
        }
    }
}
