using UnityEngine;

namespace Brackeys2026
{
    public class Titlecard : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _title;

        #endregion Variables

        #region Unity Methods

        //// Start is called once before the first execution of Update after the MonoBehaviour is created
        //private void Start() {
        //    Pickup.OnPickup += ShowText;
        //}

        // This function is called when the object becomes enabled and active
        private void OnEnable() {
            Pickup.OnPickup += ShowText;
        }

        // This function is called when the behaviour becomes disabled or inactive
        private void OnDisable() {
            Pickup.OnPickup -= ShowText;
        }

        // Update is called once per frame
        private void Update() {

        }

        #endregion Unity Methods

        #region Custom Methods

        private void ShowText() {
            _title.SetActive(true);

            Invoke(nameof(HideText), 5f);
        }

        private void HideText() {
            _title.SetActive(false);
        }

        #endregion Custom Methods
    }
}
