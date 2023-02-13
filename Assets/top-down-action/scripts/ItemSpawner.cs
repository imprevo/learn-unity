namespace LearnUnity
{
    using UnityEngine;

    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject healthPrefab;

        public GameObject GetHealth()
        {
            return healthPrefab;
        }
    }
}
