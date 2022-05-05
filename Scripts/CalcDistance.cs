using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcDistance : MonoBehaviour,ICanSwitch
{
    [SerializeField] private bool _active;
    [SerializeField] private IntWithEvent hight;
    [SerializeField] private Transform _targetT;
    [SerializeField] private Transform _startT;
    [SerializeField] private float scale;
    
    
    private void OnEnable()
    {
        Activate();
    }
    private void OnDisable()
    {
        Deactivate();
    }
    void Update()
    {
        if (_active)
            Calc();
    }
    private void Calc()
    {
        hight.Count = (int) ((_targetT.position.y - _startT.position.y) * scale);
    }
    public void Activate()
    {
        _active = true;
    }

    public void Deactivate()
    {
        _active = false;
    }

    public void Switch()
    {
        _active = !_active;
    }
}
