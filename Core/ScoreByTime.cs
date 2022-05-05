using System;
using UnityEngine;


public class ScoreByTime : MonoBehaviour
{
    #region VAR

    [SerializeField] private bool _needAdd;
    [SerializeField] private IntWithEvent _curScore;
    private float curScore;

    #endregion

    #region MONO
    
    private void Update()
    {
        if (_needAdd)
            Add();
    }

    #endregion

    #region FUNC

    public void StartAdd()
    {
        _needAdd = true;
    }

    public void StopAdd()
    {
        _needAdd = false;
    }

    private void Add()
    {
        curScore += Time.deltaTime;

        if ((int) curScore > _curScore.Count)
            _curScore.Count = (int) curScore;
    }

    #endregion

    #region CALLBAKS

    // V Code referenced by UnityEvents only V   
    public void ResetScore()
    {
        _curScore.Count = 0;
        curScore = 0;
    }
    public void AddScore(int added)
    {
        _curScore.Count += added;
    }
    #endregion
}

