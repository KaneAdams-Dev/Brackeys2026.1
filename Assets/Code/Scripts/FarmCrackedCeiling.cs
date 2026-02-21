using UnityEngine;

namespace Brackeys2026
{
    public class FarmCrackedCeiling : MonoBehaviour, IDamagable
    {
        [SerializeField] private Animator _anim;
        [SerializeField] private Collider2D _collider;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {

            _collider.enabled = true;
        }

        // Update is called once per frame
        void Update() {

        }

        public void TakeDamage(int a_amount = 1) {
            _anim.Play("Fall");
            _collider.enabled = false;
        }
    }
}
