using UnityEngine;

namespace Brackeys2026
{
    public class StaticCameraBoundaries : MonoBehaviour
    {
        #region Variables

        private Vector2 _screenBounds;
        [SerializeField] private float _objectWidth = 4f;
        [SerializeField] private float _objectHeight = 2f;

        private Vector3 viewPos;

        #endregion Variables

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start() {
            _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            ColourLogger.Log(this, $"Screenbounds: {_screenBounds}");
        }

        // Update is called once per frame
        private void Update() {

        }

        // LateUpdate is called every frame, if the Behaviour is enabled
        private void LateUpdate() {
            viewPos = transform.position;
            viewPos.x = Mathf.Clamp(viewPos.x, _screenBounds.x * -1 + _objectWidth, _screenBounds.x - _objectWidth);
            viewPos.y = Mathf.Clamp(viewPos.y, _screenBounds.y * -1 + _objectHeight, _screenBounds.y - _objectHeight);
            transform.position = viewPos;
        }

        #endregion Unity Methods

        #region Custom Methods

        #endregion Custom Methods
    }
}
