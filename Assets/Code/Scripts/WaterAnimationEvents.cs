using UnityEngine;

namespace Brackeys2026
{
    public class WaterAnimationEvents : MonoBehaviour
    {
        [SerializeField] private AudioClip _waterClip;

        public void PlayDrop() {
            SoundFXManager.Instance.PlaySound(_waterClip, transform, 0.5f);
        }
    }
}
