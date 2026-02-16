using UnityEngine;

namespace Brackeys2026
{
    [RequireComponent(typeof(Rigidbody2D), typeof(BHEnemies))]
    public class BHMovement : MonoBehaviour
    {
        #region Variables

        [SerializeField] protected BHEnemies _enemy;
        [SerializeField] protected Rigidbody2D _rbdy;

        #endregion Variables

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start() {
            _enemy = GetComponent<BHEnemies>();
            _rbdy = GetComponent<Rigidbody2D>();

            _rbdy.gravityScale = 0f;
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

        virtual internal void Move(Transform a_target = null) {

        }

        #endregion Custom Methods
    }
}
