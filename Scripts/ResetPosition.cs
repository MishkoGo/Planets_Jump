using System;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    private Vector3 _startPos;

    private void Start()
    {
        if (_transform == null)
        {
            _startPos = transform.position;
        }
    }
    public void ResetPos()
    {
        if (_transform == null)
            transform.position = _startPos;
        else
        {
            transform.position = _transform.position;
        }
       
    }
}
