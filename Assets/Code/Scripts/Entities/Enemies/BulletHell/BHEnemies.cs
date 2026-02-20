using System;
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

        [SerializeField] private BHEnemyAnimator _anim;

        private GameObject _droppableItem;

        public static event Action OnDeath;

        #endregion Variables

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start() {
            canDestroy = false;
        }

        //// Update is called once per frame
        //private void Update() {
        //    if (!canDestroy) {
        //        return;
        //    }

        //    if (!spriteRend.isVisible) {
        //        //Destroy(gameObject);
        //        ObjectPoolManager.ReturnToPool(gameObject);
        //    }
        //}

        // This function is called when the object becomes enabled and active
        private void OnEnable() {
            //AssignStats(_defaultStats);
            //Invoke(nameof(EnableDestroyOnLeaveScreen), 2f);
            _anim.ChangeAnimation("Idle");
        }

        // This function is called when the behaviour becomes disabled or inactive
        private void OnDisable() {

        }


        #endregion Unity Methods

        #region Custom Methods

        public void AssignStats(BulletHellSO a_stats) {
            ColourLogger.Log(this, "Stats assigning");

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

            _anim.controller.runtimeAnimatorController = a_stats.Anim;

            _droppableItem = a_stats.DroppableItem;
        }

        private void EnableDestroyOnLeaveScreen() {
            canDestroy = true;
        }

        protected override void DefeatEntity() {
            if (_droppableItem != null) {
                ObjectPoolManager.SpawnObject(_droppableItem, transform.position, _droppableItem.transform.rotation);
                _droppableItem = null;
            }

            Destroy(movement);
            Destroy(attack);
            canDestroy = false;

            OnDeath?.Invoke();
            _anim.ChangeAnimation("Death");

            //base.DefeatEntity();

        }

        #endregion Custom Methods
    }
}
