using UnityEngine;

namespace Brackeys2026
{
    public class Player : BaseEntities
    {
        #region Variables

        [Header("References")]
        [SerializeField] internal PlayerInputHandler inputHandler;
        [SerializeField] internal PlayerMovement movement;

        [Header("Stats")]
        [SerializeField] internal float moveSpeed = 10f;

        internal bool canJump;
        internal bool isJumping;

        internal bool isGroundPounding;

        #endregion Variables

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start() {
            isJumping = false;
            isGroundPounding = false;
        }

        // Update is called once per frame
        private void Update() {
            //if (isJumping) {
            //    CheckIfGrounded();
            //}
        }

        // OnCollisionEnter2D is called when this collider2D/rigidbody2D has begun touching another rigidbody2D/collider2D (2D physics only)
        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.gameObject.TryGetComponent(out IBreakable breakable)) {
                if (!isGroundPounding) {
                    return;
                }

                breakable.Break();
            }
        }

        //// Implement this OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn
        //private void OnDrawGizmos() {
        //    Gizmos.DrawRay();
        //}


        #endregion Unity Methods

        #region Custom Methods

        #endregion Custom Methods
    }
}
