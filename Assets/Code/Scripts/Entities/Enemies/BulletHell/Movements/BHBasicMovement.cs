using UnityEngine;

namespace Brackeys2026
{
    public class BHBasicMovement : BHMovement
    {
        #region Variables

        #endregion Variables

        #region Unity Methods

        protected override void Start() {
            base.Start();

            _targetPosition = new Vector2(0f, 5f);
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
            }
        }

        #endregion Custom Methods
    }
}
