using System;
using UnityEngine;

public class CheckPositionCondition : Condition
{
    [SerializeField] private Transform _target;
    [Space(10)]
    [SerializeField] private TypeCheck _typeCheck;
    [SerializeField] private float _min;
    [SerializeField] private float _max;

   
    public override bool CheckCondition()
    {
        float value;
        
        switch (_typeCheck)
        {
            case TypeCheck.x:
                value = _target.position.x;
                break;
            case TypeCheck.y:
                value = _target.position.y;
                break;
            case TypeCheck.z:
                value = _target.position.z;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return Check(value);
    }
    private bool Check(float value)
    {
        return value < _max && value > _min;
    }
    private enum TypeCheck
    {
        x,
        y,
        z
    }
}
