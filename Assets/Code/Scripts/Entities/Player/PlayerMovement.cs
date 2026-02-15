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


        #endregion Variables

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start() {

        }

        // Update is called once per frame
        private void Update() {

        }

        private void FixedUpdate() {
            Move();
        }

        #endregion Unity Methods

        #region Custom Methods

        internal void SetMoveDirection(float a_inputDir) {
            _moveDir = a_inputDir;
        }

        internal void Move() {
            _rbody.linearVelocityX = _moveDir * player.moveSpeed;
        }

        internal void Jump() {


            player.isJumping = true;
            _rbody.AddForceY(_jumpForce, ForceMode2D.Impulse);
        }

        internal void GroundPound() {
            player.isGroundPounding = true;
            _rbody.AddForceY(_jumpForce * -3f, ForceMode2D.Impulse);
        }

        #endregion Custom Methods
    }
}
