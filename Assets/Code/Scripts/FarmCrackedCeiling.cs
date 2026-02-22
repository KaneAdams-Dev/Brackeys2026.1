using UnityEngine;

namespace Brackeys2026
{
    public class FarmCrackedCeiling : MonoBehaviour, IDamagable
    {
        [SerializeField] private Animator _anim;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private Crop _crop;

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
            float time = _anim.GetCurrentAnimatorStateInfo(0).length;

            Invoke(nameof(WaterPlant), time);
        }

        private void WaterPlant() {
            _crop._isWatered = true;
        }
    }
}
