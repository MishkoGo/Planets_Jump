using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Service/IntLimitSO")]
public class IntLimitSO : ScriptableObject
{
    [SerializeField]
    public int val;
    [SerializeField]
    public int MaxVal;

    public void Add()
    {
        val += 1;
        val = Mathf.Clamp(val, 0, MaxVal);
    }
    public void Substact()
    {
        val -= 1;
        val = Mathf.Clamp(val, 0, MaxVal);
    }
    public void ChangeVal(int _count)
    {
        val += _count;
        val = Mathf.Clamp(val, 0, MaxVal);
    }
    public void SetVal(int _val)
    {
        val = _val;
        val = Mathf.Clamp(val, 0, MaxVal);
    }
    public void SetMaxVal(int _val)
    {
        MaxVal = _val;
    }
}
