using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawner : MonoBehaviour
{
    #region VAR
    [Space(10)] [SerializeField] private bool _active;
    [SerializeField] private Stage _curStage;
    [SerializeField] private Transform _spawnT;
    [SerializeField] private IntWithEvent allCount;
    private GameObject lastGO;

    #endregion

    #region MONO
    #endregion

    #region FUNC

    public void ActivateSpawn()
    {
        _active = true;
        Invoke(nameof(Spawn), 0.05f);
        allCount.Count = 0;
    }
    public void DeactivateSpawn()
    {
        _active = false;
        if(lastGO != null)
            Destroy(lastGO);
    }
    public void CircleDestroyed()
    {
        if(_active)
            Invoke(nameof(Spawn), 0.05f);
    }
    public void SetStage(Stage stage)
    {
        _curStage = stage;
    }
    private void Spawn()
    {
        var spawnPos = transform.position;

        var go = Instantiate(_curStage.GetPref(), _spawnT);
     //   NewCircle circle = go.GetComponent<NewCircle>();
        lastGO = go;
     //   circle.onCircleDestroyed.AddListener(CircleDestroyed);
     //   circle.Init(_curStage);
        _curStage.AddCount(1);
        allCount.Count += 1;
    }
    #endregion
}
