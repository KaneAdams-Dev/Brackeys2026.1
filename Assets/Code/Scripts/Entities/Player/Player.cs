using UnityEngine;

namespace Brackeys2026
{
    public class Player : BaseEntities
    {
        #region Variables

        [Header("References")]
        [SerializeField] internal PlayerInputHandler inputHandler;
        [SerializeField] internal PlayerMovement movement;

        [Header("Stats")]
        [SerializeField] internal float moveSpeed = 10f;

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

        #endregion Custom Methods
    }
}
