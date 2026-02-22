using UnityEngine;

namespace Brackeys2026
{
    public class BHFloor : MonoBehaviour
    {
        [SerializeField] private GameObject _floor;
        [SerializeField] private GameObject _crack;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {

        }

        // This function is called when the object becomes enabled and active
        private void OnEnable() {
            BossFinalStrike.OnImpact += RevealExit;
        }

        // This function is called when the behaviour becomes disabled or inactive
        private void OnDisable() {
            BossFinalStrike.OnImpact -= RevealExit;
        }




        // Update is called once per frame
        void Update() {

        }

        private void RevealExit() {
            _crack.SetActive(true);
            _floor.SetActive(false);
        }
    }
}
