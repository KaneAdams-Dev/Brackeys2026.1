using UnityEngine;

namespace Brackeys2026
{
    public class WaterSlideAnimationEvents : MonoBehaviour
    {
        [SerializeField] private Crop _crop;

        public void WaterPlant() {
            _crop._isWatered = true;
        }
    }
}
