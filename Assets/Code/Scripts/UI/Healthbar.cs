using UnityEngine;

namespace Brackeys2026
{
    public class Healthbar : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject[] _hearts;

        #endregion Variables

        #region Unity Methods

        // This function is called when the object becomes enabled and active
        private void OnEnable() {
            foreach (var heart in _hearts) {
                heart.SetActive(true);
            }

            Player.OnHealthChange += OnHealthUpdate;
        }

        // This function is called when the behaviour becomes disabled or inactive
        private void OnDisable() {
            Player.OnHealthChange -= OnHealthUpdate;
        }

        #endregion Unity Methods

        #region Custom Methods

        public void OnHealthUpdate(int a_newHealth) {
            if (_hearts.Length <= 0) {
            }

            for (int i = 0; i < _hearts.Length; i++) {
                //if (i > a_newHealth) {
                //    _hearts[i].SetActive(false);
                //} else {
                //    _hearts[i].SetActive(true);
                //}

                _hearts[i].SetActive(i < a_newHealth);
            }
        }

        #endregion Custom Methods
    }
}
