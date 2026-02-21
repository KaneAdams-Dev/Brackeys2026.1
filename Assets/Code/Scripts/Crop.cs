using System;
using UnityEngine;

namespace Brackeys2026
{
    public class Crop : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject _plant;

        [SerializeField] private bool _isWatered;
        private bool _hasSeed;
        [SerializeField] private SpriteRenderer spriteRend;
        [SerializeField] private Sprite _Planted;

        public static event Action OnSeedPlanted;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {

            _plant.SetActive(false);
        }

        // Update is called once per frame
        void Update() {
            if (_isWatered) {
                GrowBeanStalk();
            }
        }

        public void Interact() {

        }

        public void Interact(Player player) {
            _hasSeed = player.hasSeed;
            spriteRend.sprite = _Planted;
            OnSeedPlanted?.Invoke();
        }

        private void GrowBeanStalk() {
            if (_plant.activeInHierarchy) return;

            if (_hasSeed) {
                _plant.SetActive(true);
            }
        }
    }
}
