using System;
using UnityEngine;


[CreateAssetMenu(menuName = "Service/IntWithEvent")]
public class IntWithEvent : ScriptableObject
{
    public event Action<int> onChanged;
    public int Count
    {
        get => _count;
        set
        {
            _count = value;
            onChanged?.Invoke(_count);
        }
    }
    
    [SerializeField] private int _count;
}