using UnityEngine;

namespace Brackeys2026
{
    public class Inventory : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _seed;

        #endregion Variables

        #region Unity Methods

        //// Start is called once before the first execution of Update after the MonoBehaviour is created
        //private void Start() {
        //    Player.OnSeedPickup += AddToInventory;
        //    Crop.OnSeedPlanted += RemoveFromInventory;
        //}

        // This function is called when the object becomes enabled and active
        private void OnEnable() {
            Player.OnSeedPickup += AddToInventory;
            Crop.OnSeedPlanted += RemoveFromInventory;
        }

        // This function is called when the behaviour becomes disabled or inactive
        private void OnDisable() {
            Player.OnSeedPickup -= AddToInventory;
            Crop.OnSeedPlanted -= RemoveFromInventory;
        }

        // Update is called once per frame
        private void Update() {

        }

        #endregion Unity Methods

        #region Custom Methods

        private void AddToInventory() {
            _seed.SetActive(true);
        }

        private void RemoveFromInventory() {
            _seed.SetActive(false);
        }

        #endregion Custom Methods
    }
}
