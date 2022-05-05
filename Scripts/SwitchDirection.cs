using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDirection : MonoBehaviour
{
    #region VAR
    public Vector3Event onChangeDirection;
    [SerializeField] private Vector3 _first;
    [SerializeField] private Vector3 _second;
    [SerializeField] private bool _once;
    [ShowOnly] [SerializeField] private bool _secondIsActive;
    
    #endregion

    #region MONO
    private void OnEnable()
    {
      onChangeDirection?.Invoke(_first);
    }
    #endregion
    
    #region FUNC
    public void Switch()
    {
        if (_once && _secondIsActive)
            return;
        
        if (_secondIsActive)
        {
            onChangeDirection?.Invoke(_first);
            _secondIsActive = false;
        }
        else
        {
            onChangeDirection?.Invoke(_second);
            _secondIsActive = true;
        }
    }
    #endregion
}
