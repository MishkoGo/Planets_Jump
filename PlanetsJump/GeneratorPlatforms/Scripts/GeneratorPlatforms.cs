
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GeneratorPlatforms : MonoBehaviour
{
    [ShowOnly][SerializeField] private bool _active;
    [SerializeField] private List<Stage> _stages;
    [SerializeField] private int _curStageId;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _startPos;
    [SerializeField] private float _offsetSpawn;
    [SerializeField] private float _offsetCheckSpawn;
    [SerializeField] private bool _dontDestroy;
    private Transform _prevBlock;
    private Transform _curBlock;
    private Vector3 _curPosition;


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
        if (_active)
            SpawnControl();
    }
    
    private void Spawn()
    {
        if(_prevBlock != null && !_dontDestroy)
            Destroy(_prevBlock.gameObject);
        
        if (_curBlock != null)
            _prevBlock = _curBlock;

        GameObject pref = _stages[_curStageId].GetPref();
        GameObject go = Instantiate(pref, _curPosition, quaternion.identity);
        _curBlock = go.transform;
        
       
        _curPosition.y += _offsetSpawn;
        
        
        _stages[_curStageId].AddCount(1);
        if (_stages[_curStageId].CheckEnd())
        {
            _curStageId++;
            _stages[_curStageId].ActivateStage();
        }
        
    }
    private void SpawnControl()
    {
        if (_curBlock == null)
        {
            Spawn();
        }

        if (_curBlock.position.y - _player.position.y < _offsetCheckSpawn)
        {
            Spawn();
        }
    }
    public void Activate()
    {
        _curBlock = null;
        _prevBlock = null;
        _curStageId = 0;
        _curPosition = _startPos.position;
        _stages[_curStageId].ActivateStage();

        _active = true;
    }
    public void Deactivate()
    {
        if(_prevBlock != null)
            Destroy(_prevBlock.gameObject);
        if(_curBlock != null)
            Destroy(_curBlock.gameObject);
        
        _active = false;
    }
}
