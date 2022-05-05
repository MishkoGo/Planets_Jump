using UnityEngine;


public class DynamicValue : MonoBehaviour
{
  #region VAR
  public FloatEvent onUpdateValue;
  [ShowOnly] [SerializeField] private float _cur;
  [SerializeField] private float _start;
  [SerializeField] private float _max;
  [SerializeField] private float _min;
  [SerializeField] private float _target;
  [ShowOnly] [SerializeField] private float _curSpeedUp;
  [SerializeField] private float _minSpeedUp;
  [SerializeField] private float _maxSpeedUp;
  [ShowOnly] [SerializeField] private float _curSpeedDown;
  [SerializeField] private float _minSpeedDown;
  [SerializeField] private float _maxSpeedDown;
  [ShowOnly] [SerializeField] private float _curDurationPhase;
  [SerializeField] private float _minDurationPhase;
  [SerializeField] private float _maxDurationPhase;
  [ShowOnly] [SerializeField] private bool _up;
  [ShowOnly] [SerializeField] private bool _down;
  private float timeStartPhase;
  
  #endregion

  #region MONO
  private void OnEnable()
  {
    _cur = _start;
    NewPhase();
  }
  private void Update()
  {
    Control();
    ControlPhase();
  }
  #endregion

  #region FUNC
  private void Control()
  {
    if (_up)
    {
      Up();
    }
    if (_down)
    {
      Down();
    }
    onUpdateValue?.Invoke(_cur);
  }
  private void ControlPhase()
  {
    if(Time.time > timeStartPhase + _curDurationPhase)
      NewPhase();
  }
  private void NewPhase()
  {
    timeStartPhase = Time.time;
    _curDurationPhase = Random.Range(_minDurationPhase, _maxDurationPhase);
    _target = Random.Range(_min, _max);
    
    if (Random.Range(0, 2) > 0)
    {
      _up = true;
      _down = false;
      
      _curSpeedUp = Random.Range(_minSpeedUp, _maxSpeedUp);
    }
    else
    {
      _up = false;
      _down = true;

      _curSpeedDown = Random.Range(_minSpeedDown, _maxSpeedDown);
    }
  }
  private void Up()
  {
    _cur += _curSpeedUp * Time.deltaTime;
    if (_cur > _max)
      _cur = _max;
  }
  private void Down()
  {
    _cur -= _curSpeedUp * Time.deltaTime;
    if (_cur < _min)
      _cur = _min;
  }
  #endregion
  
  
  
}
