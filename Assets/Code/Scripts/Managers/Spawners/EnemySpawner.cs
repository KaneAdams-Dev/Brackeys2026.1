using System.Collections;
using UnityEngine;

namespace Brackeys2026
{
    public class EnemySpawner : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private BulletHellSO[] _enemyStats;
        [SerializeField] private float spawnRate = 1f;

        [SerializeField] private BulletHellSO _firstEnemy;
        [SerializeField] private BulletHellSO _boss;

        private Vector2 _screenBounds;
        private float _objectWidth;
        private float _objectHeight;

        float spawnY;

        [SerializeField] private int enemiesSpawned;
        [SerializeField] private int enemiesAlive;
        [SerializeField] private int wave;

        #endregion Variables

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start() {
            _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            _objectWidth = _enemyPrefab.GetComponentInChildren<Renderer>().bounds.size.x / 2;
            _objectHeight = _enemyPrefab.GetComponentInChildren<Renderer>().bounds.size.y / 2;

            if (_enemyPrefab == null) {
                ColourLogger.LogWarning(this, "No Enemy prefab available to spawn");
                return;
            }

            spawnY = (_screenBounds.y + _objectHeight) + 2;
            wave = 1;
            enemiesAlive = 1;

            //GameObject spawnedObj = Instantiate(_enemyPrefab, new Vector2(randomX, spawnY), _enemyPrefab.transform.rotation);
            GameObject spawnedObj = ObjectPoolManager.SpawnObject(_enemyPrefab, new Vector2(0, spawnY), _enemyPrefab.transform.rotation);//Instantiate(_enemyPrefab, new Vector2(randomX, spawnY), _enemyPrefab.transform.rotation);
            if (spawnedObj.TryGetComponent(out BHEnemies enemy)) {
                enemy.isNormalEnemy = false;
                enemy.AssignStats(_firstEnemy);
            } else {
                ColourLogger.LogWarning(this, "This GameObject is not an enemy");
            }
        }

        // Update is called once per frame
        private void Update() {
            //if (Keyboard.current.kKey.wasPressedThisFrame) {
            //    if (IsInvoking(nameof(SpawnEnemies))) {
            //        OnBossSpawn();
            //    } else {
            //        //OnStartLevel();
            //    }
            //}
        }

        // This function is called when the object becomes enabled and active
        private void OnEnable() {
            BHEnemies.OnDeath += OnEnemyDeath;
        }

        // This function is called when the behaviour becomes disabled or inactive
        private void OnDisable() {
            StopAllCoroutines();
            BHEnemies.OnDeath -= OnEnemyDeath;
        }



        #endregion Unity Methods

        #region Custom Methods

        private void OnEnemyDeath() {
            enemiesAlive--;

            if (enemiesAlive <= 0) {
                ColourLogger.Log(this, "Spawning Enemies...");
                wave++;

                if (wave == 5) {
                    OnBossSpawn();

                } else if (wave > 5) {

                } else {
                    StartCoroutine(BeginNextWave());
                }
            }
        }

        private void SpawnEnemies() {
            if (_enemyPrefab == null) {
                ColourLogger.LogWarning(this, "No Enemy prefab available to spawn");
                return;
            }

            if (_enemyStats.Length == 0) {
                ColourLogger.LogWarning(this, "No stats able to be applied to enemy");
                return;
            }

            float randomX = Random.Range(_screenBounds.x + _objectWidth - 5f, _screenBounds.x * -1 + _objectWidth + 5f);

            //GameObject spawnedObj = Instantiate(_enemyPrefab, new Vector2(randomX, spawnY), _enemyPrefab.transform.rotation);
            GameObject spawnedObj = ObjectPoolManager.SpawnObject(_enemyPrefab, new Vector2(randomX, spawnY), _enemyPrefab.transform.rotation);//Instantiate(_enemyPrefab, new Vector2(randomX, spawnY), _enemyPrefab.transform.rotation);
            if (spawnedObj.TryGetComponent(out BHEnemies enemy)) {
                enemy.isNormalEnemy = true;
                enemy.AssignStats(_enemyStats[Random.Range(0, _enemyStats.Length)]);

            } else {
                ColourLogger.LogWarning(this, "This GameObject is not an enemy");
            }
        }

        private void OnBossSpawn() {
            CancelInvoke();


            float randomX = Random.Range(_screenBounds.x - _objectWidth, _screenBounds.x * -1 + _objectWidth);
            float spawnY = (_screenBounds.y + _objectHeight) + 5;
            GameObject spawnedObj = ObjectPoolManager.SpawnObject(_enemyPrefab, new Vector2(randomX, spawnY), _enemyPrefab.transform.rotation);//Instantiate(_enemyPrefab, new Vector2(randomX, spawnY), _enemyPrefab.transform.rotation);
            if (spawnedObj.TryGetComponent(out BHEnemies enemy)) {
                enemy.isNormalEnemy = false;
                enemy.AssignStats(_boss);

            } else {
                ColourLogger.LogWarning(this, "This GameObject is not an enemy");
            }
        }

        private IEnumerator BeginNextWave() {
            enemiesSpawned = 0;
            enemiesAlive = 5;

            for (int i = 0; i < 5; i++) {
                yield return new WaitForSeconds(spawnRate);
                SpawnEnemies();
                enemiesSpawned++;
            }
        }

        #endregion Custom Methods
    }
}
