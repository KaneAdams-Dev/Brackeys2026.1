using UnityEngine;

namespace Brackeys2026
{
    public class BHAdvanceMovement : BHMovement
    {
        #region Variables

        private float _direction;

        #endregion Variables

        #region Unity Methods

        protected override void Start() {
            base.Start();

            //_targetPosition = new Vector2(0f, 5f);

            _direction = Random.value > 0.5f ? -1 : 1;
        }

        // Update is called once per frame
        private void Update() {

        }

        #endregion Unity Methods

        #region Custom Methods

        internal override void Move(Transform a_target = null) {
            base.Move(a_target);

            //ColourLogger.Log(this, transform.position.ToString());
            //ColourLogger.Log(this, _targetPosition.ToString());

            //if (transform.position.y > _targetPosition.y) {
            //    _rbdy.linearVelocityY = _enemy.moveSpeed * -1f;
            //} else {
            //    _rbdy.linearVelocityY = 0f;
            //}

            if (transform.position.y > _targetPosition.y) {
                transform.Translate(new Vector3(0, _enemy.moveSpeed * -1 * Time.deltaTime, 0));
            } else {
                SideStep();
            }
        }

        private void SideStep() {
            if (transform.position.x > 30) {
                _direction = -1;
            } else if (transform.position.x < -30) {
                _direction = 1;
            }

            transform.Translate(new Vector3(_direction * _enemy.moveSpeed * Time.deltaTime, 0));
        }

        #endregion Custom Methods
    }
}
