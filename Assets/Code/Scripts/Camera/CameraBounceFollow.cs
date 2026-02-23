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
            if (_target.position.y + 5 > transform.position.y) {
                //transform.position = new Vector3(_target.position.x, _target.position.y + 12f, -10f);

                Vector3 targetPos = new Vector3(transform.position.x, _target.position.y + 5f, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetPos, _lerp);
            }

			Vector3 targetPos2 = new Vector3(_target.position.x, transform.position.y, transform.position.z);
			transform.position = Vector3.Lerp(transform.position, targetPos2, _lerp);
		}

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.CompareTag("Player")) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
