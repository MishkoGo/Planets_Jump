using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



[System.Serializable]
public class Vector3Event : UnityEvent<Vector3> { };

public class InputDirection : MonoBehaviour, ICanSwitch
{
    #region VAR
    public Vector3Event onDirectionUpdate;
    [SerializeField] private bool _active;
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _minDistance = 10;
    private Vector3 beginPos;
    private Vector3 curPos;
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
        if (Input.GetMouseButtonDown(0))
        {
            beginPos = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
        }

        if (Input.GetMouseButton(0))
        {
            curPos = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);

            if (Vector3.Distance(beginPos, curPos) > _minDistance)
            {
                _direction = curPos - beginPos;
                _direction = _direction.normalized;
            }
            else
            {
                _direction = Vector3.zero;
            }

            onDirectionUpdate?.Invoke(_direction);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _direction = Vector3.zero;
            onDirectionUpdate?.Invoke(_direction);
        }
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

