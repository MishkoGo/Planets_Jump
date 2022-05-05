using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartImpulse : MonoBehaviour
{
    #region VAR
    public UnityEvent onStart;
    public UnityEvent onEnd;
    [SerializeField] private float _power = 100;
    [SerializeField] private Vector2 _direction;
    private Rigidbody2D _rigidbody2D;
    [Space(10)]
    [SerializeField] private Condition _condition;
    [SerializeField] private float _startDelay = 2f;
    [SerializeField] private float _endDelay = 2f;
    #endregion

    #region MONO
    private void OnEnable()
    {
        if (_rigidbody2D == null)
            _rigidbody2D = GetComponent<Rigidbody2D>();
        
        Activate();
    }
    #endregion

    #region FUNC
    public void Activate()
    {
        Invoke(nameof(Impulse), _startDelay);
    }
    private void Impulse()
    {
        if(_rigidbody2D == null)
            return;
        if (_condition != null && !_condition.CheckCondition())
            return;
        
        onStart?.Invoke();
        
        _rigidbody2D.AddRelativeForce(_direction * _power);
        Invoke(nameof(EndDelay), _endDelay);
    }
    private void EndDelay()
    {
        onEnd?.Invoke();
    }
    #endregion
}
