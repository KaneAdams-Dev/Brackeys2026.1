using UnityEngine;

namespace Brackeys2026
{
    public class Clam : MonoBehaviour, IBreakable
    {
        [SerializeField] private Animator _anim;
        [SerializeField] private GameObject _seed;
        [SerializeField] private Collider2D _collider;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {
            _collider.enabled = true;
        }

        // Update is called once per frame
        void Update() {

        }

        public void Break() {
            ColourLogger.Log(this, "Break!");
            _collider.enabled = false;
            _anim.Play("Clam Open");
            Instantiate(_seed, transform.position, Quaternion.identity);
        }
    }
}
