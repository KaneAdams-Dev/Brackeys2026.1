using UnityEngine;

namespace Brackeys2026
{
    public class BHBasicAttack : BHAttack
    {
        #region Variables

        #endregion Variables

        #region Unity Methods

        protected override void Start() {
            base.Start();

            InvokeRepeating(nameof(Fire), _enemy.attackSpeed, _enemy.attackSpeed);
        }

        #endregion Unity Methods

        #region Custom Methods

        internal override void Fire() {
            base.Fire();

            GameObject spawnedObj = ObjectPoolManager.SpawnObject(_enemy.projectile, transform.position, Quaternion.identity);

            if (spawnedObj.TryGetComponent(out BHProjectiles projectile)) {
                projectile.SetupProjectile(_enemy._currentStats);
            }
        }

        #endregion Custom Methods
    }
}
