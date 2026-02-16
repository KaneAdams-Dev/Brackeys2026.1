using UnityEngine;

namespace Brackeys2026
{
    public class BHEnemies : BaseEntities
    {
        #region Variables

        [SerializeField] internal BulletHellSO _defaultStats;

        [Header("Combat")]
        [SerializeField] internal BHAttack attack;
        internal float attackSpeed;
        internal GameObject projectile;

        [Header("Movement")]
        [SerializeField] internal BHMovement movement;
        internal float moveSpeed;

        #endregion Variables

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start() {

        }

        // Update is called once per frame
        private void Update() {

        }

        // This function is called when the object becomes enabled and active
        private void OnEnable() {
            AssignStats(_defaultStats);
        }

        #endregion Unity Methods

        #region Custom Methods

        private void AssignStats(BulletHellSO a_stats) {
            //attack = a_stats.Attack;
            //movement = a_stats.Movement;
            _maxHealth = a_stats.Health;
            _currentHealth = _maxHealth;

            moveSpeed = a_stats.MoveSpeed;
            attackSpeed = a_stats.AttackSpeed;
            projectile = a_stats.Projectile;

            movement = a_stats.Movement switch
            {
                BHDifficulties.Basic => gameObject.AddComponent<BHBasicMovement>(),
                BHDifficulties.Inter => gameObject.AddComponent<BHMovement>(),
                BHDifficulties.Advance => gameObject.AddComponent<BHMovement>(),
                _ => gameObject.AddComponent<BHMovement>()
            };

            attack = a_stats.Attack switch
            {
                BHDifficulties.Basic => gameObject.AddComponent<BHBasicAttack>(),
                BHDifficulties.Inter => gameObject.AddComponent<BHAttack>(),
                BHDifficulties.Advance => gameObject.AddComponent<BHAttack>(),
                _ => gameObject.AddComponent<BHAttack>()
            };
        }

        #endregion Custom Methods
    }
}
