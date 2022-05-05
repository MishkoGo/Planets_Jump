using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Types/ColorType")]
public class ColorType : ScriptableObject
{
    public Color Color => _color;
    [SerializeField] private Color _color;
}
