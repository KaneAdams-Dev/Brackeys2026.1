using UnityEngine;

namespace Brackeys2026
{
    public class PlayerProjectiles : MonoBehaviour
    {
        #region Variables

        [SerializeField] protected Rigidbody2D _rbdy;
        [SerializeField] private SpriteRenderer spriteRend;

        [SerializeField] private Animator _anim;
        [SerializeField] private Collider2D _collider;

        private bool _isReleased;

        private float _moveSpeed = 10;
        private int _attackStrength = 1;

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
            _collider.enabled = true;

            Invoke(nameof(DespawnProjectile), 20f);
        }

        // This function is called when the behaviour becomes disabled or inactive
        private void OnDisable() {

        }

        // Update is called once per frame
        private void Update() {
            if (_isReleased) return;

            //if (!spriteRend.isVisible) {
            //    _isReleased = true;
            //    ObjectPoolManager.ReturnToPool(gameObject);
            //}
        }

        // This function is called every fixed framerate frame, if the MonoBehaviour is enabled
        private void FixedUpdate() {
            Move();
        }

        // OnCollisionEnter2D is called when this collider2D/rigidbody2D has begun touching another rigidbody2D/collider2D(2D physics only)
        private void OnCollisionEnter2D(Collision2D collision) {
            if (_isReleased) return;

            _rbdy.linearVelocityY = 0f;
            _collider.enabled = false;

            if (collision.gameObject.TryGetComponent(out IDamagable entity)) {
                entity.TakeDamage(_attackStrength);
            }

            _isReleased = true;

            ObjectPoolManager.ReturnToPool(gameObject);
        }

        //// OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
        //private void OnTriggerEnter2D(Collider2D collision) {
        //    if (_isReleased) return;

        //    _rbdy.linearVelocityY = 0f;
        //    _collider.enabled = false;

        //    if (collision.gameObject.TryGetComponent(out IDamagable entity)) {
        //        entity.TakeDamage(_attackStrength);
        //    }

        //    _isReleased = true;

        //    ObjectPoolManager.ReturnToPool(gameObject);
        //}

        #endregion Unity Methods

        #region Custom Methods

        //internal void SetupProjectile(RuntimeAnimatorController a_anim, float a_speed, int a_strength) {
        //    _anim.runtimeAnimatorController = a_anim;
        //    _moveSpeed = a_speed;
        //    _attackStrength = a_strength;
        //}

        private void Move() {
            _rbdy.linearVelocityY = _moveSpeed * 1f;
        }

        private void DespawnProjectile() {
            if (_isReleased) return;

            _isReleased = true;
            ObjectPoolManager.ReturnToPool(gameObject);
        }

        #endregion Custom Methods
    }
}
