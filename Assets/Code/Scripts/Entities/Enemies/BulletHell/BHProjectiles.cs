using UnityEngine;

namespace Brackeys2026
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class BHProjectiles : MonoBehaviour
    {
        #region Variables

        [SerializeField] protected Rigidbody2D _rbdy;
        [SerializeField] private SpriteRenderer spriteRend;

        [SerializeField] private Animator _anim;

        private bool _isReleased;

        private float _moveSpeed;
        private int _attackStrength;

        #endregion Variables

        #region Unity Methods

        // Awake is called when the script instance is being loaded
        private void Awake() {
            if (spriteRend == null) {
                spriteRend = GetComponent<SpriteRenderer>();
            }
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start() {

        }

        // This function is called when the object becomes enabled and active
        private void OnEnable() {
            _isReleased = false;
        }

        // This function is called when the behaviour becomes disabled or inactive
        private void OnDisable() {

        }



        // Update is called once per frame
        private void Update() {
            if (_isReleased) return;

            if (!spriteRend.isVisible) {
                _isReleased = true;
                ObjectPoolManager.ReturnToPool(gameObject);
            }
        }

        // This function is called every fixed framerate frame, if the MonoBehaviour is enabled
        private void FixedUpdate() {
            Move();
        }

        // OnCollisionEnter2D is called when this collider2D/rigidbody2D has begun touching another rigidbody2D/collider2D (2D physics only)
        private void OnCollisionEnter2D(Collision2D collision) {
            if (_isReleased) return;

            if (collision.gameObject.TryGetComponent(out IDamagable entity)) {
                entity.TakeDamage(_attackStrength);
            }

            _isReleased = true;

            ObjectPoolManager.ReturnToPool(gameObject);
        }

        #endregion Unity Methods

        #region Custom Methods

        internal void SetupProjectile(BulletHellSO a_stats) {
            _anim.runtimeAnimatorController = a_stats.ProjectileAnim;
            _moveSpeed = a_stats.ProjectileSpeed;
            _attackStrength = a_stats.ProjectileStrength;
        }

        private void Move() {
            _rbdy.linearVelocityY = _moveSpeed * -1f;
        }

        #endregion Custom Methods
    }
}
