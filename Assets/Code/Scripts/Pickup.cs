using System;
using UnityEngine;

namespace Brackeys2026
{
    public class Pickup : MonoBehaviour, IInteractable
    {
        #region Variables

        [SerializeField] protected ToolsAndAbilities _pickedUpItem;

        public static event Action OnPickup;

        [SerializeField] private AudioClip _pickupSound;

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

        virtual public void Interact() {

        }

        virtual public void Interact(Player a_player) {
            a_player.EquipToolOrAbility(_pickedUpItem);

            if (_pickupSound != null) {
                SoundFXManager.Instance.PlaySound(_pickupSound, transform, 0.85f);
            }

            OnPickup?.Invoke();

            Destroy(gameObject);
        }

        #endregion Custom Methods
    }
}
