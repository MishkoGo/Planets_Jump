using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Payload : MonoBehaviour
{
    #region VAR
    [SerializeField] private List<Color> _colors;
    [SerializeField] private SpriteRenderer _color1;
    [SerializeField] private SpriteRenderer _color2;
    [SerializeField] private SpriteRenderer _color3;
    
    [SerializeField] private SpriteRenderer _obj1;
    [SerializeField] private SpriteRenderer _obj2;
    [SerializeField] private SpriteRenderer _obj3;

    [SerializeField] private bool _active;
    [SerializeField] private float _percentIsBad = 30;
    [SerializeField] private bool isBad;
    private int curIndex;
    
    #endregion
    #region MONO
    
    private void OnEnable()
    {
        Activate();
        curIndex = Random.Range(0, _colors.Count);
        Init();
    }
    private void OnDisable()
    {
        Deactivate();
    }
    #endregion

    #region FUNC

    private void Init()
    {
        if (Random.Range(0, 100) > _percentIsBad)
        {
            if (_color1 != null && _obj1 != null)
            {
                Color color = GetRandomColor();
                _color1.color = color;
                _obj1.color = color;
            }
            if (_color2 != null && _obj2 != null)
            {
                Color color = GetRandomColor();
                _color2.color = color;
                _obj2.color = color;
            }
            if (_color3 != null && _obj3 != null)
            {
                Color color = GetRandomColor();
                _color3.color = color;
                _obj3.color = color;
            }

            isBad = false;
        }
        else
        {
            if (_color1 != null && _obj1 != null)
            {
                Color color = GetRandomColor();
                _color1.color = color;
                color = GetRandomColor();
                _obj1.color = color;
            }
            if (_color2 != null && _obj2 != null)
            {
                Color color = GetRandomColor();
                _color2.color = color;
                color = GetRandomColor();
                _obj2.color = color;
            }
            if (_color3 != null && _obj3 != null)
            {
                Color color = GetRandomColor();
                _color3.color = color;
                color = GetRandomColor();
                _obj3.color = color;
            }
            isBad = true;
        }
    }
    private Color GetRandomColor()
    {
        int index = curIndex;
        curIndex++;
        if (curIndex >=_colors.Count)
            curIndex = 0;
        return _colors[index];
    }
    public bool CheckBad()
    {
        return isBad;
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
