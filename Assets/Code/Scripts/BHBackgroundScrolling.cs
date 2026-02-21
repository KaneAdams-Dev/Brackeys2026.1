using UnityEngine;

namespace Brackeys2026
{
    public class BHBackgroundScrolling : MonoBehaviour
    {
        public float _lowY;
        public float _highY;
        public float _speed;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            ColourLogger.Log(this, transform.position.ToString());
            if (transform.position.y < _lowY) {
                transform.position = new Vector3(transform.position.x, _highY, transform.position.z);
            }
        }

        // This function is called every fixed framerate frame, if the MonoBehaviour is enabled
        private void FixedUpdate() {
            transform.Translate(new Vector3(0, _speed * Time.deltaTime * -1f, 0));
        }


    }
}
