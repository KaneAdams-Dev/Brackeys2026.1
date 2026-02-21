using UnityEngine;
using UnityEngine.SceneManagement;

namespace Brackeys2026
{
    public class CameraBounceFollow : MonoBehaviour
    {
        public Transform _target;
        public SpriteRenderer _targetSprite;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {
        }

        // Update is called once per frame
        void Update() {

        }

        private void LateUpdate() {
            if (_target.position.y + 10 > transform.position.y) {
                transform.position = new Vector3(_target.position.x, _target.position.y + 10f, -10f);
            }


        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.CompareTag("Player")) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
