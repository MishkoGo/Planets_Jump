using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeedByDistance : MonoBehaviour
{
    #region VAR
    public FloatEvent onSpeedFast;
    public FloatEvent onSpeedNormal;
    [SerializeField] private Transform _targetT;
    [SerializeField] private float _fastDistance;
    
    [SerializeField] private float _normalFactor;
    [SerializeField] private float _fastFactor;
    private bool isFast;
    #endregion

    #region MONO
    private void Update()
    {
        if ((Vector3.Distance(transform.position, _targetT.position) > _fastDistance))
        {
            if (isFast) return;
            
            onSpeedFast?.Invoke(_fastFactor);
            isFast = true;
        }
        else
        {
            if (!isFast) return;
            
            onSpeedNormal?.Invoke(_normalFactor);
            isFast = false;
        }
    }
    #endregion
}
