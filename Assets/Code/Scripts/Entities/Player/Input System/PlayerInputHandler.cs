using UnityEngine;
using UnityEngine.InputSystem;

namespace Brackeys2026
{
    public class PlayerInputHandler : MonoBehaviour
    {
        #region Variables

        [SerializeField] internal Player player;

        public PlayerActions playerActions;
        private PlayerActions.MetroidvaniaActions _mapActions;

        #endregion Variables

        #region Unity Methods

        // Awake is called when the script instance is being loaded
        private void Awake() {
            playerActions = new PlayerActions();
            _mapActions = playerActions.Metroidvania;

            ColourLogger.RegisterColour(this, "cyan");
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start() {
        }

        // Update is called once per frame
        private void Update() {
            if (Keyboard.current.pKey.wasPressedThisFrame) {
                EnableGroundPound();
            }

            if (Keyboard.current.qKey.wasPressedThisFrame) {
                DisableGroundPound();
            }
        }

        // This function is called when the object becomes enabled and active
        private void OnEnable() {
            EnableInputs();
        }

        // This function is called when the behaviour becomes disabled or inactive
        private void OnDisable() {
            DisableInputs();
        }

        #endregion Unity Methods

        #region Custom Methods

        private void EnableInputs() {
            _mapActions.Enable();

            _mapActions.Movement.performed += OnMovementPerformed;
            _mapActions.Movement.canceled += OnMovementCanceled;

            _mapActions.Jump.performed += OnJumpPerformed;
        }

        private void DisableInputs() {
            _mapActions.Movement.performed -= OnMovementPerformed;
            _mapActions.Movement.canceled -= OnMovementCanceled;

            _mapActions.Jump.performed -= OnJumpPerformed;
            _mapActions.GroundPound.performed -= OnGroundPoundPerformed;

            _mapActions.Disable();
        }

        private void OnMovementPerformed(InputAction.CallbackContext context) {
            ColourLogger.Log(this, $"Movement performed: {context.ReadValue<float>()}");
            player.movement.SetMoveDirection(context.ReadValue<float>());
        }

        private void OnMovementCanceled(InputAction.CallbackContext context) {
            player.movement.SetMoveDirection(0f);
        }

        private void OnJumpPerformed(InputAction.CallbackContext context) {
            //if (player.isJumping) {
            //    return;
            //}

            if (!player.CheckIfGrounded()) {
                ColourLogger.Log(this, "not grounded");
                return;
            }

            ColourLogger.Log(this, "Jump performed");
            player.movement.Jump();
        }

        private void EnableGroundPound() {
            _mapActions.GroundPound.performed += OnGroundPoundPerformed;
        }

        private void DisableGroundPound() {
            _mapActions.GroundPound.performed -= OnGroundPoundPerformed;
        }

        private void OnGroundPoundPerformed(InputAction.CallbackContext context) {
            if (!player.isJumping) {
                return;
            }

            ColourLogger.Log(this, "Ground Pounded");
            player.movement.GroundPound();
        }

        #endregion Custom Methods
    }
}
