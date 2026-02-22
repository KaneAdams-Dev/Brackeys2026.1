using UnityEngine;

namespace Brackeys2026
{
    public class WaterAnimationEvents : MonoBehaviour
    {
        [SerializeField] private AudioClip _waterClip;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        public void PlayDrop() {
            SoundFXManager.Instance.PlaySound(_waterClip, transform, 0.5f);
        }
    }
}
