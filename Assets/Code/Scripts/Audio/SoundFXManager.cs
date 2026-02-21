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
            if (Instance == null) Instance = null;
        }


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        public void PlaySound(AudioClip a_clip, Transform a_parent, float a_volume = 1f) {
            AudioSource source = ObjectPoolManager.SpawnObject(_soundFXPrefab.gameObject, a_parent.position, Quaternion.identity).GetComponent<AudioSource>();

            source.clip = a_clip;
            source.volume = a_volume;
            source.pitch = _defaultPitch + Random.Range(-0.1f, 0.1f);
            float clipLength = source.clip.length;
            source.Play();

            Invoke(nameof(DespawnAudioSource), clipLength);
        }

        private void DespawnAudioSource(GameObject a_objectToDespawn) {
            ObjectPoolManager.ReturnToPool(a_objectToDespawn);
        }
    }
}
