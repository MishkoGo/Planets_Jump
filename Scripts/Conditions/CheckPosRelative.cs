using System;
using UnityEngine;

public class CheckPosRelative : Condition
{
    [SerializeField] private Transform _target;
    [Space(10)]
    [SerializeField] private TypeCheck _typeCheck;
    [SerializeField] private TypeRelative _typeRelative;

    public override void SetTarget(Transform target)
    {
        _target = target;
    }
    public override bool CheckCondition()
    {
        float targetCoord;
        float myCoord;
        
        switch (_typeCheck)
        {
            case TypeCheck.x:
                targetCoord = _target.position.x;
                myCoord = transform.position.x;
                break;
            case TypeCheck.y:
                targetCoord = _target.position.y;
                myCoord = transform.position.y;
                break;
            case TypeCheck.z:
                targetCoord = _target.position.z;
                myCoord = transform.position.z;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return Check(myCoord, targetCoord);
    }
    private bool Check(float myCoord,float targetCoord)
    {
        if (_typeRelative == TypeRelative.bigger && myCoord > targetCoord)
            return true;
        if (_typeRelative == TypeRelative.lower && myCoord < targetCoord)
            return true;

        return false;
    }
    private enum TypeCheck
    {
        x,
        y,
        z
    }
    private enum TypeRelative
    {
        bigger,
        lower
    }
}
