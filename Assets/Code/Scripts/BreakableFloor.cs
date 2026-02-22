using UnityEngine;

namespace Brackeys2026
{
    public class BreakableFloor : MonoBehaviour, IBreakable
    {
        #region Variables
        [SerializeField] private Collider2D _collider;
        [SerializeField] private AudioClip _screenBreak;

        #endregion Variables

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start() {

        }

        // Update is called once per frame
        private void Update() {

        }

        #endregion Unity Methods

        #region Custom Methods

        public void Break() {
            if (_screenBreak != null) {
                SoundFXManager.Instance.PlaySound(_screenBreak, transform, 0.6f);
            }

            _collider.enabled = false;
            Destroy(gameObject);
        }

        #endregion Custom Methods
    }
}
