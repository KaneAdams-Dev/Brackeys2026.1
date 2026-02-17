using UnityEngine;

namespace Brackeys2026
{
    public class EnemySpawner : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private BulletHellSO[] _enemyStats;
        [SerializeField] private float spawnRate = 1f;

        private Vector2 _screenBounds;
        private float _objectWidth;
        private float _objectHeight;

        #endregion Variables

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start() {
            _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            _objectWidth = _enemyPrefab.GetComponentInChildren<Renderer>().bounds.size.x / 2;
            _objectHeight = _enemyPrefab.GetComponentInChildren<Renderer>().bounds.size.y / 2;

            InvokeRepeating(nameof(SpawnEnemies), spawnRate, spawnRate);
        }

        // Update is called once per frame
        private void Update() {

        }

        #endregion Unity Methods

        #region Custom Methods

        private void SpawnEnemies() {
            if (_enemyPrefab == null) {
                ColourLogger.LogWarning(this, "No Enemy prefab available to spawn");
                return;
            }

            if (_enemyStats.Length == 0) {
                ColourLogger.LogWarning(this, "No stats able to be applied to enemy");
                return;
            }

            float randomX = Random.Range(_screenBounds.x - _objectWidth, _screenBounds.x * -1 + _objectWidth);
            float spawnY = (_screenBounds.y + _objectHeight) + 5;

            //GameObject spawnedObj = Instantiate(_enemyPrefab, new Vector2(randomX, spawnY), _enemyPrefab.transform.rotation);
            GameObject spawnedObj = ObjectPoolManager.SpawnObject(_enemyPrefab, new Vector2(randomX, spawnY), _enemyPrefab.transform.rotation);//Instantiate(_enemyPrefab, new Vector2(randomX, spawnY), _enemyPrefab.transform.rotation);
            if (spawnedObj.TryGetComponent(out BHEnemies enemy)) {
                enemy.AssignStats(_enemyStats[Random.Range(0, _enemyStats.Length)]);

            } else {
                ColourLogger.LogWarning(this, "This GameObject is not an enemy");
            }
        }

        #endregion Custom Methods
    }
}
