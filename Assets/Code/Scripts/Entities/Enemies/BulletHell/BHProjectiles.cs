using UnityEngine;

namespace Brackeys2026
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class BHProjectiles : MonoBehaviour
    {
        #region Variables

        [SerializeField] protected Rigidbody2D _rbdy;
        [SerializeField] private SpriteRenderer spriteRend;

        #endregion Variables

        #region Unity Methods

        // Awake is called when the script instance is being loaded
        private void Awake() {
            if (spriteRend == null) {
                spriteRend = GetComponent<SpriteRenderer>();
            }
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start() {

        }

        // Update is called once per frame
        private void Update() {
            if (!spriteRend.isVisible) {
                ObjectPoolManager.ReturnToPool(gameObject);
            }
        }

        // This function is called every fixed framerate frame, if the MonoBehaviour is enabled
        private void FixedUpdate() {
            Move();
        }


        #endregion Unity Methods

        #region Custom Methods

        private void Move() {
            _rbdy.linearVelocityY = -15f;
        }

        #endregion Custom Methods
    }
}
