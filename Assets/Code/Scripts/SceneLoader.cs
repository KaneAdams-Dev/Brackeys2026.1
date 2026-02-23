using UnityEngine;
using UnityEngine.SceneManagement;

namespace Brackeys2026
{
    public class SceneLoader : MonoBehaviour
    {
        public string _sceneToLoad;

        // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.CompareTag("Player")) {
                SceneManager.LoadSceneAsync(_sceneToLoad);
            }
        }
    }
}
