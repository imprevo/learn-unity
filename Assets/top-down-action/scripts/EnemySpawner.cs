namespace LearnUnity.TopDownAction
{
    using System.Collections;
    using UnityEngine;

    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private ItemSpawner itemSpawner;

        [SerializeField]
        private Transform player;

        [SerializeField]
        private GameObject enemyPrefab;

        [SerializeField]
        private int waveCount = 10;

        [SerializeField]
        private float waveDelay = 5f;

        [SerializeField]
        private float spawnDistance = 10f;

        private Coroutine spawnCoroutine;

        public void OnEnable()
        {
            spawnCoroutine = StartCoroutine(SpawnLoop());
        }

        public void OnDisable()
        {
            if (spawnCoroutine != null)
            {
                StopCoroutine(spawnCoroutine);
            }
        }

        private IEnumerator SpawnLoop()
        {
            for (var i = 0; i < waveCount; i++)
            {
                yield return new WaitForSeconds(waveDelay);
                SpawnWave(i + 1);
            }
        }

        private void SpawnWave(int count)
        {
            for (var i = 0; i < count; i++)
            {
                var spawnPosition = GetSpawnPosition();
                var shouldDropHealth = Random.Range(0f, 1f) < 0.1f;
                SpawnEnemy(spawnPosition, shouldDropHealth);
            }
        }

        private void SpawnEnemy(Vector3 position, bool shouldDropHealth)
        {
            var enemyObject = Instantiate(enemyPrefab, position, Quaternion.identity, transform);
            var enemy = enemyObject.GetComponent<Enemy>();
            enemy?.SetTarget(player);
            if (shouldDropHealth)
            {
                var item = enemyObject.GetComponent<ItemDroppable>();
                item?.SetItem(itemSpawner.GetHealth());
            }
        }

        private Vector3 GetSpawnPosition()
        {
            var angle = Random.Range(0, 360);
            var start = Vector3.left * spawnDistance;
            var direction = Quaternion.AngleAxis(angle, Vector3.up) * start;
            return player.position + direction;
        }
    }
}
