using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shayba : MonoBehaviour
{
    public UnityEvent onGoalUp;
    public UnityEvent onGoalDown;
    private Rigidbody2D _rigidbody2D;
    
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("vorotaUp"))
        {
            onGoalUp?.Invoke();
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.angularVelocity = 0;
        }
        if (other.CompareTag("vorotaDown"))
        {
            onGoalDown?.Invoke();
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.angularVelocity = 0;
        }
    }
}
