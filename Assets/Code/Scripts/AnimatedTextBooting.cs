using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace KabejaDevTools
{
    public class AnimatedTextBooting : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI bootSymbol;
        private List<string> loopedSymbols;
        [SerializeField] private float animationSpeed = 0.05f;  // Speed between "frame" changes

        private WaitForSeconds waitTime;
        private int currentIndex = 0;
        private Coroutine bootCoroutine;

        // Awake is called when the script instance is being loaded
        private void Awake() {
            loopedSymbols = new List<string> {
                "\u0041", "\u0042", "\u0043", "\u0044", "\u0045", "\u0046",
                "\u0047", "\u0048", "\u0049", "\u004A", "\u004B", "\u004C",
                "\u004D", "\u004E", "\u004F", "\u0050", "\u0051",
                "\u0052", "\u0053", "\u0054", "\u0055", "\u0056",
                "\u0057", "\u0058", "\u0059", "\u005A",
                "\u0061", "\u0062", "\u0063", "\u0064", "\u0065", "\u0066",
                "\u0067", "\u0068", "\u0069", "\u006A", "\u006B", "\u006C",
                "\u006D", "\u006E", "\u006F", "\u0070", "\u0071",
                "\u0072", "\u0073", "\u0074", "\u0075", "\u0076",
                "\u0077", "\u0078", "\u0079", "\u007A"
            };
        }

        // This function is called when the object becomes enabled and active
        private void OnEnable() {
            bootCoroutine = StartCoroutine(BootSymbolCoroutine());
        }

        // This function is called when the behaviour becomes disabled or inactive
        private void OnDisable() {
            StopBootAnimation();
        }


        /// <summary>
        /// Resets animation then plays loop from beginning
        /// </summary>
        public void StartBootAnimation() {
            StopBootAnimation();
            currentIndex = 0;
            bootCoroutine = StartCoroutine(BootSymbolCoroutine());
        }

        /// <summary>
        /// Closes the active animation ready to restart
        /// </summary>
        public void StopBootAnimation() {
            if (bootCoroutine != null) {
                StopCoroutine(bootCoroutine);
            }
        }

        /// <summary>
        /// Loops through the symbols list to create an animated boot symbol
        /// </summary>
        /// <returns>waits user entered time</returns>
        private IEnumerator BootSymbolCoroutine() {
            currentIndex = 0;

            waitTime = new WaitForSeconds(animationSpeed);

            while (true) {
                bootSymbol.text = loopedSymbols[currentIndex];
                currentIndex = (currentIndex + 1) % loopedSymbols.Count;    // modulus of count resets index to 0 when more than list size

                yield return waitTime;
            }
        }
    }
}
