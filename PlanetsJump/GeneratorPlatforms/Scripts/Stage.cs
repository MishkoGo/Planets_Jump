using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Common/Stage")]
public class Stage : ScriptableObject
{
    public UnityEvent onStageEnd;

    [SerializeField] private List<GameObject> _prefabs;
    [SerializeField] private List<int> _chancePrefabs;

    [Space(10)]
    [ShowOnly][SerializeField] private int _countSpawned;
    [SerializeField] private int _countToEnd;

    public void AddCount(int count)
    {
        _countSpawned += count;
    }
    public bool CheckEnd()
    {
        if (_countSpawned >= _countToEnd)
        {
            return true;
        }

        return false;
    }
    public void ActivateStage()
    {
        _countSpawned = 0;
    }
    public GameObject GetPref()
    {
        var randomId = GetRandomId();
        return _prefabs[randomId];
    }
    
    private int GetRandomId()
    {
        if (_prefabs.Count != _chancePrefabs.Count)
        {
            Debug.LogError("Need same length");
            return 0;
        }

        var allChance = 0;

        for (int i = 0; i < _prefabs.Count; i++)
        {
            allChance += _chancePrefabs[i];
        }

        var random = Random.Range(1, allChance + 1);

        for (int i = 0; i < _prefabs.Count; i++)
        {

            allChance -= _chancePrefabs[i];


            if (random >= allChance)
            {
                return i;
            }
        }

        return 0;
    }
}
