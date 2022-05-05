using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recreate : MonoBehaviour
{
    [SerializeField] private Transform _originalT;
    [SerializeField] private GameObject _pref;

    public void Replace()
    {
       GameObject go =  Instantiate(_pref, _originalT.position, _originalT.rotation);
        Destroy(_originalT.gameObject);
        _originalT = go.transform;
    }
}
