using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PayloadCount : MonoBehaviour
{
     #region VAR
    [SerializeField] private List<Color> _colors;
    [SerializeField] private SpriteRenderer _obj1;
    [SerializeField] private SpriteRenderer _obj2;
    [SerializeField] private SpriteRenderer _obj3;

    [SerializeField] private bool _active;
    [SerializeField] private float _percentIsBad = 30;
    [SerializeField] private bool isBad; 
    [SerializeField] private TMP_Text countText;
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
        int count = 0;

        if (_obj1 != null)
        {
            count++;
            Color color = GetRandomColor();
            _obj1.color = color;
        }

        if (_obj2 != null)
        {
            count++;
            Color color = GetRandomColor();
            _obj2.color = color;
        }

        if (_obj3 != null)
        {
            count++;
            Color color = GetRandomColor();
            _obj3.color = color;
        }

        if (Random.Range(0, 100) > _percentIsBad)
        {
            countText.text = count.ToString();
            isBad = false;
        }
        else
        {
            int findNotEquilar = Random.Range(1, 4);
            while (count == findNotEquilar)
            {
                findNotEquilar = Random.Range(1, 4);
            }
            
            isBad = true;
            countText.text = findNotEquilar.ToString();
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
