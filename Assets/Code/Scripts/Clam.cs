using UnityEngine;

namespace Brackeys2026
{
    public class Clam : MonoBehaviour, IBreakable
    {
        [SerializeField] private Animator _anim;
        [SerializeField] private GameObject _seed;
        [SerializeField] private Collider2D _collider;

        [SerializeField] private GameObject _floorToBreak;
        [SerializeField] private GameObject _crack;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {
            _collider.enabled = true;
        }

        // This function is called when the object becomes enabled and active
        private void OnEnable() {
            Pickup.OnPickup += RevealNextLevel;
        }

        // This function is called when the behaviour becomes disabled or inactive
        private void OnDisable() {
            Pickup.OnPickup -= RevealNextLevel;
        }

        public void Break() {
            _collider.enabled = false;
            _anim.Play("Clam Open");
            Instantiate(_seed, transform.position, Quaternion.identity);
        }

        private void RevealNextLevel() {
            _crack.SetActive(true);
            _floorToBreak.SetActive(false);
        }
    }
}
