using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirection : MonoBehaviour
{
    #region VAR
    public Vector3Event onChangeDirection;
    [SerializeField] private Vector3 _first;
    [SerializeField] private Vector3 _second;
    [ShowOnly] [SerializeField] private bool _needChange;
    [ShowOnly] [SerializeField] private bool _activated;
    #endregion

    #region MONO
    private void OnEnable()
    {
        onChangeDirection?.Invoke(_first);
    }
    #endregion
    
    #region FUNC
    public void SetNeed()
    {
        _needChange = true;
    }
    public void TryChange()
    {
        if (_needChange && ! _activated)
        {
            onChangeDirection?.Invoke(_second);
            _activated = true;
        }
    }
    #endregion
}
