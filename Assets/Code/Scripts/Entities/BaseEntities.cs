using UnityEngine;

namespace Brackeys2026
{
    public class BaseEntities : MonoBehaviour, IDamagable
    {
        #region Variables

        protected int _currentHealth;
        [SerializeField] protected int _maxHealth = 3;

        [SerializeField] private AudioClip _damageClip;

        #endregion Variables

        #region Unity Methods

        // Awake is called when the script instance is being loaded
        virtual protected void Awake() {
            _currentHealth = _maxHealth;
        }

        #endregion Unity Methods

        #region Custom Methods

        virtual public void TakeDamage(int a_damage = 1) {
            _currentHealth -= a_damage;

            SoundFXManager.Instance.PlaySound(_damageClip, transform, Mathf.Clamp(0.64f * a_damage, 0.64f, 1f));

            if (_currentHealth <= 0) {
                DefeatEntity();
            }
        }

        virtual protected void DefeatEntity() {
            ObjectPoolManager.ReturnToPool(gameObject);
        }

        #endregion Custom Methods
    }
}
