using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public IntEvent onChangeSkin;
    
    [SerializeField] private Skins _skins;
    [SerializeField] private DataController _dataController;
    [SerializeField] private IntWithEvent _score;
    public List<Slot> _Slots;
    public GameObject _selected;
    public List<bool> _purchasedSkins;
    [SerializeField] private List<int> _pricesSkins;


    public void Init()
    {
        int selected = _skins.GetCurSkinId();
        for (int i = 0; i < _Slots.Count; i++)
        {
            if(_purchasedSkins[i])
                _Slots[i].Open();

            if (i == selected)
                _selected.transform.localPosition = _Slots[i].transform.localPosition;
        }
    }
    public void Clicked(int index)
    {
        if (index == _skins.GetCurSkinId())
            return;

        if (_purchasedSkins[index])
        {
            _skins.SetSkin(index);
            _selected.transform.localPosition = _Slots[index].transform.localPosition;
            onChangeSkin?.Invoke(index);
        }
        else if(_score.Count >= _pricesSkins[index])
        {
            _score.Count -= _pricesSkins[index];
            _purchasedSkins[index] = true;
            _skins.SetSkin(index);
            _Slots[index].Open();
            _selected.transform.localPosition = _Slots[index].transform.localPosition;
            _dataController.Save();
            onChangeSkin?.Invoke(index);
        }
    }
}
