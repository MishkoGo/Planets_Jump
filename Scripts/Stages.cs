using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntEvent : UnityEvent<int> {};
[System.Serializable]
public class StageEvent : UnityEvent<Stage> {};

public class Stages : MonoBehaviour, ICanSwitch
{
    #region VAR

    [ShowOnly] [SerializeField] private bool _active;
    public StageEvent onNextStage;
    [SerializeField] private IntWithEvent _curStage;
    [SerializeField] private List<Stage> _stages;
    #endregion

    #region MONO
    private void OnEnable()
    {
        for (int i = 0; i < _stages.Count; i++)
        {
            _stages[i].onStageEnd.AddListener(StageUp);
        }
    }
    #endregion
    
    #region FUNC
    
    private void StageUp()
    {
        if(!_active)
            return;
        
        _curStage.Count += 1;
        onNextStage?.Invoke(_stages[_curStage.Count - 1]);
        
        if (_curStage.Count >= _stages.Count)
            _active = false;
    }

    #endregion

    public void Activate()
    { 
        _curStage.Count = 1;
        onNextStage?.Invoke(_stages[_curStage.Count - 1]);
        _active = true;
    }

    public void Deactivate()
    {
        _active = false;
    }
    public void ResetState()
    {
        _curStage.Count = 1;
        onNextStage?.Invoke(_stages[_curStage.Count - 1]);
        _active = true;
    }
    public void Switch()
    {
        _active = !_active;
    }

}

