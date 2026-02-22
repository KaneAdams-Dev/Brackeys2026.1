using UnityEngine;
using UnityEngine.SceneManagement;

namespace Brackeys2026
{
    public class AnimatedDoorEvents : MonoBehaviour
    {
        [SerializeField] private GameObject _EndGameText;

        public float _endGameTime;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {
            _EndGameText.SetActive(false);
        }

        // Update is called once per frame
        void Update() {

        }

        public void EndGame() {
            _EndGameText.SetActive(true);

            Invoke(nameof(ReturnToMainMenu), _endGameTime);
        }

        private void ReturnToMainMenu() {
            SceneManager.LoadScene("MainMenuScene");
        }
    }
}
