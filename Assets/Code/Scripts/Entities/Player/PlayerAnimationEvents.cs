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

        public void EndSwordAttack() {
            ColourLogger.Log(this, "return to idle");
            _player.canAttack = true;
            //_player.UpdateState(PlayerStates.Idle, (int)AnimationLayers.Sword);
            _player.animator.Unarm();
            _player.animator.UpdateAnimation("Base", (int)AnimationLayers.Sword);
        }

        #endregion Custom Methods
    }
}
