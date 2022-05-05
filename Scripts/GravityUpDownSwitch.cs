using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityUpDownSwitch : MonoBehaviour
{
    #region VAR
    [SerializeField] private float _scaleUp = 1;
    [SerializeField] private float _scaleDown = 1;
    private bool isUp; 
    private Rigidbody2D _rigidbody2D;
    private float _startScale = 1;
    #endregion

    #region MONO
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        if (_rigidbody2D != null)
            _startScale = _rigidbody2D.gravityScale;
    }
    private void OnEnable()
    {
        if (_rigidbody2D == null)
            _rigidbody2D = GetComponent<Rigidbody2D>();
        
        _rigidbody2D.gravityScale = _startScale;
    }
    private void FixedUpdate()
    {
        GravityControl();
    }
    #endregion

    #region FUNC
    private void GravityControl()
    {
        if (_rigidbody2D.velocity.y > 0 && !isUp)
        {
            _rigidbody2D.gravityScale = _scaleUp;
            isUp = true;
        }
        if (_rigidbody2D.velocity.y < 0 && isUp)
        {
            _rigidbody2D.gravityScale = _scaleDown;
            isUp = false;
        }   
    }
    #endregion
}
