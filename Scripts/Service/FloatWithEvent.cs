using System;
using UnityEngine;


[CreateAssetMenu(menuName = "Service/FloatWithEvent")]
public class FloatWithEvent : ScriptableObject
{
    public event Action<float> onChanged;

    public float Count
    {
        get => _count;
        set
        {
            _count = value;
            onChanged?.Invoke(_count);
        }
    }

    [SerializeField] private float _count;
}

