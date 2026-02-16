using UnityEngine;

namespace Brackeys2026
{
    public class PlayerAnimator : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Animator _anim;

        private string _currentClip;

        internal bool canInterupt;

        #endregion Variables

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start() {
            canInterupt = true;
        }

        // Update is called once per frame
        private void Update() {

        }

        #endregion Unity Methods

        #region Custom Methods

        internal void UpdateAnimation(string a_newClip) {
            if (_currentClip == a_newClip) return;

            ColourLogger.Log(this, a_newClip);
            _currentClip = a_newClip;
            _anim.Play(_currentClip);
        }

        #endregion Custom Methods
    }
}
