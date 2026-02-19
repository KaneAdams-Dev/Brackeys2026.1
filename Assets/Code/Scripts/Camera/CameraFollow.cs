using UnityEngine;

namespace Brackeys2026
{
    public class CameraFollow : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform _objectToFollow;
        [SerializeField] private float _lerp = 1f;

        [SerializeField] private Vector3 _cameraOffset;

        #endregion Variables

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start() {

        }

        // Update is called once per frame
        private void Update() {

        }

        private void LateUpdate() {
            if (_objectToFollow == null) {
                return;
            }

            Vector3 targetPos = new Vector3(_objectToFollow.position.x, _objectToFollow.position.y, transform.position.z) + _cameraOffset;
            transform.position = Vector3.Lerp(transform.position, targetPos, _lerp);
        }

        #endregion Unity Methods

        #region Custom Methods

        #endregion Custom Methods
    }
}
