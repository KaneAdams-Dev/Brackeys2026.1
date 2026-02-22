using UnityEngine;

namespace Brackeys2026
{
    public class WaterSlideAnimationEvents : MonoBehaviour
    {

        [SerializeField] private Crop _crop;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        public void WaterPlant() {
            _crop._isWatered = true;
        }
    }
}
