using UnityEngine;

namespace Brackeys2026
{
    [RequireComponent(typeof(BHEnemies))]
    public class BHMovement : MonoBehaviour
    {
        #region Variables

        [SerializeField] protected BHEnemies _enemy;
        //[SerializeField] protected Rigidbody2D _rbdy;

        [SerializeField] internal Vector2 _targetPosition;

        private Vector2 _screenBounds;

        #endregion Variables

        #region Unity Methods

        private void Awake() {
            _targetPosition = new Vector2(0f, 5f);

        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        virtual protected void Start() {
            _enemy = GetComponent<BHEnemies>();
            //_rbdy = GetComponent<Rigidbody2D>();

            //_rbdy.gravityScale = 0f;

            _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

            float twoThirds = (_screenBounds.y / 3);
            ColourLogger.Log(this, _screenBounds.y.ToString());

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
