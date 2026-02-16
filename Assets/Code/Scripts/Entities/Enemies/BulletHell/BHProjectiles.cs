using UnityEngine;

namespace Brackeys2026
{
    public class BHProjectiles : MonoBehaviour
    {
        #region Variables

        [SerializeField] protected Rigidbody2D _rbdy;

        #endregion Variables

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start() {

        }

        // Update is called once per frame
        private void Update() {

        }

        // This function is called every fixed framerate frame, if the MonoBehaviour is enabled
        private void FixedUpdate() {
            Move();
        }


        #endregion Unity Methods

        #region Custom Methods

        private void Move() {
            _rbdy.linearVelocityY = -15f;
        }

        #endregion Custom Methods
    }
}
