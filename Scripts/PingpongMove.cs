using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingpongMove : MonoBehaviour
{
    #region VAR
    [SerializeField] private bool _active;
    [SerializeField] private bool _random;
    [SerializeField] private float _distanceMove;
    [SerializeField] private float _minDistance;

    [SerializeField] private bool _moveX;
    [SerializeField] private bool _moveY;
    [SerializeField] private bool _moveZ;

    [SerializeField] private float _speedMoveX;
    [SerializeField] private float _speedMoveY;
    [SerializeField] private float _speedMoveZ;
    private float _factor = 1;
    private bool _moveBack;
    private Vector3 _startPos;

    private Vector3 _temp;
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
    private void Start()
    {
        CalculateVector();
        _startPos = transform.position;
    }
    private void Update()
    {
        CalculateVector();
        MoveTransform();
        DistanceControl();
    }
    #endregion

    #region FUNC
    public void SetSpeed(float speed)
    {
        _speedMoveX = speed;
        _speedMoveY = speed;
        _speedMoveZ = speed;
    }
    public void SetFactor(float factor)
    {
        _factor = factor;
    }
    
    private void CalculateVector()
    {
        if (_moveX)
        {
            if (_random)
                _temp.x = Random.Range(-_speedMoveX, _speedMoveX) * Time.deltaTime;
            else
                _temp.x = _speedMoveX * Time.deltaTime;
        }
        if (_moveY)
        {
            if (_random)
                _temp.y = Random.Range(-_speedMoveY, _speedMoveY) * Time.deltaTime;
            else
                _temp.y = _speedMoveY * Time.deltaTime;
        }
        if (_moveZ)
        {
            if (_random)
                _temp.z = Random.Range(-_speedMoveZ, _speedMoveZ) * Time.deltaTime;
            else
                _temp.z = _speedMoveZ * Time.deltaTime;
        }
    }
    private void MoveTransform()
    {
        transform.Translate(_temp * _factor);
    }
    private void DistanceControl()
    {
        if (!_moveBack && Vector3.Distance(_startPos, transform.position) > _distanceMove)
        {
            if (_moveX)
                _speedMoveX *= -1;
            if (_moveY)
                _speedMoveY *= -1;
            if (_moveZ)
                _speedMoveZ *= -1;

            _moveBack = true;
            
            return;
        }
        if (_moveBack && Vector3.Distance(_startPos, transform.position) < _minDistance)
        {
            if (_moveX)
                _speedMoveX *= -1;
            if (_moveY)
                _speedMoveY *= -1;
            if (_moveZ)
                _speedMoveZ *= -1;
            
            _moveBack = false;
        }
    }
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
        _active = !_active;
    }
}
