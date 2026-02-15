using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KabejaDevTools
{
    public class FPSCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _framerateText;

        private int lastFrameIndex;
        private float[] frameDeltaTimes;

        private void Awake() {
            frameDeltaTimes = new float[50];
        }


        // Update is called once per frame
        private void Update() {
            frameDeltaTimes[lastFrameIndex] = Time.unscaledDeltaTime;
            lastFrameIndex = (lastFrameIndex + 1) % frameDeltaTimes.Length;

            _framerateText.text = (Mathf.RoundToInt(CalculateFPS()).ToString() + " FPS");

            if (Keyboard.current.lKey.wasPressedThisFrame) {
                _framerateText.gameObject.SetActive(!_framerateText.gameObject.activeInHierarchy);
            }
        }

        private float CalculateFPS() {
            float total = 0f;
            foreach (float deltaTime in frameDeltaTimes) {
                total += deltaTime;
            }

            return frameDeltaTimes.Length / total;
        }
    }
}
