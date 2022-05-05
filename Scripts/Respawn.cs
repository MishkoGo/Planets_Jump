using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform _spawnT;
    [SerializeField] private Transform _pref;

    public void Spawn()
    {
        Instantiate(_pref, _spawnT.position, _spawnT.rotation);
    }
}
