using UnityEngine;

namespace Brackeys2026
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Variables

        [SerializeField] internal Player player;

        [SerializeField] private Rigidbody2D _rbody;

        private float _moveDir = 0f;
        [SerializeField] private float _jumpForce = 100f;

        [SerializeField] private float _raySize = 10f;
        [SerializeField] private LayerMask _jumpableLayers;

        private float _coyoteTime = 0.2f;
        private float _coyoteTimeCounter;

        private float _jumpBufferTime = 0.2f;
        private float _jumpBufferCounter;

        #endregion Variables

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start() {
            ColourLogger.RegisterColour(this, "cyan");
        }

        // Update is called once per frame
        private void Update() {
            if (CheckIfGrounded()) {
                _coyoteTimeCounter = _coyoteTime;
            } else {
                _coyoteTimeCounter -= Time.deltaTime;
            }

            _jumpBufferCounter -= Time.deltaTime;
        }

        private void FixedUpdate() {
            Move();
            Jump();
        }

        #endregion Unity Methods

        #region Custom Methods

        internal void SetMoveDirection(float a_inputDir) {
            _moveDir = a_inputDir;
        }

        internal void Move() {
            _rbody.linearVelocityX = _moveDir * player.moveSpeed;
        }

        internal void BeginJumpBuffer() {
            _jumpBufferCounter = _jumpBufferTime;
        }

        internal void Jump() {
            if (_coyoteTimeCounter > 0f && _jumpBufferCounter > 0f) {
                _jumpBufferCounter = 0f;

                player.isJumping = true;
                _rbody.linearVelocityY = _jumpForce;
            }
        }

        internal void ResetJumpTime() {
            _coyoteTimeCounter = 0f;
        }

        internal void GroundPound() {
            player.isGroundPounding = true;
            _rbody.AddForceY(_jumpForce * -3f, ForceMode2D.Impulse);
        }

        internal bool CheckIfGrounded() {
            Debug.DrawRay(transform.position, Vector2.down * _raySize, Color.red, 0.2f);
            return Physics2D.Raycast(transform.position, Vector2.down, _raySize, _jumpableLayers);
        }

        #endregion Custom Methods
    }
}
