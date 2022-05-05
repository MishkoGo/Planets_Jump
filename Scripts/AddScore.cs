using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    public IntEvent onChange;
    [SerializeField] private IntWithEvent _score;
    

    public void Add()
    {
        _score.Count++;
        onChange?.Invoke(_score.Count);
    }
}
