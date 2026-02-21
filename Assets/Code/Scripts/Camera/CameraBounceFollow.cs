using UnityEngine;
using UnityEngine.SceneManagement;

namespace Brackeys2026
{
    public class CameraBounceFollow : MonoBehaviour
    {
        public Transform _target;
        public SpriteRenderer _targetSprite;
        public float _lerp;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {
        }

        // Update is called once per frame
        void Update() {

        }

        private void LateUpdate() {
            if (_target.position.y + 12 > transform.position.y) {
                //transform.position = new Vector3(_target.position.x, _target.position.y + 12f, -10f);

                Vector3 targetPos = new Vector3(_target.position.x, _target.position.y + 12f, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetPos, _lerp);
            }


        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.CompareTag("Player")) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
