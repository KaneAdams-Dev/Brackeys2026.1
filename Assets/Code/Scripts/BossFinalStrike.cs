using System;
using UnityEngine;

namespace Brackeys2026
{
    public class BossFinalStrike : MonoBehaviour
    {
        public static event Action OnImpact;
        [SerializeField] private AudioClip _shotClip;
        [SerializeField] private AudioClip _impactClip;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {
            SoundFXManager.Instance.PlaySound(_shotClip, transform, 1f);
        }

        // Update is called once per frame
        void Update() {

        }

        // OnCollisionEnter2D is called when this collider2D/rigidbody2D has begun touching another rigidbody2D/collider2D (2D physics only)
        private void OnCollisionEnter2D(Collision2D collision) {
            OnImpact?.Invoke();
            SoundFXManager.Instance.PlaySound(_impactClip, transform, 1f);
            ObjectPoolManager.ReturnToPool(gameObject);
        }



    }
}
