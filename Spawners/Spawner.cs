using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    #region VAR

    [SerializeField] private List<GameObject> _prefabs;
    [SerializeField] private List<int> _chancePrefabs;
    [Space(10)] [SerializeField] private bool _active;
    [SerializeField] private float _scaleSpeed;
    [SerializeField] private float _curReload = 5;
    [SerializeField] private float _widthSpawn;
    [Space(10)] [SerializeField] private IncreaseFloat _reloadSpawn;
    private float _globalScroll;
    private List<GameObject> _spawned = new List<GameObject>();
    private float _lastSpawn;

    #endregion

    #region MONO
    private void OnEnable()
    {
        Activate();
    }
    private void OnDisable()
    {
        Deactivate();
    }
    private void Update()
    {
        if (!_active || _prefabs.Count == 0)
            return;

        if (Time.time > _lastSpawn + _curReload)
        {
            Spawn();
        }
    }

    #endregion

    #region FUNC

    public void Activate()
    {
        _active = true;
        if (_reloadSpawn != null)
            _reloadSpawn.Activate();
    }

    public void Deactivate()
    {
        _active = false;
        if (_reloadSpawn != null)
            _reloadSpawn.Deactivate();
    }

    public void SetReload(float newValue)
    {
        _curReload = newValue;
    }

    public void SetGlobalScroll(float newValue)
    {
        _globalScroll = newValue;
    }

    public void DestroyAllSpawned()
    {
        for (int i = 0; i < _spawned.Count; i++)
        {
            Destroy(_spawned[i]);
        }

        _spawned.Clear();
    }

    private void Spawn()
    {
        var randomId = GetRandomId();
        var spawnPos = transform.position;
        spawnPos.y += Random.Range(-_widthSpawn / 2, _widthSpawn / 2);

        var go = Instantiate(_prefabs[randomId], spawnPos, transform.rotation);
        _spawned.Add(go);

        //  var haveSpeed = go.GetComponent<IHaveSpeed>();
        //  if (haveSpeed != null)
        //     haveSpeed.Speed = _globalScroll;

        _lastSpawn = Time.time;
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

    #endregion
}

