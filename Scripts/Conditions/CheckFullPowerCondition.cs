using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFullPowerCondition : Condition
{
    [SerializeField] private Power _power;

    public override bool CheckCondition()
    {
        if (_power != null) 
            return _power.CheckFull();
        
        Debug.Log("need power component");
        return false;

    }
}