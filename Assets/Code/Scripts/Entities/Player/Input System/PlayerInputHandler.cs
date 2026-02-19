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

        private bool _isInteracting;

        public Vector2 boxSize = new Vector2(1f, 0.8f);
        public float castDistance = 1.5f;
        public LayerMask interactableLayer;
        public Vector3 pivotOffet = new Vector3(0, 2.5f, 0);

        public Vector2 facingDirection = Vector2.right;

        #endregion Variables

        #region Unity Methods

        // Awake is called when the script instance is being loaded
        private void Awake() {
            playerActions = new PlayerActions();
            _mapActions = playerActions.Metroidvania;

            ColourLogger.RegisterColour(this, "cyan");

            _isInteracting = false;
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
                EnableGun();
            }

            if (Keyboard.current.hKey.wasPressedThisFrame) {
                EnableSword();
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

        // Implement this OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn
        private void OnDrawGizmos() {
            Gizmos.color = Color.yellow;

            //if (_isInteracting) {
            //    ColourLogger.Log(this, "Is Interacting");
            //}

            //Gizmos.DrawWireCube(transform.position, (transform.right * (player.animator.transform.position.x < 0f ? -1 : 1)));

            Vector3 center = transform.position + (Vector3)(new Vector2(player.animator.transform.localScale.x, 0).normalized * castDistance * 0.5f) + pivotOffet;
            Vector3 size = new Vector3(boxSize.x, boxSize.y, 0f);

            Gizmos.DrawWireCube(center, size);
        }

        #endregion Unity Methods

        #region Custom Methods

        private void EnableInputs() {
            _mapActions.Enable();

            _mapActions.Movement.performed += OnMovementPerformed;
            _mapActions.Movement.canceled += OnMovementCanceled;

            _mapActions.Jump.performed += OnJumpPerformed;
            _mapActions.Jump.canceled += OnJumpReleased;

            _mapActions.Interact.performed += OnInteractPerformed;
            _mapActions.Interact.canceled += OnInteractCanceled;
        }

        private void DisableInputs() {
            _mapActions.Movement.performed -= OnMovementPerformed;
            _mapActions.Movement.canceled -= OnMovementCanceled;

            _mapActions.Jump.performed -= OnJumpPerformed;
            _mapActions.Jump.canceled -= OnJumpReleased;

            _mapActions.Interact.performed -= OnInteractPerformed;
            _mapActions.Interact.canceled -= OnInteractCanceled;

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

        private void OnInteractPerformed(InputAction.CallbackContext context) {
            ColourLogger.Log(this, "Interact Pressed");
            _isInteracting = true;
            //Physics2D.BoxCast(transform.position, new Vector2(2, 5), 0f, transform.right, 0.25f);

            //RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, Vector2.right, 0, Vector2.zero);
            //foreach (RaycastHit2D hit in hits) {
            //    ColourLogger.Log(this, $"I hit: {hit.transform.gameObject.name}");
            //}
            //if (hit.transform.gameObject.TryGetComponent(out IInteractable interact)) {
            //    interact.Interact();
            //    ColourLogger.Log(this, $"Hit{}")
            //}

            RaycastHit2D hit = Physics2D.BoxCast(transform.position + pivotOffet, boxSize, 0f, new Vector2(player.animator.transform.localScale.x, 0).normalized, castDistance, interactableLayer);
            if (hit.collider != null) {
                ColourLogger.Log(this, $"Interacting with{hit.transform.name}");
                hit.transform.GetComponent<IInteractable>()?.Interact(player);
            }
        }

        private void OnInteractCanceled(InputAction.CallbackContext context) {
            _isInteracting = false;
        }

        internal void EnableGroundPound() {
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

        internal void EnableSword() {
            _mapActions.SwordAttack.performed += OnSwordAttackPerformed;
            player.animator.EquipSword();
        }


        private void DisableSword() {
            _mapActions.SwordAttack.performed -= OnSwordAttackPerformed;
        }

        private void OnSwordAttackPerformed(InputAction.CallbackContext context) {
            ColourLogger.Log(this, "Sword Attack Pressed");
            player.animator.EquipSword();
        }

        internal void EnableGun() {
            _mapActions.GunAttack.performed += OnGunAttackPerformed;
        }

        private void DisableGun() {
            _mapActions.GunAttack.performed -= OnGunAttackPerformed;
        }

        private void OnGunAttackPerformed(InputAction.CallbackContext context) {
            player.animator.EquipGun();
        }

        #endregion Custom Methods
    }
}
