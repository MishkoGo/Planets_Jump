using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indicator3LampGUI : MonoBehaviour,ICanSwitch
{
    #region VAR
    [SerializeField] private bool _active;
    [SerializeField] private List<Image> _lamps;
    [SerializeField] private Color _goodColor;
    [SerializeField] private Color _badColor;
    #endregion

    #region MONO
    private void OnEnable()
    {
        ResetState();
    }
    #endregion

    #region MyRegion
    private void ResetState()
    {
        for (int i = 0; i < _lamps.Count; i++)
        {
            _lamps[i].color = _goodColor;
        }
    }
    public void Add()
    {
        for (int i = 0; i < _lamps.Count; i++)
        {
            if (_lamps[i].color == _goodColor)
            {
                _lamps[i].color = _badColor;
                return;
            }
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
