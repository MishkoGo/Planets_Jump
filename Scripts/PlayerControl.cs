using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour, ICanSwitch
{
    #region VAR
    [ShowOnly] [SerializeField] private bool _drag;
    [SerializeField] private bool _active; 
    [SerializeField] private bool _test;
    [SerializeField] private bool _isUp;
    [SerializeField] private float _scale;
    [SerializeField] private LimitPosition _limitPositionUp;
    [SerializeField] private LimitPosition _limitPositionDown;
    [SerializeField] private Rigidbody2D _rigidbody2DUp;
    [SerializeField] private Rigidbody2D _rigidbody2DDown;
    private Vector2 _newPos;
    private Vector2 _lastPos;
    private Vector3 _touchDelta;
    private int fingerIDUp;
    private int fingerIDDown;

    #endregion

    #region MONO
    private void FixedUpdate()
    {
        if (_active)
        {
            ControlDrag();
        }
    }
    #endregion

    #region FUNC
    #endregion

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
        throw new NotImplementedException();
    }
    private void ControlDrag()
    {
        if (Input.touchCount == 0 || Input.touchCount > 2)
            return;

        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.touches[i].position);


            if (worldPos.y > 0)
            {
                fingerIDUp = Input.touches[i].fingerId;
                SetPos(worldPos, _rigidbody2DUp, _limitPositionUp);
            }
            else
            {
                fingerIDDown = Input.touches[i].fingerId;
                SetPos(worldPos, _rigidbody2DDown, _limitPositionDown);
            }
        }

        return;

        for (int i = 0; i < Input.touchCount; i++)
        { 
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            
            if (Input.touches[i].phase == TouchPhase.Began)
            {
                if (worldPos.y > 0)
                {
                    if (fingerIDUp < 0)
                    {
                        fingerIDUp = Input.touches[i].fingerId;
                        SetPos(worldPos, _rigidbody2DUp, _limitPositionUp);
                    }
                }
                else
                {
                    if (fingerIDDown < 0)
                    {
                        fingerIDDown = Input.touches[i].fingerId;
                        SetPos(worldPos, _rigidbody2DUp, _limitPositionUp);
                    }
                }
            }
            else if (Input.touches[i].phase == TouchPhase.Moved)
            {
                
            }
         

            if (worldPos.y > 0)
            {
                SetPos(worldPos, _rigidbody2DUp, _limitPositionUp);
            }
            else
            {
                SetPos(worldPos, _rigidbody2DDown, _limitPositionDown);
            }
            
            return;
        }
        if (Input.touchCount == 2)
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
            Vector3 worldPos2 = Camera.main.ScreenToWorldPoint(Input.touches[1].position);
            
            if (worldPos.y > 0)
            {
                SetPos(worldPos, _rigidbody2DUp, _limitPositionUp);
            }
            else
            {
                SetPos(worldPos, _rigidbody2DDown, _limitPositionDown);
            }
            if (worldPos2.y < 0)
            {
                SetPos(worldPos2, _rigidbody2DUp, _limitPositionUp);
            }
            else
            {
                SetPos(worldPos2, _rigidbody2DDown, _limitPositionDown);
            }
            return;
        }
    }
    private void SetPos(Vector3 pos, Rigidbody2D rigidbody2D, LimitPosition limitPosition)
    {
        if (limitPosition != null)
        {
            pos = limitPosition.LimitPos(pos);
        }

        rigidbody2D.MovePosition(pos);
    }
}
