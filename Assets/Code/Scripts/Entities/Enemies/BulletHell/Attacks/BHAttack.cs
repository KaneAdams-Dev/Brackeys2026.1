using UnityEngine;

namespace Brackeys2026
{
    [RequireComponent(typeof(BHEnemies))]
    public class BHAttack : MonoBehaviour
    {
        #region Variables

        [SerializeField] protected BHEnemies _enemy;
        [SerializeField] protected GameObject _projectile;

        #endregion Variables

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        virtual protected void Start() {
            _enemy = GetComponent<BHEnemies>();
        }

        // Update is called once per frame
        private void Update() {

        }

        #endregion Unity Methods

        #region Custom Methods

        virtual internal void Fire() {

        }

        #endregion Custom Methods
    }
}
