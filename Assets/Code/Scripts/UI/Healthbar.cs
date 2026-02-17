using UnityEngine;
using UnityEngine.InputSystem;

namespace Brackeys2026
{
    public class Healthbar : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject[] _hearts;

        #endregion Variables

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start() {
            foreach (var heart in _hearts) {
                heart.SetActive(true);
            }
        }

        // Update is called once per frame
        private void Update() {
            if (Keyboard.current.digit1Key.wasPressedThisFrame) {
                OnHealthUpdate(1);
            }
            if (Keyboard.current.digit2Key.wasPressedThisFrame) {
                OnHealthUpdate(2);
            }
            if (Keyboard.current.digit3Key.wasPressedThisFrame) {
                OnHealthUpdate(3);
            }
            if (Keyboard.current.digit4Key.wasPressedThisFrame) {
                OnHealthUpdate(4);
            }
            if (Keyboard.current.digit5Key.wasPressedThisFrame) {
                OnHealthUpdate(5);
            }
            if (Keyboard.current.digit6Key.wasPressedThisFrame) {
                OnHealthUpdate(6);
            }
            if (Keyboard.current.digit7Key.wasPressedThisFrame) {
                OnHealthUpdate(7);
            }
            if (Keyboard.current.digit8Key.wasPressedThisFrame) {
                OnHealthUpdate(8);
            }
            if (Keyboard.current.digit9Key.wasPressedThisFrame) {
                OnHealthUpdate(9);
            }
            if (Keyboard.current.digit0Key.wasPressedThisFrame) {
                OnHealthUpdate(10);
            }
            if (Keyboard.current.minusKey.wasPressedThisFrame) {
                OnHealthUpdate(0);
            }
        }

        #endregion Unity Methods

        #region Custom Methods

        public void OnHealthUpdate(int a_newHealth) {
            if (_hearts.Length <= 0) {
                ColourLogger.LogWarning(this, "No hearts available");
            }

            for (int i = 0; i < _hearts.Length; i++) {
                //if (i > a_newHealth) {
                //    _hearts[i].SetActive(false);
                //} else {
                //    _hearts[i].SetActive(true);
                //}

                _hearts[i].SetActive(i < a_newHealth);
            }
        }

        #endregion Custom Methods
    }
}
