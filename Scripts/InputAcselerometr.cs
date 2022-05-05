using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAcselerometr : MonoBehaviour
{
    #region VAR
    public Vector3Event onDirectionUpdate;
    [SerializeField] private bool _active;
    [SerializeField] private float _minValue = 0.1f;
    #endregion

    #region MONO
    private void OnEnable()
    {
        Activate();
    }
    private void OnDisable()
    {
        Deactivate();
    }
    private void Update()
    {
        if (_active)
        {
            DirectionControl();
        }
    }
    #endregion

    #region FUNC
    private void DirectionControl()
    {
        Vector3 dir = Input.acceleration;

        if (Mathf.Abs(dir.y) < _minValue)
            dir.y = 0;
        if (Mathf.Abs(dir.x) < _minValue)
            dir.x = 0;
        
        onDirectionUpdate?.Invoke(dir);
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
    #endregion
}