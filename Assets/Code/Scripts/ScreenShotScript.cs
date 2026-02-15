using UnityEngine;
using UnityEngine.InputSystem;

namespace KabejaDevTools
{
    /// <summary>
    /// This class is used to take screenshots throughout development for logs and marketing material.
    /// This is to be removed for the final build.
    /// </summary>
    public class ScreenShotScript : MonoBehaviour
    {
        [Tooltip("Turning this on causes screenshots at set times")]
        [SerializeField] private bool takeScreenshots = false;  // off by default to prevent spamming 

        [Tooltip("How long in seconds between screenshots")]
        [Range(1, 100)][SerializeField] private int timeSpan = 50;

        // Start is called before the first frame update
        private void Start() {
            if (takeScreenshots) {
                InvokeRepeating(nameof(TakeScreenshot), timeSpan, timeSpan);
            }
        }

        // Update is called once per frame
        private void Update() {
            // User can press F10 to manually create screenshot
            if (Keyboard.current.f10Key.wasPressedThisFrame) {
                TakeScreenshot();
            }
        }

        /// <summary>
        /// Takes screenshot of game screen and saves in project root folder
        /// </summary>
        private void TakeScreenshot() {
            ScreenCapture.CaptureScreenshot("GameScreenshot" + System.DateTime.Now.ToString("MM-dd-yy (HH-mm-ss)") + ".png");
            Debug.Log("Screenshot Taken");
        }
    }
}
