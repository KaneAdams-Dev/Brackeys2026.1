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
        [SerializeField] private float _groundPoundForce = -32f;

        [SerializeField] private float _raySize = 10f;
        [SerializeField] private LayerMask _jumpableLayers;

        private float _coyoteTime = 0.2f;
        private float _coyoteTimeCounter;

        private float _jumpBufferTime = 0.2f;
        private float _jumpBufferCounter;

        internal bool canDoubleJump;
        internal bool isDoubleJumping;

        [SerializeField] private float _normalGravity;
        [SerializeField] private float _fallGravity;
        [SerializeField] private float _jumpGravity;

        public Vector2 boxSize = new Vector2(1f, 0.8f);
        public float castDistance = 1.5f;
        //public LayerMask interactableLayer;
        public Vector3 pivotOffet = new Vector3(0, 2.5f, 0);

        public Vector2 facingDirection = Vector2.right;


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
                canDoubleJump = true;
                isDoubleJumping = false;
                //StopGroundPound();

                if (player.isGroundPounding && player._currentState == PlayerStates.GroundPoundFall) {
                    player.UpdateState(PlayerStates.GroundPoundLand);
                }

            } else {
                _coyoteTimeCounter -= Time.deltaTime;
            }

            _jumpBufferCounter -= Time.deltaTime;
        }

        private void FixedUpdate() {
            //if (!player.animator.canInterupt) return;
            //if (player.isGroundPounding) return;

            ApplyVariableGravity();
            Move();
            Jump();
        }

        // Implement this OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn
        private void OnDrawGizmos() {
            Vector3 center = transform.position + (Vector3)(facingDirection.normalized * castDistance * 0.5f) + pivotOffet;
            Vector3 size = new Vector3(boxSize.x, boxSize.y, 0f);

            Gizmos.DrawWireCube(center, size);
        }



        #endregion Unity Methods

        #region Custom Methods

        internal void SetMoveDirection(float a_inputDir) {
            _moveDir = a_inputDir;
        }

        internal void Move() {
            if (player.isGroundPounding || player._currentState == PlayerStates.Land) {
                return;
            }

            _rbody.linearVelocityX = _moveDir * player.moveSpeed;

            if (!player.isGroundPounding) {
                if (_moveDir < 0) {
                    //player.animator.transform.rotation = Quaternion.Euler(0, 180, 0);
                    player.animator.transform.localScale = new Vector2(-1, 1);
                } else if (_moveDir > 0) {
                    //player.animator.transform.rotation = Quaternion.Euler(0, 0, 0);
                    player.animator.transform.localScale = new Vector2(1, 1);
                }
            }

            if (_rbody.linearVelocityY != 0 || player._currentState == PlayerStates.GroundPoundLand) return;

            player.UpdateState(Mathf.Abs(_rbody.linearVelocityX) > 0.1f ? PlayerStates.Run : PlayerStates.Idle);
        }

        internal void ApplyVariableGravity() {
            if (_rbody.linearVelocityY > 0.1f) {
                _rbody.gravityScale = _jumpGravity;

            } else if (_rbody.linearVelocityY < -0.1f) {
                _rbody.gravityScale = _fallGravity;

                if (!player.isGroundPounding) {
                    player.UpdateState(PlayerStates.Fall);
                }

            } else {
                _rbody.gravityScale = _normalGravity;
            }
        }

        internal void BeginJumpBuffer() {
            _jumpBufferCounter = _jumpBufferTime;
        }

        internal void Jump() {
            if (player.isGroundPounding) return;

            if (_coyoteTimeCounter > 0f && _jumpBufferCounter > 0f) {
                player.UpdateState(PlayerStates.Jump);

                _jumpBufferCounter = 0f;

                player.isJumping = true;
                _rbody.linearVelocityY = _jumpForce;
            }
        }

        internal void DoubleJump() {
            if (canDoubleJump) {
                _rbody.linearVelocityY = _jumpForce * 0.75f;
                canDoubleJump = false;
                isDoubleJumping = true;
                player.UpdateState(PlayerStates.Jump);
            }
        }

        internal void ResetJumpTime() {
            _coyoteTimeCounter = 0f;

            if (_rbody.linearVelocityY > 0f && !isDoubleJumping) {
                _rbody.linearVelocityY = _jumpForce * 0.5f;
            }
        }

        internal void GroundPound() {
            if (CheckIfGrounded()) {
                return;
            }

            player.UpdateState(PlayerStates.GroundPoundFall);

            player.isGroundPounding = true;
            _rbody.linearVelocityX = 0f;
            _rbody.AddForceY(_groundPoundForce, ForceMode2D.Impulse);
            SetMoveDirection(0f);

            //Invoke(nameof(StopGroundPound), 0.5f);
        }

        internal void StopGroundPound() {
            player.isGroundPounding = false;
            _rbody.linearVelocity = Vector3.zero;

            float currentInput = player.inputHandler.horizontalInput;

            if (currentInput > 0.01f) {
                SetMoveDirection(currentInput);
                player.UpdateState(PlayerStates.Run);
            } else {
                _moveDir = 0;
                player.UpdateState(PlayerStates.Idle);
            }
        }

        internal bool CheckIfGrounded() {
            Debug.DrawRay(transform.position, Vector2.down * _raySize, Color.blue, 0.2f);
            //return Physics2D.Raycast(transform.position, Vector2.down, _raySize, _jumpableLayers);
            return Physics2D.BoxCast(transform.position + pivotOffet, boxSize, 0f, Vector2.zero, castDistance, _jumpableLayers);
        }

        #endregion Custom Methods
    }
}
