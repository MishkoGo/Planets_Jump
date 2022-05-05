using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpeedPhysUpDown : MonoBehaviour
{
    #region VAR
    public FloatEvent onSpeed;
    public UnityEvent onUp;
    public UnityEvent onDown;
    private bool isUp;
  
    [SerializeField] private Rigidbody2D _rigidbody2D;
    #endregion

    #region MONO
    private void Start()
    {
        if (_rigidbody2D == null)
            _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        StateControl();
    }
    #endregion

    #region FUNC
    private void StateControl()
    {
        onSpeed?.Invoke(_rigidbody2D.velocity.y);
        
        if (_rigidbody2D.velocity.y > 0 && !isUp)
        {
            onUp?.Invoke();
            isUp = true;
        }
        if (_rigidbody2D.velocity.y < 0 && isUp)
        {
            onDown?.Invoke();
            isUp = false;
        }
    }
    #endregion
}
