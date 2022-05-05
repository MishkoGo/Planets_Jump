using UnityEngine;
using UnityEngine.Events;

public class SpawnOnTouch : MonoBehaviour
{
    public UnityEvent onSpawned;
    public UnityEvent onDestroyed;
    [SerializeField] private bool _active;
    [SerializeField] private Transform _spawnT;
    
    [SerializeField] private GameObject _pref;
    [SerializeField] private float randomAngle;
    [SerializeField] private LimitPosition _limitPosition;
    private bool _needSpawn;
    private Vector3 _pos;
    [SerializeField] private GameObject _spawnedGO;

    
    private void Update()
    {
        if (_active)
        {
            InputControl();

            if (_needSpawn)
            {
                Spawn();
                _needSpawn = false;
            }
        }
    }
    
    public void SpawnedDestroyed()
    {
        onDestroyed?.Invoke();
        _spawnedGO = null;
    }
    public void Activate()
    {
        StartSpawn();
        _active = true;
    }
    public void Deactivate()
    {
        Destroy(_spawnedGO);
        SpawnedDestroyed();
        
        _active = false;
    }
    private void InputControl()
    {
        if (Input.GetMouseButtonDown(0) && _spawnedGO == null)
        {
            _needSpawn = true;
            GetWorldPos();
        }
    }

    private void StartSpawn()
    {
        onSpawned?.Invoke();
        _pos = _spawnT.position;
        _spawnedGO = Instantiate(_pref, _pos, Quaternion.identity);
        
        IDestoyable destoyable = _spawnedGO.GetComponent<IDestoyable>();
        if (destoyable != null)
            destoyable.onDestroyed += SpawnedDestroyed;
    }
    private void Spawn()
    {
        onSpawned?.Invoke();
        _pos = _limitPosition.LimitPos(_pos);
        _spawnedGO = Instantiate(_pref, _pos, Quaternion.identity);
        _spawnedGO.transform.Rotate(0, 0, Random.Range(-randomAngle, randomAngle));

        IDestoyable destoyable = _spawnedGO.GetComponent<IDestoyable>();
        if (destoyable != null)
            destoyable.onDestroyed += SpawnedDestroyed;
    }

    private void GetWorldPos()
    {
        _pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * -1));
        _pos.z = _spawnT.position.z;
    }
    
}
