using UnityEngine;

namespace Brackeys2026
{
    public class SwordInStone : Pickup, IInteractable
    {
        #region Variables

        [SerializeField] private GameObject _sword;

        #endregion Variables

        #region Unity Methods

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
