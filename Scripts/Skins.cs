using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skins : MonoBehaviour
{
    [SerializeField] private List<Skin> _skins;
    [SerializeField] private int  _curSkin;

    public void SetSkin(int index)
    {
        _skins[_curSkin].Deactivate();
        _curSkin = index;
        _skins[_curSkin].Activate();
    }
    public int GetCurSkinId()
    {
        return _curSkin;
    }

    public void Init()
    {
        
    }
}
