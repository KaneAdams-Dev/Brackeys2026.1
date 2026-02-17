using UnityEngine;

namespace Brackeys2026
{
    public class PlayerAnimationEvents : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Player _player;

        #endregion Variables

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start() {

        }

        // Update is called once per frame
        private void Update() {

        }

        #endregion Unity Methods

        #region Custom Methods

        public void ExitLanding() {
            _player.animator.canInterupt = true;

            _player.isGroundPounding = false;
            _player.UpdateState(PlayerStates.Idle);
        }

        public void EndGroundPound() {
            _player.animator.canInterupt = true;
            _player.movement.StopGroundPound();
        }

        #endregion Custom Methods
    }
}
