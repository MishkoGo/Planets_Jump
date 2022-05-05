using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddImpulse : MonoBehaviour
{
    #region VAR
    [SerializeField] private float _power = 100;
    [SerializeField] private Vector2 _direction;
    private Rigidbody2D _rigidbody2D;
    [Space(10)]
    [SerializeField] private Condition _condition;
    [SerializeField] private float _timeReload = 0.1f;
    private bool _reloading;
    #endregion

    #region MONO
    private void OnEnable()
    {
        if (_rigidbody2D == null)
            _rigidbody2D = GetComponent<Rigidbody2D>();
        
        _reloading = false;
    }
    #endregion

    #region FUNC
    public void Impulse()
    {
        if(_rigidbody2D == null && _reloading)
            return;
        if (_condition != null && !_condition.CheckCondition())
            return;
        
        _rigidbody2D.AddRelativeForce(_direction * _power);
        Invoke(nameof(EndReload), _timeReload);
    }
    private void EndReload()
    {
        if (_reloading)
            _reloading = false;
    }
    #endregion
}
