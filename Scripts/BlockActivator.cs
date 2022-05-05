using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockActivator : MonoBehaviour
{
    
    [SerializeField] private bool _active;
    [SerializeField] private Transform _target;
    [SerializeField] private List<Transform> _blocks;
    [SerializeField] private float _speed;
    [SerializeField] private float _distActivate;

    private void OnEnable()
    {
        if (_target == null)
        {
            _target = GameObject.FindGameObjectWithTag("player").transform;
        }
    }
    private void Update()
    {
        if(_active)
            ActivateControl();
    }

    private void ActivateControl()
    {
        if (_blocks[0].position.y - _distActivate < _target.position.y)
        {
            _blocks[0].gameObject.SetActive(true);
            _blocks.RemoveAt(0);
        }
    }
}
