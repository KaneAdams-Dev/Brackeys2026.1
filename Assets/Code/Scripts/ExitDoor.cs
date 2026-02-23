using UnityEngine;

namespace Brackeys2026
{
    public class ExitDoor : MonoBehaviour
    {
        [SerializeField] private Animator _anim;

        // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.CompareTag("Player")) {
                Destroy(collision.gameObject);
                _anim.Play("DoorClose");
            }
        }


    }
}
