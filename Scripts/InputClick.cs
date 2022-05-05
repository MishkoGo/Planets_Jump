using UnityEngine;
using UnityEngine.Events;


public class InputClick : MonoBehaviour,ICanSwitch
{
    #region VAR
    public UnityEvent onClick;
    [SerializeField] private bool _active;
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
    private void Update()
    {
        if (_active)
        {
            Control();
        }
    }
    #endregion

    #region FUNC
    private void Control()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onClick?.Invoke();
        }
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
