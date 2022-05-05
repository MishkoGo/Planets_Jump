using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChangeByCondition : MonoBehaviour
{
    public UnityEvent OnChange;
    [SerializeField] private Condition _condition;

    private void Update()
    {
        if(_condition.CheckCondition())
            OnChange?.Invoke();
    }
}
