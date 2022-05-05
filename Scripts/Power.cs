using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public float Value => _value;
    public FloatEvent onChangePower;
    [ShowOnly][SerializeField] private float _value;
    [ShowOnly][SerializeField] private bool _full;
    [SerializeField] private float _countAdd;
    [SerializeField] private bool _everyTick;

    public void SetPower(float amount)
    {
        _value = Mathf.Clamp(amount, 0, 100);
        onChangePower?.Invoke(_value);
    }
    public void AddPower()
    {
        if (_everyTick)
            _value += _countAdd * Time.deltaTime;
        else
        {
            _value += _countAdd;
        }
        _value = Mathf.Clamp(_value, 0, 100);
        onChangePower?.Invoke(_value);
    }
    public void ResetPower()
    {
        _value = 0;
        onChangePower?.Invoke(_value);
    }
    public bool CheckFull()
    {
        return _value >= 100;
    }
}
