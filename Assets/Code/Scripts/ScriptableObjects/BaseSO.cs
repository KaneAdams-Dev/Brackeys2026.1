using UnityEngine;

namespace KabejaDevTools
{
    public class BaseSO : ScriptableObject
    {
        [SerializeField] private Sprite _icon;
        public Sprite Icon => _icon;
    }
}
