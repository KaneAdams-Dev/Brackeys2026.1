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

        [Header("Visuals")]
        [SerializeField] private RuntimeAnimatorController _anim;
        public RuntimeAnimatorController Anim => _anim;


        [Header("Combat")]
        [SerializeField] private int _health;
        public int Health => _health;

        [Space(5)]

        [SerializeField] private BHDifficulties _attack;
        public BHDifficulties Attack => _attack;

        [SerializeField] private float _fireRate;
        public float FireRate => _fireRate;

        [SerializeField] private GameObject _projectile;
        public GameObject Projectile => _projectile;

        [SerializeField] private RuntimeAnimatorController _projectileAnim;
        public RuntimeAnimatorController ProjectileAnim => _projectileAnim;

        [SerializeField] private float _projectileSpeed;
        public float ProjectileSpeed => _projectileSpeed;

        [SerializeField] private int _projectileStrength;
        public int ProjectileStrength => _projectileStrength;


        [Header("Movement")]
        [SerializeReference] private BHDifficulties _movement;
        public BHDifficulties Movement => _movement;

        [SerializeField] private float _moveSpeed;
        public float MoveSpeed => _moveSpeed;

        [Space(10)]
        [SerializeField] private GameObject _droppableItem;
        public GameObject DroppableItem => _droppableItem;
    }
}
