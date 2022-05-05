using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Block : MonoBehaviour
{
    [SerializeField] private List<Transform> _pointsSpawn; 
    [SerializeField] private List<GameObject> _linesPrefab;
    [SerializeField] private List<int> _chanceLinesPrefab;
    private GameObject _prevPrefab;

    private void OnEnable()
    {
        GeneratePlatforms();
    }
    private void GeneratePlatforms() 
    {
        for (int i = 0; i < _pointsSpawn.Count; i++) 
        {
            SpawnLine(i);
        }
    }
    
    private void SpawnLine(int curIndex)
    {
        GameObject randomPrefab = GetRandomObjectFromList(_linesPrefab, _chanceLinesPrefab);
        int _count = 0;
        while (randomPrefab == _prevPrefab || _count < 10)
        {
            randomPrefab = GetRandomObjectFromList(_linesPrefab, _chanceLinesPrefab);
            _count++;
        }

        _prevPrefab = randomPrefab;
        GameObject gameobject = Instantiate(randomPrefab, _pointsSpawn[curIndex]);
    }
    
    
    public GameObject GetRandomObjectFromList(List<GameObject> objects, List<int> chances)
    {
        if (objects.Count != chances.Count)
        {
            Debug.LogError("Need same length");
            return null;
        }

        var allChance = 0;

        for (int i = 0; i < objects.Count; i++)
        {
            allChance += chances[i];
        }

        var random = Random.Range(1, allChance + 1);

        for (int i = 0; i < objects.Count; i++)
        {

            allChance -= chances[i];


            if (random >= allChance)
            {
                return _linesPrefab[i];
            }
        }
        
        Debug.LogError("Random Error");
        return null;
    }

  
}
