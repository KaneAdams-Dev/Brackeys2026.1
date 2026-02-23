using UnityEngine;

namespace Brackeys2026
{
    public class WeaponHitBox : MonoBehaviour
    {
        #region Variables

        #endregion Variables

        #region Unity Methods


        // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.TryGetComponent(out IDamagable entity)) {
                entity.TakeDamage();
            }
        }



        #endregion Unity Methods

        #region Custom Methods

        #endregion Custom Methods
    }
}
