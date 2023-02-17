namespace LearnUnity.TopDownAction
{
    using System;
    using System.Collections;
    using UnityEngine;

    public class EnemySpawner : MonoBehaviour
    {
        public event Action OnChange;

        public int Wave { get; private set; } = 0;

        [SerializeField]
        private ItemSpawner itemSpawner;

        [SerializeField]
        private Transform player;

        [SerializeField]
        private GameObject enemyPrefab;

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
            while (true)
            {
                yield return new WaitForSeconds(waveDelay);
                SpawnWave(1 + (Wave * 2));

                while (HasAliveEnemy())
                {
                    yield return new WaitForSeconds(1f);
                }

                var shouldSpawnUpgrade = Wave < 50 && Wave % 2 != 0;
                if (shouldSpawnUpgrade)
                {
                    SpawnUpgrade();
                }
                UpdateWave();
            }
        }

        private void UpdateWave()
        {
            Wave++;
            OnChange?.Invoke();
        }

        private bool HasAliveEnemy()
        {
            return FindObjectOfType<Enemy>() != null;
        }

        private void SpawnWave(int enemyCount)
        {
            for (var i = 0; i < enemyCount; i++)
            {
                var spawnPosition = GetSpawnPosition();
                var shouldDropHealth = i == 0;
                var health = 100 + (10 * Wave);
                SpawnEnemy(spawnPosition, health, shouldDropHealth);
            }
        }

        private void SpawnEnemy(Vector3 position, int health, bool shouldDropHealth)
        {
            var enemyObject = Instantiate(enemyPrefab, position, Quaternion.identity, transform);
            var enemy = enemyObject.GetComponent<Enemy>();
            if (enemy)
            {
                enemy.SetTarget(player);
                enemy.SetMaxHealth(health);
                if (shouldDropHealth)
                {
                    var item = enemyObject.GetComponent<ItemDroppable>();
                    item?.SetItem(itemSpawner.GetHealth());
                }
            }
        }

        private void SpawnUpgrade()
        {
            Instantiate(itemSpawner.GetUpgrade(), player.position, Quaternion.identity, transform);
        }

        private Vector3 GetSpawnPosition()
        {
            var angle = UnityEngine.Random.Range(0, 360);
            var start = Vector3.left * spawnDistance;
            var direction = Quaternion.AngleAxis(angle, Vector3.up) * start;
            return player.position + direction;
        }
    }
}
