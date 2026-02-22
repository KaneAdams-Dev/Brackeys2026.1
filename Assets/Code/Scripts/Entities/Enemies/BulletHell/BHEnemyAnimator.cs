using UnityEngine;

namespace Brackeys2026
{
    public class BHEnemyAnimator : MonoBehaviour
    {
        #region Variables

        [SerializeField] private BHEnemies _enemy;
        [SerializeField] internal Animator controller;

        private string _currentClip;

        [SerializeField] private AudioClip _deathClip;

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

        public void ChangeAnimation(string a_newClip) {
            if (_currentClip == a_newClip) return;

            _currentClip = a_newClip;
            controller.Play(_currentClip);
        }

        public void DespawnEnemy() {
            ObjectPoolManager.ReturnToPool(_enemy.gameObject);
        }

        public void PlayDeathClip() {
            SoundFXManager.Instance.PlaySound(_deathClip, transform);
        }

        #endregion Custom Methods
    }
}
