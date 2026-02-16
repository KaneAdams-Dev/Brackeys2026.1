using UnityEngine;

namespace Brackeys2026
{
    public class BHBasicMovement : BHMovement
    {
        #region Variables

        #endregion Variables

        #region Unity Methods

        #endregion Unity Methods

        #region Custom Methods

        internal override void Move(Transform a_target = null) {
            base.Move(a_target);

            _rbdy.linearVelocityY = _enemy.moveSpeed * -1f;
        }

        #endregion Custom Methods
    }
}
