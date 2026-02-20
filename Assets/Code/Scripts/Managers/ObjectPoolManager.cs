using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Brackeys2026
{
    public class ObjectPoolManager : MonoBehaviour
    {
        private GameObject _emptyHolder;

        private static GameObject _particlesSystemEmpty;
        private static GameObject _gameObjectsEmpty;
        private static GameObject _soundFXEmpty;

        private static Dictionary<GameObject, ObjectPool<GameObject>> _objectPools;
        private static Dictionary<GameObject, GameObject> _cloneToPrefabMap;

        public enum PoolType
        {
            ParticleSystems,
            GameObjects,
            SoundFX
        }

        public static PoolType PoolingType;

        // Awake is called when the script instance is being loaded
        private void Awake() {
            _objectPools = new Dictionary<GameObject, ObjectPool<GameObject>>();
            _cloneToPrefabMap = new Dictionary<GameObject, GameObject>();

            SetupEmpties();
        }

        private void SetupEmpties() {
            _emptyHolder = new GameObject("Object Pools");

            _particlesSystemEmpty = new GameObject("Particle Effects");
            _particlesSystemEmpty.transform.SetParent(_emptyHolder.transform);

            _gameObjectsEmpty = new GameObject("Game Objects");
            _gameObjectsEmpty.transform.SetParent(_emptyHolder.transform);

            _soundFXEmpty = new GameObject("Sound Effects");
            _soundFXEmpty.transform.SetParent(_emptyHolder.transform);
        }

        private static void CreatePool(GameObject a_prefab, Vector3 a_pos, Quaternion a_rot, PoolType a_poolType = PoolType.GameObjects) {
            ObjectPool<GameObject> pool = new ObjectPool<GameObject>(
                createFunc: () => CreateObject(a_prefab, a_pos, a_rot, a_poolType),
                actionOnGet: OnGetObject,
                actionOnRelease: OnReleaseObject,
                actionOnDestroy: OnDestroyObject
                );

            _objectPools.Add(a_prefab, pool);
        }

        private static GameObject CreateObject(GameObject a_prefab, Vector3 a_pos, Quaternion a_rot, PoolType a_poolType = PoolType.GameObjects) {
            a_prefab.SetActive(false);

            GameObject obj = Instantiate(a_prefab, a_pos, a_rot);

            a_prefab.SetActive(true);

            GameObject parentObject = SetParentObject(a_poolType);
            obj.transform.SetParent(parentObject.transform);

            return obj;
        }

        private static void OnGetObject(GameObject a_obj) {

        }

        private static void OnReleaseObject(GameObject a_obj) {
            a_obj.SetActive(false);
        }

        private static void OnDestroyObject(GameObject a_obj) {
            if (_cloneToPrefabMap.ContainsKey(a_obj)) {
                _cloneToPrefabMap.Remove(a_obj);
            }
        }

        private static GameObject SetParentObject(PoolType a_poolType) {
            return a_poolType switch
            {
                PoolType.GameObjects => _gameObjectsEmpty,
                PoolType.ParticleSystems => _particlesSystemEmpty,
                PoolType.SoundFX => _soundFXEmpty,
                _ => null,
            };
        }

        private static T SpawnObject<T>(GameObject a_objectToSpawn, Vector3 a_spawnPos, Quaternion a_spawnRotation, PoolType a_poolType = PoolType.GameObjects) where T : Object {
            if (!_objectPools.ContainsKey(a_objectToSpawn)) {
                CreatePool(a_objectToSpawn, a_spawnPos, a_spawnRotation, a_poolType);
            }

            GameObject obj = _objectPools[a_objectToSpawn].Get();

            if (obj != null) {
                if (!_cloneToPrefabMap.ContainsKey(obj)) {
                    _cloneToPrefabMap.Add(obj, a_objectToSpawn);
                }

                obj.transform.SetPositionAndRotation(a_spawnPos, a_spawnRotation);
                obj.SetActive(true);

                if (typeof(T) == typeof(GameObject)) {
                    return obj as T;
                }

                T component = obj.GetComponent<T>();
                if (component == null) {
                    Debug.LogError($"Object {a_objectToSpawn.name} doesn't have component of  type: {typeof(T)}");
                    return null;
                }

                return component;
            }

            return null;
        }
        public static T SpawnObject<T>(T a_typePrefab, Vector3 a_spawnPos, Quaternion a_spawnRotation, PoolType a_poolType = PoolType.GameObjects) where T : Component {
            return SpawnObject<T>(a_typePrefab.gameObject, a_spawnPos, a_spawnRotation, a_poolType);
        }

        public static GameObject SpawnObject(GameObject a_objectToSpawn, Vector3 a_spawnPos, Quaternion a_spawnRotation, PoolType a_poolType = PoolType.GameObjects) {
            return SpawnObject<GameObject>(a_objectToSpawn, a_spawnPos, a_spawnRotation, a_poolType);
        }

        public static void ReturnToPool(GameObject a_objectToReturn, PoolType a_poolType = PoolType.GameObjects) {
            if (_cloneToPrefabMap.TryGetValue(a_objectToReturn, out GameObject prefab)) {
                GameObject parentObject = SetParentObject(a_poolType);

                if (a_objectToReturn.transform.parent != parentObject.transform) {
                    a_objectToReturn.transform.parent = parentObject.transform;
                }

                if (_objectPools.TryGetValue(prefab, out ObjectPool<GameObject> pool)) {
                    pool.Release(a_objectToReturn);
                }
            } else {
                Debug.LogWarning("Trying to return an object that is not pooled: " + a_objectToReturn.name);
            }
        }
    }
}
