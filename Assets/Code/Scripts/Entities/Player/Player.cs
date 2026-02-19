using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Brackeys2026
{
    public enum PlayerStates
    {
        Idle,
        Run,
        Jump,
        Fall,
        Land,
        GroundPoundFall,
        GroundPoundLand
    }

    public enum ToolsAndAbilities
    {
        Sword,
        Gun,
        Pickaxe,
        Seed
    }

    public class Player : BaseEntities
    {
        #region Variables

        [Header("References")]
        [SerializeField] internal PlayerInputHandler inputHandler;
        [SerializeField] internal PlayerMovement movement;
        [SerializeField] internal PlayerAnimator animator;

        [Header("Stats")]
        [SerializeField] internal float moveSpeed = 10f;

        internal bool canJump;
        internal bool isJumping;

        internal bool isGroundPounding;

        [SerializeField] private float _raySize;
        [SerializeField] private LayerMask _groundPoundLayers;

        internal PlayerStates _currentState;

        public static event Action<int> OnHealthChange;

        private bool hasSeed;

        #endregion Variables

        #region Unity Methods

        // Awake is called when the script instance is being loaded
        override protected void Awake() {
            base.Awake();

            isJumping = false;
            isGroundPounding = false;
            hasSeed = false;
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start() {

        }

        // Update is called once per frame
        private void Update() {
            //if (isJumping) {
            //    CheckIfGrounded();
            //}

            if (isGroundPounding) {

                Debug.DrawRay(transform.position, Vector2.down * _raySize, Color.green, 0.2f);
                if (Physics2D.Raycast(transform.position, Vector2.down, _raySize, _groundPoundLayers)) {

                }

                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _raySize, _groundPoundLayers);
                if (hit) {
                    if (hit.collider.gameObject.TryGetComponent(out IBreakable breakable)) {
                        breakable.Break();
                    }
                }
            }
        }

        // OnCollisionEnter2D is called when this collider2D/rigidbody2D has begun touching another rigidbody2D/collider2D (2D physics only)
        //private void OnCollisionEnter2D(Collision2D collision) {
        //    if (collision.gameObject.TryGetComponent(out IBreakable breakable)) {
        //        if (!isGroundPounding) {
        //            return;
        //        }

        //        breakable.Break();
        //    }
        //}

        //// Implement this OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn
        //private void OnDrawGizmos() {
        //    Gizmos.DrawRay();
        //}


        #endregion Unity Methods

        #region Custom Methods

        internal void UpdateState(PlayerStates a_newState) {
            if (_currentState == a_newState) return;
            if (!animator.canInterupt) return;


            if (_currentState == PlayerStates.Land || _currentState == PlayerStates.GroundPoundLand) {
                if (a_newState != PlayerStates.Idle) {

                }
            }

            _currentState = a_newState;
            animator.UpdateAnimation(_currentState.ToString());
        }

        public override void TakeDamage(int a_damage = 1) {
            base.TakeDamage(a_damage);
            OnHealthChange?.Invoke(_currentHealth);
        }

        protected override void DefeatEntity() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void EquipToolOrAbility(ToolsAndAbilities a_item) {

            switch (a_item) {
                case ToolsAndAbilities.Sword:
                    inputHandler.EnableSword();
                    inputHandler.EnableGroundPound();

                    break;

                case ToolsAndAbilities.Gun:
                    inputHandler.EnableGun();

                    break;

                case ToolsAndAbilities.Pickaxe:

                    break;

                case ToolsAndAbilities.Seed:
                    hasSeed = true;

                    break;

                default:
                    break;
            }
        }

        #endregion Custom Methods
    }
}
