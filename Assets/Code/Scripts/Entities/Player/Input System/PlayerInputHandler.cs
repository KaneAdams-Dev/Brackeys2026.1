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


        internal float horizontalInput;

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
            _mapActions.Jump.canceled += OnJumpReleased;
        }

        private void DisableInputs() {
            _mapActions.Movement.performed -= OnMovementPerformed;
            _mapActions.Movement.canceled -= OnMovementCanceled;

            _mapActions.Jump.performed -= OnJumpPerformed;
            _mapActions.Jump.canceled -= OnJumpReleased;

            _mapActions.GroundPound.performed -= OnGroundPoundPerformed;
            _mapActions.GroundPound.canceled -= OnGroundPoundReleased;

            _mapActions.Disable();
        }

        private void OnMovementPerformed(InputAction.CallbackContext context) {
            horizontalInput = context.ReadValue<float>();
            player.movement.SetMoveDirection(horizontalInput);
        }

        private void OnMovementCanceled(InputAction.CallbackContext context) {
            horizontalInput = 0;
            player.movement.SetMoveDirection(horizontalInput);
        }

        private void OnJumpPerformed(InputAction.CallbackContext context) {

            if (player.isJumping) {
                player.movement.DoubleJump();
            }

            player.movement.BeginJumpBuffer();
        }

        private void OnJumpReleased(InputAction.CallbackContext context) {
            player.movement.ResetJumpTime();
        }

        private void EnableGroundPound() {
            _mapActions.GroundPound.performed += OnGroundPoundPerformed;
            _mapActions.GroundPound.canceled += OnGroundPoundReleased;
        }

        private void DisableGroundPound() {
            _mapActions.GroundPound.performed -= OnGroundPoundPerformed;
            _mapActions.GroundPound.canceled -= OnGroundPoundReleased;
        }

        private void OnGroundPoundPerformed(InputAction.CallbackContext context) {
            player.movement.GroundPound();
        }

        private void OnGroundPoundReleased(InputAction.CallbackContext context) {
            //player.movement.StopGroundPound();
        }

        #endregion Custom Methods
    }
}
