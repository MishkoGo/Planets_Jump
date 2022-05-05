using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitSpeedPhys : MonoBehaviour,ICanSwitch
{
    [SerializeField] private bool _active = true;
    [SerializeField] private float _maxSpeed = 5;
   
    private Rigidbody2D _rigidbody2D;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
      
    }
    private void Update()
    {
        if (_active)
            if (_rigidbody2D.velocity.magnitude > _maxSpeed)
                _rigidbody2D.velocity = _rigidbody2D.velocity.normalized * _maxSpeed;
    }
    public void Activate()
    {
        _active = true;
    }
    public void Deactivate()
    {
        _active = false;
        _rigidbody2D.velocity = Vector2.zero;
    }
    public void Switch()
    {
        throw new System.NotImplementedException();
    }
}
