using UnityEngine;

namespace Brackeys2026
{
    public class BreakableFloor : MonoBehaviour, IBreakable
    {
        #region Variables

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

        public void Break() {
            ColourLogger.Log(this, "Breakable hit");
            Destroy(gameObject);
        }

        #endregion Custom Methods
    }
}
