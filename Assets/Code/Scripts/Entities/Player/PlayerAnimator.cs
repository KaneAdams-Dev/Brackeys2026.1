using System.Collections;
using UnityEngine;

namespace Brackeys2026
{
    public class PlayerAnimator : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Animator _anim;

        private string _currentClip;

        internal bool canInterupt;

        private int _swordLayer;
        private int _gunLayer;

        [Range(0, 1)][SerializeField] private float _layerFadeDuration = 0.5f;

        #endregion Variables

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start() {
            canInterupt = true;

            _swordLayer = _anim.GetLayerIndex("Sword");
            _gunLayer = _anim.GetLayerIndex("Gun Up");

            Unarm();
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

        internal void EquipSword() {
            //_anim.SetLayerWeight(_gunLayer, 0f);
            //_anim.SetLayerWeight(_swordLayer, 1f);

            StartCoroutine(FadeInWeaponLayer(_gunLayer, 0f, _layerFadeDuration));
            StartCoroutine(FadeInWeaponLayer(_swordLayer, 1f, _layerFadeDuration));


            ColourLogger.Log(this, $"Gun: {_anim.GetLayerWeight(_gunLayer)}, Sword {_anim.GetLayerWeight(_swordLayer)}");
        }

        internal void EquipGun() {
            //_anim.SetLayerWeight(_swordLayer, 0f);
            //_anim.SetLayerWeight(_gunLayer, 1f);

            StartCoroutine(FadeInWeaponLayer(_swordLayer, 0f, _layerFadeDuration));
            StartCoroutine(FadeInWeaponLayer(_gunLayer, 1f, _layerFadeDuration));

            ColourLogger.Log(this, $"Gun: {_anim.GetLayerWeight(_gunLayer)}, Sword {_anim.GetLayerWeight(_swordLayer)}");
        }

        internal void Unarm() {
            //_anim.SetLayerWeight(_gunLayer, 0f);
            StartCoroutine(FadeInWeaponLayer(_gunLayer, 0f, _layerFadeDuration));
            //_anim.SetLayerWeight(_swordLayer, 0f);
            StartCoroutine(FadeInWeaponLayer(_swordLayer, 0f, _layerFadeDuration));

            ColourLogger.Log(this, $"Gun: {_anim.GetLayerWeight(_gunLayer)}, Sword {_anim.GetLayerWeight(_swordLayer)}");
        }

        IEnumerator FadeInWeaponLayer(int a_layerIndex, float a_targetWeight, float a_duration) {
            float time = 0f;

            float startingWeight = _anim.GetLayerWeight(a_layerIndex);

            float layerWeight;
            while (time < a_duration) {
                layerWeight = Mathf.Lerp(startingWeight, a_targetWeight, time / a_duration);
                _anim.SetLayerWeight(a_layerIndex, layerWeight);
                time += Time.deltaTime;

                yield return null;
            }

            _anim.SetLayerWeight(a_layerIndex, a_targetWeight);
        }

        #endregion Custom Methods
    }
}
