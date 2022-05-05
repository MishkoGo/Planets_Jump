using System;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable] public class FloatEvent : UnityEvent<float> {};

public class IncreaseFloat : MonoBehaviour
{
    #region VAR

    public FloatEvent onUpdate;
    public float CurValue => _curValue;
    [Space(10)] [SerializeField] private bool _active;
    [Space(10)] [SerializeField] private float _startValue;
    [SerializeField] private float _targetValue;
    [ShowOnly] [SerializeField] private float _curValue;
    [Space(10)] [SerializeField] private float _speedChangeValue;
    [SerializeField] private float _reloadChange;

    #endregion

    #region FUNC
    private void OnEnable()
    {
        Activate();
    }
    private void OnDisable()
    {
        Deactivate();
    }
    public void Activate()
    {
        ResetState();
        _active = true;
        _curValue = _startValue;

        StartChange();
    }

    public void Deactivate()
    {
        _active = false;
        _curValue = 0;
        onUpdate?.Invoke(_curValue);
    }

    private void ResetState()
    {
        _curValue = _startValue;
    }

    private void StartChange()
    {
        ChangeControl();
    }

    private void ChangeControl()
    {
        if (!_active)
        {
            return;
        }

        if (_startValue < _targetValue && _curValue < _targetValue)
        {
            _curValue += _speedChangeValue;
            onUpdate?.Invoke(_curValue);
        }
        else if (_startValue > _targetValue && _curValue > _targetValue)
        {
            _curValue -= _speedChangeValue;
            onUpdate?.Invoke(_curValue);
        }

        Invoke(nameof(ChangeControl), _reloadChange);
    }

    #endregion
}

