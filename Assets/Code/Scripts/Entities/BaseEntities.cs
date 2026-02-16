using UnityEngine;

namespace Brackeys2026
{
    public class BaseEntities : MonoBehaviour, IDamagable
    {
        #region Variables

        protected int _currentHealth;
        [SerializeField] protected int _maxHealth = 100;

        #endregion Variables

        #region Unity Methods

        // Awake is called when the script instance is being loaded
        private void Awake() {
            _currentHealth = _maxHealth;
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start() {

        }

        // Update is called once per frame
        private void Update() {

        }

        #endregion Unity Methods

        #region Custom Methods

        public void TakeDamage(int amount) {
            _currentHealth -= amount;

            if (_currentHealth <= 0) {
                Destroy(gameObject);
            }
        }

        #endregion Custom Methods
    }
}
