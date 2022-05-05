using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGravity : MonoBehaviour,ICanSwitch
{
    #region VAR
    public FloatEvent onGravityUpdate;
    [SerializeField] private bool _active;
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _scale = 1;
    [SerializeField] private float _gravity = 1;
    private Rigidbody2D _rigidbody2D;
 
    #endregion

    #region MONO
    private void OnEnable()
    {
        if (_rigidbody2D == null)
            _rigidbody2D = GetComponent<Rigidbody2D>();
        
        Activate();
    }
    private void OnDisable()
    {
        Deactivate();
    }
    #endregion

    #region FUNC
    public void UpdateGravity(float gravity)
    {
        _gravity = gravity;
        _rigidbody2D.gravityScale = _scale * _gravity;
        onGravityUpdate?.Invoke(_gravity);
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
