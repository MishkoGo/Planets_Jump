using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorGO : MonoBehaviour,ICanSwitch
{
    [SerializeField] private List<GameObject> _objects = new List<GameObject>();

    public void Activate()
    {
        if (_objects.Count == 0)
            return;

        for (int i = 0; i < _objects.Count; i++)
        {
            _objects[i].SetActive(true);
        }
    }

    public void Deactivate()
    {
        if (_objects.Count == 0)
            return;

        for (int i = 0; i < _objects.Count; i++)
        {
            _objects[i].SetActive(false);
        }
    }

    public void Switch()
    {
        throw new System.NotImplementedException();
    }
}
