using System;
using UnityEngine;

namespace Rings
{
    [CreateAssetMenu(menuName = "Service/BoolWithEvent")]
    public class BoolWithEvent : ScriptableObject
    {
        public event Action<bool> onChanged;
        public bool Value
        {
            get => _value;
            set
            {
                _value = value;
                onChanged?.Invoke(_value);
            }
        }
    
        [SerializeField] private bool _value;
    }
}
