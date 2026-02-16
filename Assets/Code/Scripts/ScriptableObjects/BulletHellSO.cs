using KabejaDevTools;
using UnityEngine;

namespace Brackeys2026
{
    public enum BHDifficulties
    {
        Basic,
        Inter,
        Advance,
    }

    [CreateAssetMenu(fileName = "BulletHellSO", menuName = "Scriptable Objects/BulletHellSO")]
    public class BulletHellSO : BaseSO
    {
        [Header("Combat")]
        [SerializeField] private int _health;
        public int Health => _health;

        [Space(5)]

        [SerializeField] private BHDifficulties _attack;
        public BHDifficulties Attack => _attack;

        [SerializeField] private float _attackSpeed;
        public float AttackSpeed => _attackSpeed;

        [SerializeField] private GameObject _projectile;
        public GameObject Projectile => _projectile;


        [Header("Movement")]
        [SerializeReference] private BHDifficulties _movement;
        public BHDifficulties Movement => _movement;

        [SerializeField] private float _moveSpeed;
        public float MoveSpeed => _moveSpeed;
    }
}
