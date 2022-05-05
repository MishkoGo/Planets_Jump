using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPSSimulationSpeed : MonoBehaviour
{
  #region VAR

  [SerializeField] private float _scale;
  private ParticleSystem _particleSystem;
  private float timeStartPhase;
  private ParticleSystem.MainModule _main;

  #endregion

  #region MONO
  private void OnEnable()
  {
    if (_particleSystem == null)
      _particleSystem = GetComponent<ParticleSystem>();

    _main = _particleSystem.main;
  }
  #endregion

  #region FUNC
  public void SetSpeed(float speed)
  {
    _main.simulationSpeed = speed * _scale;
  }
  #endregion


}
