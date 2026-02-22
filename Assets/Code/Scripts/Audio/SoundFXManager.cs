using System.Collections;
using UnityEngine;

namespace Brackeys2026
{
    public class SoundFXManager : MonoBehaviour
    {
        public static SoundFXManager Instance;

        [SerializeField] private AudioSource _soundFXPrefab;
        private const float _defaultPitch = 1f;

        // Awake is called when the script instance is being loaded
        private void Awake() {
            if (Instance == null) Instance = this;
        }


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        public void PlaySound(AudioClip a_clip, Transform a_parent, float a_volume = 1f) {
            AudioSource source = ObjectPoolManager.SpawnObject(_soundFXPrefab.gameObject, a_parent.position, Quaternion.identity, ObjectPoolManager.PoolType.SoundFX).GetComponent<AudioSource>();

            source.clip = a_clip;
            source.volume = a_volume;
            source.pitch = _defaultPitch + Random.Range(-0.01f, 0.01f);
            float clipLength = a_clip.length;
            source.Play();

            //Invoke(nameof(DespawnAudioSource), clipLength);
            StartCoroutine(DespawnAudioSource(source.gameObject, clipLength));
        }

        private void DespawnAudioSource(GameObject a_objectToDespawn) {
            ObjectPoolManager.ReturnToPool(a_objectToDespawn);
        }

        IEnumerator DespawnAudioSource(GameObject a_objectToDespawn, float a_time) {
            yield return new WaitForSeconds(a_time);

            ObjectPoolManager.ReturnToPool(a_objectToDespawn);
        }
    }
}
