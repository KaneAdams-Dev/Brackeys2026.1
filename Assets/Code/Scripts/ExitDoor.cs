using UnityEngine;

namespace Brackeys2026
{
    public class ExitDoor : MonoBehaviour
    {
        [SerializeField] private Animator _anim;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.CompareTag("Player")) {
                Destroy(collision.gameObject);
                _anim.Play("DoorClose");
            }
        }


    }
}
