using UnityEngine;

namespace Brackeys2026
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Variables

        [SerializeField] internal Player player;

        [SerializeField] private Rigidbody2D _rbody;

        #endregion Variables

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start() {

        }

        // Update is called once per frame
        private void Update() {

        }

        //private void FixedUpdate() {
        //    Move();
        //}



        #endregion Unity Methods

        #region Custom Methods

        internal void Move(float a_inputDir) {
            _rbody.linearVelocityX = a_inputDir * player.moveSpeed;
        }

        #endregion Custom Methods
    }
}
