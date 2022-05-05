using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultHockey : MonoBehaviour
{
    public TMP_Text heightText;
    public TMP_Text score;
    
    [SerializeField] private Animator _animator;
    [SerializeField]private IntWithEvent _score;
    [SerializeField]private IntWithEvent _height;
    [SerializeField] private DataController _dataController;
    [SerializeField] private GameObject _block1;
    [SerializeField] private GameObject _block2;
    [SerializeField] private Vector3 block1Pos;
    private int _curHeight;
    
    
    public void UpdateHeight(int height)
    {
        _curHeight = height;
    }

    public void Result()
    {
        if (_curHeight > _height.Count)
        {
            _height.Count = _curHeight;
            _dataController.Save();
            _animator.enabled = true;
        }

        heightText.text = _curHeight + "m";
        score.text = _score.Count.ToString();
    }
    public void ResetState()
    {
        _animator.enabled = false;
        _block2.SetActive(false);
        _block1.transform.localPosition = block1Pos;
    }
}
