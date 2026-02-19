using UnityEngine;

namespace Brackeys2026
{
    public class SwordInStone : Pickup, IInteractable
    {
        #region Variables

        [SerializeField] private GameObject _sword;

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

        override public void Interact(Player a_player) {
            if (_sword.activeInHierarchy) {
                _sword.SetActive(false);
            }

            base.Interact(a_player);
        }

        #endregion Custom Methods
    }
}
