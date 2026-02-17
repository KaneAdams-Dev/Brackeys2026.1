using UnityEngine;

namespace Brackeys2026
{
    public class BHEnemies : BaseEntities
    {
        #region Variables

        [SerializeField] internal BulletHellSO _defaultStats;
        internal BulletHellSO _currentStats;


        [Header("Combat")]
        [SerializeField] internal BHAttack attack;
        internal float attackSpeed;
        internal GameObject projectile;

        [Header("Movement")]
        [SerializeField] internal BHMovement movement;
        internal float moveSpeed;

        [SerializeField] internal SpriteRenderer spriteRend;
        private bool canDestroy;

        [SerializeField] private Animator _anim;

        #endregion Variables

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start() {
            canDestroy = false;
        }

        // Update is called once per frame
        private void Update() {
            if (!canDestroy) {
                return;
            }

            if (!spriteRend.isVisible) {
                //Destroy(gameObject);
                ObjectPoolManager.ReturnToPool(gameObject);
            }
        }

        // This function is called when the object becomes enabled and active
        private void OnEnable() {
            //AssignStats(_defaultStats);
            Invoke(nameof(EnableDestroyOnLeaveScreen), 2f);
        }

        // This function is called when the behaviour becomes disabled or inactive
        private void OnDisable() {
            Destroy(movement);
            Destroy(attack);
            canDestroy = false;
        }


        #endregion Unity Methods

        #region Custom Methods

        public void AssignStats(BulletHellSO a_stats) {
            _currentStats = a_stats;
            //attack = a_stats.Attack;
            //movement = a_stats.Movement;
            _maxHealth = a_stats.Health;
            _currentHealth = _maxHealth;

            moveSpeed = a_stats.MoveSpeed;
            attackSpeed = a_stats.FireRate;
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

            _anim.runtimeAnimatorController = a_stats.Anim;
        }

        private void EnableDestroyOnLeaveScreen() {
            canDestroy = true;
        }

        #endregion Custom Methods
    }
}
